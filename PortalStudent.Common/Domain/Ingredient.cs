﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortalStudent.Common.Domain
{
    public class Ingredient
    {
        public int IngredientId { get; set; }

        public string Name { get; set;}

        public virtual ICollection<Sandwich> Sandwiches { get; set; }
    }
}
