using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace LearnMVC.Controllers
{
    public class MoviesController : Controller // MVC Controller
    {
        // Action
        // BaseURL/Movies/GetMovie/10?name=film
        // send parameters as query string
        public void GetMovie(int? id,string name)
        {


        }

        // any action called index --> is Master Action
        public string Index()
        {
            return $"Hello From Index";
        }

    }
}
