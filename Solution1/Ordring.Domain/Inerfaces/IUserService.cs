using System;
using System.Collections.Generic;
using System.Text;
using Oordring.Api.Models;

namespace Oordring.Api.Inerfaces
{
   public interface IUserService
    {
        User Authenticate(string username, string password);
        IEnumerable<User> GetAll();
       
        
    }
}
