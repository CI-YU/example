using Example.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Repository {
  public class ExampleDAL : IExampleDAL {

    public async Task<bool> Example() {
      //需要加上await才能執行非同步
      return true;
    }
  }
}
