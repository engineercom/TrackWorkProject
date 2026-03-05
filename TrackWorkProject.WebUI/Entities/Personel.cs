namespace TrackWorkProject.WebUI.Entities
{
    public class Personel:BaseEntity
    {
        public Personel()
        {
            PersonelDuties = new HashSet<PersonelDuty>();
        }
        public string FullName { get; set; } = null!;
        public ICollection<PersonelDuty> PersonelDuties { get; set; }
    }
}
