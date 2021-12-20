using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Aantal { get; set; } = 0;
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
