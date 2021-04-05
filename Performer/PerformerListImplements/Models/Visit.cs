using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerListImplements.Models
{
    public class Visit
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public DateTime Date { get; set; }

        public Dictionary<int, int> VisitProcedures { get; set; }
    }
}
