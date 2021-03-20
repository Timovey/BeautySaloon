using System.Collections.Generic;
using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.ViewModels;

namespace PerformerBusinessLogic.Interfaces
{
    public interface IPurchaseStorage
    {
        List<PurchaseViewModel> GetFullList();
        List<PurchaseViewModel> GetFilteredList(PurchaseBindingModel model);
        PurchaseViewModel GetElement(PurchaseBindingModel model);
        void Insert(PurchaseBindingModel model);
        void Update(PurchaseBindingModel model);
        void Delete(PurchaseBindingModel model);
    }
}
