//-----------------------------------Start of employeeProduct-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace PROG3_Part2
{
    public partial class employeeProduct : System.Web.UI.Page
    {
        //Declaring global variable of database connection string.
        private string conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"].ConnectionString;
        //Declaring object of type EmployeeControl
        private EmployeeControl myEmployee = new EmployeeControl();
        //Declaring Global Variables
        private int myUserID = 0;
        private int result = 0;

        /// <summary>
        /// This method is called when the page loads.
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
                        GetFarmer();//calls farmer list
                    }
                    
                }
                else
                {
                    Response.Redirect("~/Login");
                }

            }
        }

        /// <summary>
        /// This method is responsible for getting all farmers in db into select
        /// </summary>
        public void GetFarmer()
        {
            string getItemQuery = "SELECT Username from Users U JOIN Farmer F ON F.MyUserID = U.UserID";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(getItemQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string myValue = reader["Username"].ToString();

                    ListItem listItem = new ListItem(myValue);

                    farmerSelect.Items.Add(listItem);
                }
                reader.Close();
                connection.Close();
            }
        }

        /// <summary>
        /// This method is called when the search button is called.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void searchbtn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = fromCalendar.SelectedDate;
            DateTime toDate = toCalendar.SelectedDate;

            if(farmerSelect.Value == "" || toDate.ToString().Equals("0001/01/01 00:00:00")|| toDate.ToString().Equals("0001/01/01 00:00:00"))
            {
                errorlbl.Text = "Must choose farmer, and dates to search";
            }
            else if (toDate < fromDate)
            {
                errorlbl.Text = "Your from date cannot start later, than your to date";
            }
            else
            {
                errorlbl.Text = "";
                DataTable myTable = myEmployee.SearchFarmer(farmerSelect.Value, fromDate.ToShortDateString(), toDate.ToShortDateString());
                farmerProductView.DataSource = myTable;
                farmerProductView.DataBind();
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
//-----------------------------------End of employeeProduct-------------------------------//