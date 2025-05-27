using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web_KhoaHoc.Models
{
    public class Account
    {
        [Required(ErrorMessage = "Vui lòng nhập tên đăng nhập")]
        public string username {  get; set; }
        [Required(ErrorMessage = "Vui lòng nhập mật khẩu")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        public DateTime accessDate { get; set; }
        public string email { get; set; }
        public Role roleID { get; set; }
    }
}
