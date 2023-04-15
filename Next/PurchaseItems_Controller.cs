﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEduardoAnacletoWindowsForm1.A_To_do
{
    public class PurchaseItems_Controller
    {
        private PurchaseItems _purchaseItems = new PurchaseItems();
        private PurchaseItems_DAO _purchaseItemsDAO = new PurchaseItems_DAO();

        public PurchaseItems_Controller()
        {

        }

        public void SaveItem(PurchaseItems purchaseItems)
        {
            _purchaseItems = purchaseItems;
            _purchaseItemsDAO.SaveToDb(_purchaseItems);
        }
        public List<PurchaseItems> LoadItems()
        {
            return _purchaseItemsDAO.SelectAllFromDb();
        }
        public List<PurchaseItems> FindItemId(int id)
        {
            return _purchaseItemsDAO.SelectFromDb(id);
        }
        public List<PurchaseItems> FindProductId(int id)
        {
            return _purchaseItemsDAO.SelectProductIdFromDb(id);
        }
        public List<PurchaseItems> FindProductName(string name)
        {
            return _purchaseItemsDAO.SelectProductNameFromDb(name);
        }
        public List<PurchaseItems> FindTotalValue(double minValue)
        {
            decimal value = (decimal)minValue;
            return _purchaseItemsDAO.SelectTotalValueFromDb(value);
        }
        public List<PurchaseItems> FindPurchaseId(int id)
        {
            return _purchaseItemsDAO.SelectPurchaseIdFromDb(id);
        }
        public void DeleteItem(int id)
        {
            _purchaseItemsDAO.DeleteFromDb(id);
        }
        public void UpdateItem(PurchaseItems purchaseItems)
        {
            _purchaseItems = purchaseItems;
            string format = "yyyy-MM-dd";
            _purchaseItems.dateOfLastUpdate = DateTime.Parse(DateTime.Now.ToString(format));
            _purchaseItemsDAO.EditFromDB(_purchaseItems);
        }

        public DataTable PopulateDGV() //Cria obj DataTable chama a DAO para trazer a conexao da tabela da DB
        {
            DataTable ds = new DataTable();
            ds = _purchaseItemsDAO.SelectDataSourceFromDB();
            return ds;
        }
    }
}
