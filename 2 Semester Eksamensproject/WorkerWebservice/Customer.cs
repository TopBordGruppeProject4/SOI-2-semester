namespace WorkerWebservice
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public Customer()
        {
            SavedOrders = new HashSet<SavedOrder>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string Address { get; set; }

        [Required]
        [StringLength(50)]
        public string Tlf { get; set; }

        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        public virtual ICollection<SavedOrder> SavedOrders { get; set; }
    }
}
