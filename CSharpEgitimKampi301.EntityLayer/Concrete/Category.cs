using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }
        public bool CategoryStatus { get; set; }

        public List<Product> Products { get; set; }

    }
}

#region Field-Variable-Property ayrımları
// Field-Variable-Property*
/*
 int x; --> Field
public int X { get; set; } --> Property
void Method() --> Method    
 */
#endregion