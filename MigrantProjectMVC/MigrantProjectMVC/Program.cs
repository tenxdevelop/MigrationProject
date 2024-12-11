using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Queries;
using MigrantProjectMVC.QueryHandlers;
using MigrantProjectMVC.Repositories;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();

//Dependencies
builder.Services.AddSingleton<ITokenProvider, JwtTokenProvider>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IMigrantRepository, MigrantRepository>();
builder.Services.AddSingleton<IRegulationRepository, RegulationRepository>();

// Регаем в CommandProcessor все исполнители комманд
builder.Services.AddSingleton<ICommandProcessor>(sp =>
{
    var commandProcessor = new CommandProcessor();
    commandProcessor.RegisterCommandHadnler(new CreateUserStatementCommandHandler(sp.GetService<IUserRepository>()));
    commandProcessor.RegisterCommandHadnler(new DeleteUserCommandHandler(sp.GetService<IUserRepository>()));
    commandProcessor.RegisterCommandHadnler(new LoginUserCommandHandler(sp.GetService<IUserRepository>(), sp.GetService<IPasswordHasher>(), sp.GetService<ITokenProvider>(), sp.GetService<IHttpContextAccessor>()));
    commandProcessor.RegisterCommandHadnler(new RegisterUserCommandHandler(sp.GetService<IUserRepository>(), sp.GetService<IPasswordHasher>()));
    commandProcessor.RegisterCommandHadnler(new SetRoleCommandHandler(sp.GetService<IUserRepository>()));
    return commandProcessor;
});
builder.Services.AddSingleton<IQueryProcessor>(sp =>
{
    var queryProcessor = new QueryProcessor();
    queryProcessor.RegisterQueryHandler(new GetUserListQueryHandler(sp.GetService<IUserRepository>()));
    queryProcessor.RegisterQueryHandler(new GetUserQueryHandler(sp.GetService<IUserRepository>()));
    queryProcessor.RegisterQueryHandler(new GetRegulationListQueryHandler(sp.GetService<IRegulationRepository>()));
    queryProcessor.RegisterQueryHandler(new GetRegulationQueryHandler(sp.GetService<IMigrantRepository>(), sp.GetService<IRegulationRepository>()));
    return queryProcessor;
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Secure API", Version = "v1" });

    // Добавляем поддержку авторизации
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter 'Bearer' [space] and then your token."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});

var jwtSettings = builder.Configuration.GetSection("JwtSettings");
var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);
builder.Services.AddAuthentication().AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
{
    ValidateIssuer = true,
    ValidateAudience = true,
    ValidateLifetime = true,
    ValidateIssuerSigningKey = true,
    ValidIssuer = jwtSettings["Issuer"],
    ValidAudience = jwtSettings["Audience"],
    IssuerSigningKey = new SymmetricSecurityKey(key)
});


var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger(); 
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty;
    });
}

app.Use(async (context, next) =>
{
    var token = context.Request.Cookies["Auth"];
    if (!string.IsNullOrEmpty(token))
    {
        context.Request.Headers.Add("Authorization", $"Bearer {token}");
    }
    await next();
}); // проверка токена пользователя
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
