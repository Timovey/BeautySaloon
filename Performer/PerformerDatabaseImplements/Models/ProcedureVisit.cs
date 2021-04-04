using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PerformerDatabaseImplements.Models
{
    public class ProcedureVisit
    {
        public int Id { get; set; }
        public int ProcedureId { get; set; }
        public int VisitId { get; set; }
        [Required]

        public virtual Procedure Procedure { get; set; }
        public virtual Visit Visit { get; set; }
    }
}
