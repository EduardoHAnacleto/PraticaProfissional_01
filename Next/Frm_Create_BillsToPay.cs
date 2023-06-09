﻿using ProjetoEduardoAnacletoWindowsForm1.Controllers;
using ProjetoEduardoAnacletoWindowsForm1.Forms_Find;
using ProjetoEduardoAnacletoWindowsForm1.FormsCreate;
using ProjetoEduardoAnacletoWindowsForm1.Models;
using ProjetoEduardoAnacletoWindowsForm1.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ProjetoEduardoAnacletoWindowsForm1.Next
{
    public partial class Frm_Create_BillsToPay : ProjetoEduardoAnacletoWindowsForm1.InheritForms.Frm_Create_Master
    {
        public Frm_Create_BillsToPay()
        {
            InitializeComponent();
            edt_instalmentNumber.Controls[0].Visible = false;
            edt_supplierId.Controls[0].Visible = false;
            edt_BillPage.Controls[0].Visible = false;
            edt_BillNum.Controls[0].Visible = false;
            edt_BillSeries.Controls[0].Visible = false;
            edt_totalValue.Controls[0].Visible = false;
            PopulateComboBox();
        }

        private BillsToPay _auxObj;
        private BillsToPay_Controller _controller = new BillsToPay_Controller();
        private readonly Suppliers_Controller _supplierController = new Suppliers_Controller();

        public override bool CheckCamps()   //Valida Campos
        {
            if (edt_BillModel.Value <= 0 && edt_BillNum.Value <= 0 && edt_BillSeries.Value <= 0 && edt_BillPage.Value <= 0)
            {
                string message = "DANFe camps must be inserted.";
                string caption = "Invalid camps.";
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                Utilities.Msgbox(message, caption, buttons, icon);
                return false;
            }
            else if (datePicker_due.Value <= datePicker_due.MinDate)
            {
                string message = "Due date must be more selected.";
                string caption = "Invalid camp.";
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                Utilities.Msgbox(message, caption, buttons, icon);
                return false;
            }
            else if (!Utilities.IsNotSelected(cbox_payMethod.SelectedItem, "Payment Method"))
            {
                cbox_payMethod.Focus();
                return false;
            }
            else if (!Utilities.HasOnlyDigits(edt_instalmentNumber.Text, "Instalment Number"))
            {
                edt_instalmentNumber.Focus();
                return false;
            }
            else if (edt_instalmentNumber.Value <= 0)
            {
                string message = "Instalment number must be higher than 0.";
                string caption = "Invalid camp.";
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                Utilities.Msgbox(message, caption, buttons, icon);
                return false;
            }
            else if (edt_totalValue.Value <= 0)
            {
                string message = "Total value must be higher than 0.";
                string caption = "Invalid camp.";
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                Utilities.Msgbox(message, caption, buttons, icon);
                return false;
            }
            else if (!(check_Active.Checked) && !(check_Paid.Checked))
            {
                string message = "Status must be more selected.";
                string caption = "Invalid camp.";
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                Utilities.Msgbox(message, caption, buttons, icon);
                gbox_isPaid.Focus();
                return false;
            }
            return true;
        }

        public void PopulateComboBox()
        {
            ComboBox comboBox = new ComboBox();
            PaymentMethods_Controller pController = new PaymentMethods_Controller();
            DataTable dt = pController.PopulateDGV();
            foreach (DataRow dr in dt.Rows)
            {
                comboBox.Items.Add(dr.ItemArray[1].ToString());
            }
            foreach (string text in comboBox.Items)
            {
                cbox_payMethod.Items.Add(text);
            }
        }

        public BillsToPay GetObject()
        {
            var obj = new BillsToPay();
            obj.Supplier = _supplierController.FindItemId((int)edt_supplierId.Value);

            obj.BillNumber = (int)edt_BillNum.Value;
            obj.BillModel = (int)edt_BillModel.Value;
            obj.BillSeries = (int)edt_BillSeries.Value;
            obj.BillPage = (int)edt_BillPage.Value;

            obj.InstalmentNumber = (int)edt_instalmentNumber.Value;
            obj.TotalValue = (double)edt_totalValue.Value;
            obj.DueDate = datePicker_due.Value;
            if (check_Paid.Checked)
            {
                obj.PaidDate = datePicker_paid.Value;
                obj.IsPaid = true;
            }
            else
            {
                obj.IsPaid = false;
                obj.PaidDate = null;
            }
            return obj;

        }

        public override void LockCamps()
        {
            gbox_supplier.Enabled = false;
            gbox_isPaid.Enabled = false;
            gbox_dates.Enabled = false;
            gbox_danfe.Enabled = false;
            gbox_billInfo.Enabled = false;
            check_Active.Enabled = false;
            check_Paid.Enabled = false;
        }

        public override void UnlockCamps()
        {
            gbox_supplier.Enabled = true;
            gbox_isPaid.Enabled = true;
            gbox_dates.Enabled = true;
            gbox_danfe.Enabled = true;
            gbox_billInfo.Enabled = true;
            check_Active.Enabled = true;
            check_Paid.Enabled = true;
        }

        public override void ClearCamps()
        {
            edt_supplierId.Value = 0;
            edt_supplierName.Text = string.Empty;
            edt_BillModel.Value = 0;
            edt_BillNum.Value = 0;
            edt_BillPage.Value = 0;
            edt_BillSeries.Value = 0;
            edt_instalmentNumber.Value = 0;
            edt_totalValue.Value = 0;
            cbox_payMethod.SelectedIndex = 0;
            datePicker_due.Value = datePicker_due.MinDate;
            datePicker_paid.Value = datePicker_paid.MinDate;
            check_Active.Checked = false;
            check_Paid.Checked = false;
            lbl_CreationDate.Text = DateTime.Now.ToShortDateString();
            lbl_LastUpdate.Visible = false;
        }

        public override void Save()
        {
            if (CheckCamps())
            {
                LockCamps();
                try
                {
                    if (btn_Edit.Text == "E&dit")
                    {                    
                        _controller.SaveItem(this.GetObject());
                        ClearCamps();
                        Populated(false);
                    }
                    else if (btn_Edit.Text == "Cancel")
                    {
                        _controller.UpdateItem(GetObject());
                        btn_Edit.Text = "E&dit";
                        btn_NewSave.Enabled = false;
                        btn_SelectDelete.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        public override void EditObject() //EditObject
        {
            if (btn_Edit.Text == "E&dit")
            {
                UnlockCamps();
                btn_Edit.Text = "Cancel";
                btn_NewSave.Enabled = true;
                btn_SelectDelete.Enabled = true;
                _auxObj = GetObject();
            }
            else if (btn_Edit.Text == "Cancel")
            {
                btn_Edit.Text = "E&dit";
                LockCamps();
                btn_SelectDelete.Enabled = false;
                btn_NewSave.Enabled = false;
                this.PopulateCamps(_auxObj);
            }
        }

        public void PopulateCamps(BillsToPay bill)
        {
            edt_BillModel.Value = bill.BillModel;
            edt_BillNum.Value = bill.BillNumber;
            edt_BillPage.Value = bill.BillPage;
            edt_BillSeries.Value = bill.BillSeries;
            edt_instalmentNumber.Value = bill.InstalmentNumber;
            edt_totalValue.Value = (decimal)bill.TotalValue;
            cbox_payMethod.SelectedItem = bill.PaymentMethod.paymentMethod;
            datePicker_due.Value = bill.DueDate;
            lbl_CreationDate.Text = bill.dateOfCreation.ToShortTimeString();
            if (bill.dateOfLastUpdate != null)
            {
                lbl_LastUpdate.Text = bill.dateOfLastUpdate.ToShortTimeString();
                lbl_LastUpdate.Visible = true;
            }
            if (bill.PaidDate != null)
            {
                datePicker_paid.Value = (DateTime)bill.PaidDate;
            }
            if (bill.IsPaid)
            {
                check_Paid.Checked = true;
            }
            else { check_Paid.Checked = false;}
        }

        public override void DeleteObject() //DeleteObject
        {
            if (CheckCamps())
            {
                LockCamps();
                try
                {
                    int billNum = Convert.ToInt32(edt_BillNum.Value);
                    int billModel = Convert.ToInt32(edt_BillModel.Value);
                    int billSeries = Convert.ToInt32(edt_BillSeries.Value);
                    int billPage = Convert.ToInt32(edt_BillPage.Value);
                    int instalmentNum = Convert.ToInt32(edt_instalmentNumber.Value);

                    _controller.DeleteItem(billNum, billModel, billSeries, billPage, instalmentNum);
                    this.ClearCamps();
                    this.edt_id.Value = this.BringNewId();
                    btn_SelectDelete.Enabled = false;
                    btn_Edit.Enabled = false;
                    btn_Edit.Text = "E&dit";
                    Populated(false);
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            UnlockCamps();
        }


        private void check_Active_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Active.Checked)
            {
                check_Paid.Checked = false;
            }
        }

        private void check_Paid_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Paid.Checked)
            {
                check_Active.Checked = false;
            }
        }

        public void PopulateSupplier(Suppliers supplier)
        {
            edt_supplierId.Value = supplier.id;
            edt_supplierName.Text = supplier.name;
        }

        public void SearchSupplier()
        {
            Suppliers supplier = new Suppliers();
            if (edt_supplierId.Value > 0)
            {
                supplier = _supplierController.FindItemId(Convert.ToInt32(edt_supplierId.Value));      
            }
            else if (!string.IsNullOrWhiteSpace(edt_supplierName.Text))
            {
                supplier = _supplierController.FindItemName(edt_supplierName.Text);
            }
            else if (Utilities.AskToFind())
            {
                Frm_Find_Suppliers formSupplier = new Frm_Find_Suppliers();
                formSupplier.hasFather = true;
                formSupplier.ShowDialog();
                if (!formSupplier.ActiveControl.ContainsFocus)
                {
                    supplier = formSupplier.GetObject();
                }
                formSupplier.Close();
            }
            if (supplier != null)
            {
                PopulateSupplier(supplier);
            }
        }

        private void btn_SearchSupplier_Click(object sender, EventArgs e)
        {
            SearchSupplier();
        }
    }
}
