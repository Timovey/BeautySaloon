using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerBusinessLogic.ViewModels
{
    public class VisitViewModel
    {
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public Dictionary<int, (string, int)> VisitProcedures { get; set; }
    }
}
