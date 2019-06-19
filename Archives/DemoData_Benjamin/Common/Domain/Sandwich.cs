using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Domain
{
    public class Sandwich
    {
        public int SandwichId { get; set; }
        public string Name { get; set; }

        public ICollection<Ingredient> Ingredients { get; set; }

    }
}
