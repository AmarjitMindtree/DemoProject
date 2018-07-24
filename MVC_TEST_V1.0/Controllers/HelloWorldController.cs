using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_TEST_V1._0.Models;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Core.Objects;

namespace MVC_TEST_V1._0.Controllers
{
    public class Actor
    {
        [Required(AllowEmptyStrings =false, ErrorMessage ="Actor {0} details is required")]
        [StringLength(20,MinimumLength =3,ErrorMessage ="Name should be atleast of 3 character and max of 20 characater")]
        [RegularExpression("^([a-zA-Z]{2,}\\s[a-zA-z]{1,})", ErrorMessage ="Name can not be integer type")]
        public string Name { get; set; }

        [Range(5, 10, ErrorMessage ="Number should be in range of 5 to 10")]
        public int Number { get; set; }
    }

    public class HelloWorldController : Controller
    {
        private MovieDBContext _dbContextObject; 
        // GET: HelloWorld
        public ActionResult Index()
        {
            using (_dbContextObject = new MovieDBContext())
            {
                Movie movie = new Movie() { Title = "P.K", Genre = "Comedy", ReleaseDate = DateTime.Parse("4/15/15"), Price = 7.5M };
                try
                {
                    var contextObject = _dbContextObject.Movies.Add(movie);                    
                    _dbContextObject.SaveChanges();
                    ViewBag.SuccessMessage = "Data Stored Successfully";
                    return View();
                }
                catch(Exception ex)
                {
                    ViewBag.Message = ex.Message.ToString();
                    return View("ErrorMessageView", "~/Views/Shared/Error.cshtml");
                }
            }
                
        }
        public ActionResult Welcome(Actor actor)
        {
            if(ModelState.IsValid)
            {
                ViewBag.Actors = actor;
                return View();
            }
            else
            {
                ViewBag.ErrorMessage = ViewData.ModelState.SelectMany(errors => errors.Value.Errors).First().ErrorMessage.ToString();
                return View("ErrorMessageView", "~/Views/Shared/Error.cshtml");
            }
        }
    }
}