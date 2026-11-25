using LearnMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace LearnMVC.Controllers
{
    public class MoviesController : Controller // MVC Controller
    {

      
        // Action
        // BaseURL/Movies/GetMovie/10?name=film
        // send parameters as query string
        public void GetMovie(int? id)
        {

        }

        // any action called index --> is Master Action
        public string Index()
        {
            // String ==> ContentResult ==> Render Browser HTML Page
            return $"Hello From Index";
        }

        //  [NonAction] // Not Accesiable From the URL
        //public void DeleteMovie(int id) // Regular Method
        //{

        //}

        //[HttpGet]
        //public ContentResult GetMovie(int? id, string name)
        //{
        //    //ContentResult result = new ContentResult();
        //    //result.ContentType = "text/html"; // content type 
        //    //result.StatusCode = StatusCodes.Status200OK;
        //    //result.Content = $"Movie with id ={id} , name={name}";
        //    //return result;

        //    return Content(content: $"Movie with id ={id}, name={name}", contentType: "text/html");


        //}
        [HttpGet]
        public IActionResult GetMovie(int? id, string name)
        {

            // BadRequestResult inherit ActionResult , ActionResult implement IActionResult 
            if (id == null || id == 0)
            {
                return BadRequest();
            }
            else if (id < 10)
            {
                return NotFound();
            }
            else
            {
                return Content(content: $"Movie with id ={id}, name={name}", contentType: "text/html");
            }
        }

        //public IActionResult TestRedirect()
        //{
        //    //  return RedirectToAction("Index"); // redirect to this action in the same controller
        //    //  return RedirectToAction(actionName:"GetMovie",controllerName:"Movies"); // redirect to this action in another controller
        //    //  return RedirectToAction(actionName: "GetMovie", controllerName: "Movies", routeValues: new {id=20}); // redirect to this action in another controller with the route Values
        //    return RedirectToRoute(routeName: "default", routeValues: new { Action = "GetMovie", Controller="Movies",Id=20 }); // can't read default values in original route yo direct to it , Action & Controller are required
        //}

        //[HttpGet]
        //public IActionResult TestModelBinding([FromQuery]int? id, [FromForm]string name) // make it take Id data from query only , name data from Form Only
        //{
        //    return Content(content: "");
        //}

        [HttpPost]
        public IActionResult TestModelBinding([FromHeader]string? name,[FromForm]int id,[FromBody]Movie movie) // make it take Id data from query only , name data from Form Only , Movie get data from Json file
        {
            // Movie ==> Id , Name
            return Content(content: "");
        }

        [HttpGet]
        public IActionResult TestModelBinding(int[] arr,int? id,string name, Movie movie) 
        {
            return Content(content: "");
        }



    }
} 
