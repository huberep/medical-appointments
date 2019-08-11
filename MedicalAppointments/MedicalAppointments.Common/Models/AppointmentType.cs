using MedicalAppointments.Common.Interfaces;

namespace MedicalAppointments.Common.Models
{
    public class AppointmentType : IAppointmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
