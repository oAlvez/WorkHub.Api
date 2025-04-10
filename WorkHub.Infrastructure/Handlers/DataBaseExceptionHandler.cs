using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WorkHub.Exceptions;

namespace WorkHub.Infrastructure.Handlers;
public static class DataBaseExceptionHandler
{
    public static void Throw(DbUpdateException exception)
    {
        var sqlException = exception.InnerException as SqlException;
        if (sqlException is not null)
        {
            switch (sqlException.Number) // Tratar os principais erros de SQL Server
            {
                case -2: // Timeout
                    throw new DatabaseException("O tempo limite foi excedido.");
                case 547: // Violação de chave estrangeira
                    throw new DatabaseException("Violação da chave estrangeira.");
                case 2627: // Violação de chave única
                case 2601: // Índice duplicado
                    throw new DatabaseException("Violação de chave única ou duplicação de índice.");
                default: // Caso de erro desconhecido
                    throw new DatabaseException($"Erro de banco de dados desconhecido");
            }
        }
        throw new DatabaseException(""); //TODO
    }
}