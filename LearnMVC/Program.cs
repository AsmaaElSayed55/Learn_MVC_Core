using System.Diagnostics;

namespace LearnMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configuratios

            //// Good for string values
            //var value = builder.Configuration["JWT:ExpiryMinutes"]; // The value is often used when creating a JWT token: If ExpiryMinutes is 60, the token will expire 60 minutes after it is created.

            //Console.WriteLine(value);

            //var expireM = builder.Configuration.GetValue<int>("JWT:ExpiryMinutes",100); // will take 100 as default value if ExpiryMinutes is empty

            #endregion

            #region Connection String

          //  var value = builder.Configuration.GetConnectionString("DefaultConnection");

            #endregion

            var app = builder.Build();

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

            // ckeck Some IPs address
            app.Use(async (context, next) =>
            {
                var stopWatch= Stopwatch.StartNew(); // Start time to Calculate Response Time  

                Console.WriteLine("From MiddleWare 1");
                await next(); // point to next middleware
                Console.WriteLine("From MiddleWare 1");
                stopWatch.Stop();
                Console.WriteLine(stopWatch.ElapsedMilliseconds); // Output Response time

            }); // 

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

            app.Use(async (context, next) =>
            {
                Console.WriteLine("From MiddleWare 2");
                await next(); // point to next middleware
                Console.WriteLine("From MiddleWare 2");

            }); // 

            app.Use(async (context, next) =>
            {
                Console.WriteLine("From MiddleWare 3");
                await next(); // point to next middleware
                Console.WriteLine("From MiddleWare 3");

            }); // 

            //   app.UseAuthentication(); // Built-In, Checks who the user is.MiddleWares

            //    app.UseAuthorization(); // Built-In MiddleWares, Checks what the user is allowed to do.



            #endregion

            app.MapGet("/", () => "Hello World!"); // By Default URL


            #region Routing

            //app.MapGet("/Asmaa", () => "Hello SemSem"); // Static Segment

            //// Use Context to Use Request & Response to Send what i want to put in request & response
            //app.MapGet("{name}/{age}", async (context)  =>
            //{
            //    var Name = context.GetRouteValue("name");
            //    var Age = context.GetRouteValue("age");
            //    await context.Response.WriteAsync($"Hello {Name} with {Age}");
            //}); // Variable [Dynamic] Segment










            #endregion


            #region Action Return Types

            #endregion


            #region Model Binding & Action Patameters

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
