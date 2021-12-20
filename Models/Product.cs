using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AngularChallengeAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int? FoodId { get; set; }
        public int? NonFoodId { get; set; }
        public string Naam { get; set; }
        public double Prijs { get; set; }
        public bool IsActief { get; set; }
#nullable enable
        public string? Beschrijving { get; set; }       
        public int? AantalInStock { get; set; }
        public string? Foto { get; set; }
        public Food? Food { get; set; }
        public NonFood? NonFood { get; set; }
        public ICollection<OrderProduct>? OrderProducts { get; set; }
#nullable disable
    }
}
