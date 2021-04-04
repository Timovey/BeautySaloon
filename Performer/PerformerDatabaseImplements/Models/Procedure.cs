using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PerformerDatabaseImplements.Models
{
    public class Procedure
    {
        public int Id { get; set; }

        [Required]
        public string ProcedureName { get; set; }

        //Продолжительность в минутах
        [Required]
        public int Duration { get; set; }
        [Required]
        public decimal Price { get; set; }

        public virtual Visit Visit { get; set; }

        public virtual Purchase Purchase { get; set; }

        public virtual Client Client { get; set; }
    }
}
