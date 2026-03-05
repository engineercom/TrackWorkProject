namespace TrackWorkProject.WebUI.Entities
{
    public class Duty: BaseEntity
    {
        public Duty()
        {
            PersonelDuties = new HashSet<PersonelDuty>();
        }
        public string Name { get; set; }
        public int DirectorateId { get; set; }
        public Directorate? Directorate { get; set; }

        public ICollection<PersonelDuty> PersonelDuties { get; set; }
    }
}
