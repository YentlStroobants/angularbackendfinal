using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Naam { get; set; } = "default";
        public ICollection<Order> Orders { get; set; }
    }
}
