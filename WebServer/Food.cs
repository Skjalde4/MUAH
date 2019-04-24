namespace WebServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Food")]
    public partial class Food
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }

        [Required]
        [StringLength(100)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string Category { get; set; }

        public double Price { get; set; }
    }
}
