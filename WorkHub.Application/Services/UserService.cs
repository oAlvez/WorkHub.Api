using FluentValidation;
using Microsoft.AspNetCore.Identity;
using WorkHub.Application.DTOs.Updates;
using WorkHub.Application.Interfaces.Repositories;
using WorkHub.Application.Interfaces.Services;
using WorkHub.Domain.Entities;
using WorkHub.Exceptions;

namespace WorkHub.Application.Services;
public class UserService(UserManager<User> _userManager,
    IUserRepository _repository,
    IValidator<CreateUserDTO> _validator,
    IValidator<UpdateUserDTO> _validatorUpdate
    ) : IUserService
{

    public async Task<IEnumerable<User>> GetAllAsync() => await _repository.GetAllAsync();
    public async Task<User?> GetByIdAsync(Guid id) => await _userManager.FindByIdAsync(id.ToString());
    public async Task<Guid> CreateAsync(CreateUserDTO dto)
    {
        var validation = await _validator.ValidateAsync(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = new User
        {
            Id = Guid.NewGuid(),
            UserName = dto.Email,
            Email = dto.Email,
            FullName = dto.FullName,
            ShortName = dto.ShortName
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
            throw new Exception("Erro ao criar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));

        return user.Id;
    }

    public async Task<bool> UpdateAsync(UpdateUserDTO dto)
    {
        var validation = await _validatorUpdate.ValidateAsync(dto);
        if (!validation.IsValid)
            throw new ValidationException(validation.Errors);

        var user = await _userManager.FindByIdAsync(dto.Id.ToString());
        if (user is null)
            throw new NotFoundException("Usuário não encontrado.");

        user.Email = dto.Email;
        user.UserName = dto.Email;
        user.FullName = dto.FullName;
        user.ShortName = dto.ShortName;

        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
            throw new Exception("Erro ao atualizar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));

        return true;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var user = await _userManager.FindByIdAsync(id.ToString());
        if (user is null)
            throw new NotFoundException("Usuário não encontrado.");

        var result = await _userManager.DeleteAsync(user);
        if (!result.Succeeded)
            throw new Exception("Erro ao deletar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));

        return true;
    }
}
