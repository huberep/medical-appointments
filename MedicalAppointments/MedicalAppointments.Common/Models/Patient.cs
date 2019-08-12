using System;
using System.ComponentModel.DataAnnotations;
using MedicalAppointments.Common.Interfaces;

namespace MedicalAppointments.Common.Models
{
    public class Patient : IPatient
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15)]
        public string IdCard { get; set; }
        [Required]
        [StringLength(25)]
        public string Name { get; set; }
        [Required]
        [StringLength(25)]
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
