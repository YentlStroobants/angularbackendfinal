using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; } = 1;
        public User User { get; set; }
        public Status Status { get; set; }
    }
}
