using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserManagement.Models;

namespace UserManagement.Services
{
    public interface IUserService
    {
        User getUserDetails(int Id);
    }
}
