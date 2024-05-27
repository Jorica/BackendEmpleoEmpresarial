using BackendEmpleoEmpressarial.Aplication.AppliedJob;
using BackendEmpleoEmpressarial.Aplication.Employment;
using BackendEmpleoEmpressarial.Aplication.User;
using BackendEmpleoEmpressarial.Domain.AppliedJob;
using BackendEmpleoEmpressarial.Domain.Employment;
using BackendEmpleoEmpressarial.Domain.StatusEmploymentUser;
using BackendEmpleoEmpressarial.Domain.User;
using BackendEmpleoEmpressarial.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<EmpleoEmpresarialContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Inyecciones

builder.Services.AddTransient<IUserAppService, UserAppService>();
builder.Services.AddTransient<IUserDomainService, UserDomainService>();

builder.Services.AddTransient<IEmploymentAppService, EmploymentAppService>();
builder.Services.AddTransient<IEmploymentDomainService, EmploymentDomainService>();

builder.Services.AddTransient<IStatusEmploymentUserDomainService, StatusEmploymentUserDomainService>();

builder.Services.AddTransient<IAppliedJobAppService, AppliedJobAppService>();
builder.Services.AddTransient<IAppliedJobDomainService, AppliedJobDomainService>();

// cors

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseCors("AllowAnyOrigin");

app.Run();
