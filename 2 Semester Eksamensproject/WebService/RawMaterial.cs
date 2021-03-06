namespace WebService
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RawMaterial")]
    public partial class RawMaterial
    {
        public int Id { get; set; }

        public int Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }
    }
}
