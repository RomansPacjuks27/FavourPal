using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using FavourPal.Api.Models;

namespace FavourPal.Api.Models
{
    [Table("Transfers", Schema = "dbo")]
    public class Transfer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid? Id { get; set; }

        public string SenderUserId { get; set; }
        public virtual User SenderUser { get; set; }

        public string RecipientUserId { get; set; }
        public virtual User RecipientUser { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public DateTime SendOn { get; set; }
    }
}
