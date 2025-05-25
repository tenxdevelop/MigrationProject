using MigrantProjectMVC.Interfaces.Services;
using MigrantProjectMVC.Interfaces;
using MigrantProjectMVC.ViewModel;
using MigrantProjectMVC.Models;

namespace MigrantProjectMVC.Application.Features.Services
{
    public class RefferalService : IRefferalService
    {
        private IMigrantRepository _migrantRepository;
        private ITargetRepository _targetRepository;
        
        public RefferalService(IMigrantRepository migrantRepository, ITargetRepository targetRepository)
        {
            _migrantRepository = migrantRepository;
            _targetRepository = targetRepository;
        }
        public async Task<RefferalViewModel> GetRefferal(string targetName, string name, string surname, string patronymic)
        {
            var migrant = await _migrantRepository.GetMigrant(name, surname, patronymic);

            if (migrant is null)
                return RefferalViewModel.Create("", $"не найдены данные о мигранте: {name} {surname} {patronymic}");

            var target = await _targetRepository.GetTarget(targetName, migrant.EnteringDate);
            
            if(target is null)
                return RefferalViewModel.Create("", $"цель: {targetName}, не найдена в системе");
            
            var condition = target.Condition;

            var regulations = target.GetRegulations();

            foreach (var regulation in regulations)
            {
                if (regulation.IsValidRegulation(migrant))
                {
                    var countRemandingDays = Convert.ToInt32(regulation.Term - (DateTime.Now - migrant.EnteringDate).TotalDays);
                    var notification = new NotificationModel(condition, migrant, DateTime.Today,  countRemandingDays);
                    
                    return RefferalViewModel.Create(notification.RefferalText);
                }
            }
            
            var failedNotification = new NotificationModel(null, migrant, DateTime.Today,  0);
            
            return RefferalViewModel.Create(failedNotification.RefferalText);
        }
    }
}