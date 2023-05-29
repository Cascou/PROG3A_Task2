//-----------------------------------Start of Farmers-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PROG3_Part2
{
    public partial class Farmers : System.Web.UI.Page
    {
        //Creating object of type employee
        private EmployeeControl myEmployee = new EmployeeControl();
        //Declaring Global Variables
        private int myUserID = 0;
        private int result = 0;

        /// <summary>
        /// This method is called when the farmer page loads.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)//checks if user is logged in
                {
                    if (CheckLoggedInUser() == 0)//checks whether user is employee or farmer by calling the CheckLoggedInUser Method
                    {
                        MessageBox.Show(null, "You have been signed out. Farmer cannot access employee pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Session["Username"] = null;//reset user session
                        Response.Redirect("~/Login");
                    }
                    else
                    {
                        DataTable myTable = myEmployee.GetDataTable();
                        farmerView.DataSource = myTable;
                        farmerView.DataBind();
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
        /// This method cancels the edit on the list of farmers.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FarmerViewCancel(object sender, GridViewCancelEditEventArgs e)
        {
            farmerView.EditIndex = -1;
            BindGridView();
        }

        /// <summary>
        /// This method deletes the farmer from the database.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FarmerViewDelete(object sender, GridViewDeleteEventArgs e)
        {
            string id = farmerView.DataKeys[e.RowIndex].Value.ToString();
            myEmployee.DeleteFarmer(id);
            BindGridView();
        }

        /// <summary>
        /// This method allows employee to edit farmers name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FarmerViewEditing(object sender, GridViewEditEventArgs e)
        {
            farmerView.EditIndex = e.NewEditIndex;
            BindGridView();
        }

        /// <summary>
        /// This method allows employee to update farmers name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void FarmerViewUpdate(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = farmerView.Rows[e.RowIndex];

            string id = farmerView.DataKeys[e.RowIndex].Value.ToString();
            string updatedValue = (row.FindControl("usernametxt") as System.Web.UI.WebControls.TextBox).Text;

            myEmployee.UpdateFarmer(updatedValue, id);
            
            farmerView.EditIndex = -1;
            BindGridView();
        }

        /// <summary>
        /// This method is responsible for binding the changes to the database.
        /// </summary>
        private void BindGridView()
        {
            DataTable myTable = myEmployee.GetDataTable();
            farmerView.DataSource = myTable;
            farmerView.DataBind();
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
//-----------------------------------End of Farmers-------------------------------//