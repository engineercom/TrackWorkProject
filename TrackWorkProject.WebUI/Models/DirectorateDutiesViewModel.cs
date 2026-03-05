using TrackWorkProject.WebUI.Entities;

namespace TrackWorkProject.WebUI.Models
{
    public class DirectorateDutiesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Duty> Duties { get; set; }=new List<Duty>();
    }
}
