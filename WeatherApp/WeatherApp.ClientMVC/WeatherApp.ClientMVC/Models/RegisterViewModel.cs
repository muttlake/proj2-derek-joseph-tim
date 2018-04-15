using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeatherApp.ClientLib;

namespace WeatherApp.ClientMVC.Models
{
    public class RegisterViewModel
    { 
        
         public User usr { get; set; }

         public string InputZipCode { get; set; }

         public bool ValidateUserFirstName()
         {
             return usr.FirstName != null && usr.FirstName != "";
         }
      

        public bool ValidateUserLastName()
         {
             return usr.LastName != null && usr.LastName != "";
         }


         public bool ValidateUserEmail()
         {
             return usr.Email != null && usr.Email != "";
         }


         public bool ValidateUserName()
         {
             return usr.Username != null && usr.Username != "";
         }

          public bool ValidatePassword()
         {
             return usr.Password != null && usr.Password != "";
         }

        public bool ValidateZipCode()
         {
             int testZip = 0;
             return InputZipCode.Trim().Length == 5 && Int32.TryParse(InputZipCode, out testZip);
         }


         public bool ValidUserInput()
         {
             return ValidateUserFirstName() && ValidateUserLastName() && 
                    ValidateUserEmail() && ValidateUserName() &&
                    ValidatePassword() && ValidateZipCode(); 

         }
      

        public bool AddUser()
        {
            if(ValidUserInput())
            {
                usr.HomeZipCode = Convert.ToInt32(InputZipCode);
                //EfData ef = new EfData();
                //ef.AddUsertoDB(usr);
                return true;
            }
           Console.WriteLine("Invalid user input.");
            return false;
           
        }

    }
}
