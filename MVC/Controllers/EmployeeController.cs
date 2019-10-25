using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using System.Web;
using System.Web.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            IEnumerable<EmployeeModel> empList;
            HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("Employee").Result;
            empList=response.Content.ReadAsAsync<IEnumerable<EmployeeModel>>().Result;
            return View(empList);
        }

        public ActionResult Create(int id = 0)
        {
            if (id == 0) { 
                return View(new EmployeeModel());
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.httpClient.GetAsync("Employee/"+id).Result;
                return View(response.Content.ReadAsAsync<EmployeeModel>().Result);
            }
        }

        [HttpPost]
        public ActionResult Create(EmployeeModel employee)
        {
            if (employee.EmployeeId == 0)
            {
                HttpResponseMessage response = GlobalVariables.httpClient.PostAsJsonAsync("Employee", employee).Result;
            }
            else
            {
                HttpResponseMessage response = GlobalVariables.httpClient.PutAsJsonAsync("Employee/"+employee.EmployeeId, employee).Result;
            }
            
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(int id)
        {
           
            HttpResponseMessage response = GlobalVariables.httpClient.DeleteAsync("Employee/"+id).Result;
           
            return RedirectToAction("Index");
        }
    }
}