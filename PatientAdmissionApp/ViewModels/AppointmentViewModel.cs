using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using PatientAdmissionApp.Interface;

namespace PatientAdmissionApp.ViewModels
{

    public class AppointmentViewModel : BaseViewModel, IAppointment
    {
        public event EventHandler AppointmentUpdated;
        public ObservableCollection<PatientModel> ConfirmedPatients { get; set; } = new ObservableCollection<PatientModel>();


        private PatientModel _selectedPatient;

        public AppointmentViewModel()
        {
            SendUpdateCommand = new RelayCommand(SendUpdate);
            AppointmentUpdated += OnAppointmentUpdated;


        }

        public PatientModel SelectedPatient
        {
            get { return _selectedPatient; }
            set { _selectedPatient = value; OnPropertyChanged(); }
        }
        public ICommand SendUpdateCommand { get; set; }

        public void SendUpdate(object parameter)
        {
            if (SelectedPatient != null)
            {
                SelectedPatient.ConfirmationStatus = NewPatient.ConfirmationStatus;
                SelectedPatient.AppointmentDate = NewPatient.AppointmentDate;
                AppointmentUpdated?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                MessageBox.Show("Please select a Patient");
            }
        }
        private void OnAppointmentUpdated(object sender, EventArgs e)
        {
            if (SelectedPatient != null && !ConfirmedPatients.Contains(SelectedPatient))
            {
                ConfirmedPatients.Add(SelectedPatient);
                MessageBox.Show($"Appointment Confirmed for {SelectedPatient.Name}");
            }
        }
    }

}
