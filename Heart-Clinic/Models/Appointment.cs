using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Heart_Clinic.Models
{
    public class Appointment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AppointmentId { get; set; }

        [Display(Name = "Patient ID")]
        [Required(ErrorMessage = "Patient ID is required.")]
        public int PatientId { get; set; }

        [Display(Name = "Specialization Required")]
        public ASpecializationRequired SpecializationRequired { get; set; }
        public enum ASpecializationRequired
        {
            General, Gynaecologist, Pediatrics, Orthopedics, Ophthalmology
        }

        [Required(ErrorMessage = "Doctor Name is required.")]
        [Display(Name = "Doctor Name")]
        public string DoctorName { get; set; }

        [Required(ErrorMessage = "Date is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Visiting Date")]
        public DateTime VisitDate { get; set; }
        //public DateTime AppointmentTime { get; set; }


        [Required(ErrorMessage = "Date is required.")]
        [Display(Name = "From")]
        [DataType(DataType.Time)]
        public DateTime FromTime { get; set; }


        [Required(ErrorMessage = "Time is required.")]
        [Display(Name = "To")]
        [DataType(DataType.Time)]
        public DateTime ToTime { get; set; }


    }
}
