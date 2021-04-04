using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace PerformerDatabaseImplements.Models
{
    public class ProcedurePurchase
    {
        public int Id { get; set; }
        public int ProcedureId { get; set; }
        public int PurchaseId { get; set; }
        [Required]

        public virtual Procedure Procedure { get; set; }
        public virtual Purchase Purchase { get; set; }
    }
}
