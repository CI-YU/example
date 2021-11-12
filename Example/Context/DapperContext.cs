using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Context {
  public class DapperContext {
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    /// <summary>
    /// 建構子
    /// </summary>
    /// <param name="configuration"></param>
    public DapperContext(IConfiguration configuration) {
      _configuration = configuration;
      _connectionString = _configuration.GetConnectionString("SqlConnection");
    }

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
  }
}
