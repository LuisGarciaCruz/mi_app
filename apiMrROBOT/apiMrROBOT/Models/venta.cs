namespace apiMrROBOT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("venta")]
    public partial class venta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public venta()
        {
            detalle_venta = new HashSet<detalle_venta>();
        }

        [Key]
        public int IdVenta { get; set; }

        public int? IdCliente { get; set; }

        public int? TotalProducto { get; set; }

        public decimal? MontoTotal { get; set; }

        [StringLength(50)]
        public string Contacto { get; set; }

        [StringLength(10)]
        public string IdDistrito { get; set; }

        [StringLength(50)]
        public string Telefono { get; set; }

        [StringLength(500)]
        public string Direccion { get; set; }

        [StringLength(50)]
        public string IdTransaccion { get; set; }

        public DateTime? FechaVenta { get; set; }

        public virtual cliente cliente { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<detalle_venta> detalle_venta { get; set; }
    }
}
