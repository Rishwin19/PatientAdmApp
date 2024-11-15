﻿using System.Windows;
using PatientAdmissionApp.UserControls;

namespace PatientAdmissionApp.Views
{
    public partial class MainWindow : Window
    {
        private PatientViewModel _viewModel;
        private PatientRegistrationControl registrationControl;
        private AppointmentControl appointmentControl;
        private PatientDashboardControl dashboardControl;

        public MainWindow()
        {
            InitializeComponent();
            _viewModel = new PatientViewModel();
            DataContext = _viewModel;
        }

        private void btnRegistration_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainContent.Content is PatientRegistrationControl))
            {
                registrationControl = new PatientRegistrationControl();
                appointmentControl = new AppointmentControl();
                dashboardControl = new PatientDashboardControl();
                MainContent.Content = registrationControl;
                _viewModel.PatientUpdated += registrationControl.DisplayPatientName;
                _viewModel.PatientUpdated += appointmentControl.DisplayPatientName;
                _viewModel.PatientUpdated += dashboardControl.DisplayPatientName;
            }
        }

        private void btnAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainContent.Content is AppointmentControl))
            {
                MainContent.Content = appointmentControl;

            }
        }

        private void btnDashboard_Click(object sender, RoutedEventArgs e)
        {
            if (!(MainContent.Content is PatientDashboardControl))
            {
                MainContent.Content = dashboardControl;
            }
        }
        public void UnsubscribeFromPatientUpdatedEvent()
        {
            _viewModel.PatientUpdated -= registrationControl.DisplayPatientName;
            _viewModel.PatientUpdated -= appointmentControl.DisplayPatientName;
            _viewModel.PatientUpdated -= dashboardControl.DisplayPatientName;

        }
    }
}
