using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Wachtwoord { get; set; }
#nullable enable
        public string? Adres { get; set; }
        public string? Postcode { get; set; }
#nullable disable
        public int RoleId { get; set; } = 2;
        //user can 0 of meer orders hebben
        public ICollection<Order> Orders { get; set; }
        public Role Role { get; set; }
        [NotMapped]
        public string Token { get; set; }
    }
}
