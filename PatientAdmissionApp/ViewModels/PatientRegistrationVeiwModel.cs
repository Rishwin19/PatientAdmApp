using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PatientAdmissionApp.UserControls;

namespace PatientAdmissionApp.Views
{
    public class PatientRegistrationVeiwModel : BaseViewModel, IPatient
    {
        private MainWindow mainWindow;
        public PatientRegistrationControl patientRegistrationControl;
        public event EventHandler PatientRegistered;
        public event EventHandler<PatientModel> PatientUpdated;
        public ObservableCollection<PatientModel> Patients { get; set; } = new ObservableCollection<PatientModel>();

        private bool _selectedSlot;
        public bool SelectedSlot
        {
            get { return _selectedSlot; }
            set { _selectedSlot = value; OnPropertyChanged(nameof(SelectedSlot)); }
        }
        public ICommand RegisterPatientCommand { get; set; }

        public PatientRegistrationVeiwModel()
        {
            NewPatient = new PatientModel();
            patientRegistrationControl = new PatientRegistrationControl();
            RegisterPatientCommand = new RelayCommand(RegisterPatient);
            PatientRegistered += OnPatientRegistered;
        }
        public void RegisterPatient(object parameter)
        {
            PatientRegistered?.Invoke(this, EventArgs.Empty);
        }
        private void OnPatientRegistered(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(NewPatient.Name) && NewPatient.Dateofbirth != default)
            {
                Patients.Add(new PatientModel
                {
                    Name = NewPatient.Name,
                    Dateofbirth = NewPatient.Dateofbirth,
                    Age = DateTime.Now.Year - NewPatient.Dateofbirth.Year,
                    Address = NewPatient.Address,
                    Slot = NewPatient.Slot,
                    BookingDate = NewPatient.BookingDate
                });
                PatientUpdated?.Invoke(this, NewPatient);
                NewPatient = new PatientModel();
            }
            else
            {
                MessageBox.Show("Please provide valid patient details.");
            }
        }
    }
}
