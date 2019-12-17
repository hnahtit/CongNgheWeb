namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderDetail")]
    public partial class OrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string ProductID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string OrderID { get; set; }

        public int? Quantity { get; set; }

        public decimal? Price { get; set; }
    }
}