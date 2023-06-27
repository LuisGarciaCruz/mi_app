namespace apiMrROBOT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("carrito")]
    public partial class carrito
    {
        [Key]
        public int IdCarrito { get; set; }

        public int? IdCliente { get; set; }

        public int? IdProducto { get; set; }

        public int? Cantidad { get; set; }

        public virtual cliente cliente { get; set; }

        public virtual producto producto { get; set; }
    }
}
