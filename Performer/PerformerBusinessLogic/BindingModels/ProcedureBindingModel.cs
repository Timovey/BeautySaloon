using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerBusinessLogic.BindingModels
{
    /// <summary>
    /// Процедура
    /// </summary>
    public class ProcedureBindingModel
    {
        public int? Id { get; set; }
        public int? ClientId { get; set; }

        public string ProcedureName { get; set; }

        //Продолжительность в минутах
        public int Duration { get; set; }

        public decimal Price { get; set; }
    }
}
