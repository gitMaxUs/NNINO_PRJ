namespace BLL.TransferObjects
{
    public class TeacherDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }

        public string Position { get; set; }

        public int? LessonId { get; set; }

        public int AddressId { get; set; }
    }
}
