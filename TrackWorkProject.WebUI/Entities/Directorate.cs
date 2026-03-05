namespace TrackWorkProject.WebUI.Entities
{
    public class Directorate : BaseEntity
    {
        public Directorate()
        {
            Duties= new HashSet<Duty>();
        }
        public string? Name { get; set; }

        public ICollection<Duty> Duties { get; set; }
    }
}
