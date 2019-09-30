using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShopWithOperation.ItemsRepository
{
    public class ItemRepository
    {
       public bool additems(string name, int price)
        {
            bool isaded = false;
            try
            {
                string connectserver = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlItems = new SqlConnection(connectserver);

                string itemsqurey = @" INSERT INTO  Items(Name,Price) VALUES('" + name + "'," + price + ")";
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

                string sqlvalues = @"select*from  Items where name='" + name + "'";
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
       public DataTable showitems()
        {

            //try
            //{
                string connectserver = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlItems = new SqlConnection(connectserver);

                string itemsqurey = @" select * from Items";
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
        public bool update(string name, int price, int id)
        {
            try
            {
                string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
                SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

                string sqlvalues = @"UPDATE Items SET Name='" + name + "',Price=" + price + " WHERE ID=" + id + "";
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

                string sqlvalues = @"DELETE FROM Items WHERE ID=" + id + "";
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

                string sqlvalues = @"select*from  Items  where name='" + name + "'";
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
