using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerListImplements.Models
{
    public class Procedure
    {
        public int? Id { get; set; }

        public string ProcedureName { get; set; }

        //Продолжительность в минутах
        public int Duration { get; set; }

        public decimal Price { get; set; }
    }
}
