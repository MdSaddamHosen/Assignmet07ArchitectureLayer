using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopWithOperation.ItemsBLL;

namespace CoffeeShopWithOperation
{
    public partial class ItemUi : Form
    {
        ItemManager _ItemManager = new ItemManager();
        public ItemUi()
        {
            InitializeComponent();
        }

        private void addItemButton_Click(object sender, EventArgs e)

        {
    try
    {     
                if (_ItemManager. isexitename(nameItemTextBox.Text))

                {
                    MessageBox.Show(nameItemTextBox.Text + "   already exited  ");
                    return;
                }

                if (string.IsNullOrEmpty(priceItemTextBox.Text))
            
            {
                MessageBox.Show("price can not be emtry");
                    return;
            }
                
                bool isadded = _ItemManager. additems(nameItemTextBox.Text, Convert.ToInt32(priceItemTextBox.Text));
                if (isadded)
                {
                    MessageBox.Show("save");
                }
                else
                {
                    MessageBox.Show("not save");
                }
                // showItemDataGridView.DataSource = DataTable;
                showItemDataGridView.DataSource = _ItemManager.showitems();

            }

            catch(Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
  
        }
        //private bool additems(string name,int price)
        //{
        //    bool isaded = false;
        //    try
        //    {
        //        string connectserver = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlItems = new SqlConnection(connectserver);

        //        string itemsqurey = @" INSERT INTO  Items(Name,Price) VALUES('" + name + "'," + price+ ")";
        //        SqlCommand sqlCommand = new SqlCommand(itemsqurey, sqlItems);
        //        sqlItems.Open();
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        if (isExcuted > 0)
        //        {
        //            isaded = true;
        //        }
        //        //if (!isexitename(nameItemTextBox.Text))
        //        //{

        //        //    int isExcuted = sqlCommand.ExecuteNonQuery();
        //        //    if (isExcuted > 0)
        //        //    {
        //        //        isaded = true;
        //        //    }
                     
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show(nameItemTextBox.Text + "   already exited  ");

        //        //}

        //        sqlItems.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //    return isaded;
        //}

        private void showItemButton_Click(object sender, EventArgs e)
        {
            // showItemDataGridView.DataSource = DataTable;
            showItemDataGridView.DataSource = _ItemManager.showitems();

        }
        //private void showitems()
        //{
        //    try
        //    {
        //        string connectserver = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlItems = new SqlConnection(connectserver);

        //        string itemsqurey = @" select * from Items";
        //        SqlCommand sqlCommand = new SqlCommand(itemsqurey, sqlItems);
        //        sqlItems.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        DataTable dataTable = new DataTable();
        //        showItemDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            showItemDataGridView.DataSource = dataTable;
        //        }
        //        else
        //        {
        //            MessageBox.Show("not data found");
        //        }
        //        //int isexcuted = sqlCommand.ExecuteNonQuery();
        //        //if (isexcuted > 0)
        //        //{
        //        //    MessageBox.Show("added successfully");

        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("not added data");
        //        //}


        //        sqlItems.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}

        private void updateItemButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idItemTextBox.Text))
            {
                MessageBox.Show("id cannot empty....");
                return;

            }

            if (_ItemManager.update(nameItemTextBox.Text,Convert.ToInt32(priceItemTextBox.Text),Convert.ToInt32(idItemTextBox.Text)))
            {
                MessageBox.Show("update successfully");
            }
            else
            {
                MessageBox.Show("not update");
            }
            
            // showItemDataGridView.DataSource = DataTable;
            showItemDataGridView.DataSource = _ItemManager.showitems();


        }
        //private bool update(string name,int price,int id)
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"UPDATE Items SET Name='" + name + "',Price="+ price + " WHERE ID=" + id + "";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
        //        sqlConnection.Open();

        //        int isexcuted = sqlCommand.ExecuteNonQuery();
        //        if (isexcuted > 0)
        //        {
        //            return true;
        //        }
                

        //        sqlConnection.Close();


        //    }
        //    catch (Exception obj1)
        //    {
        //        MessageBox.Show(obj1.Message);
        //    }
        //    return false;
        //}

        private void deleteItemButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idItemTextBox.Text))
            {
                MessageBox.Show("id cannot empty....");
                return;
 
            }

            if (_ItemManager.delete(Convert.ToInt32(idItemTextBox.Text)))
            {
                MessageBox.Show("delete successfully");
            }
            else
            {
                MessageBox.Show("not delete");
            }
            // showItemDataGridView.DataSource = DataTable;
                showItemDataGridView.DataSource = _ItemManager.showitems();
        }
       //private bool delete (int id )

       // {
       //     try
       //     {
       //         string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
       //         SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

       //         string sqlvalues = @"DELETE FROM Items WHERE ID=" + id + "";
       //         SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
       //         sqlConnection.Open();
       //         int isexcuted = sqlCommand.ExecuteNonQuery();
       //         if (isexcuted > 0)
       //         {
       //             return true;  
       //         }
                 
       //         sqlConnection.Close();

       //     }
       //     catch (Exception obj)
       //     {
       //         MessageBox.Show(obj.Message);
       //     }
       //     return false;
       // }

        private void searchItemButton_Click(object sender, EventArgs e)
        {
            showItemDataGridView.DataSource = _ItemManager.search( nameItemTextBox.Text);

        }
        //private void search(string name)
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"select*from  Items  where name='" + name + "'";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();

        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showItemDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            showItemDataGridView.DataSource = dataTable;
        //        }
        //        else
        //        {
        //            MessageBox.Show("no data founded");

        //        }

        //        sqlConnection.Close();

        //    }
        //    catch (Exception obj)
        //    {
        //        MessageBox.Show(obj.Message);
        //    }
        //}
        //private bool isexitename(string name)
        //{
        //    bool exites = false;

        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"select*from  Items where name='" + name + "'";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showItemDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            exites = true;

        //        }



        //        sqlConnection.Close();

        //    }
        //    catch (Exception obj)
        //    {
        //        MessageBox.Show(obj.Message);
        //    }

        //    return exites;
        //}
    }
    }

