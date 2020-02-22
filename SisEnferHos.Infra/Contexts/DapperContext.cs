using SistEnferHos.Infra.Helpers;
using System;
using System.Data;
using System.Data.SqlClient;

namespace SistEnferHos.Infra.Contexts
{
    public sealed class DapperContext : IDisposable
    {
        public SqlConnection Connection { get; set; }

        public DapperContext()
        {
            ReadJsonSettings readJsonSettings = new ReadJsonSettings();
            Connection = new SqlConnection(readJsonSettings.ConnectionString());
            Connection.Open();
        }

        public void Dispose()
        {
            if (Connection.State != ConnectionState.Closed)
                Connection.Close();
        }
    }
}
