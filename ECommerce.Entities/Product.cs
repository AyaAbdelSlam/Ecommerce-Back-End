using ECommerce.Entities.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ECommerce.Entities
{
    public class Product : IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreatedDate { get; set; }

        public DateTime ModifiedDate { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }

        public string Name { get; set; }

        public string Images { get; set; }

        public float Price { get; set; }

        public string FullDescription { get; set; }

    }
}
