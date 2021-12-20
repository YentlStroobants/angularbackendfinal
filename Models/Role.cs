using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Naam { get; set; } = "klant";
        public ICollection<User> Users { get; set; }
    }
}
