using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace LearnMVC.Controllers
{
    public class MoviesController : Controller // MVC Controller
    {

        /*
          Actions : 
        * must be public
        * can't be static 
        * can't be an extension method
        * can't be a constructor or Getter or Setter
        * can't have open generic types
        * is not a method of the controller base class
        * can't contain Ref ot Out Parameters
         */

        /*
         Action Return Types :
         * ViewResult --> return HTML page
         * EmptyResult --> return no result
         * RedirectResult --> return redirect to a new URL
         * JsonResult --> return JavaScript Object Notation Result  (in API)
         * JavaScriptResult --> return JavaScript Script
         * ContentResult --> return text result
         * FileContentResult --> return downloadable file (With the Binary content)
         * FilePathResult --> return downloadable file (with a path)
         * FileStreamResult -->  return downloadable file (with a file Stream)
         */


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

        public IActionResult TestRedirect()
        {
            //  return RedirectToAction("Index"); // redirect to this action in the same controller
            //  return RedirectToAction(actionName:"GetMovie",controllerName:"Movies"); // redirect to this action in another controller
            //  return RedirectToAction(actionName: "GetMovie", controllerName: "Movies", routeValues: new {id=20}); // redirect to this action in another controller with the route Values
            return RedirectToRoute(routeName: "default", routeValues: new { Action = "GetMovie", Controller="Movies",Id=20 }); // can't read default values in original route yo direct to it , Action & Controller are required
        }

    }
}
