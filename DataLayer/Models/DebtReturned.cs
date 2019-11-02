using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Table("DebtReturned", Schema = "dbo")]
    public class DebtReturned
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DebtReturnId { get; set; }

        [ForeignKey("FK_ReturnFrom")]
        public string ReturnFromUser { get; set; }

        [ForeignKey("FK_ReturnTo")]
        public string ReturnToUser { get; set; }

        [ForeignKey("FK_Request")]
        public int RequestId { get; set; }
        
        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [InverseProperty("ReturnFrom")]
        public virtual Users FK_ReturnFrom { get; set; }

        [InverseProperty("ReturnTo")]
        public virtual Users FK_ReturnTo { get; set; }
    
        public virtual Requests FK_Request { get; set; }
    }
}
