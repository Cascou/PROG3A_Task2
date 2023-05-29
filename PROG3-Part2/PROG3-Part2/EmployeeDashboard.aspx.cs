//-----------------------------------Start of EmployeeDashboard-------------------------------//
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
    public partial class EmployeeDashboard : System.Web.UI.Page
    {
        //Declaring Global Variables
        private int myUserID = 0;
        private int result = 0;

        /// <summary>
        /// This method is called when the employeeDashboard page is called
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)//checks if user is logged in.
                {
                    if(CheckLoggedInUser() == 0)//checks whether user is employee or farmer by calling the CheckLoggedInUser Method
                    {
                        MessageBox.Show(null,"You have been signed out. Farmer cannot access employee pages.","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                if(findAssociatedID == 1)
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
//-----------------------------------End of EmployeeDashboard-------------------------------//