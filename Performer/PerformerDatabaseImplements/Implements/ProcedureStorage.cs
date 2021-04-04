using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.Interfaces;
using PerformerBusinessLogic.ViewModels;
using PerformerDatabaseImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformerDatabaseImplements.Implements
{
    public class ProcedureStorage : IProcedureStorage
    {
        public List<ProcedureViewModel> GetFullList()
        {
            using (var context = new PerformerDatabaseContext())
            {
                return context.Procedures
                .Select(rec => new ProcedureViewModel
                {
                    Id = rec.Id,
                    Duration = rec.Duration,
                    Price = rec.Price,
                    ProcedureName = rec.ProcedureName,
                    ClientId = context.Clients.FirstOrDefault(rec => )
                })
.ToList();
            }
        }
        public List<ProcedureViewModel> GetFilteredList(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new PerformerDatabaseContext())
            {
                return context.Procedures
                .Where(rec => rec.ProcedureName.Contains(model.ProcedureName))
               .Select(rec => new ProcedureViewModel
               {
                   Id = rec.Id,
                   Duration = rec.Duration,
                   Price = rec.Price,
                   ProcedureName = rec.ProcedureName
               })
                .ToList();
            }
        }
        public ProcedureViewModel GetElement(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new PerformerDatabaseContext())
            {
                var procedure = context.Procedures
                .FirstOrDefault(rec => rec.ProcedureName == model.ProcedureName ||
               rec.Id == model.Id);
                return procedure != null ?
                new ProcedureViewModel
                {
                    Id = procedure.Id,
                    Duration = procedure.Duration,
                    Price = procedure.Price,
                    ProcedureName = procedure.ProcedureName
                } :
               null;
            }
        }
        public void Insert(ProcedureBindingModel model)
        {
            using (var context = new PerformerDatabaseContext())
            {
                context.Procedures.Add(CreateModel(model, new Procedure()));
                context.SaveChanges();
            }
        }
        public void Update(ProcedureBindingModel model)
        {
            using (var context = new PerformerDatabaseContext())
            {
                var element = context.Procedures.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }
        public void Delete(ProcedureBindingModel model)
        {
            using (var context = new PerformerDatabaseContext())
            {
                Procedure element = context.Procedures.FirstOrDefault(rec => rec.Id ==
               model.Id);
                if (element != null)
                {
                    context.Procedures.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }
        private Procedure CreateModel(ProcedureBindingModel model, Procedure procedure)
        {
            procedure.ProcedureName = model.ProcedureName;
            procedure.Price = model.Price;
            procedure.Duration = model.Duration;
            return procedure;
        }
    }
}
