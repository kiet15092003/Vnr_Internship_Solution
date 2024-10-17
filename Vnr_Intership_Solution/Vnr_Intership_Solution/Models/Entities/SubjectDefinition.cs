namespace Vnr_Intership_Solution.Models.Entities
{
    public class SubjectDefinition
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int CourseId { get; set; }
        public CourseDefinition? Course { get; set; }
    }
}
