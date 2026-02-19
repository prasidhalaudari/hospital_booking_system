using System;
using System.Configuration;
using System.Windows.Forms;

using hospitaldesktop.BLL.Interfaces;
using hospitaldesktop.BLL.Services;
using hospitaldesktop.DAL.Interfaces;
using hospitaldesktop.DAL.Sql;   // UserRepository

namespace hospitaldesktop.UI
{
    internal static class Program
    {
        // Make AuthService available to other forms (e.g., for Log Out)
        public static IAuthService AuthService { get; private set; }=null!;
        public static IPatientRepository Patients { get; private set; } = null!;
        public static IMedicationRepository Medications { get; private set; } = null!;


        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Build services once
            var cs = ConfigurationManager.ConnectionStrings["HospitalDB"].ConnectionString;
            var userRepo = new UserRepository(cs);
            AuthService = new AuthService(userRepo);

            // Start at the login form, injecting the service
            Patients = new PatientRepository(cs);
            Medications = new MedicationRepository(cs);
            Application.Run(new Form1(AuthService));
            
        }   
    }
}
