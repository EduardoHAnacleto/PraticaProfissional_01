﻿using ProjetoEduardoAnacletoWindowsForm1.Controllers;
using ProjetoEduardoAnacletoWindowsForm1.Forms_Find;
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
    public partial class Frm_Create_BillsToReceive : ProjetoEduardoAnacletoWindowsForm1.InheritForms.Frm_Create_Master
    {
        public Frm_Create_BillsToReceive()
        {
            InitializeComponent();
            edt_clientId.Controls[0].Visible = false;
            edt_instalmentId.Controls[0].Visible = false;
            edt_saleNumber.Controls[0].Visible = false;
            edt_instalmentValue.Controls[0].Visible = false;
            PopulateComboBox();
        }

        private readonly BillsToReceive_Controller _controller = new BillsToReceive_Controller();
        private readonly Clients_Controller _cController = new Clients_Controller();
        private readonly Sales_Controller _salesController = new Sales_Controller();
        private readonly PaymentMethods_Controller _payMethodController = new PaymentMethods_Controller();
        private BillsToReceive _auxObj;

        public BillsToReceive GetBillToReceive()  //Cria um OBJ a partir dos campos
        {
            BillsToReceive bill = new BillsToReceive();
            bill.Client = _cController.FindItemId(Convert.ToInt32(edt_clientId.Value));
            bill.InstalmentValue = Convert.ToDouble(edt_instalmentValue.Value);
            bill.EmissionDate = Convert.ToDateTime(datePicker_emission.Text);
            bill.DueDate = Convert.ToDateTime(datePicker_due.Text);
            bill.dateOfLastUpdate = DateTime.Now;
            return bill;
        }

        public BillsToReceive GetObject()
        {
            var obj = new BillsToReceive();
            obj.Client = _cController.FindItemId(Convert.ToInt32(edt_clientId.Value));
            obj.Sale = _salesController.FindItemId(Convert.ToInt32(edt_saleNumber.Value));
            obj.PaymentMethod = _payMethodController.FindItemName(cbox_paymentMethod.SelectedItem.ToString());
            obj.InstalmentNumber = (int)edt_instalmentId.Value;
            obj.InstalmentValue = (double)edt_instalmentValue.Value;
            obj.EmissionDate = datePicker_emission.Value;
            obj.DueDate = datePicker_due.Value;
            obj.InstalmentsQtd = DGV_Instalments.Rows.Count;

            if (check_Active.Checked)
            {
                obj.PaidDate = null;
                obj.IsPaid = false;
            }
            else
            {
                obj.IsPaid = true;
                obj.PaidDate = datePicker_PaidDate.Value;
            }
            return obj;
        }

        public void PopulateCamps(BillsToReceive obj)
        {
            if (obj.dateOfLastUpdate != null)
            {
                lbl_LastUpdate.Text = obj.dateOfLastUpdate.ToShortTimeString();
                lbl_LastUpdate.Visible = true;
            }
            lbl_Sign_creationDate.Text = obj.dateOfCreation.ToShortTimeString();
            edt_clientId.Value = obj.Client.id;
            edt_clientName.Text = obj.Client.name;
            edt_instalmentId.Value = obj.InstalmentNumber;
            edt_instalmentValue.Value = (decimal)obj.InstalmentValue;
            edt_saleNumber.Value = obj.Sale.id;
            cbox_paymentMethod.SelectedItem = obj.PaymentMethod.paymentMethod;
            datePicker_emission.Value = obj.EmissionDate;
            datePicker_due.Value = obj.DueDate;
            if (obj.IsPaid)
            {
                datePicker_PaidDate.Value = (DateTime)obj.PaidDate;
                check_Active.Checked = false;
                check_Paid.Checked = true;
            }
            else
            {
                check_Active.Checked = true;
                check_Paid.Checked = false;
                lbl_paidDate.Visible = false;
                datePicker_PaidDate.Visible = false;
            }
        }

        public override void LockCamps()
        {
            gbox_client.Enabled = false;
            gbox_billDates.Enabled = false;
            gbox_billInstalment.Enabled = false;
            DGV_Instalments.Enabled = false;
            gbox_isPaid.Enabled = false;
            edt_saleNumber.Enabled = false;
            cbox_paymentMethod.Enabled = false;
        }

        public override void UnlockCamps()
        {
            gbox_client.Enabled = true;
            gbox_billDates.Enabled = true;
            gbox_billInstalment.Enabled = true;
            DGV_Instalments.Enabled = true;
            gbox_isPaid.Enabled = true;
            edt_saleNumber.Enabled = true;
            cbox_paymentMethod.Enabled = true;
        }

        public override void ClearCamps()
        {
            edt_clientId.Value = 0;
            edt_clientName.Text = string.Empty;
            edt_instalmentId.Value = 0;
            edt_instalmentValue.Value = 0;
            edt_saleNumber.Value = 0;
            cbox_paymentMethod.SelectedIndex = 0;
            datePicker_due.Value = datePicker_due.MinDate;
            datePicker_emission.Value = datePicker_emission.MinDate;
            datePicker_PaidDate.Value = datePicker_PaidDate.MinDate;
            check_Active.Checked = false;
            check_Paid.Checked = false;
            DGV_Instalments.Rows.Clear();
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

        public override void DeleteObject() //DeleteObject
        {
            if (CheckCamps())
            {
                LockCamps();
                try
                {
                    int saleId = (int)edt_saleNumber.Value;
                    int iNum = (int)edt_instalmentId.Value;
                    _controller.DeleteItem(saleId, iNum);
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
                cbox_paymentMethod.Items.Add(text);
            }
        }

        public override bool CheckCamps() //Validacao de campos
        {
            if (Utilities.HasOnlyLetters(edt_clientName.Text, "Client name"))
            {
                edt_clientName.Focus();
                return false;
            }
            else if (!Utilities.IsDouble(edt_instalmentValue.Text, "Instalment value"))
            {
                edt_instalmentValue.Focus();
                return false;
            }
            else if ((!check_Active.Checked) && (!check_Paid.Checked))
            {
                string message = "At least one status box must be checked.";
                string caption = "Status not checked.";
                MessageBoxIcon icon = MessageBoxIcon.Error;
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                Utilities.Msgbox(message, caption, buttons, icon);
                gbox_isPaid.Focus();
                return false;
            }
            else if (Utilities.IsNotSelected(cbox_paymentMethod.SelectedItem, "Payment Method"))
            {
                cbox_paymentMethod.Focus();
                return false;
            }
            else if (Utilities.HasOnlySpaces(datePicker_due.Text, "Date Movements"))  //testar
            {
                //gbox_dates.Focus();
                return false;
            }
            else return true;
        }

        private void check_Paid_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Paid.Checked)
            {
                check_Active.Checked = false;
            }
        }

        private void check_Active_CheckedChanged(object sender, EventArgs e)
        {
            if (check_Active.Checked)
            {
                check_Paid.Checked = false;
            }
        }

        public void SearchClient() // Abre Form para encontrar e levar Cliente
        {
            Frm_Find_Clients formClient = new Frm_Find_Clients();
            formClient.hasFather = true;
            formClient.ShowDialog();
            if (!formClient.ActiveControl.ContainsFocus)
            {
                Clients client = new Clients();
                client = formClient.GetObject();
                if (client != null)
                {
                    edt_clientId.Value = client.id;
                    edt_clientName.Text = client.name;
                }
            }
            formClient.Close();
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            SearchClient();
        }
    }
}
