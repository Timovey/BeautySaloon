using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PerformerBusinessLogic.ViewModels
{
    public class PurchaseDataGridModel
    {
        public int Id { get; set; }

        [DisplayName("Название процедуры")]
        public string ProcedureName { get; set; }
        [DisplayName("Цена")]
        public decimal ProcedurePrice { get; set; }
    }
}
