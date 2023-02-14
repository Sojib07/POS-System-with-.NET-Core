using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using System.Data;

namespace POS.Services
{
    public class DataUtility : IDataUtility
    {
        private readonly string _connectionString;

        public DataUtility(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private SqlCommand PrepareCommand(string sql, Dictionary<string, object> parameters)
        {
            SqlConnection sqlConnection = new SqlConnection();
            sqlConnection.ConnectionString = _connectionString;

            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = sql;

            if (parameters != null)
            {
                foreach (var item in parameters)
                {
                    sqlCommand.Parameters.Add(new SqlParameter(item.Key, item.Value));
                }
            }

            return sqlCommand;
        }

        public async Task ExecuteCommandAsync(string command,
            Dictionary<string, object> parameters)
        {
            using SqlCommand sqlCommand = PrepareCommand(command, parameters);

                if (sqlCommand.Connection.State != ConnectionState.Open)
                    sqlCommand.Connection.Open();

                int impact = await sqlCommand.ExecuteNonQueryAsync();
        }

        public async Task<IList<SelectListItem>> GetItemsAsync(string command,
            Dictionary<string, object> parameters)
        {
            using SqlCommand sqlCommand = PrepareCommand(command, parameters);
            IList<SelectListItem> rows = new List<SelectListItem>();

            if (sqlCommand.Connection.State != ConnectionState.Open)
                sqlCommand.Connection.Open();

            using SqlDataReader reader = await sqlCommand.ExecuteReaderAsync();

            while (reader.Read())
            {
                rows.Add(new SelectListItem
                {
                    Text = reader["ItemName"].ToString(),
                    Value = reader["UnitPrice"].ToString()
                });
            }

            return rows;
        }
    }
}