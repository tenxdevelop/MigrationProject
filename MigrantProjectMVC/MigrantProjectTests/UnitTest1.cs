using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Client;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using MigrantProjectMVC.Repositories;

namespace MigrantProjectTests
{


    public class UnitTest1
    {
        private readonly IServiceProvider _serviceProvider;
        public UnitTest1() 
        {
            var services = new ServiceCollection();
            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddSingleton<IUserRepository, UserRepository>();
            _serviceProvider = services.BuildServiceProvider();
            
        }


        [Fact]
        public void Test1()
        {
            var repository = new UserRepository(_serviceProvider.GetService<IPasswordHasher>());
            var user = new UserModel()
            {
                Id = Guid.NewGuid(),
                Name = "string3",
                Surname = "string3",
                Patronymic = "string3",
                Email = "string3",
                Phone = "string3",
                Password = "string3",
                Role = new RoleModel() { Name = "Admin"}
            };
            repository.Add(user);

            Assert.Equal(user, repository.GetUserByEmail("string3").Result);

        }
    }
}