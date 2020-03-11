using Code360_Management.Models.Guarantors;

namespace Code360_Management.Models.Students
{
    public class StudentGuarantor
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public Student student { get; set; }
        public int GuarantorId { get; set; }
        public Guarantor guarantor { get; set; }
    }
}