//-----------------------------------Start of Logout-------------------------------//
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
    public partial class Logout : System.Web.UI.Page
    {
        /// <summary>
        /// This method is called when the logout page is loaded.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageBox.Show(null,"Thank you for using Farm Central", "Logged Out", MessageBoxButtons.OK, MessageBoxIcon.Information);//messagebox to show user has been logged out
            Session["Username"] = null;//sets session to null
            Response.Redirect("~/Login");//sends user back to login
        }
    }
}
//-----------------------------------End of Logout-------------------------------//