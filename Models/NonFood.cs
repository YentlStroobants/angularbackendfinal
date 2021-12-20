using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class NonFood
    {
        public int Id { get; set; }
        public string Size { get; set; } = "XL";
        public string Color { get; set; } = "Blauw";
#nullable enable
        public ICollection<Product>? Products { get; set; }
#nullable disable
    }
}
