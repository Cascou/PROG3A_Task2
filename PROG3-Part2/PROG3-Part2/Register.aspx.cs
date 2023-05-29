//-----------------------------------Start of Register Backend-----------------------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace PROG3_Part2
{
    public partial class Register : System.Web.UI.Page
    {
        public UserControl myUser = new UserControl();

        /// <summary>
        /// This Method is called when the Register Page Loads
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This Method is called when the Register button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void submitRegisterbtn_Click(object sender, EventArgs e)
        {
            errorlbl.InnerText = "";//resets error message
            //sets variables to user entered input from textboxes
            string usernameInput = registerUsernametxt.Text;
            string passwordInput = registerPasswordtxt.Text;
            string cPasswordInput = confirmPasswordtxt.Text;

            //calls CreateUser method from UserControl, takes user details as a parameter
            string createCheck = myUser.CreateUser(usernameInput, passwordInput, cPasswordInput);

            //Nested If-statements, reacts based off of output from CreateUser Method
            if (createCheck == "You must enter all fields")
            {
                errorlbl.InnerText = createCheck;
            }
            else if (createCheck == "You passwords must match")
            {
                errorlbl.InnerText = createCheck;
                registerPasswordtxt.Text = "";
                confirmPasswordtxt.Text = "";
            }
            else if (createCheck == "This user already exists")
            {
                errorlbl.InnerText = createCheck;
                registerUsernametxt.Text = "";
                registerPasswordtxt.Text = "";
                confirmPasswordtxt.Text = "";
            }
            else if (createCheck == "Employee Succesfully registered. You can log in.")
            {
                errorlbl.InnerText = createCheck;
            }
        }

        /// <summary>
        /// This method is called when the cancel button is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelRegisterbtn_Click(object sender, EventArgs e)
        {
            errorlbl.InnerText = "";
            registerUsernametxt.Text = "";
            registerPasswordtxt.Text = "";
            confirmPasswordtxt.Text = "";
        }
    }
}
//-------------------------------------End of Register Backend-----------------------------------------------//