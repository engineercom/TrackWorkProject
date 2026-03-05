using TrackWorkProject.WebUI.Entities;

namespace TrackWorkProject.WebUI.Models
{
    public class PersonelDutiesViewModel
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public List<Duty> Duties { get; set; }=new List<Duty>();
    }
}
