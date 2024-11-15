
using System.Windows.Controls;


namespace PatientAdmissionApp.UserControls
{
    /// <summary>
    /// Interaction logic for AppointmentControl.xaml
    /// </summary>
    public partial class AppointmentControl : UserControl
    {
        public AppointmentControl()
        {
            InitializeComponent();
            
        }

        public void DisplayPatientName(object sender, PatientModel e)
        {
            if (e != null)
            {
                lblPatientNameLabel.Content = $"  Notified From Registrationpage - {e.Name}";
            }
        }
    }
}
