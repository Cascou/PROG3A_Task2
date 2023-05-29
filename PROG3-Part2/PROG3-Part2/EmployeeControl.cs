//-----------------------------------Start of Employee Control Class-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Security.Cryptography;
using System.Text;

namespace PROG3_Part2
{
    public class EmployeeControl
    {
        //Declaring global variable of database connection string.
        private string conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"].ConnectionString;

        //Creating Global Variables used for the methods
        private int myUserID = 0;
        private int myFarmerID = 0;
        private string myOutput = "";

        /// <summary>
        /// This method is responsible for getting the data of all farmers.
        /// </summary>
        /// <returns></returns>
        public DataTable GetDataTable()
        {
            //query to the database
            string query = "SELECT UserID, Username, Password, FarmerID FROM [dbo].[Users] U JOIN [dbo].[Farmer] F ON U.UserID = F.MyUserID;";

            DataTable myTable = new DataTable();

            using(SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    using(SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(myTable);
                    }
                }
            }
            return myTable;
        }

        public DataTable GetAllFarmerData()
        {
            //query to the database
            string query = "SELECT StockID, ProductID, ItemType, ProductName, Quantity, UnitCost " +
                            "FROM[dbo].[Item] I " +
                            "JOIN[dbo].[Product] P ON I.ItemID = P.MyItemID JOIN[dbo].[Stock] S ON P.ProductID = S.MyProductID ";

            DataTable myTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        adapter.Fill(myTable);
                    }
                }
            }
            return myTable;
        }

        /// <summary>
        /// This method is responsible for filter searching the farmer for a specific farmer between specific dates.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public DataTable SearchFarmer(string username, string fromDate, string toDate)
        {
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

                //query to the database
                string query = "SELECT StockID, ProductID, ItemType, ProductName, Quantity, UnitCost " +
                "FROM[dbo].[Item] I " +
                "JOIN[dbo].[Product] P ON I.ItemID = P.MyItemID JOIN[dbo].[Stock] S ON P.ProductID = S.MyProductID " +
                "WHERE S.MyFarmerID = " + myFarmerID + " AND " +
                "S.DateListed BETWEEN '" + fromDate + "' AND '" + toDate + "'";

                DataTable myTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(myTable);
                        }
                    }
                }
                return myTable;
            }
        }

        /// <summary>
        /// This method is responsible for filter searching the farmer for a specific farmer and specific item type.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="productType"></param>
        /// <returns></returns>
        public DataTable SearchType(string username, string productType)
        {
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

                //query to the database
                string query = "SELECT StockID, ProductID, ItemType, ProductName, Quantity, UnitCost " +
                "FROM[dbo].[Item] I " +
                "JOIN[dbo].[Product] P ON I.ItemID = P.MyItemID JOIN[dbo].[Stock] S ON P.ProductID = S.MyProductID " +
                "WHERE S.MyFarmerID = " + myFarmerID + " AND " +
                "I.ItemType = '" + productType + "'";

                DataTable myTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(myTable);
                        }
                    }
                }
                return myTable;
            }
        }

        /// <summary>
        /// This method is responsible for filter searching the farmer for a specific farmer ,specific item type and specific date range.
        /// </summary>
        /// <param name="username"></param>
        /// <param name="productType"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public DataTable FullSearch(string username, string productType, string fromDate, string toDate)
        {
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

                //query to the database
                string query = "SELECT StockID, ProductID, ItemType, ProductName, Quantity, UnitCost " +
                "FROM[dbo].[Item] I " +
                "JOIN[dbo].[Product] P ON I.ItemID = P.MyItemID JOIN [dbo].[Stock] S ON P.ProductID = S.MyProductID " +
                "WHERE I.ItemType = '" + productType + "' AND " + 
                "S.MyFarmerID = " + myFarmerID + " AND " +
                "S.DateListed BETWEEN '" + fromDate + "' AND '" + toDate + "'";

                DataTable myTable = new DataTable();

                using (SqlConnection connection = new SqlConnection(conString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            adapter.Fill(myTable);
                        }
                    }
                }
                return myTable;
            }
        }

        /// <summary>
        /// This method is responsible for deleting the farmer associated with that userID
        /// </summary>
        /// <param name="id"></param>
        public void DeleteFarmer(string id)
        {
            //must delete the farmer from both the Farmer and User Table.
            string deleteFarmer = "DELETE FROM Farmer WHERE MyUserID =" + id;
            string deleteUser = "DELETE FROM Users WHERE UserID =" + id;

            //Delete entry from the farmer table.
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand(deleteFarmer, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            //Delete entry from the user table.
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand(deleteUser, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// This method is responsible for updating the farmers username
        /// </summary>
        /// <param name="updatedValue"></param>
        /// <param name="id"></param>
        public void UpdateFarmer(string updatedValue, string id)
        {
            string updateQuery = "UPDATE Users SET Username= @UpdatedValue WHERE UserID = @Id";

            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@UpdatedValue", updatedValue);
                    command.Parameters.AddWithValue("@Id", id);

                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Create User Method Header, inserts user details into the database
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cPassword"></param>
        /// <returns></returns>
        public string CreateFarmer(string username, string password, string cPassword)
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

                        var myFarmer = new Farmer
                        {
                            MyUserID = myUserID
                        };

                        context.Farmers.Add(myFarmer);
                        context.SaveChanges();

                        myOutput = "Farmer Succesfully registered. You can log in.";
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
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    myBuilder.Append(hashBytes[i].ToString("x2"));
                }

                return myBuilder.ToString();
            }
        }
    }
}
//-----------------------------------End of Employee Control Class-------------------------------//
