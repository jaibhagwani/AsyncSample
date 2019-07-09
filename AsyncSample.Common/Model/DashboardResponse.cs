using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSample.Common.Model
{
    public class DashboardResponse
    {
        public DashboardResponse()
        {
            Companies = new List<Company>();
            Departments = new List<Department>();
            Employees = new List<Employee>();
        }

        public List<Company> Companies { get; set; }
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
