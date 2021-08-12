using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourPal.Domain.Models
{
    [Table("Requests", Schema = "dbo")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        //[ForeignKey("FK_RequestFrom")]
        //public int? SenderUserId { get; set; }

        public virtual User SenderUser { get; set; }

        //[ForeignKey("FK_RequestTo")]
        //public int? RecipientUserId { get; set; }

        public virtual User RecipientUser { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal AmountRequested { get; set; }

        [Column(TypeName = "decimal(10, 2)")]
        public decimal AmountPaid { get; set; }

        public string Message { get; set; }
    }
}
