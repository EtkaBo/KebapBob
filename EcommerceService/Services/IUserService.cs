using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceService.Services
{
    public interface IUserService
    {
        int Authenticate(string userName, string lastName);
    }
}
