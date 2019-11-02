using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Models
{
    [Table("Requests", Schema = "dbo")]
    public class Requests
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RequestId { get; set; }

        [ForeignKey("FK_RequestFrom")]
        public string RequestFromUser { get; set; }

        [ForeignKey("FK_RequestTo")]
        public string RequestToUser { get; set; }

        [Required(ErrorMessage = "Amount is required!")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        [Column(TypeName = "bit")]
        public bool Accepted { get; set; }

        [InverseProperty("RequestsFrom")]
        public virtual Users FK_RequestFrom { get; set; }

        [InverseProperty("RequestsTo")]
        public virtual Users FK_RequestTo { get; set; }

        public virtual DebtTaken DebtTakenId { get; set; }

        public virtual DebtReturned DebtReturnedId { get; set; }
    }
}
