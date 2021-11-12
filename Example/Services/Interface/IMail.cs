using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services.Interface {
  public interface IMail {
    /// <summary>
    /// 寄信
    /// </summary>
    /// <returns></returns>
    public Task<bool> send();
  }
}
