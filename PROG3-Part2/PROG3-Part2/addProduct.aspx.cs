//-----------------------------------Start of Add Product-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace PROG3_Part2
{
    public partial class addProduct : System.Web.UI.Page
    {
        //Creates object of type FarmerControl for backend methods
        public FarmerControl myFarmer = new FarmerControl();
        //Declaring global variable of database connection string.
        private string conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"].ConnectionString;
        //Declaring Global Variables
        private int myUserID = 0;
        private int result = 0;

        /// <summary>
        /// This method is responsible calling appropriate methods when page loags.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Username"] != null)//checks if user is signed in
                {
                    if (CheckLoggedInUser() == 1)
                    {
                        MessageBox.Show(null, "You have been signed out. Employee cannot access farmer pages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Session["Username"] = null;//reset user session
                        Response.Redirect("~/Login");
                    }
                    else
                    {
                        GetProductType();//calls itemType list
                    }
                }
                else
                {
                    Response.Redirect("~/Login");
                }
            }
        }

        /// <summary>
        /// This method calls all item names from database.
        /// </summary>
        public void GetProductType()
        {
            string getItemQuery = "SELECT ItemType FROM Item";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(getItemQuery, connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string myValue = reader["ItemType"].ToString();

                    ListItem listItem = new ListItem(myValue);

                    itemSelectType.Items.Add(listItem);
                }
                reader.Close();
                connection.Close();
            }
        }

        /// <summary>
        /// This event is triggered when the registerbtn is clicked. It registers a product in the db.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void registerProductbtn_Click(object sender, EventArgs e)
        {
            //input validation for int and decimal.
            Page.Validate("numberValidation");
            Page.Validate("decimalValidation");

            //if valid input
            if (Page.IsValid)
            {
                errorlbl.Text = "";//resets error message

                //sets variables to user entered input from textboxes
                string username = Session["Username"].ToString();
                string itemType = itemSelectType.Value;
                string productName = productNametxt.Text;
                string productQuantity = productQuantitytxt.Text;
                string productCost = productCosttxt.Text;

                //calls CreateUser method from UserControl, takes user details as a parameter
                string createCheck = myFarmer.CreateProduct(username, itemType, productName, productQuantity, productCost);

                //Nested If-statements, reacts based off of output from CreateUser Method
                if (createCheck == "You must enter all fields")
                {
                    errorlbl.Text = createCheck;
                }
                else if (createCheck == "Product Succesfully registered.")
                {
                    errorlbl.Text = createCheck;
                }
            }
            else
            {
                errorlbl.Text = "Fix errors to continue";
            }
        }

        /// <summary>
        /// This method is triggered when the cancelbtn is clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void cancelProductbtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/farmerProduct");
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
//-----------------------------------End of Add Product-------------------------------//