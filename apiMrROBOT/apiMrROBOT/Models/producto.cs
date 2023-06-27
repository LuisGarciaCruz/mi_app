namespace apiMrROBOT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("producto")]
    public partial class producto
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public producto()
        //{
        //    //carrito = new HashSet<carrito>();
        //    //detalle_venta = new HashSet<detalle_venta>();
        //}

        [Key]
        public int IdProducto { get; set; }

        [StringLength(500)]
        public string Nombre { get; set; }

        [StringLength(500)]
        public string Descripcion { get; set; }

        public int? IdMarca { get; set; }

        public int? IdCategoria { get; set; }

        public decimal? Precio { get; set; }

        public int? Stock { get; set; }

        [StringLength(100)]
        public string RutaImagen { get; set; }

        [StringLength(100)]
        public string NombreImagen { get; set; }

        public bool? Activo { get; set; }

        //public Marca oMarcar { get; set; }

        //public Categoria categoria { get; set; }

        //public DateTime? FechaRegistro { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<carrito> carrito { get; set; }

        //public virtual categoria categoria { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<detalle_venta> detalle_venta { get; set; }

        //public virtual marca marca { get; set; }
    }
}
