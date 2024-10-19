using App.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Data.Entities.Orders
{
    [Table("Orderlines")]
    [Index(nameof(ProductId))]
    [Index(nameof(CreatedOn))]
    public class Orderline : IEntity, IAuditable, IArchivable
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }

        public decimal Vat { get; set; }

        public virtual Order Order { get; set; }

        [ForeignKey("Order")]
        public Guid OrderId { get; set; }

        public bool IsDeprecated { get; set ; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? ModifiedOn { get ; set; }
    }
}
