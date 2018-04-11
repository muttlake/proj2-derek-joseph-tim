using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using WeatherApp.Library;

namespace WeatherApp.MVC.Models
{
    public class RegisterViewModel
    { 
        
         public User usr { get; set; }

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

         public bool ValidUserInput()
         {
             return ValidateUserFirstName() && ValidateUserLastName() && ValidateUserEmail() && ValidateUserName() && ValidatePassword(); 

         }
      

        public bool AddUser()
        {
            if(ValidUserInput())
            {

                EfData ef = new EfData();
                ef.AddUsertoDB(usr);
                return true;
            }
           Console.WriteLine("Invalid user input.");
            return false;
           
        }

    }
}