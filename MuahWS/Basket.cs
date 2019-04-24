namespace MuahWS
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Basket")]
    public partial class Basket
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }

        public double Price { get; set; }
    }
}
