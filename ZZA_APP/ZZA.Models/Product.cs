using System;
using System.Collections.Generic;
using System.Text;

namespace ZZA.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool HasOptions { get; set; }
        public bool IsVegetarian { get; set; }
        public bool WithTomatoSauce { get; set; }
        public string SizeIds { get; set; }
    }
}
