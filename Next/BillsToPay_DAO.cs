﻿using ProjetoEduardoAnacletoWindowsForm1.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjetoEduardoAnacletoWindowsForm1.A_To_do;
using System.Configuration;
using ProjetoEduardoAnacletoWindowsForm1.Controllers;
using System.Drawing.Drawing2D;

namespace ProjetoEduardoAnacletoWindowsForm1.DAO
{
    public class BillsToPay_DAO //TO DO
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        private readonly BillsInstalments_Controller _billsInstalmentsController = new BillsInstalments_Controller();
        private readonly PaymentConditions_Controller _paymentConditionsController = new PaymentConditions_Controller();
        private readonly PaymentMethods_Controller _paymentMethodsController = new PaymentMethods_Controller();
        private readonly Suppliers_Controller _suppliersController = new Suppliers_Controller();

        public bool SaveToDb(BillsToPay obj)
        {
            bool status = false;

            string sql = "INSERT INTO BILLSTOPAY ( BILLNUMBER, BILLSERIES, BILLMODEL, BILLPAGE, INSTALMENTNUMBER, DUEDATE, ISPAID, PAIDDATE," +
                "BILLVALUE, PAYCONDITION_ID, PAYMETHOD_ID, SUPPLIER_ID, DATE_CREATION, DATE_LAST_UPDATE ) "
                         + " VALUES (@BNUMBER, @BSERIES, @BMODEL, @BPAGE, @INUMBER, @DUEDATE, @ISPAID, @PDATE, @BVALUE, @CONDID, @METHODID," +
                         "@SUPPLIERID, @DC, @DU);";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@BNUMBER", obj.BillNumber);
                    command.Parameters.AddWithValue("@BSERIES", obj.BillSeries);
                    command.Parameters.AddWithValue("@BMODEL", obj.BillModel);
                    command.Parameters.AddWithValue("@BPAGE", obj.BillPage);
                    command.Parameters.AddWithValue("@INUMBER", obj.BillInstalment.InstalmentNumber);
                    command.Parameters.AddWithValue("@DUEDATE", obj.DueDate);
                    command.Parameters.AddWithValue("@ISPAID", obj.IsPaid);
                    command.Parameters.AddWithValue("@PDATE", obj.PaidDate);
                    command.Parameters.AddWithValue("@BVALUE", (decimal)obj.TotalValue);
                    command.Parameters.AddWithValue("@CONDID", obj.PayCondition.id);
                    command.Parameters.AddWithValue("@METHODID", obj.PayMethod.id);
                    command.Parameters.AddWithValue("@SUPPLIERID", obj.Supplier.id);
                    command.Parameters.AddWithValue("@DC", obj.dateOfLastUpdate);
                    command.Parameters.AddWithValue("@DU", obj.dateOfLastUpdate);
                    connection.Open();
                    int i = command.ExecuteNonQuery();
                    connection.Close();
                    if (i > 0)
                    {
                        MessageBox.Show("Register added with success!");
                        status = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                    return status;
                }
                finally
                {
                    connection.Close();
                }
                return status;
            }
        }

        public bool EditFromDB(BillsToPay obj)
        {
            bool status = false;

            string sql = "UPDATE BILLSTOPAY SET DUEDATE = @DDATE, ISPAID = @IPAID, PAIDDATE = @PDATE, BILLVALUE = @BVALUE, PAYCONDITION_ID = @CONDID, " +
                "PAYMETHOD_ID = @METHODID, SUPPLIER_ID = @SUPPLIERID, DATE_LAST_UPDATE = @DU " +
                "WHERE BILLNUMBER = @BNUMBER AND BILLSERIES = @BSERIES AND BILLMODEL = @BMODEL AND BILLPAGE = @BPAGE AND INSTALMENTNUMBER = @INUMBER ; ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@DDATE", obj.DueDate);
                    command.Parameters.AddWithValue("@IPAID", obj.IsPaid);
                    command.Parameters.AddWithValue("@PDATE", obj.PaidDate);
                    command.Parameters.AddWithValue("@BVALUE", obj.TotalValue);
                    command.Parameters.AddWithValue("@CONDID", obj.PayCondition.id);
                    command.Parameters.AddWithValue("@METHODID", obj.PayMethod.id);
                    command.Parameters.AddWithValue("@SUPPLIERID", obj.Supplier.id);
                    command.Parameters.AddWithValue("@BNUMBER", obj.BillNumber);
                    command.Parameters.AddWithValue("@BSERIES", obj.BillSeries);

                    command.Parameters.AddWithValue("@BMODEL", obj.BillModel);
                    command.Parameters.AddWithValue("@BPAGE", obj.BillPage);
                    command.Parameters.AddWithValue("@INUMBER", obj.InstalmentNumber);
                    command.Parameters.AddWithValue("@DU", obj.dateOfLastUpdate);
                    connection.Open();
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Register altered with success!");
                        status = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                    return status;
                }
                finally
                {
                    connection.Close();
                }
                return status;
            }
        }

        public bool DeleteFromDb(int billNumber, int billModel, int billSeries, int billPage, int instalmentNumber)
        {
            bool status = false;
            string sql = "DELETE FROM BILLSTOPAY WHERE BILLNUMBER = @BNUM AND BILLMODEL = @BMODEL AND BILLSERIES = @BSERIES AND BILLPAGE = @BPAGE " +
                "AND INSTALMENTNUMBER = @INUM ;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.Parameters.AddWithValue("@BNUM", billNumber);
                    command.Parameters.AddWithValue("@BMODEL", billModel);
                    command.Parameters.AddWithValue("@BSERIES", billSeries);
                    command.Parameters.AddWithValue("@BPAGE", billPage);
                    command.Parameters.AddWithValue("@INUM", instalmentNumber);
                    connection.Open();
                    int i = command.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Register erased with success!");
                        status = true;
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                    return status;
                }
                finally
                {
                    connection.Close();
                }
                return status;
            }
        }

        public BillsToPay SelectFromDb(int billNumber, int billModel, int billSeries, int billPage, int instalmentNumber)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM BILLSTOPAY WHERE BILLNUMBER = @BNUM AND BILLMODEL = @BMODEL AND BILLSERIES = @BSERIES AND BILLPAGE = @BPAGE " +
                        "AND INSTALMENTNUMBER = @INUM ; ";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@BNUM", billNumber);
                        command.Parameters.AddWithValue("BMODEL", billModel);
                        command.Parameters.AddWithValue("BSERIES", billSeries);
                        command.Parameters.AddWithValue("@BPAGE", billPage);
                        command.Parameters.AddWithValue("@INUM", instalmentNumber);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                BillsToPay obj = new BillsToPay()
                                {
                                    BillNumber = billNumber,
                                    BillSeries = billSeries,
                                    BillModel = billModel,
                                    BillPage = billPage,

                                    TotalValue = Convert.ToDouble(reader["BillValue"]),
                                    IsPaid = Convert.ToBoolean(reader["isPaid"]),
                                    PaidDate = Convert.ToDateTime(reader["paidDate"]),
                                    DueDate = Convert.ToDateTime(reader["dueDate"]),
                                    Supplier = _suppliersController.FindItemId(Convert.ToInt32(reader["supplier_id"])),
                                    InstalmentNumber = Convert.ToInt32(reader["instalmentNumber"]),
                                    PayCondition = _paymentConditionsController.FindItemId(Convert.ToInt32(reader["payCondition_id"])),
                                    dateOfCreation = Convert.ToDateTime(reader["date_creation"]),
                                    dateOfLastUpdate = Convert.ToDateTime(reader["date_last_update"]),
                                };
                                obj.PayMethod = obj.PayCondition.BillsInstalments[instalmentNumber].PaymentMethod;
                                obj.BillInstalment = obj.PayCondition.BillsInstalments[instalmentNumber];
                                return obj;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }

        public List<BillsToPay> SelectSupplierFromDb(int supplierId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM BILLSTOPAY WHERE SUPPLIER_ID = @ID ;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ID", supplierId);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                List<BillsToPay> list = new List<BillsToPay>();
                                foreach (BillsToPay item in reader)
                                {
                                    BillsToPay obj = new BillsToPay()
                                    {
                                        BillNumber = Convert.ToInt32(reader["billNumber"]),
                                        BillSeries = Convert.ToInt32(reader["billModel"]),
                                        BillModel = Convert.ToInt32(reader["billSeries"]),
                                        BillPage = Convert.ToInt32(reader["billPage"]),

                                        TotalValue = Convert.ToDouble(reader["BillValue"]),
                                        IsPaid = Convert.ToBoolean(reader["isPaid"]),
                                        PaidDate = Convert.ToDateTime(reader["paidDate"]),
                                        DueDate = Convert.ToDateTime(reader["dueDate"]),
                                        Supplier = _suppliersController.FindItemId(Convert.ToInt32(reader["supplier_id"])),
                                        PayCondition = _paymentConditionsController.FindItemId(Convert.ToInt32(reader["payCondition_id"])),
                                        dateOfCreation = Convert.ToDateTime(reader["date_creation"]),
                                        dateOfLastUpdate = Convert.ToDateTime(reader["date_last_update"]),
                                    };
                                    obj.PayMethod = obj.PayCondition.BillsInstalments[obj.InstalmentNumber].PaymentMethod;
                                    obj.BillInstalment = obj.PayCondition.BillsInstalments[obj.InstalmentNumber];

                                    list.Add(obj);
                                }
                                return list;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }

        public List<BillsToPay> SelectAllFromDb()
        {
            string sql = "SELECT * FROM BILLSTOPAY ;";
            List<BillsToPay> bill = null;
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (reader.HasRows)
                    {
                        bill = new List<BillsToPay>();
                        foreach (BillsToPay item in reader)
                        {
                            bill.Add(item);
                        }
                    }
                    else
                    {
                        bill = null;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return bill;
        }

        public List<BillsToPay> SelectisPaidFromDb(bool isPaid)
        {

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT * FROM BILLSTOPAY WHERE IS_PAID = @ISPAID ;";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@ISPAID", isPaid);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                List<BillsToPay> list = new List<BillsToPay>();
                                foreach (BillsToPay item in reader)
                                {
                                    BillsToPay obj = new BillsToPay()
                                    {
                                        BillNumber = Convert.ToInt32(reader["billNumber"]),
                                        BillSeries = Convert.ToInt32(reader["billModel"]),
                                        BillModel = Convert.ToInt32(reader["billSeries"]),
                                        BillPage = Convert.ToInt32(reader["billPage"]),

                                        TotalValue = Convert.ToDouble(reader["BillValue"]),
                                        IsPaid = Convert.ToBoolean(reader["isPaid"]),
                                        PaidDate = Convert.ToDateTime(reader["paidDate"]),
                                        DueDate = Convert.ToDateTime(reader["dueDate"]),
                                        Supplier = _suppliersController.FindItemId(Convert.ToInt32(reader["supplier_id"])),
                                        PayCondition = _paymentConditionsController.FindItemId(Convert.ToInt32(reader["payCondition_id"])),
                                        dateOfCreation = Convert.ToDateTime(reader["date_creation"]),
                                        dateOfLastUpdate = Convert.ToDateTime(reader["date_last_update"]),
                                    };
                                    obj.PayMethod = obj.PayCondition.BillsInstalments[obj.InstalmentNumber].PaymentMethod;
                                    obj.BillInstalment = obj.PayCondition.BillsInstalments[obj.InstalmentNumber];

                                    list.Add(obj);
                                }
                                return list;
                            }
                        }
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error : " + ex.Message);
                }
                finally
                {
                    connection.Close();
                }
            }
            return null;
        }

        public DataTable SelectDataSourceFromDB()
        {
            string sql = "SELECT * FROM BILLSTOPAY ;";
            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sql, connectionString);
                sqlDataAdapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message);
            }
            finally
            {
                con.Close();
            }
            return dt;
        }
    }
}
