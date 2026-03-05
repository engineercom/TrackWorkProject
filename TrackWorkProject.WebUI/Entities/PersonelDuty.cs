namespace TrackWorkProject.WebUI.Entities
{
    public class PersonelDuty
    {
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
        public int DutyId { get; set; }
        public Duty Duty { get; set; }
    }
}
