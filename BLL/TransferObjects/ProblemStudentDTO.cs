namespace BLL.TransferObjects
{
    public class ProblemStudentDTO
    {
        public int Id { get; set; }

        public int? StudentId { get; set; }
        public StudentDTO Student { get; set; }

        public string Note { get; set; }
    }
}
