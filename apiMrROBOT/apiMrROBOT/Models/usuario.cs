namespace apiMrROBOT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("usuario")]
    public partial class usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [StringLength(100)]
        public string Nombres { get; set; }

        [StringLength(100)]
        public string Apellidos { get; set; }

        [StringLength(100)]
        public string Correo { get; set; }

        [StringLength(150)]
        public string Clave { get; set; }

        public bool? Reestablecer { get; set; }

        public bool? Activo { get; set; }

        public DateTime? FechaRegistro { get; set; }
    }
}
