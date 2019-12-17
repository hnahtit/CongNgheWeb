namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        [Key]
        [StringLength(20)]
        public string Customer_ID { get; set; }

        [StringLength(50)]
        public string Customer_Name { get; set; }

        [StringLength(50)]
        public string Company_Name { get; set; }

        [StringLength(50)]
        public string E_mail { get; set; }

        [StringLength(20)]
        public string C_Password { get; set; }

        [StringLength(200)]
        public string C_Address { get; set; }

        [StringLength(50)]
        public string Country { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(20)]
        public string Phone_Number { get; set; }

        [StringLength(30)]
        public string Customer_UserName { get; set; }
    }
}
