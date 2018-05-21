using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Beltretake.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Diagnostics;
using System.Web;
using System.Collections.Specialized;


namespace Beltretake.Controllers{
	//[Route("/")]
    public class BeltretakeController:Controller{
        private ActivityContext _context;
        public BeltretakeController(ActivityContext context){
            _context =  context;
    }
        [HttpGet]
        [Route("")]
        public IActionResult Index(){
            return View("Index");
        }
        [HttpGet]
        [Route("login")]
        public IActionResult login(LoginVM loginVM){
            if(ModelState.IsValid){
                User user = _context.Login(loginVM);
                if(user == null){
                    TempData["error"] = "Invalid credentials.";
                }
                else{
                    return RedirectToAction("Activities");
                }
            }
            return View("login");
        }
        [HttpPost]
        [Route("loginpost")]
        public IActionResult loginPost(LoginVM loginVM){
            if(ModelState.IsValid){
                System.Console.WriteLine("STATE IS QUITE VALID INDEED.");
                User user = _context.Login(loginVM);
                System.Console.WriteLine(user);
                System.Console.WriteLine(user.id);
                HttpContext.Session.SetInt32("logged", user.id);
                HttpContext.Session.SetString("alias", user.first);
                if(user == null){
                    TempData["error"] = "Invalid credentials.";
                }
                else{
                List<Beltretake.Models.Activity>activities = _context._activities.Include(p => p.participating).ToList();
                    return RedirectToAction("Activities");
                }
            }
            return View("login");
        }
        [HttpGet]
        [Route("register")]
        public IActionResult register(){
            return View();
        }
        [HttpPost]
        [Route("register")]
        public IActionResult registerPost(RegisterVM registerVM){
            if(ModelState.IsValid){
                _context.CreateUser(registerVM);
                _context.SaveChanges();     
            }           
            return RedirectToAction("register");
        }
        [HttpGet]
        [Route("Activities")]
        public IActionResult Activities(){
            List<Beltretake.Models.Activity>activities = _context._activities.Include(p => p.participating).ToList();            
            ViewBag.loggedin=_context._users.SingleOrDefault(u => u.id == HttpContext.Session.GetInt32("logged"));
            ViewBag.activities=activities;
            System.Console.WriteLine(activities);
            return View();
        }
        [HttpPost]
        [Route("add")]
        public IActionResult Add(Beltretake.Models.Activity item){
            Beltretake.Models.Activity diversion = new Beltretake.Models.Activity();
            diversion.name = item.name;
            diversion.start= item.start;
            diversion.description = item.description;
            diversion.creatorid = Convert.ToInt32(HttpContext.Session.GetInt32("logged"));
            diversion.creator= _context._users.SingleOrDefault(u => u.id == HttpContext.Session.GetInt32("logged"));
            System.Console.WriteLine("HERE'S THAT");
            System.Console.WriteLine(item.duration);
            // if(Request.Form["timeunit"]=="days")
            // {
            //     int days= Convert.ToInt32(item.duration);
            //     diversion.duration= new TimeSpan(days,0,0,0);
            // }
            // if(Request.Form["timeunit"]=="hours")
            // {
            //     int hours= Convert.ToInt32(item.duration);
            //     diversion.duration= new TimeSpan(0,hours,0,0);
            // }
            // if(Request.Form["timeunit"]=="minutes")
            // {
            //     int minutes = Convert.ToInt32(item.duration);
            //     diversion.duration= new TimeSpan(0,0,minutes,0);
            // }
            diversion.duration=item.duration;
            _context._activities.Add(diversion);
            _context.SaveChanges();
            ViewBag.loggedin=_context._users.SingleOrDefault(u => u.id == HttpContext.Session.GetInt32("logged"));
            List<Beltretake.Models.Activity>activities = _context._activities.Include(p => p.participating).Include(c => c.creator).ToList();
            ViewBag.activities=activities;
            return View("Activities");
        }
        [HttpGet]
        [Route("logout")]
        public IActionResult Logout(){
            HttpContext.Session.Remove("logged");
            return View("Index");
        }
        [HttpGet]
        [Route("delete/{id}")]
        public IActionResult Delete(int id){
            Beltretake.Models.Activity cancelled= _context._activities.SingleOrDefault(u => u.id == id);
            _context._activities.Remove(cancelled);
            _context.SaveChanges();
            ViewBag.loggedin=_context._users.SingleOrDefault(u => u.id == HttpContext.Session.GetInt32("logged"));
            List<Beltretake.Models.Activity>activities = _context._activities.Include(p => p.participating).ToList();
            ViewBag.activities=activities;
            return RedirectToAction("Activities");
        }
        [HttpGet]
        [Route("join/{id}")]
        public IActionResult Join(int id){
            if(_context._joins.Any(j => j.activityid==id && j.userid== Convert.ToInt32(HttpContext.Session.GetInt32("logged")))==false){
            Join participating = new Join(){
                activityid= id,
                userid= Convert.ToInt32(HttpContext.Session.GetInt32("logged"))
            };
            _context._joins.Add(participating);
            _context.SaveChanges();
            }
            ViewBag.loggedin=_context._users.SingleOrDefault(u => u.id == HttpContext.Session.GetInt32("logged"));
            List<Beltretake.Models.Activity>activities = _context._activities.Include(p => p.participating).ToList();
            ViewBag.activities=activities;
            return View("Activities");
        }
        [HttpGet]
        [Route("create")]
        public IActionResult Create(){
            return View("Create");
        }
        [HttpGet]
        [Route("show/{id}")]
        public IActionResult Show(int id){
            Beltretake.Models.Activity scrutinized = _context._activities.Include(a => a.participating).ThenInclude(p => p.user).SingleOrDefault(a => a.id == id);
            User creator = _context._users.SingleOrDefault(u => u.id== scrutinized.creatorid);
            //System.Console.WriteLine("HERE WE GO");
            //System.Console.WriteLine(creator);
            List<Join> participating = _context._joins.Where(g => g.activityid == scrutinized.id).Include (g => g.activity).Include(g => g.user).ToList();
            ViewBag.participating=participating;
            ViewBag.creator = creator;
            ViewBag.shown= scrutinized;
            return View("Show");
        }
    }
}
namespace Kendo.Mvc.Examples.Controllers
{
    public partial class DateTimePickerController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}


