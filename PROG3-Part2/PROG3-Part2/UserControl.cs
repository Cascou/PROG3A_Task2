//-----------------------------------Start of User Control Class-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;

namespace PROG3_Part2
{
    public class UserControl
    {
        //Creating Global Variables used for the methods
        private int myUserID = 0;
        private string myOutput = "";


        /// <summary>
        /// Default Constructor
        /// </summary>
        public UserControl()
        {

        }

        /// <summary>
        /// CheckUser Method Header, check user login details exist in the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns name="myOutput"></returns>
        public string CheckUser(string username, string password)
        {
            string hashedPassword = CreateHash(password);
            //if-statement for input validation
            if (username == "" || password == "")
            {
                myOutput = "You must enter all fields";
            }
            else
            {
                using (var context = new FarmCentralEntities())
                {
                    var count = context.Users.Where(a => a.Username.Equals(username) && a.Password.Equals(hashedPassword)).Count();//counts how many users with the correct details

                    //if 1, user details are found
                    if (count == 1)
                    {
                        var userID = context.Users.Where(a => a.Username.Equals(username) && a.Password.Equals(hashedPassword)).Select(a => new { a.UserID });//returns userID with correct details

                        foreach (var user in userID)
                        {
                            myUserID = user.UserID;//sets record of userID to myUserID variable
                        }

                        var countEmployee = context.Employees.Where(a => a.MyUserID == myUserID).Count();//checks if this userID is present in employees table

                        //if 1, user detail is found in employee
                        if (countEmployee == 1)
                        {
                            //Response.Redirect("EmployeeDashboard.aspx");//redirects to employee master page
                            myOutput = "Employee";
                        }
                        else//if not 1, must be farmer
                        {
                            //Response.Redirect("FarmerDashboard.aspx");//redirects to farmer master page
                            myOutput = "Farmer";
                        }
                    }
                    else if (count == 0)
                    {
                        //errorlbl.InnerText = "Invalid Credentials, Try again or register";//error sent out due to details not being found.
                        myOutput = "Invalid Credentials, Try again or register";
                    }
                }
            }
            return myOutput;
        }

        /// <summary>
        /// Create User Method Header, inserts user details into the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cPassword"></param>
        /// <returns></returns>
        public string CreateUser(string username, string password, string cPassword)
        {
            string hashedPassword = CreateHash(password);
            //Nested if-statement for input validation
            if (username == "" || password == "" || cPassword == "")
            {
                myOutput = "You must enter all fields";
            }
            else if (password != cPassword)
            {
                myOutput = "You passwords must match";
            }
            else
            {
                using (var context = new FarmCentralEntities())
                {
                    var count = context.Users.Where(a => a.Username.Equals(username)).Count();

                    //if 1, user details are found
                    if (count == 1)
                    {
                        myOutput = "This user already exists";
                    }
                    else
                    {
                        var myUser = new User
                        {
                            Username = username,
                            Password = CreateHash(password)
                        };

                        context.Users.Add(myUser);
                        context.SaveChanges();

                        var userID = context.Users.Where(a => a.Username.Equals(username) && a.Password.Equals(hashedPassword)).Select(a => new { a.UserID });//returns userID with correct details

                        foreach (var user in userID)
                        {
                            myUserID = user.UserID;//sets record of userID to myUserID variable
                        }

                        var myEmployee = new Employee
                        {
                            MyUserID = myUserID
                        };

                        context.Employees.Add(myEmployee);
                        context.SaveChanges();

                        myOutput = "Employee Succesfully registered. You can log in.";
                    }
                }
            }
            return myOutput;
        }

        /// <summary>
        /// Creates hash of the password. Method was found online and would be useful to encrypt password for further security.
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        public static string CreateHash(string password)
        {
            using (SHA256 myHash = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = myHash.ComputeHash(inputBytes);

                StringBuilder myBuilder = new StringBuilder();
                for(int i = 0; i < hashBytes.Length; i++)
                {
                    myBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return myBuilder.ToString();
            }
        }

    }
}
//-----------------------------------End of User Control Class-----------------------------------------------//
