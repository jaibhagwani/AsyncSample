using AsyncSample.Common.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSample.DataProvider
{
    public partial class SqlProvider
    {
        public async Task<List<Employee>> GetEmployeesAsync()
        {
            var lstEmployee = new List<Employee>();
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "select Name, Designation, PhoneNo, Address, Salary from Employee";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var emp = new Employee
                        {
                            Name = reader.GetFieldValue<string>(0),
                            Designation = reader.GetFieldValue<string>(1),
                            PhoneNo = reader.GetFieldValue<string>(2),
                            Address = reader.GetFieldValue<string>(3),
                            Salary = reader.GetFieldValue<double>(4)
                        };

                        lstEmployee.Add(emp);
                    };
                }
            }

            return lstEmployee;
        }
    }
}
