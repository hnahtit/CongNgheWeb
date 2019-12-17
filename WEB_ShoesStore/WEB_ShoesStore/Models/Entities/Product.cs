namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            Product_Attribute = new HashSet<Product_Attribute>();
        }

        [Key]
        [StringLength(20)]
        public string Product_ID { get; set; }

        [StringLength(50)]
        public string Product_Name { get; set; }

        [StringLength(20)]
        public string Manufacturer_ID { get; set; }

        public int? Price { get; set; }

        public int? Rating { get; set; }

        [StringLength(100)]
        public string Src1 { get; set; }

        [StringLength(100)]
        public string Src2 { get; set; }

        [StringLength(100)]
        public string Src3 { get; set; }

        [StringLength(4000)]
        public string decription { get; set; }

        [StringLength(100)]
        public string Src4 { get; set; }

        [StringLength(100)]
        public string Src5 { get; set; }

        [StringLength(100)]
        public string Src6 { get; set; }

        public virtual Manufacturer Manufacturer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Attribute> Product_Attribute { get; set; }
    }
}
