using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopWithOperation.OrderRepository
{
    public class OrdersRepository
    {
        public bool addorder(string name, string item, int quantity,int totalprice)
        {
            bool isaded = false;
            try
            {
                string connectserver = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlItems = new SqlConnection(connectserver);

                string itemsqurey = @" INSERT INTO  Ordercustomer (Name,Item,Quantity,TotalPrice) VALUES('" + name + "','" + item + "'," + quantity + ","+totalprice+")";
                SqlCommand sqlCommand = new SqlCommand(itemsqurey, sqlItems);
                sqlItems.Open();
                int isExcuted = sqlCommand.ExecuteNonQuery();
                if (isExcuted > 0)
                {
                    isaded = true;
                }
                //if (!isexitename(nameItemTextBox.Text))
                //{

                //    int isExcuted = sqlCommand.ExecuteNonQuery();
                //    if (isExcuted > 0)
                //    {
                //        isaded = true;
                //    }

                //}
                //else
                //{
                //    MessageBox.Show(nameItemTextBox.Text + "   already exited  ");

                //}

                sqlItems.Close();
            }
            catch (Exception exception)
            {
                // MessageBox.Show(exception.Message);
            }
            return isaded;
        }
        public bool isexitename(string name)
        {
            bool exites = false;

            try
            {
                string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

                string sqlvalues = @"select*from  Ordercustomer where name='" + name + "'";
                SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

                sqlConnection.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                //int isExcuted = sqlCommand.ExecuteNonQuery();
                DataTable dataTable = new DataTable();

                //showItemDataGridView.DataSource = dataTable;
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows.Count > 0)
                {
                    exites = true;

                }



                sqlConnection.Close();

            }
            catch (Exception obj)
            {
                //MessageBox.Show(obj.Message);
            }

            return exites;
        }
        public DataTable show()
        {

            //try
            //{
            string connectserver = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
            SqlConnection sqlItems = new SqlConnection(connectserver);

            string itemsqurey = @" select * from Ordercustomer";
            SqlCommand sqlCommand = new SqlCommand(itemsqurey, sqlItems);
            sqlItems.Open();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            DataTable dataTable = new DataTable();

            //showItemDataGridView.DataSource = dataTable;
            sqlDataAdapter.Fill(dataTable);


            //if (dataTable.Rows.Count > 0)
            //{

            //   // showItemDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //    MessageBox.Show("not data found");
            //}
            //int isexcuted = sqlCommand.ExecuteNonQuery();
            //if (isexcuted > 0)
            //{
            //    MessageBox.Show("added successfully");

            //}
            //else
            //{
            //    MessageBox.Show("not added data");
            //}


            sqlItems.Close();
            return dataTable;

            //    return dataTable;
            //}

            //catch (Exception exception)
            //{

            //       // MessageBox.Show(exception.Message);
            //}

        }
        public bool update(string name, string item, int quntity, int totalprice,int id)
        {
            try
            {
                string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

                string sqlvalues = @"UPDATE Ordercustomer SET Name='" + name + "',Item='" + item + "',Quantity=" + quntity + ",TotalPrice="+totalprice+" WHERE ID=" + id + "";
                SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
                sqlConnection.Open();

                int isexcuted = sqlCommand.ExecuteNonQuery();
                if (isexcuted > 0)
                {
                    return true;
                }


                sqlConnection.Close();


            }
            catch (Exception obj1)
            {
                //MessageBox.Show(obj1.Message);
            }
            return false;
        }
        public bool delete(int id)

        {
            try
            {
                string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

                string sqlvalues = @"DELETE FROM Ordercustomer WHERE ID=" + id + "";
                SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
                sqlConnection.Open();
                int isexcuted = sqlCommand.ExecuteNonQuery();
                if (isexcuted > 0)
                {
                    return true;
                }

                sqlConnection.Close();

            }
            catch (Exception obj)
            {
                //MessageBox.Show(obj.Message);
            }
            return false;
        }
        public DataTable search(string name)
        {
            //try
            //{
            string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
            SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

            string sqlvalues = @"select*from  Ordercustomer where Name='" + name + "'";
            SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

            sqlConnection.Open();

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
            // int isExcuted = sqlCommand.ExecuteNonQuery();
            DataTable dataTable = new DataTable();
            //showItemDataGridView.DataSource = dataTable;
            sqlDataAdapter.Fill(dataTable);
            //if (dataTable.Rows.Count > 0)
            //{
            //   // showItemDataGridView.DataSource = dataTable;
            //}
            //else
            //{
            //   // MessageBox.Show("no data founded");

            //}

            sqlConnection.Close();
            return dataTable;

            //}
            //catch (Exception obj)
            //{
            //    //MessageBox.Show(obj.Message);
            //}
        }
    }
}
