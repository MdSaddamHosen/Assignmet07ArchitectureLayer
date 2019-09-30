﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CoffeeShopWithOperation.OrderBLL;

namespace CoffeeShopWithOperation
{
    public partial class OrderUi : Form
    {
        OrderManager _orderManager = new OrderManager();
        public OrderUi()
        {
            InitializeComponent();
        }

        private void addOfOrderButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_orderManager.isexitename(nameOfOrderTextBox.Text))

                {
                    MessageBox.Show(nameOfOrderTextBox.Text + "   already exited  ");
                    return;
                }

                if (string.IsNullOrEmpty(itemOfOrderTextBox.Text))

                {
                    MessageBox.Show("item can not be emtry");
                    return;
                }

                bool isadded = _orderManager.addorder(nameOfOrderTextBox.Text, itemOfOrderTextBox.Text, Convert.ToInt32(quantityOfOrderTextBox4.Text), Convert.ToInt32(totalPriceOfOrderTextBox.Text));
                if (isadded)
                {
                    MessageBox.Show("save");
                }
                else
                {
                    MessageBox.Show("not save");
                }
                // showItemDataGridView.DataSource = DataTable;
                showOrderDataGridView.DataSource = _orderManager.show();

            }

            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }

        }


        //private void addorder()
        //{
        //    try
        //    {
        //        string connectserver = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlItems = new SqlConnection(connectserver);

        //        string itemsqurey = @" INSERT INTO  Ordercustomer (Name,Item,Quantity,TotalPrice) VALUES('" + nameOfOrderTextBox.Text + "','" + itemOfOrderTextBox.Text + "'," + quantityOfOrderTextBox4.Text + "," + totalPriceOfOrderTextBox.Text + ")";
        //        SqlCommand sqlCommand = new SqlCommand(itemsqurey, sqlItems);
        //        sqlItems.Open();
        //        if (!isexitename(nameOfOrderTextBox.Text))
        //        {

        //            int isExcuted = sqlCommand.ExecuteNonQuery();
        //            if (isExcuted > 0)
        //            {
        //                MessageBox.Show("successfully Data added");
        //            }
        //            else
        //            {
        //                MessageBox.Show("not added data");
        //            }
        //        }
        //        else
        //        {
        //            MessageBox.Show(nameOfOrderTextBox.Text + "   already exited  ");

        //        }

        //        sqlItems.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}


        private void searchOfOrderButton_Click(object sender, EventArgs e)
        {
            showOrderDataGridView.DataSource = _orderManager.search(nameOfOrderTextBox.Text);
        }
        //private void search()
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"select*from  Ordercustomer where name='" + nameOfOrderTextBox.Text + "'";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();

        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showOrderDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            showOrderDataGridView.DataSource = dataTable;
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

        //        string sqlvalues = @"select*from Ordercustomer where name='" + name + "'";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showOrderDataGridView.DataSource = dataTable;
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

        private void showOfOrderButton_Click(object sender, EventArgs e)
        {
            showOrderDataGridView.DataSource = _orderManager.show();

        }
        //private void show()
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"select * from Ordercustomer";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showOrderDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            showOrderDataGridView.DataSource = dataTable;
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

        private void updateOfOrderButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idOfOrderTextBox.Text))
            {
                MessageBox.Show("id cannot empty....");
                return;

            }

            if (_orderManager.update(nameOfOrderTextBox.Text, itemOfOrderTextBox.Text, Convert.ToInt32(quantityOfOrderTextBox4.Text), Convert.ToInt32(totalPriceOfOrderTextBox.Text), Convert.ToInt32(idOfOrderTextBox.Text)))
            {
                MessageBox.Show("update successfully");
            }
            else
            {
                MessageBox.Show("not update");
            }

            // showItemDataGridView.DataSource = DataTable;
            showOrderDataGridView.DataSource = _orderManager.show();


        }
        //  private void update()
        //  {
        //      try
        //      {
        //          string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //          SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //          string sqlvalues = @"UPDATE Ordercustomer SET Name='" + nameOfOrderTextBox.Text + "',Item='" + itemOfOrderTextBox.Text + "',Quantity="+quantityOfOrderTextBox4.Text+",TotalPrice="+totalPriceOfOrderTextBox.Text+" WHERE ID=" + idOfOrderTextBox.Text + "";
        //          SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
        //          sqlConnection.Open();

        //          int isexcuted = sqlCommand.ExecuteNonQuery();
        //          if (isexcuted > 0)
        //          {
        //              MessageBox.Show("successfully Data update");
        //          }
        //          else
        //          {
        //              MessageBox.Show("not updated data");
        //          }

        //          sqlConnection.Close();


        //      }
        //      catch (Exception obj1)
        //      {
        //          MessageBox.Show(obj1.Message);
        //      }
        //} 

        private void deleteOfOrderButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idOfOrderTextBox.Text))
            {
                MessageBox.Show("id cannot empty....");
                return;

            }

            if (_orderManager.delete(Convert.ToInt32(idOfOrderTextBox.Text)))
            {
                MessageBox.Show("delete successfully");
            }
            else
            {
                MessageBox.Show("not delete");
            }
            // showItemDataGridView.DataSource = DataTable;
            showOrderDataGridView.DataSource = _orderManager.show();
        }
        //private void delete()
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"DELETE FROM Ordercustomer WHERE ID=" + idOfOrderTextBox.Text + "";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
        //        sqlConnection.Open();
        //        int isexcuted = sqlCommand.ExecuteNonQuery();
        //        if (isexcuted > 0)
        //        {
        //            MessageBox.Show("successfully Data delete");
        //        }
        //        else
        //        {
        //            MessageBox.Show("not delete data");
        //        }
        //        sqlConnection.Close();

        //    }
        //    catch (Exception obj)
        //    {
        //        MessageBox.Show(obj.Message);
        //    }
        //}
    }
}
