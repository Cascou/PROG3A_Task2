//-----------------------------------Start of Login Backend-----------------------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PROG3_Part2
{
    public partial class Login : System.Web.UI.Page
    {
        private UserControl myUser = new UserControl();


        /// <summary>
        /// This Method is called when the Login Page Loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This Method is called when the Login button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitLoginbtn_Click(object sender, EventArgs e)
        {
            errorlbl.InnerText = "";//resets error message
            //sets variables to user entered input from textboxes
            string usernameInput = loginUsernametxt.Text;
            string passwordInput = loginPasswordtxt.Text;

            //calls CheckUser method from UserControl, takes user details as a parameter
            string loginCheck = myUser.CheckUser(usernameInput, passwordInput);

            //Nested If-statements, reacts based off of output from CheckUser Method
            if(loginCheck == "You must enter all fields")
            {
                errorlbl.InnerText = loginCheck;
            }else if(loginCheck == "Employee")
            {
                Session["Username"] = usernameInput;
                Response.Redirect("EmployeeDashboard.aspx");
            }
            else if(loginCheck == "Farmer")
            {
                Session["Username"] = usernameInput;
                Response.Redirect("FarmerDashboard.aspx");
            }
            else if(loginCheck == "Invalid Credentials, Try again or register")
            {
                errorlbl.InnerText = loginCheck;
            }
        }

        /// <summary>
        /// This method is called when the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelLoginbtn_Click(object sender, EventArgs e)
        {
            //this resets the necessary fields
            loginUsernametxt.Text = "";
            loginPasswordtxt.Text = "";
            errorlbl.InnerText = "";
        }
    }
}
//-------------------------------------End of Login Backend-----------------------------------------------//