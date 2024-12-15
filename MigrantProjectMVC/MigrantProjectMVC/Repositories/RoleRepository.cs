using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class RoleRepository : IRoleRepostory
    {
        public List<RoleModel> Roles { get; set; }
        private string _filePath = "jsons/roles.json";
        public RoleRepository() 
        {

            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                Roles = JsonSerializer.Deserialize<List<RoleModel>>(fs);
                fs.Dispose();
            }
            catch (Exception ex)
            {
                fs.Dispose();
                Roles = new List<RoleModel>()
                    {
                        new RoleModel()
                        {
                            Name = "User"
                        },
                        new RoleModel()
                        {
                            Name = "Admin"
                        },
                        new RoleModel()
                        {
                            Name = "Migrant"
                        },
                        new RoleModel()
                        {
                            Name = "Place Owner"
                        }
                    };
                var jsonRoles = JsonSerializer.Serialize(Roles);
                File.WriteAllTextAsync(_filePath, jsonRoles);
            }
        }

        public Task<IList<RoleModel>> GetAllRoles()
        {
            return Task.FromResult(Roles as IList<RoleModel>);
        }
    }
}
