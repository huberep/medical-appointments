using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalAppointments.DataAccess.Interfaces
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
