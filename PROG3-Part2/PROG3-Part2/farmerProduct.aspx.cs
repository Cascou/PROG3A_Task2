//-----------------------------------Start of farmerProduct-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PROG3_Part2
{
    public partial class farmerProduct : System.Web.UI.Page
    {
        //sets global variables
        private FarmerControl myFarmer = new FarmerControl();
        private int myUserID = 0;
        private int myFarmerID = 0;
        private int loginUserID = 0;
        private int result = 0;

        /// <summary>
        /// This method is called when the farmerProduct is called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)//checks if user is signed in.
                {
                    if (CheckLoggedInUser() == 1)//checks whether user is employee or farmer by calling the CheckLoggedInUser Method
                    {
                        MessageBox.Show(null, "You have been signed out. Employee cannot access farmer pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Session["Username"] = null;//reset user session
                        Response.Redirect("~/Login");
                    }
                    else
                    {
                        //call getdatatable method for farmer products associated with farmerID.
                        DataTable myTable = myFarmer.GetDataTable(getFarmerID());
                        productView.DataSource = myTable;
                        productView.DataBind();
                        if (myTable.Rows.Count == 0)
                        {
                            NoResultlbl.Visible = true;
                        }
                        else if (myTable.Rows.Count > 0)
                        {
                            NoResultlbl.Visible = false;
                        }
                    }
                    
                }
                else
                {
                    Response.Redirect("~/Login");
                }

            }
        }

        /// <summary>
        /// This method is responsible for getting the farmerID associated with the currently logged in farmer.
        /// </summary>
        /// <returns></returns>
        public int getFarmerID()
        {
            string username = Session["Username"].ToString();
            using (var context = new FarmCentralEntities())
            {
                var findUserID = context.Users.Where(a => a.Username.Equals(username)).Select(a => new { a.UserID });

                foreach (var user in findUserID)
                {
                    myUserID = user.UserID;//sets record of userID to myUserID variable
                }

                var findFarmerID = context.Farmers.Where(a => a.MyUserID.Equals(myUserID)).Select(a => new { a.FarmerID });

                foreach (var user in findFarmerID)
                {
                    myFarmerID = user.FarmerID;//sets record of userID to myUserID variable
                }
            }
            return myFarmerID;
        }

        /// <summary>
        /// This method is responsible for deleting product for farmer.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void productViewDelete(object sender, GridViewDeleteEventArgs e)
        {
            string id = productView.DataKeys[e.RowIndex].Value.ToString();
            myFarmer.DeleteProduct(id);
            BindGridView();
        }

        /// <summary>
        /// This method is responsible for binding the changes to the database.
        /// </summary>
        private void BindGridView()
        {
            DataTable myTable = myFarmer.GetDataTable(getFarmerID());
            productView.DataSource = myTable;
            productView.DataBind();
        }

        /// <summary>
        /// This method is responsible for checking if it's the right user that is logged in
        /// </summary>
        /// <returns></returns>
        private int CheckLoggedInUser()
        {
            string username = Session["Username"].ToString();

            using (var context = new FarmCentralEntities())
            {
                var findUserID = context.Users.Where(a => a.Username.Equals(username)).Select(a => new { a.UserID });

                foreach (var user in findUserID)
                {
                    loginUserID = user.UserID;//sets record of userID to myUserID variable
                }

                var findAssociatedID = context.Employees.Where(a => a.MyUserID.Equals(loginUserID)).Count();

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
//-----------------------------------End of farmerProduct-------------------------------//