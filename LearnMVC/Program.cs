using Microsoft.AspNetCore.Routing.Constraints;
using System.Diagnostics;

namespace LearnMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            var app = builder.Build();



            #region Configuratios

            //// Good for string values
            //var value = builder.Configuration["JWT:ExpiryMinutes"]; // The value is often used when creating a JWT token: If ExpiryMinutes is 60, the token will expire 60 minutes after it is created.

            //Console.WriteLine(value);

            //var expireM = builder.Configuration.GetValue<int>("JWT:ExpiryMinutes",100); // will take 100 as default value if ExpiryMinutes is empty

            #endregion

            #region Connection String

            //  var value = builder.Configuration.GetConnectionString("DefaultConnection");

            #endregion


            #region MiddleWares [Will Applied On All Endpoints]

            // MiddleWares is a piece of code that sits between the HTTP request and the HTTP response
            /* 
             --> Examples to security checkpoints
             * Inspect the request
             * Modify the request
             * Stop the request
             * Pass it to the next middleware
             * Modify the response before it returns
             */

            // Use to Because many tasks need to happen before or after your controller runs.

            // Types of MiddleWares Using :
            // 1. Inline
            // 1. Use
            // 2. Run
            // 3. Map /////
            // 2. Class
            // 1. Conventional MiddleWares
            // 2. Factory Based MiddleWares

            // Important : MiddleWares will be applied by call order

            //// ckeck Some IPs address
            //app.Use(async (context, next) =>
            //{
            //    var stopWatch= Stopwatch.StartNew(); // Start time to Calculate Response Time  

            //    Console.WriteLine("From MiddleWare 1");
            //    await next(); // point to next middleware
            //    Console.WriteLine("From MiddleWare 1");
            //    stopWatch.Stop();
            //    Console.WriteLine(stopWatch.ElapsedMilliseconds); // Output Response time

            //}); // 

            //// Better Version 
            //app.Use(async (context, next) =>
            //{
            //    var stopwatch = Stopwatch.StartNew();

            //    await next();

            //    stopwatch.Stop();

            //    Console.WriteLine(
            //        $"{context.Request.Method} {context.Request.Path} " +
            //        $"took {stopwatch.ElapsedMilliseconds} ms");
            //});

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("From MiddleWare 2");
            //    await next(); // point to next middleware
            //    Console.WriteLine("From MiddleWare 2");

            //}); // 

            //app.Use(async (context, next) =>
            //{
            //    Console.WriteLine("From MiddleWare 3");
            //    await next(); // point to next middleware
            //    Console.WriteLine("From MiddleWare 3");

            //}); // 

            //   app.UseAuthentication(); // Built-In, Checks who the user is.MiddleWares

            //    app.UseAuthorization(); // Built-In MiddleWares, Checks what the user is allowed to do.



            #endregion

              app.MapGet("/", () => "Hello World!"); // By Default URL


            #region Routing

            //app.MapGet("/Asmaa", () => "Hello SemSem"); // Static Segment

            //// Use Context to Use Request & Response to Send what i want to put in request & response
            //app.MapGet("/{name}", async (context) =>
            //{
            //    var Name = context.GetRouteValue("name"); // take route value for parameter name , Must take it in Variable because it will not know it without this
            //    await context.Response.WriteAsync($"Hello {Name}");

            //});

            //app.MapGet("/Miss {name}", async (context) =>
            //{
            //    var Name = context.GetRouteValue("name");
            //    await context.Response.WriteAsync($"Hello Miss {Name}");
            //}); // Variable [Dynamic] Segment

            //// This Way Good for i Want to validate on Data

            //app.MapGet("/{name}/{age}", async (context) =>
            //{
            //    var Name = context.GetRouteValue("name");
            //    var Age = context.GetRouteValue("age");
            //    await context.Response.WriteAsync($"Hello {Name} with {Age}");
            //}); // Variable [Dynamic] Segment


            //// this way good for No Validate , onle send parameters (static or variable or mixed)
            //app.MapGet("/X{name}", async (context) =>
            //{
            //   await context.Response.WriteAsync($"Hello {context.Request.RouteValues["name"]}");
            //});

            // Map Controllers

            // Name for Route
            // pattern --> How to arrive to this action
            //app.MapControllerRoute(name: "Default", pattern: "{Controller}/{Action}/{Id?}",
            //    constraints: new {Id=@"\d{2}"}, // mean it validate before send request
            //    defaults: new {Controller="Movies",Action="Index"} // By Default it return this action without send any request
            //    // new {Id=new IntRouteConstraint()}
            //     ); //  Id is nullable to go to the action with no parameters , IntRoutConstrain to not get any type except Int
            //// Movies/Index

            //app.MapControllerRoute(name: "Default",
            //    pattern: "{Controller}/{Action}/{Id:int?}", // constrain
            //    defaults: new { Controller = "Movies", Action = "Index" } 
            //   );

            //// there are more Routing Constrains


            // Sugar Way
            app.MapControllerRoute(name: "Default",
                pattern: "{Controller=Movies}/{Action}/{Id:regex(^\\d{{2}}$)?}" // if not send controller name --> open Movies by Default
               );



            #endregion


            #region Action Return Types

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



            #endregion


            #region Model Binding & Action Patameters

            // is the process of automatically mapping incoming HTTP request data to action method parameters or model properties

            //////  Types 
            // 1. Simple data / Data Types Built-In (int, string, decimal)
            // 2. Complex data / User Defined (Employee, Student, Car) --> Can't bind data from the headers
            // 3. Collection data (List)
            // 4. Mixed Data (Simple data with complex data with collections) more than one type

            /////// Values Providers [In Order and by Priority decreasing]
            // 1. Form --> Hight Priority
            // 2. Route Data 
            // 3. Query String
            // 4. Request Body
            // 5. Request Headers --> Low Priority


            #endregion


            #region Install Bootstrap

            #endregion


            #region Views

            #endregion


            #region Layout & View Start

            #endregion


            #region Tag Helpers & View Imports

            #endregion

            app.Run();
























        }
    }
}
