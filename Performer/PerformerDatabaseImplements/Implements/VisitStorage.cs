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
    public class VisitStorage : IVisitStorage
    {
        public List<VisitViewModel> GetFullList()
        {
            using (var context = new PerformerDatabaseContext())
            {
                return context.Visits
               .ToList()
               .Select(rec => new VisitViewModel
               {
                   Id = rec.Id,
                   Date = rec.Date,
                   ClientId = rec.Client.Id,
                   VisitProcedures = rec.Procedures
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
               })
               .ToList();
            }
        }
        public List<VisitViewModel> GetFilteredList(VisitBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new PerformerDatabaseContext())
            {
                return context.Visits
                .Include(rec => rec.VisitComponents)
               .ThenInclude(rec => rec.Component)
               .Where(rec => rec.VisitName.Contains(model.VisitName))
               .ToList()
               .Select(rec => new VisitViewModel
               {
                   Id = rec.Id,
                   VisitName = rec.VisitName,
                   Price = rec.Price,
                   VisitComponents = rec.VisitComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
                (recPC.Component?.ComponentName, recPC.Count))
               })
.ToList();
            }
        }
        public VisitViewModel GetElement(VisitBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new PerformerDatabaseContext())
            {
                var Visit = context.Visits
                .Include(rec => rec.VisitComponents)
               .ThenInclude(rec => rec.Component)
               .FirstOrDefault(rec => rec.VisitName == model.VisitName || rec.Id
               == model.Id);
                return Visit != null ?
                new VisitViewModel
                {
                    Id = Visit.Id,
                    VisitName = Visit.VisitName,
                    Price = Visit.Price,
                    VisitComponents = Visit.VisitComponents
                .ToDictionary(recPC => recPC.ComponentId, recPC =>
               (recPC.Component?.ComponentName, recPC.Count))
                } :
               null;
            }
        }
        public void Insert(VisitBindingModel model)
        {

            using (var context = new PerformerDatabaseContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var man = CreateModel(model, new Visit());
                        context.Visits.Add(man);
                        context.SaveChanges();
                        man = CreateModel(model, man, context);
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
        public void Update(VisitBindingModel model)
        {
            using (var context = new PerformerDatabaseContext())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var element = context.Visits.FirstOrDefault(rec => rec.Id ==
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
        public void Delete(VisitBindingModel model)
        {
            using (var context = new PerformerDatabaseContext())
            {
                Visit element = context.Visits.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Visits.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Visit CreateModel(VisitBindingModel model, Visit visit)
        {
            visit.Date = model.Date;
            return visit;
        }

        private Visit CreateModel(VisitBindingModel model, Visit visit,
       PerformerDatabaseContext context)
        {
            visit.Date = model.Date;
            if (model.Id.HasValue)
            {
                var VisitComponents = context.VisitComponents.Where(rec =>
               rec.VisitId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.VisitComponents.RemoveRange(VisitComponents.Where(rec =>
               !model.VisitComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in VisitComponents)
                {
                    updateComponent.Count =
                   model.VisitComponents[updateComponent.ComponentId].Item2;
                    model.VisitComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var pc in model.VisitComponents)
            {
                context.VisitComponents.Add(new VisitComponent
                {
                    VisitId = Visit.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });
                context.SaveChanges();
            }
            return Visit;
        }
    }
}
