using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.Models;
using System.Text.Json;

namespace MigrantProjectMVC.Repositories
{
    public class MigrantRepository : IMigrantRepository
    {
        public List<MigrantModel> migrants;
        private IUserRepository _userRepository;

        private string _filePath = "jsons/migrants.json";

        public MigrantRepository(IUserRepository userRepository)
        {
            var fs = new FileStream(_filePath, FileMode.Open);
            try
            {
                migrants = JsonSerializer.Deserialize<List<MigrantModel>>(fs);
                fs.Dispose();
            }
            catch (Exception e)
            {
                fs.Dispose();
                _userRepository = userRepository;
                migrants = new List<MigrantModel>();
                var migrantUsers = _userRepository.GetAllUsers().Result.Where(x => x.Role.Name == "Migrant").ToList();
                foreach (var user in migrantUsers)
                {
                    migrants.Add(
                        new MigrantModel()
                        {
                            Id = user.Id,
                            Name = user.Name,
                            Surname = user.Surname,
                            Patronymic = user.Patronymic,
                            Email = user.Email,
                            PasswordHash = user.PasswordHash,
                            Role = user.Role,
                            EnteringDate = DateTime.Parse("1990-01-01"),
                            HighlyQualified = false,
                            ResettelmentProgramMember = false,
                            ConsistOfMigrationRegistration = false,
                            Country = "Белоруссь"
                        }
                        );
                }
                SaveContext();
            }
        }



        public Task<string> GetCountryByMigrantId(string email)
        {
            var migrant = migrants.FirstOrDefault(x => x.Email == email);
            if (migrant == null)
            {
                throw new NullReferenceException();
            }
            return Task.FromResult(migrant.Country);
        }

        public Task<MigrantModel?> GetMigrantBySNP(string name, string surname, string patronymic)
        {
            var migrant = migrants.Find(x =>
            x.Name.Equals(name, StringComparison.OrdinalIgnoreCase) &&
            x.Surname.Equals(surname, StringComparison.OrdinalIgnoreCase) &&
            x.Patronymic.Equals(patronymic, StringComparison.OrdinalIgnoreCase)
            );
            return Task.FromResult(migrant);
        }

        public Task<bool> UpdateMigrant(MigrantModel migrant)
        {
            var foundedMigrant = migrants.FirstOrDefault(x => x.Id == migrant.Id);
            if (foundedMigrant == null) return Task.FromResult(false);
            foundedMigrant.EnteringDate = migrant.EnteringDate;
            foundedMigrant.HighlyQualified = migrant.HighlyQualified;
            foundedMigrant.ResettelmentProgramMember = migrant.ResettelmentProgramMember;
            foundedMigrant.ConsistOfMigrationRegistration = migrant.ConsistOfMigrationRegistration;
            foundedMigrant.Country = migrant.Country;
            return Task.FromResult(true);
        }

        public Task<MigrantModel> GetMigrantById(Guid id)
        {
            var migrant = migrants.FirstOrDefault(m => m.Id == id);
            return Task.FromResult(migrant);
        }

        public Task SaveContext()
        {
            var jsonMigrants = JsonSerializer.Serialize(migrants);
            File.WriteAllText(_filePath, jsonMigrants);
            return Task.CompletedTask;
        }
    }
}
