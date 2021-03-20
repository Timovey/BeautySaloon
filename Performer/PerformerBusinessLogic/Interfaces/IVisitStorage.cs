using System.Collections.Generic;
using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.ViewModels;


namespace PerformerBusinessLogic.Interfaces
{
    public interface IVisitStorage
    {
        List<VisitViewModel> GetFullList();
        List<VisitViewModel> GetFilteredList(VisitBindingModel model);
        VisitViewModel GetElement(VisitBindingModel model);
        void Insert(VisitBindingModel model);
        void Update(VisitBindingModel model);
        void Delete(VisitBindingModel model);
    }
}
