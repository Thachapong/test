using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class EmployeeModel
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Positions { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<decimal> Salary { get; set; }
    }
}