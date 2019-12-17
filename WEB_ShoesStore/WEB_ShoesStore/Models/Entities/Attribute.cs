namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Attribute")]
    public partial class Attribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Attribute()
        {
            Attribute_Type = new HashSet<Attribute_Type>();
            Product_Attribute = new HashSet<Product_Attribute>();
        }

        [Key]
        [StringLength(20)]
        public string Attribute_ID { get; set; }

        [StringLength(50)]
        public string Attribute_Name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attribute_Type> Attribute_Type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Product_Attribute> Product_Attribute { get; set; }
    }
}
