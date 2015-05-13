namespace WorkerWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SavedOrder")]
    public partial class SavedOrder
    {
        public int Id { get; set; }

        
        public string CreationDate { get; set; }

        public string Deadline { get; set; }

        [Required]
        [StringLength(50)]
        public string Description { get; set; }

        public int Price { get; set; }

        public int? WorkerId { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Worker Worker { get; set; }
    }
}
