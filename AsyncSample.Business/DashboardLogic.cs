using AsyncSample.Common.Model;
using AsyncSample.DataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSample.Business
{
    public class DashboardLogic
    {
        private SqlProvider sqlProvider;

        public DashboardLogic()
        {
            sqlProvider = new SqlProvider();
        }

        public async Task<DashboardResponse> GetDashboardData()
        {
            var dashboardResponse = new DashboardResponse();
            var companies = sqlProvider.GetCompaniesAsync();
            var departments = sqlProvider.GetDepartmentsAsync();
            var employees = sqlProvider.GetEmployeesAsync();
            
            dashboardResponse.Companies = await companies;
            dashboardResponse.Departments =await departments;
            dashboardResponse.Employees = await employees;

            return dashboardResponse;
        }
    }
}
