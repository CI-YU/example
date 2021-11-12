using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Repository.Interface {
  public interface IExampleDAL {
    /// <summary>
    /// 範例介面
    /// </summary>
    /// <returns>bool</returns>
    Task<bool> Example();
  }
}
