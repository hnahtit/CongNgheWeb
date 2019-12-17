namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Product_Attribute
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Product_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Attribute_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string Attribute_Type_ID { get; set; }

        public virtual Attribute Attribute { get; set; }

        public virtual Product Product { get; set; }
    }
}
