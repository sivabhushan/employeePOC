using EmployeeBAL;
using EmployeeBAL.Model;
using EmployeeDAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace AspCoreApp.Controllers
{
    public class EmployeeController : Controller
    {
        BusinessAccessLayer businessLayer;

        DataAccessLayer dbLayer;

        private readonly IConfiguration _config;

        public EmployeeController(IConfiguration config)
        {
            _config = config;
        }

        public ActionResult Employees()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetEmployees()
        {
            CheckAndCreateObjects();

            var employees = businessLayer.GetEmployees();

            return Json(employees);
        }

        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            CheckAndCreateObjects();

            businessLayer.InsertEmployee(emp);

            return Json("Employee created");
        }

        public ActionResult GetById(int id)
        {
            CheckAndCreateObjects();

            var employee = businessLayer.GetEmployeeById(id);

            return Json(employee);
        }

        [HttpPost]
        public ActionResult Update(Employee emp)
        {
            CheckAndCreateObjects();

            businessLayer.UpdateEmployee(emp);

            return Json("Employee updated!");
        }

        public ActionResult Delete(int id)
        {
            CheckAndCreateObjects();

            businessLayer.DeleteEmployee(id);

            return Json("Employee deleted!");
        }

        private void CheckAndCreateObjects()
        {
            if (businessLayer == null)
                businessLayer = new BusinessAccessLayer(_config.GetValue<string>("ConnectionStrings:MySQLEmployeeDB"));

            if (dbLayer == null)
                dbLayer = new DataAccessLayer(_config.GetValue<string>("ConnectionStrings:MySQLEmployeeDB"));
        }
    }
}
