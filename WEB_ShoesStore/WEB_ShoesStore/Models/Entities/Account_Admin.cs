namespace WEB_ShoesStore.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account_Admin
    {
        [Key]
        [StringLength(50)]
        public string Ac_Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Ac_Password { get; set; }
    }
}
