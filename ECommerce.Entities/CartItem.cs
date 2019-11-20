using ECommerce.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Entities
{
    public class CartItem:IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual Product Product { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int Quantity { get; set; }

        public float ItemCost { get; set; }
    }
}
