using System;
using System.Collections.Generic;

namespace TestWebApp.Data
{
    public class DbContext
    {
        public IEnumerable<Cat> AllCats()
        {
            return new List<Cat>
            {
                new Cat { Id = 1, Name = "Kitty", Age = 5, Owner = new Owner { Id = 1, Name = "Ivan" } },
                new Cat { Id = 2, Name = "Fluffy", Age = 7, Owner = new Owner { Id = 2, Name = "Pesho" } },
                new Cat { Id = 3, Name = "New Cat", Age = 3, Owner = new Owner { Id = 3, Name = "New Owner" } }
            };
        }
    }
}
