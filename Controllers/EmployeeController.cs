using EmployeeProject.DAL;
using EmployeeProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeProject.Controllers
{
    public class EmployeeController:Controller
    {
        EmployeeContext dal = null;
        public EmployeeController()
        {
            dal = new EmployeeContext();
        }
        //Get:Product 
        public ActionResult Index()
        {
            List<Employee> elist = dal.Employees.ToList();
            return View(elist);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Employee e)
        {
            if (ModelState.IsValid)
            {
                dal.Employees.Add(e);
                dal.SaveChanges();
                List <Employee> elist=dal.Employees.ToList();
                return View("Index",elist);
            }
            return View("Create",e);
        }
        public ActionResult Details(int Id)
        {
            Employee e = dal.Employees.Find(Id);
            return View(e);
        }
        public ActionResult Delete(int Id)
        {
            Employee e = dal.Employees.Find(Id);
            dal.Employees.Remove(e);
            dal.SaveChanges();
            List<Employee>elist=dal.Employees.ToList();
            return View("Index", elist);
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            Employee e=dal.Employees.Find(Id);
            return View(e);
        }
        [HttpPost]
        public ActionResult Edit(Employee e)
        {
            if (ModelState.IsValid)
            {
                Employee x = dal.Employees.Find(e.Id);
                x.Name= e.Name;
                x.Position= e.Position;
                x.Salary=e.Salary;
                dal.SaveChanges();
                return View("Index", dal.Employees.ToList());
            }
            return View("Edit",e);
        }
    }
    
}