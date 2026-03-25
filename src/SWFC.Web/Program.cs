using SWFC.Application.Security;
using SWFC.Infrastructure.DependencyInjection;
using SWFC.Application.Modules.M100.M101.Commands;
using SWFC.Application.Modules.M100.M101.Policies;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddScoped<ICurrentUserService, DefaultCurrentUserService>();
builder.Services.AddScoped<IAuthorizationPolicy<CreateMachineCommand>, CreateMachinePolicy>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
