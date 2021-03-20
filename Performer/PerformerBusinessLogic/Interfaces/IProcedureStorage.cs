using System.Collections.Generic;
using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.ViewModels;
namespace PerformerBusinessLogic.Interfaces
{
    public interface IProcedureStorage
    {
        List<ProcedureViewModel> GetFullList();
        List<ProcedureViewModel> GetFilteredList(ProcedureBindingModel model);
        ProcedureViewModel GetElement(ProcedureBindingModel model);
        void Insert(ProcedureBindingModel model);
        void Update(ProcedureBindingModel model);
        void Delete(ProcedureBindingModel model);
    }
}
