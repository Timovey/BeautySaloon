using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerListImplements.Models
{
    public class Purchase
    {
        public int? Id { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }
    }
}
