using Microsoft.EntityFrameworkCore;

namespace Heart_Clinic.Models
{
    public class ClinicContext : DbContext
    {
        public ClinicContext()
        {
        }

        public ClinicContext(DbContextOptions<ClinicContext> options) : base(options)
        { }
        public DbSet<Appointment> AppointmentTable { get; set; }
        public DbSet<DoctorDetails> DoctorTable { get; set; }
        public DbSet<PatientDetails> PatientsTable { get; set; }



    }
}
