using Microsoft.AspNetCore.Mvc;

namespace MigrantProjectMVC.Controllers
{
    public class RefferalController : Controller
    {
        public IActionResult ChooseRefferal()
        {
            var targetNames = new List<string>() {
                "Постановка на миграционный учёт",
                "Другая цель1",
                "Другая цель2"
            };
            return View(targetNames);
        }

        public JsonResult GetRefferal(string targetName)
        {
            var refferals = new Dictionary<string, (string Description, string FullName, DateTime Date, int Count)>(){
               {"Постановка на миграционный учёт",
                    (Description: "Некий текст регламента",
                     FullName: "Мигрантов Мигрант Мигрантович",
                     Date: DateTime.Now,
                     Count: 13) 
               }
            };
            var targetRefferal = refferals[targetName];

            var result = new
            {
                Description = targetRefferal.Item1,
                FullName = targetRefferal.Item2,
                Date = targetRefferal.Item3,
                Count = targetRefferal.Item4
            };//перегоняю для json


            return Json(result);
        }
    }
}
