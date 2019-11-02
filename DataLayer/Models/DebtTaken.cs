using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Table("DebtTaken", Schema = "dbo")]
    public class DebtTaken
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DebtTakenId { get; set; }

        [ForeignKey("FK_RequestId")]
        public int RequestId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public virtual Requests FK_RequestId { get; set; }
    }
}
