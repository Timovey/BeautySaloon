using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerBusinessLogic.ViewModels
{
    public class ProcedureViewModel
    {
        public int Id { get; set; }

        public string ProcedureName { get; set; }

        //Продолжительность в минутах
        public int Duration { get; set; }

        public decimal Price { get; set; }
    }
}
