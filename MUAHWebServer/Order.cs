namespace MUAHWebServer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order")]
    public partial class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }

        [Required]
        [StringLength(50)]
        public string CustomerName { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateAndTime { get; set; }

        [Required]
        [StringLength(500)]
        public string ProductName { get; set; }

        [StringLength(200)]
        public string Comment { get; set; }

        public double Price { get; set; }

        [Required]
        [StringLength(11)]
        public string PhoneNo { get; set; }
    }
}
