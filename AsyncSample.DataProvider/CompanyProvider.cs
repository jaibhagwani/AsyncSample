using AsyncSample.Common.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncSample.DataProvider
{
    public partial class SqlProvider
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["AsyncConnectionString"].ConnectionString;
        public async Task<List<Company>> GetCompaniesAsync()
        {
            var lstCompany = new List<Company>();
            using(var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                string query = "select Name,Location from Company";

                using (var cmd = new SqlCommand(query, conn))
                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while(await reader.ReadAsync())
                    {
                        var company = new Company
                        {
                            Name = reader.GetFieldValue<string>(0),
                            Location = reader.GetFieldValue<string>(1)
                        };

                        lstCompany.Add(company);
                    };
                }
            }

            return lstCompany;
        }
    }
}
