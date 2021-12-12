
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using TextMatch.Models;
using TextMatch.Services;

namespace TextMatch.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMatchService _matchService;

        public HomeController(IMatchService matchService)
        {
            _matchService = matchService;
        }

        public IActionResult Index()
        {
            var textString = new TextString{Text="", SubText = ""};
            return View(textString);
        }
        
        [HttpPost]
        public ActionResult FindMatches( TextString textString)
        {
            var indexList = _matchService.AllIndicesOf(textString);
            var enumerable = indexList.ToList();
            if (enumerable.Count > 0)
            {
                var resultString = "";
                for (var i = 0; i < enumerable.Count -1; i++)
                {
                    resultString = resultString + (enumerable[i]+1) + ",";
                }
                resultString += (enumerable[^1] +1);
                ViewBag.Result = $"Result: {resultString}"; // 1,26,51
            }
            else
            {
                ViewBag.Result = $"Result: There is no output";
            }
            return View("Index" , textString);
        }
    }
}