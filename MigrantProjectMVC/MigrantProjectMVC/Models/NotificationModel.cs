
namespace MigrantProjectMVC.Models
{

    public class NotificationModel
    {
        public string RefferalText { get; set; }
        public DateTime Date { get; set; }
        public int CountRemandingDays { get; set; }

        public static NotificationModel Create(ConditionModel condition, MigrantModel migrant, DateTime date, int countRemandingDays)
        {
            var refferal = "Уважаемый, " + migrant.GetFIO() + ", ";
            
            if (condition is null || countRemandingDays <= 0)
                refferal += "В соответствии с законом вы нарушили статью 18.9 КоАП РФ";
            else    
                refferal += condition.Instruction + ", в течении " + countRemandingDays + " дней.";
            
            return new NotificationModel() { RefferalText = refferal, Date = date, CountRemandingDays = countRemandingDays };
        }
    }
}