using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BasicDotNetCoreMVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        //DataAnnotations
        [Required(ErrorMessage = "กรุณาป้อนซื่อนักเรียน")]
        [DisplayName("ชื่อนักเรียน")]
        public string Name { get; set; }

        //DataAnnotations
        [DisplayName("คะแนนสอบ")]
        [Range(0,100,ErrorMessage = "กรุณาป้อนคะแนนในช่วง 0-100")]
        public int Score { get; set; }
    }
}