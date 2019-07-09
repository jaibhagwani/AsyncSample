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
        public async Task<List<Department>> GetDepartmentsAsync()
        {
            var lstDepartment = new List<Department>();
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "select Name from Department";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        var dept = new Department
                        {
                            Name = reader.GetFieldValue<string>(0)
                        };

                        lstDepartment.Add(dept);
                    };
                }
            }

            return lstDepartment;
        }
    }
}
