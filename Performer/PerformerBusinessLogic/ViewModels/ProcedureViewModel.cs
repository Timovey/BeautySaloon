using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PerformerBusinessLogic.ViewModels
{
    public class ProcedureViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string ProcedureName { get; set; }
        [DisplayName("Продолжительность (мин)")]
        //Продолжительность в минутах
        public int Duration { get; set; }
        [DisplayName("Цена (руб)")]
        public decimal Price { get; set; }
    }
}
