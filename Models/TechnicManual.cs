namespace CourseWorkFactoryAutomatization.Models
{
    public class TechnicManual
    {
        public long Id { get; set; }
        public DateTime DateCreate { get; set; }
        public virtual ICollection<SuperVisor> SuperVisors { get; set; }
        public virtual ICollection<Technic> Technics { get; set; }
    }
}
