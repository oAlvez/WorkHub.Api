using WorkHub.Api.Filters;
using WorkHub.CrossCutting.InjectionsConfiguration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddJsonSerializerConfiguration();
builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));
builder.Services.AddAuthenticationConfiguration(builder.Configuration);
builder.Services.AddRepositoriesConfiguration(builder.Configuration);
builder.Services.AddOptionsConfiguration(builder.Configuration);
builder.Services.AddAutoMapperConfiguration();
builder.Services.AddServicesConfiguration();
builder.Services.AddSwaggerConfiguration();
builder.Services.AddOutputCacheConfiguration();
builder.Services.AddHealthChecksConfiguration();

var app = builder.Build();

app.UseHealthChecksConfiguration(builder.Configuration);
app.UseSwaggerConfiguration();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseOutputCache();
app.MapControllers();

app.Run();