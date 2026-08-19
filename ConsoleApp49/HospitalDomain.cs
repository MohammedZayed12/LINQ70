using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp49
{
    #region HospitalDomain
    // ======================= ENUMS =======================

    public enum Gender { Male, Female, Other }

    public enum RoomType { General, ICU, Operation, Emergency, Maternity }

    public enum AppointmentStatus { Scheduled, Completed, Cancelled, NoShow }

    // ======================= DOMAIN CLASSES =======================

    public class Hospital
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Address { get; set; } = "";
        public int FoundedYear { get; set; }
        public bool IsGovernmentFunded { get; set; }
        public List<Department> Departments { get; set; } = new();
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double AnnualBudget { get; set; }
        public int FloorNumber { get; set; }
        public List<Doctor> Doctors { get; set; } = new();
        public List<Nurse> Nurses { get; set; } = new();
        public List<Room> Rooms { get; set; } = new();
    }

    public class Doctor
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Specialty { get; set; } = "";
        public int YearsOfExperience { get; set; }
        public double Salary { get; set; }
        public bool IsAvailable { get; set; }
        public int DepartmentId { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
    }

    public class Nurse
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int ShiftHoursPerWeek { get; set; }
        public double Salary { get; set; }
        public bool IsOnDuty { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Patient
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public int Age { get; set; }
        public Gender Gender { get; set; }
        public bool HasInsurance { get; set; }
        public double OutstandingBalance { get; set; }
        public List<Appointment> Appointments { get; set; } = new();
        public List<MedicalRecord> MedicalRecords { get; set; } = new();
        public List<Prescription> Prescriptions { get; set; } = new();
    }

    public class Room
    {
        public int Id { get; set; }
        public int RoomNumber { get; set; }
        public RoomType Type { get; set; }
        public bool IsOccupied { get; set; }
        public double DailyRate { get; set; }
        public int DepartmentId { get; set; }
    }

    public class Appointment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public AppointmentStatus Status { get; set; }
        public double Cost { get; set; }
        public bool IsEmergency { get; set; }
        public int DoctorId { get; set; }
        public int PatientId { get; set; }
        public int RoomId { get; set; }
    }

    public class MedicalRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Diagnosis { get; set; } = "";
        public string Notes { get; set; } = "";
        public bool IsChronic { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
    }

    public class Medication
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double PricePerUnit { get; set; }
        public bool RequiresPrescription { get; set; }
        public int StockQuantity { get; set; }
    }

    public class Prescription
    {
        public int Id { get; set; }
        public DateTime DateIssued { get; set; }
        public int Quantity { get; set; }
        public bool Refillable { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public int MedicationId { get; set; }
    }
    #endregion
}
