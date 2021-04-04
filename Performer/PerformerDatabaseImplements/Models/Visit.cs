using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PerformerDatabaseImplements.Models
{
    public class Visit
    {
        public int Id { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [ForeignKey("VisitId")]
        public virtual List<Procedure> Procedures { get; set; }

        public virtual Client Client { get; set; }
    }
}
