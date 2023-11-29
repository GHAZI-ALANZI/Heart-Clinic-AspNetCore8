using Heart_Clinic.Models;

namespace Heart_Clinic.Services
{
    public class Manager
    {
        public class ClinicManager : IFunction<DoctorDetails>, IFunction<PatientDetails>, IFunction<Appointment>
        {
            private ClinicContext _context;
            private ILogger<ClinicManager> _logger;

            public ClinicManager()
            {

            }
            public ClinicManager(ClinicContext context, ILogger<ClinicManager> logger)
            {
                _context = context;
                _logger = logger;
            }

            public void Add(DoctorDetails t)
            {
                _context.DoctorTable.Add(t);
                _context.SaveChanges();
            }

            public void Add(PatientDetails t)
            {
                _context.PatientsTable.Add(t);
                _context.SaveChanges();
            }

            public void Add(Appointment t)
            {
                throw new NotImplementedException();
            }



            public DoctorDetails Get(int id)
            {
                try
                {
                    DoctorDetails doctor = _context.DoctorTable.FirstOrDefault(a => a.DoctorID == id);
                    return doctor;
                }
                catch (Exception e)
                {
                    _logger.LogDebug(e.Message);
                }
                return null;
            }




            PatientDetails IFunction<PatientDetails>.Get(int id)
            {
                try
                {
                    PatientDetails patient = _context.PatientsTable.FirstOrDefault(a => a.PatientId == id);
                    return patient;
                }
                catch (Exception e)
                {
                    _logger.LogDebug(e.Message);
                }
                return null;
            }

            Appointment IFunction<Appointment>.Get(int id)
            {
                try
                {
                    Appointment appointment = _context.AppointmentTable.FirstOrDefault(a => a.AppointmentId == id);
                    return appointment;
                }
                catch (Exception e)
                {
                    _logger.LogDebug(e.Message);
                }
                return null;
            }
        }
    }
}
