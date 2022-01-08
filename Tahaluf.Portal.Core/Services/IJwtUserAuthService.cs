using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.Portal.Core.Data;

namespace Tahaluf.Portal.Core.Services
{
  public  interface IJwtUserAuthService
    {
       string Authenticate(User user);
    }
}
