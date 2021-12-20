using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class Food
    {
        public int Id { get; set; }
        public string VervalDatum { get; set; } = "01/01/2000";
        public string Hoeveelheid { get; set; } = "1L";
#nullable enable
        public ICollection<Product>? Products { get; set; }
#nullable disable
    }
}
