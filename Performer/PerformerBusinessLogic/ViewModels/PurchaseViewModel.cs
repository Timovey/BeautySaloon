using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PerformerBusinessLogic.ViewModels
{
    public class PurchaseViewModel
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        [DisplayName("Дата покупки")]
        public DateTime Date { get; set; }
        [DisplayName("Цена (руб)")]
        public decimal Price { get; set; }

        public Dictionary<int, (string, decimal)> PurchaseProcedures { get; set; }
    }
}
