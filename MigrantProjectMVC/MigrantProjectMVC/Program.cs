using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


//Dependencies
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICommandHandler<CreateUserStatementCommand, bool>, CreateUserStatementCommandHandler>();
builder.Services.AddScoped<ICommandHandler<DeleteUserCommand, bool>, DeleteUserCommandHandler>();

// Регаем в CommandProcessor все исполнители комманд
builder.Services.AddScoped<ICommandProcessor>(sp =>
{
    var createUserStatementCommandHandler = sp.GetService<ICommandHandler<CreateUserStatementCommand, bool>>();
    var deleteUserCommandHandler = sp.GetService<ICommandHandler<DeleteUserCommand, bool>>();
    var commandProcessor = new CommandProcessor();
    commandProcessor.RegisterCommandHadnler(createUserStatementCommandHandler);
    commandProcessor.RegisterCommandHadnler(deleteUserCommandHandler);
    return commandProcessor;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=User}/{action=Index}/{id?}");

app.Run();
