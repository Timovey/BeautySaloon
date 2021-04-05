using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.Interfaces;
using PerformerBusinessLogic.ViewModels;
using PerformerListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace PerformerListImplements.Implements
{
    public class ProcedureStorage : IProcedureStorage
    {
        private readonly DataListSingleton source;
        public ProcedureStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ProcedureViewModel> GetFullList()
        {
            List<ProcedureViewModel> result = new List<ProcedureViewModel>();
            foreach (var procedure in source.Procedures)
            {
                result.Add(CreateModel(procedure));
            }
            return result;
        }
        public List<ProcedureViewModel> GetFilteredList(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ProcedureViewModel> result = new List<ProcedureViewModel>();
            foreach (var procedure in source.Procedures)
            {
                if (procedure.ClientId == model.ClientId )
                {
                    result.Add(CreateModel(procedure));
                }
            }
            return result;
        }
        public ProcedureViewModel GetElement(ProcedureBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var procedure in source.Procedures)
            {
                if (procedure.Id == model.Id || procedure.ProcedureName ==
               model.ProcedureName)
                {
                    return CreateModel(procedure);
                }
            }
            return null;
        }
        public void Insert(ProcedureBindingModel model)
        {
            Procedure tempProcedure = new Procedure { Id = 1 };
            foreach (var procedure in source.Procedures)
            {
                if (procedure.Id >= tempProcedure.Id)
                {
                    tempProcedure.Id = procedure.Id + 1;
                }
            }
            source.Procedures.Add(CreateModel(model, tempProcedure));
        }
        public void Update(ProcedureBindingModel model)
        {
            Procedure tempProcedure = null;
            foreach (var procedure in source.Procedures)
            {
                if (procedure.Id == model.Id)
                {
                    tempProcedure= procedure;
                }
            }
            if (tempProcedure == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProcedure);
        }
        public void Delete(ProcedureBindingModel model)
        {
            for (int i = 0; i < source.Procedures.Count; ++i)
            {
                if (source.Procedures[i].Id == model.Id.Value)
                {
                    source.Procedures.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Procedure CreateModel(ProcedureBindingModel model, Procedure procedure)
        {
            procedure.ProcedureName = model.ProcedureName;
            procedure.Price = model.Price;
            procedure.Duration = model.Duration;
            procedure.ClientId = (int)model.ClientId;

            return procedure;
        }
        private ProcedureViewModel CreateModel(Procedure procedure)
        {
            return new ProcedureViewModel
            {
                Id = procedure.Id,
                ProcedureName = procedure.ProcedureName,
                Price = procedure.Price,
                Duration = procedure.Duration,
                ClientId = procedure.ClientId
        };
        }
    }
}
