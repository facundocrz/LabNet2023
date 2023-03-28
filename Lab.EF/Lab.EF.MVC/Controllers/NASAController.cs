using Lab.EF.MVC.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class NASAController : Controller
    {

        public async Task<ActionResult> Index(string date)
        {
            DateTime oldestDate = DateTime.Parse("1995-06-16");

            if (string.IsNullOrEmpty(date))
            {
                date = DateTime.Today.ToString("yyyy-MM-dd");
            }
            else if (DateTime.Parse(date) < oldestDate)
            {
                date = oldestDate.ToString("yyyy-MM-dd");
            }
            else if (DateTime.Parse(date) > DateTime.Today)
            {
                date = DateTime.Today.ToString("yyyy-MM-dd");
            }

            string url = "https://api.nasa.gov/planetary/apod?api_key=fPJe2GnKIUkE5EbcadFajgFijX6FEmqqi9MrSIYl&date=" + date;

            try
            {
                HttpClient client = new HttpClient();
                var json = await client.GetStringAsync(url);
                dynamic res = JsonConvert.DeserializeObject(json);



                AstronomicPictureViewModel model = new AstronomicPictureViewModel
                {
                    Title = res.title,
                    Description = res.explanation,
                    ImageUrl = res.url,
                    Date = DateTime.Parse(date),
                };

                return View(model);
            }
            catch
            {
                return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "Ocurrió un error al intentar obtener la información" });
            }
        }
    }
}