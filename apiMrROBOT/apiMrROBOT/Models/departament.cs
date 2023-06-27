namespace apiMrROBOT.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("departament")]
    public partial class departament
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string IdDepartement { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(45)]
        public string Descripcion { get; set; }
    }
}
