//-----------------------------------Start of Farmer Control Class-------------------------------//
//Importing Libraries
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace PROG3_Part2
{
    public class FarmerControl
    {
        //Declaring global variable of database connection string.
        private string conString = System.Configuration.ConfigurationManager.ConnectionStrings["DBConString"].ConnectionString;

        //Creating Global Variables used for the methods
        private int myUserID = 0;
        private int myFarmerID = 0;
        private int myItemID = 0;
        private int myProductID = 0;
        private DateTime currentDate = DateTime.Now.Date;
        private string myOutput = "";

        /// <summary>
        /// This method is responsible for filling table with farmer products.
        /// </summary>
        /// <param name="farmerID"></param>
        /// <returns></returns>
        public DataTable GetDataTable(int farmerID)
        {
            //query to the database
            string query = "SELECT StockId, ProductID, ItemType, ProductName, Quantity, UnitCost, CAST(S.DateListed AS DATE) AS ListedDate FROM [dbo].[Item] I " +
                            "JOIN[dbo].[Product] P ON I.ItemID = P.MyItemID JOIN[dbo].[Stock] S ON P.ProductID = S.MyProductID" +
                            " WHERE S.MyFarmerID = " + farmerID + ";";

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
        /// This method is responsible for adding product to database table
        /// </summary>
        /// <param name="username"></param>
        /// <param name="itemType"></param>
        /// <param name="productName"></param>
        /// <param name="productQuantity"></param>
        /// <param name="productCost"></param>
        /// <returns></returns>
        public string CreateProduct(string username, string itemType, string productName, string productQuantity, string productCost)
        {

            //Nested if-statement for input validation
            if (itemType == "" || productName == "" || productQuantity == "" || productCost == "")
            {
                myOutput = "You must enter all fields";
            }
            else
            {
                using (var context = new FarmCentralEntities())
                {
                    //gets userID
                    var findUserID = context.Users.Where(a => a.Username.Equals(username)).Select(a => new { a.UserID });

                    foreach (var user in findUserID)
                    {
                        myUserID = user.UserID;//sets record of userID to myUserID variable
                    }

                    //gets farmerID
                    var findFarmerID = context.Farmers.Where(a => a.MyUserID.Equals(myUserID)).Select(a => new { a.FarmerID });

                    foreach (var user in findFarmerID)
                    {
                        myFarmerID = user.FarmerID;//sets record of farmerID to myFarmerID variable
                    }

                    //get ItemID
                    var findItemID = context.Items.Where(a => a.ItemType.Equals(itemType)).Select(a => new { a.ItemID });

                    foreach (var item in findItemID)
                    {
                        myItemID = item.ItemID;//sets record of itemID to myItemID variable
                    }

                    //change fullstop, to comma for syntex purposes.
                    string replacedNumber = productCost.Replace(".", ",");
                    decimal decimalProductCost = Convert.ToDecimal(replacedNumber);

                    var myProduct = new Product
                    {
                        MyItemID = myItemID,
                        ProductName = productName,
                        Quantity = productQuantity,
                        UnitCost = decimalProductCost
                    };

                    context.Products.Add(myProduct);//adds to products table
                    context.SaveChanges();

                    //gets productID
                    var productID = context.Products.Where(a => a.ProductName.Equals(productName) && a.Quantity.Equals(productQuantity)).Select(a => new { a.ProductID });//returns userID with correct details

                    foreach (var product in productID)
                    {
                        myProductID = product.ProductID;//sets record of productID to myProductID variable
                    }

                    var myStock = new Stock//adds to stock table.
                    {
                        MyFarmerID = myFarmerID,
                        MyProductID = myProductID,
                        DateListed = currentDate
                    };

                    context.Stocks.Add(myStock);
                    context.SaveChanges();

                    myOutput = "Product Succesfully registered.";
                }
            }
            return myOutput;
        }

        /// <summary>
        /// This method is responsible for delete farmer added product
        /// </summary>
        /// <param name="id"></param>
        public void DeleteProduct(string id)
        {
            //must delete the product from both the Stock and Product Table.
            string deleteStock = "DELETE FROM Stock WHERE myProductID =" + id;
            string deleteProduct = "DELETE FROM Product WHERE ProductID=" + id;

            //Delete entry from the Stock table.
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand(deleteStock, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
            //Delete entry from the Product table.
            using (SqlConnection connection = new SqlConnection(conString))
            {
                using (SqlCommand command = new SqlCommand(deleteProduct, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
//-----------------------------------End of FarmerControl-------------------------------//
