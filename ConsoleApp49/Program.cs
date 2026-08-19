namespace ConsoleApp49
{
    internal class Program
    {
        #region Questions 1 to 70
        static void Main(string[] args)
        {
            #region Q1
            var q1Result = HospitalSeeder.Doctors
                 .Select(d => d.Name)
                    .ToList();
            foreach (var name in q1Result)
            {
                Console.WriteLine(name);
            }
            #endregion

            #region Q2
            var resultisvalid = HospitalSeeder.Doctors
                .Where(d => d.IsAvailable)
                .Select(d => new
                {
                    d.Name,
                    d.Salary
                })
            .ToList();

            #endregion

            #region Q3
            var resultPatients = HospitalSeeder.Patients
                .OrderBy(p => p.Age)
                    .Select(p => p.Name)
                    .ToList();

            #endregion

            #region Q4
            var resultAppointments = HospitalSeeder.Appointments.Count();
            #endregion

            #region Q5
            var result = HospitalSeeder.Patients
                .Where(p => !p.HasInsurance)
                .Select(p => new
                {
                    p.Name,
                    p.Age,
                    p.OutstandingBalance
                })
                    .FirstOrDefault();
            #endregion

            #region Q6
            var resultExPerofDoctors = HospitalSeeder.Doctors
             .OrderByDescending(d => d.YearsOfExperience)
             .Select(d => new
             {
                 d.Name,
                 d.YearsOfExperience
             })
             .ToList();
            #endregion

            #region Q7
            var SkipPation = HospitalSeeder.Patients
                .Skip(2)
                .Take(2)
                .ToList();

            #endregion

            #region Q8
            var SumAppointments = HospitalSeeder.Appointments
            .Where(a => a.Status == AppointmentStatus.Completed)
            .Sum(a => a.Cost);
            #endregion

            #region Q9
            var DoctorsAveraget = HospitalSeeder.Doctors
            .Average(d => d.Salary);
            #endregion

            #region Q10
            var resultMax = HospitalSeeder.Rooms
                .Max(r => r.DailyRate);
            #endregion

            #region Q11
            var resultmin = HospitalSeeder.Medications
            .Min(m => m.PricePerUnit);
            #endregion

            #region Q12
            var resultcount = HospitalSeeder.Appointments
                .GroupBy(p => p.Status)
                .Select(p => new
                {
                    Status = p.Key,
                    Count = p.Count()
                })
                .ToList();
            #endregion

            #region Q13 //ابقي راجعه
            var resultCount = HospitalSeeder.Appointments
                   .GroupBy(a => a.DoctorId)
                   .Select(g => new
                   {
                       DoctorName = HospitalSeeder.Doctors
                           .First(d => d.Id == g.Key)
                           .Name,
                       TotalRevenue = g.Sum(a => a.Cost)
                   })
                   .ToList();
            #endregion

            #region Q14
            var specialties = HospitalSeeder.Doctors
                .Select(p => p.Specialty)
                .Distinct()
                .ToList();
            foreach (var specialty in specialties)
            {
                Console.WriteLine(specialty);
            }
            #endregion

            #region Q15 // مش مفهومه قوي
            var resultPatient = HospitalSeeder.Appointments
             .Where(a => a.IsEmergency)
             .Select(a => a.PatientId)
             .Distinct()
             .Join(HospitalSeeder.Patients,
                 patientId => patientId,
                 patient => patient.Id,
                 (patientId, patient) => new
                 {
                     patient.Name,
                     patient.Age
                 });
            #endregion

            #region Q16
            var resultDepartment = HospitalSeeder.Doctors
                 .GroupBy(p => p.DepartmentId)
                 .Where(g => g.All(p => p.IsAvailable))
                 .Select(g => g.Key)
                 .ToList();
            #endregion

            #region Q17
            var resultmany = HospitalSeeder.Patients
                .SelectMany(p => p.Appointments)
                .ToList();
            #endregion

            #region Q18
            var resultDoctors = HospitalSeeder.Appointments
             .Join(
                 HospitalSeeder.Doctors,
                 a => a.DoctorId,
                 d => d.Id,
                 (a, d) => $"{d.Name} - ${a.Cost} - {a.Date}"
             )
             .ToList();
            #endregion

            #region Q19
            var resultGroupgoin = HospitalSeeder.Departments
                .GroupJoin(
                 HospitalSeeder.Doctors,
                 dep => dep.Id,
                 d => d.DepartmentId,
                 (dep, d) => new
                 {
                     Department = dep.Name,
                     Docors = d.Select(p => p.Name)
                     .ToList()
                 }
                );

            #endregion

            #region Q20
            var patientLookup = HospitalSeeder.Patients.ToDictionary(
                p => p.Id,
                 p => p.Name
            );

            #endregion

            #region Q21
            var doctorAppointments = HospitalSeeder.Appointments.ToLookup(p => p.DoctorId);
            #endregion

            #region Q22
            #endregion// مش فاهمه

            #region Q23
            var batches = HospitalSeeder.Patients
              .Chunk(3)
              .ToList();
            #endregion

            #region Q24
            var ocrderbygender = HospitalSeeder
                .Patients
                .GroupBy(p => p.Gender)
                .Select(g => new
                {
                    Gender = g.Key,
                    Count = g.Count()
                })
                .ToList();
            #endregion

            #region Q25
            var resultMedications = HospitalSeeder.Medications
            .Where(m => !HospitalSeeder.Prescriptions.Any(p => p.MedicationId == m.Id))
                .ToList();
            #endregion

            #region Q26
            var resultintersect = HospitalSeeder.Appointments
                .Select(a => a.PatientId)
                .Intersect(HospitalSeeder.MedicalRecords
                .Select(m => m.PatientId));
            #endregion

            #region Q27
            var resultroom = HospitalSeeder.Rooms
                .Join(HospitalSeeder.Departments,
                 r => r.DepartmentId,
                 d => d.Id,
                 (r, d) => new
                 {
                     Room = r.RoomNumber,
                     Department = d.Name
                 }
                )
                .Where(r => r.Department == "Cardiology" || r.Department == "Neurology")
                .Select(d => d.Room)
                .Distinct()
                 .ToList();
            #endregion

            #region Q28
            var resultcpncat = HospitalSeeder.Doctors
                .Select(d => d.Name)
                .Concat(
                    HospitalSeeder.Nurses
                        .Select(n => n.Name)
                )
                .ToList();
            #endregion

            #region Q29
            var resultReverse = HospitalSeeder.Appointments
                .AsEnumerable()
                .Reverse()
                .ToList();
            #endregion

            #region Q30
            var resultappointment = HospitalSeeder.Appointments
                .OrderBy(a => a.Date)
                .SkipWhile(p => p.Status != AppointmentStatus.Cancelled);
            #endregion

            #region Q31
            var normalRunAudit = HospitalSeeder.Appointments
                .OrderBy(a => a.Date)
                .TakeWhile(p => p.Status != AppointmentStatus.Cancelled)
                .ToList();
            #endregion

            #region Q32
            var resultmedication = HospitalSeeder.Medications
                .OrderBy(p => p.PricePerUnit)
                .Skip(2)
                .FirstOrDefault();
            #endregion

            #region Q33
            var resultdepartment = HospitalSeeder.Departments
                .Where(d => d.Name == "Pediatrics")
                .SelectMany(n => n.Nurses)
                .Select(n => n.Name)
                .ToList();
            #endregion

            #region Q34
            var doctorNames = string.Join(",",
                HospitalSeeder.Doctors
                .Select(d => d.Name));
            #endregion

            #region Q35
            var resultdoctor = HospitalSeeder.Doctors
                .SingleOrDefault(d => d.Name == "Dr. Amina Hassan");
            #endregion

            #region Q36
            var latestPrescription = HospitalSeeder.Prescriptions
                .OrderByDescending(p => p.DateIssued)
                .FirstOrDefault();
            #endregion

            #region Q37
            var resultorderby = HospitalSeeder.Patients
                 .OrderBy(p => p.HasInsurance)
                 .ThenBy(p => p.Age)
                .ToList();
            #endregion

            #region Q38
            var departmentany = HospitalSeeder.Departments
                .Where(p => p.Rooms.Any(p => p.IsOccupied));
            #endregion

            #region Q39
            var resultorderbycount = HospitalSeeder.Departments
                .OrderByDescending(d => d.Doctors.Count)
                .ToList();
            #endregion

            #region Q40
            var resultappointments = HospitalSeeder.Appointments
                .Join(HospitalSeeder.Doctors,
                a => a.DoctorId,
                b => b.Id,
                (a, b) => new { a, b }
                )
                .Join(HospitalSeeder.Patients,
                a => a.a.PatientId,
                b => b.Id,
                (a, b) => new
                {
                    DoctorName = a.b.Name,
                    PatientName = b.Name
                }
                )
                 .Select(x => $"{x.DoctorName} treated {x.PatientName}");

            #endregion   // ابقي راجعه الفكره تاني 

            #region Q41
            var resultcounts = HospitalSeeder.Prescriptions
             .GroupBy(p => p.DoctorId)
             .Join(
                 HospitalSeeder.Doctors,
                 g => g.Key,
                 d => d.Id,
                 (g, d) => $"{d.Name}: {g.Sum(p => p.Quantity)} units total"
             )
             .ToList();
            #endregion

            #region Q42 //  راجع الكود
            var resultgroupby = HospitalSeeder.Appointments
                .GroupBy(a => new
                {
                    a.DoctorId,
                    a.Status
                })
                .Select(g => new
                {
                    DoctorId = g.Key.DoctorId,
                    Status = g.Key.Status,
                    Count = g.Count()
                })
                .ToList();

            #endregion

            #region Q43
            var resulttotal = HospitalSeeder.Patients
                .Aggregate(0.0, (total, p) => total + p.OutstandingBalance);
            #endregion

            #region Q44
            var maxpatient = HospitalSeeder.Patients
                .MaxBy(p => p.OutstandingBalance);
            #endregion

            #region Q45
            var resultminby = HospitalSeeder.Doctors
                .MinBy(p => p.YearsOfExperience);
            #endregion

            #region 46
            var resultdoctors = HospitalSeeder.Doctors
             .Join(
                HospitalSeeder.Departments,
                 d => d.DepartmentId,
                 dep => dep.Id,
                 (d, dep) => new
                 {
                     DepartmentName = dep.Name
                 }
             )
             .GroupBy(d => d.DepartmentName)
             .Where(g => g.Count() > 1)
             .Select(g => new
             {
                 DepartmentName = g.Key,
                 Doctorcount = g.Count()
             });
            #endregion

            #region 47
            var resultmedicalrecord = HospitalSeeder.Patients
                .GroupJoin(HospitalSeeder.MedicalRecords,
                 p => p.Id,
                 m => m.PatientId,
                 (p, m) => new
                 {
                     PatientName = p.Name,
                     RecordCount = m.Count()
                 }
                )
                .ToList();

            #endregion

            #region 48
            var resultjoins = HospitalSeeder.Prescriptions
                .Join(HospitalSeeder.Patients,
                 p => p.PatientId,
                 t => t.Id,
                 (p, t) => new
                 {
                     p,
                     PatientName = t.Name
                 }
                )
                .Join(HospitalSeeder.Doctors,
                 m => m.p.DoctorId,
                 s => s.Id,
                 (m, s) => new
                 {
                     m.p,
                     m.PatientName,
                     DoctorName = s.Name,
                 }
                )
                .Join(HospitalSeeder.Medications,
                 f => f.p.MedicationId,
                 v => v.Id,
                (f, v) =>
                {
                    return $"{f.PatientName} - prescribed {v.Name} by {f.DoctorName}";
                }
                );
            #endregion

            #region 49
            var roomcount = HospitalSeeder.Rooms
                .GroupBy(r => r.Type)
                .ToDictionary(
                    g => g.Key,
                    g => g.Count()
                );
            #endregion

            #region 50
            var fristspecialty = HospitalSeeder.Doctors
                 .GroupBy(g => g.Specialty)
                 .Select(g => g.First());
            #endregion

            #region 51
            var resultDcoandner = HospitalSeeder.Departments
                .Where(d => d.Doctors.Any(doc => doc.YearsOfExperience > 5)
                && d.Nurses.All(n => n.IsOnDuty)
                )
                .Select(d => d.Name)
                .ToList();


            #endregion

            #region 52
            var resul = HospitalSeeder.Appointments
                .Where(a => a.Status == AppointmentStatus.Completed && a.Cost > 500)
                .Join(HospitalSeeder.Doctors,
                a => a.DoctorId,
                b => b.Id,
                (a, b) => new
                {
                    DoctorName = b.Name,
                    Appointmentcost = a.Cost,
                    Appointment = a
                }
                )
                .Join(HospitalSeeder.Patients,
                 x => x.Appointment.PatientId,
                 m => m.Id,
                 (a, b) => new
                 {
                     a.DoctorName,
                     a.Appointmentcost,
                     PatientName = b.Name
                 }
                )
                .OrderByDescending(x => x.Appointmentcost)
                .ToList();
            #endregion

            #region 53
            var resiltlink = HospitalSeeder.Appointments
                .Join(HospitalSeeder.Doctors,
                a => a.DoctorId,
                b => b.Id,
                (a, b) => new
                {
                    Appointment = a,
                    DoctorName = b.Name,
                    AppointmentCost = a.Cost,
                    AppointmentDate = a.Date
                }
                )
                .Join(HospitalSeeder.Patients,
                x => x.Appointment.PatientId,
                p => p.Id,
                (x, p) => new
                {
                    Appointment = x.Appointment,
                    DoctorName = x.DoctorName,
                    AppointmentCost = x.AppointmentCost,
                    AppointmentDate = x.AppointmentDate,
                    PatientName = p.Name
                }
                )
                .Join(HospitalSeeder.Rooms,
                 x => x.Appointment.RoomId,
                 y => y.Id,
                 (x, y) => new
                 {
                     Appointment = x.Appointment,
                     DoctorName = x.DoctorName,
                     AppointmentCost = x.AppointmentCost,
                     AppointmentDate = x.AppointmentDate,
                     PatientName = x.PatientName,
                     RoomNumber = y.RoomNumber
                 }
                );
            #endregion

            #region 54 //by help Ai
            var resultgroup = HospitalSeeder.Appointments
                .Join(HospitalSeeder.Doctors,
                 a => a.DoctorId,
                p => p.Id,
                (a, p) => new
                {
                    Appointment = a,
                    DepartmentId = p.DepartmentId,
                }
                )
               .Join(
                 HospitalSeeder.Departments,
                 x => x.DepartmentId,
                 dep => dep.Id,
                 (x, dep) => new
                 {
                     DepartmentName = dep.Name,
                     Status = x.Appointment.Status
                 }
                )
               .GroupBy(x => x.DepartmentName)
               .Select(g => new
               {
                   DDepartment = g.Key,
                   StatusCounts = g
                       .GroupBy(x => x.Status)
                       .Select(s => new
                       {
                           Status = s.Key,
                           Count = s.Count()
                       })
                  .ToList()
               })
            .ToList();
            #endregion

            #region 55
            Double runningTotal = 0;
            var resultrunningtotal = HospitalSeeder.Patients
            .Select(P =>
            {
                runningTotal += P.OutstandingBalance;
                return new
                {
                    PatientName = P.Name,
                    OutstandingBalance = P.OutstandingBalance,
                    RunningTotal = runningTotal
                };
            }).ToList();


            #endregion

            #region 56
            var resultPrescriptions = HospitalSeeder.Prescriptions
                .Join(HospitalSeeder.Doctors,
                x => x.DoctorId,
                y => y.Id,
                (x, y) => new
                {
                    prescriptions = x,
                    Doctors = y
                }
                )
                .Join(HospitalSeeder.Departments,
                 p => p.Doctors.DepartmentId,
                    d => d.Id,
                (p, d) => new
                {
                    prescriptions = p.prescriptions,
                    DepartmentName = d.Name
                })
                .Join(HospitalSeeder.Medications,
                 m => m.prescriptions.MedicationId,
                 y => y.Id,
                 (m, y) => new
                 {
                     MedicationName = y.Name,
                     DepartmentName = m.DepartmentName
                 }

                )
                .ToList();
            #endregion

            #region 57
            var PatientsIdentification = HospitalSeeder.Patients
                .Where(p => !HospitalSeeder.Prescriptions
                .Any(pr => pr.PatientId == p.Id)
                )
              .ToList();
            #endregion

            #region 58
            var resultEmergency = HospitalSeeder.Doctors
                .Where(d => HospitalSeeder.Departments
                .Any(p => p.Id == d.DepartmentId && p.Name == "Cardiology")
                &&
                HospitalSeeder.Appointments
                .Any(a => a.DoctorId == d.Id
                && a.IsEmergency == true)

                )
                 .Select(d => d.Name)
                 .ToList();
            #endregion

            #region 59
            var resultofconcat = HospitalSeeder.Doctors
                .Select(d => new
                {
                    Name = d.Name,
                    DepartmentId = d.DepartmentId,
                })
                .Concat(HospitalSeeder.Nurses
                 .Select(n => new
                 {
                     Name = n.Name,
                     DepartmentId = n.DepartmentId,
                 })

                )
                .Distinct()
                .ToList();

            #endregion

            #region 60 // by help Ai
            var resulyzip = HospitalSeeder.Appointments
                .Select(a => a.Date);
            var resultofroom = HospitalSeeder.Appointments
            .Join(HospitalSeeder.Rooms,
             r => r.RoomId,
             x => x.Id,
             (x, y) => new
             {
                 y.RoomNumber,
             }

            );
            var costs = HospitalSeeder.Appointments
                .Select(c => c.Cost);
            var resultzips = resulyzip.Zip(resultofroom,
                (Date, RoomNumber) => new
                {
                    date = Date,
                    roomnumber = RoomNumber
                }
                )
             .Zip(costs,
              (x, cost) => $"{x.date:yyyy-MM-dd} | Room {x.roomnumber} | ${cost}"

             );
            #endregion

            #region 61
            var resultchunks = HospitalSeeder.Patients
                .Chunk(3)
                .Select((b, index) => new
                {
                    batchnumber = index + 1,
                    totalbalance = b.Sum(p => p.OutstandingBalance),
                })
                .ToList();
            #endregion

            #region 62
            var resultspicalisty = HospitalSeeder.Doctors
                .GroupBy(s => s.Specialty)
                .Select(g => new
                {
                    Specialty = g.Key,
                    count = g.Count(),
                })
                .OrderByDescending(x => x.count)
                .ToList();
            #endregion

            #region 63
            var resultde = HospitalSeeder.Departments
            .Select(dep => new
            {
                DepartmentName = dep.Name,
                ren = HospitalSeeder.Doctors
                .Where(d => d.DepartmentId == dep.Id)
                .SelectMany(a => HospitalSeeder.Appointments
                .Where(s => s.DoctorId == a.Id &&
                            s.Status == AppointmentStatus.Completed)
                )
                 .Sum(s => s.Cost)
            }
            )
            .ToList();
            #endregion

            #region 64
            var calculitingofdoctor = HospitalSeeder.Doctors
                .Select(d => new
                {
                    DoctorName = d.Name,
                    YearsOfExperience = d.YearsOfExperience,

                    appinofdoctor = HospitalSeeder.Appointments
                    .Where(a => a.DoctorId == d.Id && a.Status == AppointmentStatus.Completed)
                    .Sum(s => s.Cost)
                })
                .OrderByDescending(s => s.appinofdoctor)
                .ThenBy(e => e.YearsOfExperience)
                .ToList();


            #endregion

            #region 65
            var doctorRevenue = HospitalSeeder.Doctors
                .Select(d => new
                {
                    Doctor = d,
                    Revenues = HospitalSeeder.Appointments
                     .Where(a => a.DoctorId == d.Id &&
                      a.Status == AppointmentStatus.Completed)
                     .Sum(s => s.Cost)
                })
                .OrderByDescending(r => r.Revenues)
                .ThenByDescending(d => d.Doctor.YearsOfExperience);
            #endregion

            #region 66
            var doctoraverage = HospitalSeeder.Doctors
                .Select(d => new
                {
                    Doctor = d,
                    RevenuesAvg = HospitalSeeder.Appointments
                    .Where(a => a.DoctorId == d.Id && a.Status == AppointmentStatus.Completed)
                    .Average(a => a.Cost)
                })
                .OrderByDescending(r => r.RevenuesAvg)
                .Take(3);
            #endregion

            #region 67 // by help Ai
            var reoomstype = HospitalSeeder.Departments
                  .Select(d => new
                  {
                      Department = d.Name,
                      Rooms = HospitalSeeder.Rooms
                          .Where(r => r.DepartmentId == d.Id && r.IsOccupied)
                          .GroupBy(r => r.Type)
                          .Select(g => new
                          {
                              RoomType = g.Key,
                              Count = g.Count()
                          })
                  });

            #endregion

            #region 68 
            var Avg = HospitalSeeder.Appointments
                .Aggregate(new
                {
                    totalcost = 0.0,
                    emergencycount = 0,
                    cancelledcount = 0
                },
                 (summary, appointment) => new
                 {
                     totalcost = summary.totalcost + appointment.Cost,

                     emergencycount = summary.emergencycount + (appointment.IsEmergency ? 1 : 0),

                     cancelledcount = summary.cancelledcount +
                 (appointment.Status == AppointmentStatus.Cancelled ? 1 : 0)
                 }
                );
            #endregion

            #region 69
            var resultappoiment = HospitalSeeder.Appointments
                .GroupBy(a => a.PatientId)
                .Where(g => g.Count() > 1)
                .Select(g => new
                {
                    Patientname = HospitalSeeder.Patients
                    .First(p => p.Id == g.Key)
                    .Name,

                    TotalOutstandingBalance = HospitalSeeder.Patients
                    .First(p => p.Id == g.Key)
                    .OutstandingBalance,
                    mostrecenatppointment = g.Max(p => p.Date),
                })
                .ToList();
            #endregion

            #region 70
            var departmentSummary = HospitalSeeder.Departments
                .Select(d => new
                {
                    Department = d.Name,

                    roomcapacityvalue = HospitalSeeder.Rooms
                    .Where(r => r.Id == d.Id)
                    .Select(doc => new
                    {
                        Doctor = doc,
                        Revenueappi = HospitalSeeder.Appointments
                        .Where(a => a.DoctorId == doc.Id && a.Status == AppointmentStatus.Completed)
                        .Sum(a => a.Cost)

                    })
                })
                .OrderByDescending(rcv => rcv.roomcapacityvalue)
                .Take(3)
                .ToList();
            #endregion
        }
        #endregion
    }
}
