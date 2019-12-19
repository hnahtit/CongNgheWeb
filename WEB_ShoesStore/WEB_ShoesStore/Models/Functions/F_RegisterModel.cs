using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEB_ShoesStore.Models.Functions
{
    public class F_RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "Ten dang nhap")]
        [Required(ErrorMessage = "Yeu cau nhap ten dang nhap")]
        public string UserName { set; get; }
        [Display(Name = "mat khau")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "do dai mat khau it nhat 6 ky tu")]
        [Required(ErrorMessage = "Yeu cau nhap mat khau")]
        public string Password { set; get; }

        [Display(Name = "xac nhan mat khau")]
        [Required(ErrorMessage = "Yeu cau xac nhan mat khau")]
        public string ConfirmPassword { set; get; }
        [Display(Name = "Ten")]
        public string Name { get; set; }
        [Display(Name = "dia chi")]
        public string Address { get; set; }
        [Display(Name = "email")]
        public string Email { get; set; }
        [Display(Name = "so dien thoai")]
        public string Phone { get; set; }
    }
}