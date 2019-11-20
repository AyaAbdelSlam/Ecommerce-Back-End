using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ECommerce.Core.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public List<string> Images { get; set; }

        [Required]
        public float Price { get; set; }

        public string FullDescription { get; set; }
    }
}
