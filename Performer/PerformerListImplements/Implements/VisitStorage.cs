using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.Interfaces;
using PerformerBusinessLogic.ViewModels;
using PerformerListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformerListImplements.Implements
{
    public class VisitStorage : IVisitStorage
    {
        private readonly DataListSingleton source;
        public VisitStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<VisitViewModel> GetFullList()
        {
            List<VisitViewModel> result = new List<VisitViewModel>();
            foreach (var visit in source.Visits)
            {
                result.Add(CreateModel(visit));
            }
            return result;
        }
        public List<VisitViewModel> GetFilteredList(VisitBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<VisitViewModel> result = new List<VisitViewModel>();
            foreach (var visit in source.Visits)
            {
                if (visit.Date.Day == model.Date.Day)
                {
                    result.Add(CreateModel(visit));
                }
            }
            return result;
        }
        public VisitViewModel GetElement(VisitBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var visit in source.Visits)
            {
                if (visit.Id == model.Id || visit.Date == model.Date)
                {
                    return CreateModel(visit);
                }
            }
            return null;
        }
        public void Insert(VisitBindingModel model)
        {
            Visit tempVisit = new Visit
            {
                Id = 1,
                VisitProcedures = new
            Dictionary<int, int>()
            };
            foreach (var visit in source.Visits)
            {
                if (visit.Id >= tempVisit.Id)
                {
                    tempVisit.Id = visit.Id + 1;
                }
            }
            source.Visits.Add(CreateModel(model, tempVisit));
        }
        public void Update(VisitBindingModel model)
        {
            Visit tempVisit = null;
            foreach (var visit in source.Visits)
            {
                if (visit.Id == model.Id)
                {
                    tempVisit = visit;
                }
            }
            if (tempVisit == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempVisit);
        }
        public void Delete(VisitBindingModel model)
        {
            for (int i = 0; i < source.Visits.Count; ++i)
            {
                if (source.Visits[i].Id == model.Id)
                {
                    source.Visits.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Visit CreateModel(VisitBindingModel model, Visit visit)
        {
            visit.Date = model.Date;
            // удаляем убранные
            foreach (var key in visit.VisitProcedures.Keys.ToList())
            {
                if (!model.VisitProcedures.ContainsKey(key))
                {
                    visit.VisitProcedures.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var procedure in model.VisitProcedures)
            {
                if (!visit.VisitProcedures.ContainsKey(procedure.Key))
                {
                    visit.VisitProcedures[procedure.Key] =
                    procedure.Key;
                }
                
            }
            return visit;
        }
        private VisitViewModel CreateModel(Visit visit)
        {
            // требуется дополнительно получить список процедур для посещения 
            Dictionary<int, (string, int)> visitProcedures = new
            Dictionary<int, (string, int)>();

            foreach (var vp in visit.VisitProcedures)
            {
                string procedureName = string.Empty;
                foreach (var procedure in source.Procedures)
                {
                    if (vp.Key == procedure.Id)
                    {
                        procedureName = procedure.ProcedureName;
                        break;
                    }
                }
                visitProcedures.Add(vp.Key, (procedureName, vp.Value));
            }
            return new VisitViewModel
            {
                Id = visit.Id,
                Date = visit.Date
            };
        }
    }
}
