using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    //---------index page-string message
    [HttpGet("")]
    public IActionResult IndexView()
    {   //model for string message
        string message= "Today is a beautiful day!";
        //render
        return View("IndexView",message);
    }

    //---------page with array of integers
    [HttpGet("numbers")]
    public IActionResult NumbersView()
    {
        //list model
        List<int> NumbersList = new List<int>() {5,5,4,7,9,2};

        // return View("NumbersView");
        /////pass in the list:
        return View(NumbersList);
    }

    //----------page with a single user
    [HttpGet("user")]
    public IActionResult UserView()
    {
        //one user model
        User MyUser= new User()
        {
            FirstName= "Samantha",
            LastName= "Smith"
        };
        return View("UserView", MyUser);
    }

    //page with a list of users
    [HttpGet("users")]
    public IActionResult UsersListView()
    {
        //users list method
        List <User> ListOfUsers= new List<User>()
        {
            new User(){FirstName= "Samantha", LastName="Smith"},
            new User(){FirstName= "Terry", LastName="Pratchet"},
            new User(){FirstName= "Neil", LastName="Gaiman"},
            new User(){FirstName= "Stephen", LastName="King"},
            new User(){FirstName= "Jane", LastName="Austen"},
        };

        return View(ListOfUsers);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
