namespace WorkerWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Worker")]
    public partial class Worker
    {
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string Password { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        public bool Admin { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(8)]
        public string Tlf { get; set; }
    }
}
