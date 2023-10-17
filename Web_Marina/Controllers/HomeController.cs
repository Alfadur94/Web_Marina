using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Web_Marina.Models;

namespace Web_Marina.Controllers
{
	public class HomeController : Controller
	{
		readonly DALSqlServer datenzugriff;

		public HomeController(IConfiguration conf)
		{
			string connectionString = conf.GetConnectionString("SqlServer");
			datenzugriff = new DALSqlServer(connectionString);
		}

		public IActionResult Index()
		{
			List<Boot> boote = datenzugriff.GetAllBoote();
			return View(boote);
		}

		public IActionResult AdminTools()
		{
			List<Boot> boote = datenzugriff.GetAllBoote();
			return View(boote);
		}

		public IActionResult Details(int SID)
		{
			Boot boot = datenzugriff.GetBootById(SID);
			return View(boot);
		}

		[HttpGet]
		public IActionResult Edit(int SID)
		{
			Boot boot = datenzugriff.GetBootById(SID);
			return View(boot);
		}

		[HttpPost]
		public IActionResult Edit(Boot boot)
		{
			if (ModelState.IsValid)
			{
				datenzugriff.UpdateBoot(boot);
				return RedirectToAction("AdminTools");
			}
			else
			{
				return View(boot);
			}
		}
	}
}
