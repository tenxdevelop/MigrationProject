using MigrantProjectMVC.CommandHandlers;
using MigrantProjectMVC.Commands;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();


//Dependencies
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IRegulationRepository, RegulationRepository>();

// Регаем в CommandProcessor все исполнители комманд
builder.Services.AddSingleton<ICommandProcessor>(sp =>
{
    var commandProcessor = new CommandProcessor();
    commandProcessor.RegisterCommandHadnler(new CreateUserStatementCommandHandler(sp.GetService<IUserRepository>()));
    commandProcessor.RegisterCommandHadnler(new DeleteUserCommandHandler(sp.GetService<IUserRepository>()));
    //commandProcessor.RegisterCommandHadnler(new )
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
