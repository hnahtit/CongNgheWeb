namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Attribute_Type
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string Attribute_Type_ID { get; set; }

        [StringLength(50)]
        public string Attribute_Type_Name { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string Attribute_ID { get; set; }

        public virtual Attribute Attribute { get; set; }
    }
}
