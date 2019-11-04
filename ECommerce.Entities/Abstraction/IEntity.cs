using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerce.Entities.Abstraction
{
    public interface IEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        int Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        DateTime CreatedDate { get; set; }

        DateTime ModifiedDate { get; set; }

        [Timestamp]
        byte[] RowVersion { get; set; }
    }
}
