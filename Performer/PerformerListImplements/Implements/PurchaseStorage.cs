using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.Interfaces;
using PerformerBusinessLogic.ViewModels;
using PerformerListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace PerformerListImplements.Implements
{
    public class PurchaseStorage : IPurchaseStorage
    {
        private readonly DataListSingleton source;

        public PurchaseStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<PurchaseViewModel> GetFullList()
        {
            List<PurchaseViewModel> result = new List<PurchaseViewModel>();
            foreach (var purchase in source.Purchases)
            {
                result.Add(CreateModel(purchase));
            }
            return result;
        }
        public List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<PurchaseViewModel> result = new List<PurchaseViewModel>();
            foreach (var purchase in source.Purchases)
            {
                if (purchase.ClientId == model.ClientId)
                {
                    result.Add(CreateModel(purchase));
                }
            }
            return result;
        }
        public PurchaseViewModel GetElement(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var purchase in source.Purchases)
            {
                if (purchase.Id == model.Id || purchase.Date == model.Date)
                {
                    return CreateModel(purchase);
                }
            }
            return null;
        }
        public void Insert(PurchaseBindingModel model)
        {
            Purchase tempPurchase = new Purchase
            {
                Id = 1,
                PurchaseProcedures = new
            Dictionary<int, int>()
            };
            foreach (var purchase in source.Purchases)
            {
                if (purchase.Id >= tempPurchase.Id)
                {
                    tempPurchase.Id = purchase.Id + 1;
                }
            }
            source.Purchases.Add(CreateModel(model, tempPurchase));
        }
        public void Update(PurchaseBindingModel model)
        {
            Purchase tempPurchase = null;
            foreach (var purchase in source.Purchases)
            {
                if (purchase.Id == model.Id)
                {
                    tempPurchase = purchase;
                }
            }
            if (tempPurchase == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempPurchase);
        }
        public void Delete(PurchaseBindingModel model)
        {
            for (int i = 0; i < source.Purchases.Count; ++i)
            {
                if (source.Purchases[i].Id == model.Id)
                {
                    source.Purchases.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Purchase CreateModel(PurchaseBindingModel model, Purchase purchase)
        {
            purchase.Date = model.Date;
            purchase.ClientId = (int)model.ClientId;
            purchase.Price = model.Price;

            // удаляем убранные
            foreach (var key in purchase.PurchaseProcedures.Keys.ToList())
            {
                if (!model.PurchaseProcedures.ContainsKey(key))
                {
                    purchase.PurchaseProcedures.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var procedure in model.PurchaseProcedures)
            {
                if (!purchase.PurchaseProcedures.ContainsKey(procedure.Key))
                {
                    purchase.PurchaseProcedures[procedure.Key] =
                    procedure.Key;
                }
            }
            return purchase;
        }
        private PurchaseViewModel CreateModel(Purchase purchase)
        {
            // требуется дополнительно получить список процедур для посещения 
            Dictionary<int, (string, decimal)> purchaseProcedures = new
            Dictionary<int, (string, decimal)>();

            foreach (var pp in purchase.PurchaseProcedures)
            {
                string procedureName = string.Empty;
                decimal procedurePrice = 0;
                foreach (var procedure in source.Procedures)
                {
                    if (pp.Key == procedure.Id)
                    {
                        procedureName = procedure.ProcedureName;
                        procedurePrice = procedure.Price;
                        break;
                    }
                }
                purchaseProcedures.Add(pp.Key, (procedureName, procedurePrice));
            }
            return new PurchaseViewModel
            {
                Id = purchase.Id,
                Date = purchase.Date,
                Price = purchase.Price,
                ClientId = purchase.ClientId,
                PurchaseProcedures = purchaseProcedures
            };
        }
    }
}
