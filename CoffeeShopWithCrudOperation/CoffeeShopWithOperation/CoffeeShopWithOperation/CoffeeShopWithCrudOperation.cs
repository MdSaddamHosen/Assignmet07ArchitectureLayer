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
using CoffeeShopWithOperation.CustomerBLL;

namespace CoffeeShopWithOperation
{
    public partial class CoffeeShopWithCrudOperation : Form
    {
        CustoemerManager _CustoemerManager = new CustoemerManager();
        public CoffeeShopWithCrudOperation()
        {
            InitializeComponent();
        }

         

        private void addCustomerButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (_CustoemerManager.isexitename(nameCustomerTextBox.Text))

                {
                    MessageBox.Show(nameCustomerTextBox.Text + "   already exited  ");
                    return;
                }

                if (string.IsNullOrEmpty(addressCustomerTextBox.Text))

                {
                    MessageBox.Show("address can not be emtry");
                    return;
                }

                bool isadded = _CustoemerManager.addcustomer(nameCustomerTextBox.Text,addressCustomerTextBox.Text, Convert.ToInt32(contractCustomerTextBox.Text));
                if (isadded)
                {
                    MessageBox.Show("save");
                }
                else
                {
                    MessageBox.Show("not save");
                }
                // showItemDataGridView.DataSource = DataTable;
                showCustomerDataGridView.DataSource = _CustoemerManager.show();

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

        //        string itemsqurey = @" INSERT INTO  Customer (Name,Address,Contract) VALUES('" + nameCustomerTextBox.Text + "','" + addressCustomerTextBox.Text + "',"+contractCustomerTextBox.Text+")";
        //        SqlCommand sqlCommand = new SqlCommand(itemsqurey, sqlItems);
        //        sqlItems.Open();
        //        if (!isexitename(nameCustomerTextBox.Text))
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
        //            MessageBox.Show(nameCustomerTextBox.Text + "   already exited  ");

        //        }

        //        sqlItems.Close();
        //    }
        //    catch (Exception exception)
        //    {
        //        MessageBox.Show(exception.Message);
        //    }
        //}
        private void showCustomerButton_Click(object sender, EventArgs e)
        {
            showCustomerDataGridView.DataSource = _CustoemerManager.show();

        }
        //private void show()
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"select * from Customer";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showCustomerDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            showCustomerDataGridView.DataSource = dataTable;
        //        }
        //        else
        //        {
        //            MessageBox.Show("no data founded");
        //        }

        //        sqlConnection.Close();

        //    }
        //    catch(Exception obj)
        //    {
        //        MessageBox.Show(obj.Message);
        //    }
        //}

        private void deleteCustomerButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idCustomerTextBox.Text))
            {
                MessageBox.Show("id cannot empty....");
                return;

            }

            if (_CustoemerManager.delete(Convert.ToInt32(idCustomerTextBox.Text)))
            {
                MessageBox.Show("delete successfully");
            }
            else
            {
                MessageBox.Show("not delete");
            }
            // showItemDataGridView.DataSource = DataTable;
            showCustomerDataGridView.DataSource = _CustoemerManager.show();
        }
        //private void delete()
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"DELETE FROM Customer WHERE ID=" + idCustomerTextBox.Text + "";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
        //        sqlConnection.Open();
        //        int isexcuted=sqlCommand.ExecuteNonQuery();
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
        //    catch(Exception obj)
        //    {
        //        MessageBox.Show(obj.Message);
        //    }
        //}

        private void updaCustomerButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idCustomerTextBox.Text))
            {
                MessageBox.Show("id cannot empty....");
                return;

            }

            if (_CustoemerManager.update(nameCustomerTextBox.Text,addressCustomerTextBox.Text, Convert.ToInt32(contractCustomerTextBox.Text), Convert.ToInt32(idCustomerTextBox.Text)))
            {
                MessageBox.Show("update successfully");
            }
            else
            {
                MessageBox.Show("not update");
            }

            // showItemDataGridView.DataSource = DataTable;
            showCustomerDataGridView.DataSource = _CustoemerManager.show();


        }
        //private void update()
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"UPDATE Customer SET Name='" + nameCustomerTextBox.Text + "',Address='" + addressCustomerTextBox.Text + "',Contract=" + contractCustomerTextBox.Text + " WHERE ID=" + idCustomerTextBox.Text + "";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);
        //        sqlConnection.Open();

        //        int isexcuted = sqlCommand.ExecuteNonQuery();
        //        if (isexcuted > 0)
        //        {
        //            MessageBox.Show("successfully Data update");
        //        }
        //        else
        //        {
        //            MessageBox.Show("not updated data");
        //        }
        //        sqlConnection.Close();


        //    }
        //    catch(Exception obj1)
        //    {
        //        MessageBox.Show(obj1.Message);
        //    }
        //}

        private void searchCustomerButton_Click(object sender, EventArgs e)
        {
            showCustomerDataGridView.DataSource = _CustoemerManager.search(nameCustomerTextBox.Text);
        }
        //private void search()
        //{
        //    try
        //    {
        //        string sqlserverconnection = @"Server=DESKTOP-Q5FQUO6;Database=CoffeeShop;Integrated Security=True";
        //        SqlConnection sqlConnection = new SqlConnection(sqlserverconnection);

        //        string sqlvalues = @"select*from Customer where name='"+nameCustomerTextBox.Text+"'";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();
               
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showCustomerDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //            showCustomerDataGridView.DataSource = dataTable;
        //        }
        //        else
        //        {
        //            MessageBox.Show("no data founded");

        //        }

        //        sqlConnection.Close();

        //    }
        //    catch(Exception obj)
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

        //        string sqlvalues = @"select*from Customer where name='" + name + "'";
        //        SqlCommand sqlCommand = new SqlCommand(sqlvalues, sqlConnection);

        //        sqlConnection.Open();
        //        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
        //        int isExcuted = sqlCommand.ExecuteNonQuery();
        //        DataTable dataTable = new DataTable();
        //        showCustomerDataGridView.DataSource = dataTable;
        //        sqlDataAdapter.Fill(dataTable);
        //        if (dataTable.Rows.Count > 0)
        //        {
        //          exites= true; 

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

