using Example.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Example.Services {
  public class MailService: IMail {

    public async Task<bool> send() {
      //需要加上await才能執行非同步
      return false;
    }
  }
}
