using System.ComponentModel.DataAnnotations;

namespace StudentAssistant.WebUI.Dtos.Student
{
    public class UpdateStudentDto
    {
        public int StudentID { get; set; }
        [Required(ErrorMessage = "İsim alanını girmek zorundasınız.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Soyad alanını girmek zorundasınız.")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "Yaş alanını girmek zorundasınız.")]
        public int Age { get; set; }
        [Required(ErrorMessage = "Eğitim durumu alanını girmek zorundasınız.")]
        public string Status { get; set; }
        [Required(ErrorMessage = "Bölüm alanını girmek zorundasınız.")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Sınıf alanını girmek zorundasınız.")]
        public int Class { get; set; }
        [Required(ErrorMessage = "Şehir alanını girmek zorundasınız.")]
        public string City { get; set; }

    }
}
