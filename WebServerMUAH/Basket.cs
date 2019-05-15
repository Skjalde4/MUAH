namespace WebServerMUAH
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

        public int ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public int NoOfProduct { get; set; }

        public double TotalPrice { get; set; }
    }
}
