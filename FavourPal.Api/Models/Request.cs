using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FavourPal.Api.Models
{
    [Table("Requests", Schema = "dbo")]
    public class Request
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        [ForeignKey("FK_RequestFrom")]
        public int SenderUserId { get; set; }

        [ForeignKey("FK_RequestTo")]
        public int ReciepentUserId { get; set; }

        [Required(ErrorMessage = "Amount is required!")]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public string Message { get; set; }

        //[Column(TypeName = "bit")]
        //public bool Accepted { get; set; }
    }
}
