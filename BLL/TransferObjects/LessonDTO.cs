namespace BLL.TransferObjects
{
    public class LessonDTO
    {
        public int Id { get; set; }
        public string LessonName { get; set; }
        public string ThemeOfLesson { get; set; }
        public int? TeacherId { get; set; }
    }
}
