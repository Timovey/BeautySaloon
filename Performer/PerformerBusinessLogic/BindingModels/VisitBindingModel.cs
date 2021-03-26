using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerBusinessLogic.BindingModels
{
    public class VisitBindingModel
    {
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public Dictionary<int, string> VisitProcedures { get; set; }
    }
}
