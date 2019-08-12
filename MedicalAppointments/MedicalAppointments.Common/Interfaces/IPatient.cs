using System;

namespace MedicalAppointments.Common.Interfaces
{
    public interface IPatient
    {
         int Id { get; set; }
        string IdCard { get; set; }
        string Name { get; set; }
        string Lastname { get; set; }
        DateTime DateOfBirth { get; set; }
    }
}
