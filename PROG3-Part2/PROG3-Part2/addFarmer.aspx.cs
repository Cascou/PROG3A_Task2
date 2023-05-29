//-----------------------------------Start of Add Farmer-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PROG3_Part2
{
    public partial class addFarmer : System.Web.UI.Page
    {
        //creating object from Employee Control class.
        public EmployeeControl myEmployee = new EmployeeControl();
        //Declaring Global Variables
        private int myUserID = 0;
        private int result = 0;

        /// <summary>
        /// This method is called when the page is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)//checks if a user is logged in
                {
                    if (CheckLoggedInUser() == 0)//checks whether user is employee or farmer by calling the CheckLoggedInUser Method
                    {
                        MessageBox.Show(null, "You have been signed out. Farmer cannot access employee pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Session["Username"] = null;//reset user session
                        Response.Redirect("~/Login");
                    }
                }
                else
                {
                    Response.Redirect("~/Login");
                }

            }
        }

        /// <summary>
        /// This method is called when the registerfarmerbtn is clicked.
        /// It registers a farmer into the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void registerFarmerbtn_Click(object sender, EventArgs e)
        {
            errorlbl.Text = "";//resets error message
            //sets variables to user entered input from textboxes
            string usernameInput = farmerUsernametxt.Text;
            string passwordInput = farmerPasswordtxt.Text;
            string cPasswordInput = farmerCPasswordtxt.Text;

            //calls CreateUser method from UserControl, takes user details as a parameter
            string createCheck = myEmployee.CreateFarmer(usernameInput, passwordInput, cPasswordInput);

            //Nested If-statements, reacts based off of output from CreateUser Method
            if (createCheck == "You must enter all fields")
            {
                errorlbl.Text = createCheck;
            }
            else if (createCheck == "You passwords must match")
            {
                errorlbl.Text = createCheck;
                farmerPasswordtxt.Text = "";
                farmerCPasswordtxt.Text = "";
            }
            else if (createCheck == "This user already exists")
            {
                errorlbl.Text = createCheck;
                farmerUsernametxt.Text = "";
                farmerPasswordtxt.Text = "";
                farmerCPasswordtxt.Text = "";
            }
            else if (createCheck == "Farmer Succesfully registered. You can log in.")
            {
                errorlbl.Text = createCheck;
            }
        }

        /// <summary>
        /// This method brings the employee back to the farmers page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelFarmerbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Farmers");
        }

        /// <summary>
        /// This method is responsible for checking if it's the right user that is logged in
        /// </summary>
        /// <returns></returns>
        public int CheckLoggedInUser()
        {
            string username = Session["Username"].ToString();

            using (var context = new FarmCentralEntities())
            {
                var findUserID = context.Users.Where(a => a.Username.Equals(username)).Select(a => new { a.UserID });

                foreach (var user in findUserID)
                {
                    myUserID = user.UserID;//sets record of userID to myUserID variable
                }

                var findAssociatedID = context.Employees.Where(a => a.MyUserID.Equals(myUserID)).Count();

                if (findAssociatedID == 1)
                {
                    result = 1;
                }
                else
                {
                    result = 0;
                }
            }
            return result;
        }
    }
}
//-----------------------------------Start of Add Farmer-------------------------------//
