using Shopomo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shopomo.Controllers
{
    public class PasswordController : Controller
    {
        // verify user is valid for one user only
        private static User user = new User { Username = "JoeBloggs" };
        private int timeoutPassword = 30;

        public string GeneratePassword(string username)
        {
            if (username == user.Username)
            {
                if(user.PasswordGeneratedDate!=null 
                    && user.PasswordGeneratedDate.Value.AddSeconds(timeoutPassword) > DateTime.UtcNow)
                {
                    // if password is valid return the same password
                    return user.Password;
                }
                else
                {
                    // if password is invalid then generate new password

                    // use guid and take first 7 characters to keep it simple
                    user.Password = Guid.NewGuid().ToString().Substring(0, 7);
                    user.PasswordGeneratedDate = DateTime.UtcNow;

                    return user.Password;
                }
            }
            else
                return "User not found";
        }

        public string ValidatePassword(string username, string password)
        {
            if (username == user.Username)
            {
                if (user.PasswordGeneratedDate != null && user.PasswordGeneratedDate.Value.AddSeconds(timeoutPassword) > DateTime.UtcNow)
                {
                    if (password == user.Password)
                    {
                        // invalidate the password after one use
                        user.Password = null;
                        user.PasswordGeneratedDate = null;
                        return "Login success";
                    }
                    else
                        return "Invalid password";
                }
                else
                    return "Invalid password";

            }
            else
                return "User not found";
        }

        // GET: Password
        public ActionResult Index()
        {
            return View();
        }
    }
}