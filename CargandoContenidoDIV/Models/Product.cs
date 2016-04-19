namespace CargandoContenidoDIV.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class Product
    {
        public int ProductID { get; set; }

        [Required]
        [StringLength(40)]
        public string ProductName { get; set; }

        public int? SupplierID { get; set; }

        public int? CategoryID { get; set; }

        [StringLength(20)]
        public string QuantityPerUnit { get; set; }

        [Column(TypeName = "money")]
        public decimal? UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public short? UnitsOnOrder { get; set; }

        public short? ReorderLevel { get; set; }

        public bool Discontinued { get; set; }

        public virtual Category Categories { get; set; }

        public static List<Product> ListarPorNombre(string parametro)
        {
            List<Product> data;
            using ( var ctx = new NWContext() )
            {
                data = ctx.Products
                    .Where( x => x.ProductName.Contains( parametro ) )
                    .ToList();
                    
            }
            return data;
        }
    }
}
