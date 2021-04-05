using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.Interfaces;
using PerformerBusinessLogic.ViewModels;
using PerformerDatabaseImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace PerformerDatabaseImplements.Implements
{
    public class PurchaseStorage : IPurchaseStorage
    {
        public List<PurchaseViewModel> GetFullList()
        {
            using (var context = new PerformerDatabaseContext())
            {
                return context.Purchases
                    .Include(rec => rec.Client)
                .Include(rec => rec.ProcedurePurchase)
               .ThenInclude(rec => rec.Procedure)
               .ToList()
               .Select(rec => new PurchaseViewModel
               {
                   Id = rec.Id,
                   ClientId = rec.ClientId,
                   Date = rec.Date,
                   PurchaseProcedures = rec.ProcedurePurchase
                .ToDictionary(recPC => recPC.ProcedureId, recPC =>
               (recPC.Procedure?.ProcedureName, recPC.Procedure.Price))
               })
               .ToList();

            }
        }
        public List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new PerformerDatabaseContext())
            {
                return context.Purchases
                    .Include(rec => rec.Client)
                             .Include(rec => rec.ProcedurePurchase)
               .ThenInclude(rec => rec.Procedure)
               .Where(rec => rec.Date == model.Date)
               .ToList()
               .Select(rec => new PurchaseViewModel
               {
                   Id = rec.Id,
                   ClientId = rec.ClientId,
                   Date = rec.Date,
                   PurchaseProcedures = rec.ProcedurePurchase
                .ToDictionary(recPC => recPC.ProcedureId, recPC =>
               (recPC.Procedure?.ProcedureName, recPC.Procedure.Price))
               }).ToList();
            }
        }
        public PurchaseViewModel GetElement(PurchaseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new PerformerDatabaseContext())
            {
                var visit = context.Purchases
                    .Include(rec => rec.Client)
                .Include(rec => rec.ProcedurePurchase)
               .ThenInclude(rec => rec.Procedure)
               .FirstOrDefault(rec => rec.Date == model.Date || rec.Id
               == model.Id);
                return visit != null ?
                 new PurchaseViewModel
                 {
                     Id = visit.Id,
                     ClientId = visit.ClientId,
                     Date = visit.Date,
                     PurchaseProcedures = visit.ProcedurePurchase
                .ToDictionary(recPC => recPC.ProcedureId, recPC =>
               (recPC.Procedure?.ProcedureName, recPC.Procedure.Price))
                 } :
               null;
            }
        }
        public void Insert(PurchaseBindingModel model)
        {

            using (var context = new PerformerDatabaseContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        CreateModel(model, new Purchase(), context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Update(PurchaseBindingModel model)
        {
            using (var context = new PerformerDatabaseContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Purchases.FirstOrDefault(rec => rec.Id ==
                       model.Id);
                        if (element == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        CreateModel(model, element, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }
        public void Delete(PurchaseBindingModel model)
        {
            using (var context = new PerformerDatabaseContext())
            {
                Purchase element = context.Purchases.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Purchases.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Purchase CreateModel(PurchaseBindingModel model, Purchase purchase,
       PerformerDatabaseContext context)
        {
            purchase.Date = model.Date;
            purchase.ClientId = model.ClientId.Value;

            if (model.Id.HasValue)
            {
                var PurchaseComponents = context.ProcedurePurchases.Where(rec =>
               rec.PurchaseId == model.Id.Value).ToList();

                context.ProcedurePurchases.RemoveRange(PurchaseComponents.Where(rec =>
               !model.PurchaseProcedures.ContainsKey(rec.ProcedureId)).ToList());
                context.SaveChanges();

            }
            // добавили новые
            foreach (var pp in model.PurchaseProcedures)
            {
                context.ProcedurePurchases.Add(new ProcedurePurchase
                {
                    PurchaseId = purchase.Id,
                    ProcedureId = pp.Key,
                });
                context.SaveChanges();
            }
            return purchase;
        }
    }
}
