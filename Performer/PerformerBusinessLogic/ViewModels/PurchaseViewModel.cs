using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerBusinessLogic.ViewModels
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }

        public Dictionary<int, (string, int)> PurchaseProcedures { get; set; }
    }
}
