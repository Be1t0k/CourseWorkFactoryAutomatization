namespace CourseWorkFactoryAutomatization.Models
{
    public class SuperVisor: User
    {
        public virtual ICollection<TechnicManual> TechnicManuals { get; set; }
    }
}
