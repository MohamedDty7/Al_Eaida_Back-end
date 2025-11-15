# Al-Eaida Backend API Documentation

## Base URL
```
https://localhost:7000/api
```

## Authentication
جميع الـ endpoints تتطلب JWT authentication:
```
Authorization: Bearer <your-jwt-token>
```

---

## 1. Authentication APIs

### Register User
**POST** `/auth/register`

**Request Model:**
```json
{
  "username": "ahmed123",
  "email": "ahmed@example.com",
  "password": "password123",
  "phone": "01234567890",
  "address": "القاهرة، مصر",
  "role": ["User"]
}
```

**Response Model:**
```json
{
  "token": "jwt-token-here",
  "refresh": "refresh-token-here",
  "user": {
    "id": "user-id",
    "email": "ahmed@example.com",
    "userName": "ahmed123",
    "phone": "01234567890",
    "role": ["User"],
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z",
    "lastLoginAt": null
  }
}
```

### Login
**POST** `/auth/login`

**Request Model:**
```json
{
  "email": "ahmed@example.com",
  "password": "password123"
}
```

**Response Model:**
```json
{
  "token": "jwt-token-here",
  "refresh": "refresh-token-here",
  "user": {
    "id": "user-id",
    "email": "ahmed@example.com",
    "userName": "ahmed123",
    "phone": "01234567890",
    "role": ["User"],
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z",
    "lastLoginAt": "2024-01-15T10:30:00Z"
  }
}
```

### Refresh Token
**POST** `/auth/refresh-token`

**Request Model:**
```json
{
  "token": "jwt-token-here",
  "refreshToken": "refresh-token-here"
}
```

---

## 2. User Management APIs

### Get All Users
**GET** `/auth/getallusers`

**Response Model:**
```json
[
  {
    "id": "user-id",
    "email": "user@example.com",
    "userName": "username",
    "phone": "1234567890",
    "role": ["Admin", "Doctor"],
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z",
    "lastLoginAt": "2024-01-15T10:30:00Z"
  }
]
```

### Get User by ID
**GET** `/auth/getbyid/{id}`

**Response Model:**
```json
{
  "id": "user-id",
  "email": "user@example.com",
  "userName": "username",
  "phone": "1234567890",
  "role": ["Admin"],
  "isActive": true,
  "createdAt": "2024-01-01T00:00:00Z",
  "lastLoginAt": "2024-01-15T10:30:00Z"
}
```

### Update User
**PUT** `/auth/UpDate/{userId}`

**Request Model:**
```json
{
  "userName": "newusername",
  "email": "newemail@example.com",
  "phone": "9876543210",
  "address": "New Address"
}
```

### Delete User
**DELETE** `/auth/Delete/{userId}`

### Change Password
**PUT** `/auth/ChangePasseword/{userId}/change-password`

**Request Model:**
```json
{
  "currentPassword": "oldpassword",
  "newPassword": "newpassword123",
  "confirmPassword": "newpassword123"
}
```

### Get Users by Role
**GET** `/auth/users/role/{role}`

### Get Users by Status
**GET** `/auth/users/status/{isActive}`

### Toggle User Status
**PUT** `/auth/users/{userId}/toggle-status`

---

## 3. Patient Management APIs

### Get All Patients
**GET** `/Patient/GetAllPatients`

**Response Model:**
```json
[
  {
    "id": "patient-id",
    "fullName": "أحمد محمد",
    "email": "ahmed@example.com",
    "phone": "01234567890",
    "dateOfBirth": "1990-01-01T00:00:00Z",
    "gender": "Male",
    "address": "القاهرة، مصر",
    "emergencyContact": "01234567891",
    "insuranceInfo": "تأمين صحي",
    "medicalHistory": "لا توجد أمراض مزمنة",
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z"
  }
]
```

### Get Patient by ID
**GET** `/Patient/GetPatientById/{id}`

### Create Patient
**POST** `/Patient/CreatePatient`

**Request Model:**
```json
{
  "fullName": "أحمد محمد",
  "email": "ahmed@example.com",
  "phone": "01234567890",
  "dateOfBirth": "1990-01-01T00:00:00Z",
  "gender": "Male",
  "address": "القاهرة، مصر",
  "emergencyContact": "01234567891",
  "insuranceInfo": "تأمين صحي",
  "medicalHistory": "لا توجد أمراض مزمنة"
}
```

### Update Patient
**PUT** `/Patient/UpdatePatient/{id}`

### Delete Patient
**DELETE** `/Patient/DeletePatient/{id}`

---

## 4. Doctor Management APIs

### Get All Doctors
**GET** `/Doctor/GetAllDoctors`

**Response Model:**
```json
[
  {
    "id": "doctor-id",
    "userId": "user-id",
    "firstName": "سارة",
    "lastName": "أحمد",
    "email": "sara@example.com",
    "phone": "01987654321",
    "specialization": "أمراض القلب",
    "licenseNumber": "DOC123456",
    "medicalSchool": "كلية الطب - جامعة القاهرة",
    "yearsOfExperience": 10,
    "bio": "طبيبة قلب متخصصة",
    "profileImage": "profile.jpg",
    "startTime": "09:00:00",
    "endTime": "17:00:00",
    "maxPatientsPerDay": 20,
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z"
  }
]
```

### Get Doctor by ID
**GET** `/Doctor/GetDoctorById/{id}`

### Create Doctor
**POST** `/Doctor/CreateDoctor`

### Update Doctor
**PUT** `/Doctor/UpdateDoctor/{id}`

### Delete Doctor
**DELETE** `/Doctor/DeleteDoctor/{id}`

---

## 5. Appointment Management APIs

### Get All Appointments (with Patient & Doctor Names)
**GET** `/Appointment/GetAllAppointments`

**Response Model:**
```json
{
  "message": "تم استرجاع المواعيد مع تفاصيل المرضى والأطباء بنجاح",
  "appointments": [
    {
      "id": "appointment-id",
      "appointmentDate": "2024-01-20T10:00:00Z",
      "notes": "موعد طبي عادي",
      "time": "10:00 AM",
      "status": "Scheduled",
      "patientId": "patient-id",
      "patientName": "أحمد محمد",
      "doctorId": "doctor-id",
      "doctorName": "د. سارة أحمد",
      "userID": "user-id"
    }
  ]
}
```

### Get Appointment by ID
**GET** `/Appointment/GetAppointmentById/{id}`

### Create Appointment (Simple)
**POST** `/Appointment/CreateAppointment`

**Request Model:**
```json
{
  "appointmentDate": "2024-01-20T10:00:00Z",
  "notes": "موعد طبي عادي",
  "time": "10:00 AM",
  "patientId": "patient-id",
  "doctorId": "doctor-id",
  "userID": "user-id"
}
```

### Create Appointment with Details
**POST** `/Appointment/CreateAppointmentWithDetails`

**Request Model:**
```json
{
  "appointmentDate": "2024-01-20T10:00:00Z",
  "notes": "موعد طبي عادي",
  "time": "10:00 AM",
  "patientId": "patient-id",
  "doctorId": "doctor-id",
  "userID": "user-id"
}
```

**Response Model:**
```json
{
  "message": "تم إنشاء الموعد بنجاح مع تفاصيل المريض والطبيب",
  "appointment": {
    "id": "appointment-id",
    "appointmentDate": "2024-01-20T10:00:00Z",
    "notes": "موعد طبي عادي",
    "time": "10:00 AM",
    "status": "Scheduled",
    "patientId": "patient-id",
    "patientName": "أحمد محمد",
    "doctorId": "doctor-id",
    "doctorName": "د. سارة أحمد",
    "userID": "user-id"
  }
}
```

### Update Appointment
**PUT** `/Appointment/UpdateAppointment/{id}`

### Delete Appointment
**DELETE** `/Appointment/DeleteAppointment/{id}`

### Get Appointments by Patient
**GET** `/Appointment/GetAppointmentsByPatient/{patientId}`

### Get Appointments by Doctor
**GET** `/Appointment/GetAppointmentsByDoctor/{doctorId}`

### Get Appointments by Date Range
**GET** `/Appointment/GetAppointmentsByDateRange?startDate=2024-01-01&endDate=2024-01-31`

### Get Appointments by Status
**GET** `/Appointment/GetAppointmentsByStatus/{status}`

**Status Values:**
- `Scheduled` - مجدول
- `Confirmed` - مؤكد
- `InProgress` - قيد التنفيذ
- `Completed` - مكتمل
- `Cancelled` - ملغي
- `NoShow` - لم يحضر

---

## 6. Medicine Management APIs

### Get All Medicines
**GET** `/Medicine/GetAllMedicines`

**Response Model:**
```json
[
  {
    "id": "medicine-id",
    "name": "باراسيتامول",
    "description": "مسكن للآلام",
    "dosage": "500mg",
    "manufacturer": "شركة الأدوية",
    "price": 25.50,
    "stockQuantity": 100,
    "expiryDate": "2025-12-31T00:00:00Z",
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z"
  }
]
```

### Get Medicine by ID
**GET** `/Medicine/GetMedicineById/{id}`

### Create Medicine
**POST** `/Medicine/CreateMedicine`

### Update Medicine
**PUT** `/Medicine/UpdateMedicine/{id}`

### Delete Medicine
**DELETE** `/Medicine/DeleteMedicine/{id}`

---

## 7. Prescription Management APIs

### Get All Prescriptions
**GET** `/Prescription/GetAllPrescriptions`

**Response Model:**
```json
[
  {
    "id": "prescription-id",
    "patientId": "patient-id",
    "doctorId": "doctor-id",
    "prescriptionDate": "2024-01-20T10:00:00Z",
    "notes": "تناول الدواء بعد الأكل",
    "isActive": true,
    "createdAt": "2024-01-20T10:00:00Z"
  }
]
```

### Get Prescription by ID
**GET** `/Prescription/GetPrescriptionById/{id}`

### Create Prescription
**POST** `/Prescription/CreatePrescription`

### Update Prescription
**PUT** `/Prescription/UpdatePrescription/{id}`

### Delete Prescription
**DELETE** `/Prescription/DeletePrescription/{id}`

---

## 8. Medical Visit Management APIs

### Get All Medical Visits
**GET** `/MedicalVisit/GetAllMedicalVisits`

**Response Model:**
```json
[
  {
    "id": "visit-id",
    "patientId": "patient-id",
    "doctorId": "doctor-id",
    "visitDate": "2024-01-20T10:00:00Z",
    "diagnosis": "ضغط دم مرتفع",
    "treatment": "تناول الدواء الموصوف",
    "notes": "متابعة بعد أسبوع",
    "isActive": true,
    "createdAt": "2024-01-20T10:00:00Z"
  }
]
```

### Get Medical Visit by ID
**GET** `/MedicalVisit/GetMedicalVisitById/{id}`

### Create Medical Visit
**POST** `/MedicalVisit/CreateMedicalVisit`

### Update Medical Visit
**PUT** `/MedicalVisit/UpdateMedicalVisit/{id}`

### Delete Medical Visit
**DELETE** `/MedicalVisit/DeleteMedicalVisit/{id}`

---

## 9. Invoice Management APIs

### Get All Invoices
**GET** `/Invoice/GetAllInvoices`

**Response Model:**
```json
[
  {
    "id": "invoice-id",
    "patientId": "patient-id",
    "invoiceDate": "2024-01-20T10:00:00Z",
    "totalAmount": 150.00,
    "status": "Paid",
    "notes": "فاتورة موعد طبي",
    "isActive": true,
    "createdAt": "2024-01-20T10:00:00Z"
  }
]
```

### Get Invoice by ID
**GET** `/Invoice/GetInvoiceById/{id}`

### Create Invoice
**POST** `/Invoice/CreateInvoice`

### Update Invoice
**PUT** `/Invoice/UpdateInvoice/{id}`

### Delete Invoice
**DELETE** `/Invoice/DeleteInvoice/{id}`

---

## 10. Specialization Management APIs

### Get All Specializations
**GET** `/Specialization/GetAllSpecializations`

**Response Model:**
```json
[
  {
    "id": "specialization-id",
    "name": "أمراض القلب",
    "description": "تخصص في علاج أمراض القلب والأوعية الدموية",
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z"
  }
]
```

### Get Specialization by ID
**GET** `/Specialization/GetSpecializationById/{id}`

### Create Specialization
**POST** `/Specialization/CreateSpecialization`

### Update Specialization
**PUT** `/Specialization/UpdateSpecialization/{id}`

### Delete Specialization
**DELETE** `/Specialization/DeleteSpecialization/{id}`

---

## 11. Doctor Schedule Management APIs

### Get All Doctor Schedules
**GET** `/DoctorSchedule/GetAllDoctorSchedules`

**Response Model:**
```json
[
  {
    "id": "schedule-id",
    "doctorId": "doctor-id",
    "dayOfWeek": "Monday",
    "startTime": "09:00:00",
    "endTime": "17:00:00",
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z"
  }
]
```

### Get Doctor Schedule by ID
**GET** `/DoctorSchedule/GetDoctorScheduleById/{id}`

### Create Doctor Schedule
**POST** `/DoctorSchedule/CreateDoctorSchedule`

### Update Doctor Schedule
**PUT** `/DoctorSchedule/UpdateDoctorSchedule/{id}`

### Delete Doctor Schedule
**DELETE** `/DoctorSchedule/DeleteDoctorSchedule/{id}`

---

## 12. Clinic Settings APIs

### Get All Clinic Settings
**GET** `/ClinicSettings/GetAllClinicSettings`

**Response Model:**
```json
[
  {
    "id": "setting-id",
    "settingName": "اسم العيادة",
    "settingValue": "عيادة الأمل الطبية",
    "description": "اسم العيادة الرسمي",
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z"
  }
]
```

### Get Clinic Setting by ID
**GET** `/ClinicSettings/GetClinicSettingById/{id}`

### Create Clinic Setting
**POST** `/ClinicSettings/CreateClinicSetting`

### Update Clinic Setting
**PUT** `/ClinicSettings/UpdateClinicSetting/{id}`

### Delete Clinic Setting
**DELETE** `/ClinicSettings/DeleteClinicSetting/{id}`

---

## 13. System Settings APIs

### Get All System Settings
**GET** `/SystemSettings/GetAllSystemSettings`

**Response Model:**
```json
[
  {
    "id": "setting-id",
    "settingName": "نظام العمل",
    "settingValue": "24/7",
    "settingType": "OperatingHours",
    "description": "ساعات عمل النظام",
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z"
  }
]
```

### Get System Setting by ID
**GET** `/SystemSettings/GetSystemSettingById/{id}`

### Create System Setting
**POST** `/SystemSettings/CreateSystemSetting`

### Update System Setting
**PUT** `/SystemSettings/UpdateSystemSetting/{id}`

### Delete System Setting
**DELETE** `/SystemSettings/DeleteSystemSetting/{id}`

---

## 14. Financial Report APIs

### Get All Financial Reports
**GET** `/FinancialReport/GetAllFinancialReports`

**Response Model:**
```json
[
  {
    "id": "report-id",
    "reportDate": "2024-01-20T00:00:00Z",
    "totalRevenue": 5000.00,
    "consultationFees": 3000.00,
    "medicationSales": 1500.00,
    "otherServices": 500.00,
    "totalExpenses": 2000.00,
    "netProfit": 3000.00,
    "isActive": true,
    "createdAt": "2024-01-20T00:00:00Z"
  }
]
```

### Get Financial Report by ID
**GET** `/FinancialReport/GetFinancialReportById/{id}`

### Create Financial Report
**POST** `/FinancialReport/CreateFinancialReport`

### Update Financial Report
**PUT** `/FinancialReport/UpdateFinancialReport/{id}`

### Delete Financial Report
**DELETE** `/FinancialReport/DeleteFinancialReport/{id}`

---

## 15. Report Management APIs

### Get All Reports
**GET** `/Report/GetAllReports`

**Response Model:**
```json
[
  {
    "id": "report-id",
    "reportName": "تقرير المرضى",
    "reportType": "PatientReport",
    "reportData": "JSON data here",
    "generatedDate": "2024-01-20T10:00:00Z",
    "isActive": true,
    "createdAt": "2024-01-20T10:00:00Z"
  }
]
```

### Get Report by ID
**GET** `/Report/GetReportById/{id}`

### Create Report
**POST** `/Report/CreateReport`

### Update Report
**PUT** `/Report/UpdateReport/{id}`

### Delete Report
**DELETE** `/Report/DeleteReport/{id}`

---

## 16. Audit Log APIs

### Get All Audit Logs
**GET** `/AuditLog/GetAllAuditLogs`

**Response Model:**
```json
[
  {
    "id": "log-id",
    "userId": "user-id",
    "action": "Create",
    "entityType": "Patient",
    "entityId": "patient-id",
    "oldValues": null,
    "newValues": "{\"name\":\"أحمد محمد\"}",
    "timestamp": "2024-01-20T10:00:00Z",
    "ipAddress": "192.168.1.1",
    "userAgent": "Mozilla/5.0..."
  }
]
```

### Get Audit Log by ID
**GET** `/AuditLog/GetAuditLogById/{id}`

---

## Common Response Models

### Success Response
```json
{
  "message": "تمت العملية بنجاح",
  "data": { /* response data */ }
}
```

### Error Response
```json
{
  "message": "حدث خطأ أثناء تنفيذ العملية",
  "errors": ["خطأ 1", "خطأ 2"]
}
```

### Pagination Response
```json
{
  "data": [ /* array of items */ ],
  "totalCount": 100,
  "pageNumber": 1,
  "pageSize": 10,
  "totalPages": 10
}
```

---

## Status Codes

- `200` - OK (نجح)
- `201` - Created (تم الإنشاء)
- `400` - Bad Request (طلب غير صحيح)
- `401` - Unauthorized (غير مصرح)
- `403` - Forbidden (ممنوع)
- `404` - Not Found (غير موجود)
- `500` - Internal Server Error (خطأ في الخادم)

---

## Notes

1. جميع التواريخ في تنسيق ISO 8601 (UTC)
2. جميع الرسائل باللغة العربية
3. جميع الـ endpoints تتطلب authentication
4. يمكن استخدام query parameters للفلترة والترتيب
5. جميع الـ IDs من نوع GUID
6. الـ pagination متاح لجميع الـ GET endpoints

---

## Frontend Integration Examples

### JavaScript/Fetch Example
```javascript
// Get all appointments
const response = await fetch('https://localhost:7000/api/Appointment/GetAllAppointments', {
  headers: {
    'Authorization': 'Bearer ' + token,
    'Content-Type': 'application/json'
  }
});
const data = await response.json();
```

### Axios Example
```javascript
// Create appointment
const appointment = await axios.post('https://localhost:7000/api/Appointment/CreateAppointmentWithDetails', {
  appointmentDate: '2024-01-20T10:00:00Z',
  notes: 'موعد طبي عادي',
  time: '10:00 AM',
  patientId: 'patient-id',
  doctorId: 'doctor-id',
  userID: 'user-id'
}, {
  headers: {
    'Authorization': 'Bearer ' + token
  }
});
```
