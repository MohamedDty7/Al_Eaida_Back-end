# قائمة شاملة لجميع API Endpoints

## Base URL
```
https://localhost:7246/api
```

---

## 1. Authentication Controller (`/api/Auth`)

### **POST** `/api/Auth/register`
- **الوصف:** تسجيل مستخدم جديد في النظام
- **المدخلات:** RegisterRequestDto (username, email, password, phone, address, role)
- **المخرجات:** AuthResponseDto (token, refresh, user data)

### **POST** `/api/Auth/login`
- **الوصف:** تسجيل دخول المستخدم
- **المدخلات:** LoginDto (email, password)
- **المخرجات:** AuthResponseDto (token, refresh, user data)

### **POST** `/api/Auth/refresh-token`
- **الوصف:** تجديد JWT token باستخدام refresh token
- **المدخلات:** RefreshTokenRequestDto (token, refreshToken)
- **المخرجات:** AuthResponseDto (new token, refresh, user data)

### **GET** `/api/Auth/getallusers`
- **الوصف:** الحصول على جميع المستخدمين مع الأدوار والحالة
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من UserDTO مع الأدوار والحالة

### **GET** `/api/Auth/getbyid/{id}`
- **الوصف:** الحصول على مستخدم محدد بالمعرف
- **المدخلات:** id (string)
- **المخرجات:** UserDTO مع الأدوار والحالة

### **GET** `/api/Auth/users/role/{role}`
- **الوصف:** الحصول على المستخدمين حسب الدور
- **المدخلات:** role (string)
- **المخرجات:** قائمة من UserDTO

### **GET** `/api/Auth/users/status/{isActive}`
- **الوصف:** الحصول على المستخدمين حسب الحالة (نشط/غير نشط)
- **المدخلات:** isActive (bool)
- **المخرجات:** قائمة من UserDTO

### **GET** `/api/Auth/users/role/{role}/status/{isActive}`
- **الوصف:** الحصول على المستخدمين حسب الدور والحالة
- **المدخلات:** role (string), isActive (bool)
- **المخرجات:** قائمة من UserDTO

### **PUT** `/api/Auth/users/{userId}/toggle-status`
- **الوصف:** تبديل حالة المستخدم (نشط/غير نشط)
- **المدخلات:** userId (string)
- **المخرجات:** رسالة نجاح مع الحالة الجديدة

### **PUT** `/api/Auth/users/{userId}/set-status`
- **الوصف:** تعيين حالة المستخدم
- **المدخلات:** userId (string), SetUserStatusRequest (IsActive)
- **المخرجات:** رسالة نجاح مع الحالة الجديدة

### **GET** `/api/Auth/users/{userId}/with-roles`
- **الوصف:** الحصول على مستخدم محدد مع أدواره
- **المدخلات:** userId (string)
- **المخرجات:** UserDTO مع الأدوار

### **GET** `/api/Auth/users/with-roles`
- **الوصف:** الحصول على جميع المستخدمين مع أدوارهم
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من UserDTO مع الأدوار

### **PUT** `/api/Auth/UpDate/{userId}`
- **الوصف:** تحديث بيانات المستخدم
- **المدخلات:** userId (string), UpdateUserDto
- **المخرجات:** رسالة نجاح مع بيانات المستخدم المحدثة

### **DELETE** `/api/Auth/Delete/{userId}`
- **الوصف:** حذف مستخدم من النظام
- **المدخلات:** userId (string)
- **المخرجات:** رسالة نجاح

### **PUT** `/api/Auth/ChangePasseword/{userId}/change-password`
- **الوصف:** تغيير كلمة مرور المستخدم
- **المدخلات:** userId (string), ChangePasswordDto
- **المخرجات:** رسالة نجاح

---

## 2. Appointment Controller (`/api/Appointment`)

### **POST** `/api/Appointment/CreateAppointment`
- **الوصف:** إنشاء موعد طبي جديد
- **المدخلات:** CreateAppointmentDto
- **المخرجات:** رسالة نجاح

### **POST** `/api/Appointment/CreateAppointmentWithDetails`
- **الوصف:** إنشاء موعد طبي مع تفاصيل المريض والطبيب
- **المدخلات:** CreateAppointmentWithDetailsDto
- **المخرجات:** رسالة نجاح مع بيانات الموعد

### **GET** `/api/Appointment/GetAllAppointments`
- **الوصف:** الحصول على جميع المواعيد مع تفاصيل المرضى والأطباء
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من AppointmentWithDetailsDto

### **GET** `/api/Appointment/GetAppointmentById/{id}`
- **الوصف:** الحصول على موعد محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** AppointmentDto

### **PUT** `/api/Appointment/UpdateAppointment/{id}`
- **الوصف:** تحديث موعد طبي
- **المدخلات:** id (Guid), UpdateAppointmentDto
- **المخرجات:** AppointmentDto المحدث

### **DELETE** `/api/Appointment/DeleteAppointment/{id}`
- **الوصف:** حذف موعد طبي
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

### **GET** `/api/Appointment/GetAppointmentsByPatient/{patientId}`
- **الوصف:** الحصول على مواعيد مريض محدد
- **المدخلات:** patientId (Guid)
- **المخرجات:** قائمة من AppointmentDto

### **GET** `/api/Appointment/GetAppointmentsByDoctor/{doctorId}`
- **الوصف:** الحصول على مواعيد طبيب محدد
- **المدخلات:** doctorId (Guid)
- **المخرجات:** قائمة من AppointmentDto

### **GET** `/api/Appointment/GetAppointmentsByDateRange`
- **الوصف:** الحصول على المواعيد في نطاق تاريخ محدد
- **المدخلات:** startDate (DateTime), endDate (DateTime)
- **المخرجات:** قائمة من AppointmentDto

### **GET** `/api/Appointment/GetAppointmentsByStatus/{status}`
- **الوصف:** الحصول على المواعيد حسب الحالة
- **المدخلات:** status (string)
- **المخرجات:** قائمة من AppointmentDto

### **GET** `/api/Appointment/GetAppointmentsWithDetails`
- **الوصف:** الحصول على جميع المواعيد مع التفاصيل
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من AppointmentDto مع التفاصيل

---

## 3. Patient Controller (`/api/Patient`)

### **POST** `/api/Patient/Add-Patients`
- **الوصف:** إضافة مريض جديد
- **المدخلات:** CreatePatientDTO
- **المخرجات:** رسالة نجاح

### **PUT** `/api/Patient/UPDate`
- **الوصف:** تحديث بيانات مريض
- **المدخلات:** UpdatePatientDTO
- **المخرجات:** رسالة نجاح

### **DELETE** `/api/Patient/Delete/{id}`
- **الوصف:** حذف مريض
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

### **GET** `/api/Patient/GetbyId/{id}`
- **الوصف:** الحصول على مريض محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** PatientDTO

### **GET** `/api/Patient/Filter`
- **الوصف:** الحصول على المرضى مع فلترة
- **المدخلات:** pageNumber (int), pageSize (int), name (string), gender (string)
- **المخرجات:** قائمة من PatientDTO مع pagination

---

## 4. Doctor Controller (`/api/Doctor`)

### **POST** `/api/Doctor/CreateDoctor`
- **الوصف:** إنشاء طبيب جديد
- **المدخلات:** CreateDoctorDTO
- **المخرجات:** DoctorDTO مع معرف الطبيب

### **GET** `/api/Doctor/getdoctorbyid/{id}`
- **الوصف:** الحصول على طبيب محدد بالمعرف مع تفاصيل شاملة
- **المدخلات:** id (string)
- **المخرجات:** DoctorDetailsDTO مع التخصصات والجداول الزمنية وعدد المواعيد

### **GET** `/api/Doctor/GetAllDoctors`
- **الوصف:** الحصول على جميع الأطباء مع pagination
- **المدخلات:** pageNumber (int, default: 1), pageSize (int, default: 10)
- **المخرجات:** PaginatedDoctorsResponse مع معلومات pagination
- **مثال:** `GET /api/Doctor/GetAllDoctors?pageNumber=1&pageSize=5`

### **GET** `/api/Doctor/GetDoctorsBySpecialization/{specialization}`
- **الوصف:** الحصول على الأطباء حسب التخصص
- **المدخلات:** specialization (string)
- **المخرجات:** قائمة من DoctorDTO

### **PUT** `/api/Doctor`
- **الوصف:** تحديث بيانات طبيب
- **المدخلات:** UpdateDoctorDTO
- **المخرجات:** DoctorDTO المحدث

### **DELETE** `/api/Doctor/Delete/{id}`
- **الوصف:** حذف طبيب
- **المدخلات:** id (string)
- **المخرجات:** رسالة نجاح

---

## 5. Medicine Controller (`/api/Mediciel`)

### **POST** `/api/Mediciel/Addmediciel`
- **الوصف:** إضافة دواء جديد
- **المدخلات:** CreateMedicineDTO
- **المخرجات:** رسالة نجاح

### **GET** `/api/Mediciel/GetAllMediciels`
- **الوصف:** الحصول على جميع الأدوية مع pagination
- **المدخلات:** pageSize (int), pageNumber (int)
- **المخرجات:** قائمة من MedicineDTO

### **GET** `/api/Mediciel/GetMedicielById/{id}`
- **الوصف:** الحصول على دواء محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** MedicineDTO

### **PUT** `/api/Mediciel/UpdateMediciel`
- **الوصف:** تحديث بيانات دواء
- **المدخلات:** UpDateMedicineDTO
- **المخرجات:** MedicineDTO المحدث

### **DELETE** `/api/Mediciel/DeleteMediciel/{id}`
- **الوصف:** حذف دواء
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 6. Prescription Controller (`/api/Prescription`)

### **POST** `/api/Prescription/CreatePrescription`
- **الوصف:** إنشاء وصفة طبية جديدة
- **المدخلات:** CreatePrescriptionDto
- **المخرجات:** رسالة نجاح

### **GET** `/api/Prescription/GetAllPrescriptions`
- **الوصف:** الحصول على جميع الوصفات الطبية مع pagination
- **المدخلات:** pageSize (int), pageNumber (int)
- **المخرجات:** قائمة من PrescriptionDto

### **GET** `/api/Prescription/GetPrescriptionById/{id}`
- **الوصف:** الحصول على وصفة طبية محددة بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** PrescriptionDto

### **PUT** `/api/Prescription/UpdatePrescription/{id}`
- **الوصف:** تحديث وصفة طبية
- **المدخلات:** id (Guid), UpdatePrescriptionDto
- **المخرجات:** PrescriptionDto المحدث

### **DELETE** `/api/Prescription/DeletePrescription/{id}`
- **الوصف:** حذف وصفة طبية
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 7. Medical Visit Controller (`/api/MedicalVisit`)

### **POST** `/api/MedicalVisit/CreateMediclVisits`
- **الوصف:** إنشاء زيارة طبية جديدة
- **المدخلات:** CreateMedicalVisitDto
- **المخرجات:** رسالة نجاح

### **GET** `/api/MedicalVisit/GetAllMedicalVisits`
- **الوصف:** الحصول على جميع الزيارات الطبية مع pagination
- **المدخلات:** pageSize (int), pageNumber (int)
- **المخرجات:** قائمة من MedicalVisitDto

### **GET** `/api/MedicalVisit/GetMedicalVisitById/{id}`
- **الوصف:** الحصول على زيارة طبية محددة بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** MedicalVisitDto

### **PUT** `/api/MedicalVisit/UpdateMedicalVisit`
- **الوصف:** تحديث زيارة طبية
- **المدخلات:** UpdateMedicalVisitDto
- **المخرجات:** MedicalVisitDto المحدث

### **DELETE** `/api/MedicalVisit/DeleteMedicalVisit/{id}`
- **الوصف:** حذف زيارة طبية
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

### **GET** `/api/MedicalVisit/GetMedicalVisitsByPatientId/{patientId}`
- **الوصف:** الحصول على زيارات مريض محدد
- **المدخلات:** patientId (string)
- **المخرجات:** قائمة من MedicalVisitDto

---

## 8. Invoice Controller (`/api/Invoice`)

### **POST** `/api/Invoice/CreateInvoice`
- **الوصف:** إنشاء فاتورة جديدة
- **المدخلات:** CreateInvoiceDto
- **المخرجات:** رسالة نجاح

### **GET** `/api/Invoice/GetAllInvoices`
- **الوصف:** الحصول على جميع الفواتير مع pagination
- **المدخلات:** pageSize (int), pageNumber (int)
- **المخرجات:** قائمة من InvoiceDto

### **GET** `/api/Invoice/GetInvoiceById/{id}`
- **الوصف:** الحصول على فاتورة محددة بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** InvoiceDto

### **PUT** `/api/Invoice/UpdateInvoice`
- **الوصف:** تحديث فاتورة
- **المدخلات:** id (Guid), UpdateInvoiceDto
- **المخرجات:** InvoiceDto المحدث

### **DELETE** `/api/Invoice/DeleteInvoice/{id}`
- **الوصف:** حذف فاتورة
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 9. Specialization Controller (`/api/Specialization`)

### **POST** `/api/Specialization`
- **الوصف:** إنشاء تخصص طبي جديد
- **المدخلات:** CreateSpecializationDTO
- **المخرجات:** SpecializationDTO مع معرف التخصص

### **GET** `/api/Specialization/{id}`
- **الوصف:** الحصول على تخصص محدد بالمعرف
- **المدخلات:** id (string)
- **المخرجات:** SpecializationDTO

### **GET** `/api/Specialization`
- **الوصف:** الحصول على جميع التخصصات الطبية
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من SpecializationDTO

### **PUT** `/api/Specialization`
- **الوصف:** تحديث تخصص طبي
- **المدخلات:** UpdateSpecializationDTO
- **المخرجات:** SpecializationDTO المحدث

### **DELETE** `/api/Specialization/{id}`
- **الوصف:** حذف تخصص طبي
- **المدخلات:** id (string)
- **المخرجات:** رسالة نجاح

---

## 10. Doctor Schedule Controller (`/api/DoctorSchedule`)

### **POST** `/api/DoctorSchedule`
- **الوصف:** إنشاء جدول طبيب جديد
- **المدخلات:** CreateDoctorScheduleDTO
- **المخرجات:** DoctorScheduleDTO مع معرف الجدول

### **GET** `/api/DoctorSchedule/{id}`
- **الوصف:** الحصول على جدول محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** DoctorScheduleDTO

### **GET** `/api/DoctorSchedule`
- **الوصف:** الحصول على جميع جداول الأطباء
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من DoctorScheduleDTO

### **GET** `/api/DoctorSchedule/doctor/{doctorId}`
- **الوصف:** الحصول على جداول طبيب محدد
- **المدخلات:** doctorId (Guid)
- **المخرجات:** قائمة من DoctorScheduleDTO

### **GET** `/api/DoctorSchedule/day/{dayOfWeek}`
- **الوصف:** الحصول على جداول يوم محدد من الأسبوع
- **المدخلات:** dayOfWeek (int)
- **المخرجات:** قائمة من DoctorScheduleDTO

### **PUT** `/api/DoctorSchedule`
- **الوصف:** تحديث جدول طبيب
- **المدخلات:** UpdateDoctorScheduleDTO
- **المخرجات:** DoctorScheduleDTO المحدث

### **DELETE** `/api/DoctorSchedule/{id}`
- **الوصف:** حذف جدول طبيب
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 11. Clinic Settings Controller (`/api/ClinicSettings`)

### **POST** `/api/ClinicSettings`
- **الوصف:** إنشاء إعدادات عيادة جديدة
- **المدخلات:** CreateClinicSettingsDTO
- **المخرجات:** ClinicSettingsDTO مع معرف الإعداد

### **GET** `/api/ClinicSettings/{id}`
- **الوصف:** الحصول على إعداد محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** ClinicSettingsDTO

### **GET** `/api/ClinicSettings/active`
- **الوصف:** الحصول على الإعدادات النشطة
- **المدخلات:** لا يوجد
- **المخرجات:** ClinicSettingsDTO

### **PUT** `/api/ClinicSettings`
- **الوصف:** تحديث إعدادات العيادة
- **المدخلات:** UpdateClinicSettingsDTO
- **المخرجات:** ClinicSettingsDTO المحدث

### **DELETE** `/api/ClinicSettings/{id}`
- **الوصف:** حذف إعدادات العيادة
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 12. System Settings Controller (`/api/SystemSettings`)

### **POST** `/api/SystemSettings`
- **الوصف:** إنشاء إعداد نظام جديد
- **المدخلات:** CreateSystemSettingsDTO
- **المخرجات:** SystemSettingsDTO مع معرف الإعداد

### **GET** `/api/SystemSettings/{id}`
- **الوصف:** الحصول على إعداد محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** SystemSettingsDTO

### **GET** `/api/SystemSettings/key/{key}`
- **الوصف:** الحصول على إعداد بمفتاح محدد
- **المدخلات:** key (string)
- **المخرجات:** SystemSettingsDTO

### **GET** `/api/SystemSettings`
- **الوصف:** الحصول على جميع إعدادات النظام
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من SystemSettingsDTO

### **GET** `/api/SystemSettings/type/{type}`
- **الوصف:** الحصول على إعدادات حسب النوع
- **المدخلات:** type (int)
- **المخرجات:** قائمة من SystemSettingsDTO

### **PUT** `/api/SystemSettings`
- **الوصف:** تحديث إعداد نظام
- **المدخلات:** UpdateSystemSettingsDTO
- **المخرجات:** SystemSettingsDTO المحدث

### **DELETE** `/api/SystemSettings/{id}`
- **الوصف:** حذف إعداد نظام
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 13. Financial Report Controller (`/api/FinancialReport`)

### **POST** `/api/FinancialReport`
- **الوصف:** إنشاء تقرير مالي جديد
- **المدخلات:** CreateFinancialReportDTO
- **المخرجات:** FinancialReportDTO مع معرف التقرير

### **GET** `/api/FinancialReport/{id}`
- **الوصف:** الحصول على تقرير مالي محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** FinancialReportDTO

### **GET** `/api/FinancialReport`
- **الوصف:** الحصول على جميع التقارير المالية
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من FinancialReportDTO

### **GET** `/api/FinancialReport/date-range`
- **الوصف:** الحصول على التقارير المالية في نطاق تاريخ محدد
- **المدخلات:** startDate (DateTime), endDate (DateTime)
- **المخرجات:** قائمة من FinancialReportDTO

### **GET** `/api/FinancialReport/latest`
- **الوصف:** الحصول على أحدث تقرير مالي
- **المدخلات:** لا يوجد
- **المخرجات:** FinancialReportDTO

### **GET** `/api/FinancialReport/year/{year}`
- **الوصف:** الحصول على التقارير المالية لسنة محددة
- **المدخلات:** year (int)
- **المخرجات:** قائمة من FinancialReportDTO

### **PUT** `/api/FinancialReport`
- **الوصف:** تحديث تقرير مالي
- **المدخلات:** UpdateFinancialReportDTO
- **المخرجات:** FinancialReportDTO المحدث

### **DELETE** `/api/FinancialReport/{id}`
- **الوصف:** حذف تقرير مالي
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 14. Report Controller (`/api/Report`)

### **POST** `/api/Report`
- **الوصف:** إنشاء تقرير جديد
- **المدخلات:** CreateReportDTO
- **المخرجات:** ReportDTO مع معرف التقرير

### **GET** `/api/Report/{id}`
- **الوصف:** الحصول على تقرير محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** ReportDTO

### **GET** `/api/Report`
- **الوصف:** الحصول على جميع التقارير
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من ReportDTO

### **GET** `/api/Report/type/{type}`
- **الوصف:** الحصول على التقارير حسب النوع
- **المدخلات:** type (int)
- **المخرجات:** قائمة من ReportDTO

### **GET** `/api/Report/user/{userId}`
- **الوصف:** الحصول على التقارير لمستخدم محدد
- **المدخلات:** userId (string)
- **المخرجات:** قائمة من ReportDTO

### **GET** `/api/Report/date-range`
- **الوصف:** الحصول على التقارير في نطاق تاريخ محدد
- **المدخلات:** startDate (DateTime), endDate (DateTime)
- **المخرجات:** قائمة من ReportDTO

### **PUT** `/api/Report`
- **الوصف:** تحديث تقرير
- **المدخلات:** UpdateReportDTO
- **المخرجات:** ReportDTO المحدث

### **DELETE** `/api/Report/{id}`
- **الوصف:** حذف تقرير
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 15. Audit Log Controller (`/api/AuditLog`)

### **POST** `/api/AuditLog`
- **الوصف:** إنشاء سجل تدقيق جديد
- **المدخلات:** CreateAuditLogDTO
- **المخرجات:** AuditLogDTO مع معرف السجل

### **GET** `/api/AuditLog/{id}`
- **الوصف:** الحصول على سجل تدقيق محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** AuditLogDTO

### **GET** `/api/AuditLog`
- **الوصف:** الحصول على جميع سجلات التدقيق
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من AuditLogDTO

### **GET** `/api/AuditLog/table/{tableName}`
- **الوصف:** الحصول على سجلات التدقيق لجدول محدد
- **المدخلات:** tableName (string)
- **المخرجات:** قائمة من AuditLogDTO

### **GET** `/api/AuditLog/user/{userId}`
- **الوصف:** الحصول على سجلات التدقيق لمستخدم محدد
- **المدخلات:** userId (string)
- **المخرجات:** قائمة من AuditLogDTO

### **GET** `/api/AuditLog/date-range`
- **الوصف:** الحصول على سجلات التدقيق في نطاق تاريخ محدد
- **المدخلات:** startDate (DateTime), endDate (DateTime)
- **المخرجات:** قائمة من AuditLogDTO

### **GET** `/api/AuditLog/action/{action}`
- **الوصف:** الحصول على سجلات التدقيق لعمل محدد
- **المدخلات:** action (string)
- **المخرجات:** قائمة من AuditLogDTO

---

## ملاحظات مهمة:

1. **جميع الـ endpoints تتطلب JWT authentication** باستثناء register و login
2. **جميع التواريخ في تنسيق ISO 8601 (UTC)**
3. **جميع الرسائل باللغة العربية**
4. **يمكن استخدام query parameters للفلترة والترتيب**
5. **جميع الـ IDs من نوع GUID** باستثناء User IDs التي تكون string
6. **الـ pagination متاح لجميع الـ GET endpoints** التي تدعمه

---

## 16. Address Controller (`/api/Address`)

### **POST** `/api/Address`
- **الوصف:** إنشاء عنوان جديد
- **المدخلات:** CreateAddressDTO
- **المخرجات:** AddressDTO مع معرف العنوان

### **GET** `/api/Address/{id}`
- **الوصف:** الحصول على عنوان محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** AddressDTO

### **GET** `/api/Address`
- **الوصف:** الحصول على جميع العناوين
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من AddressDTO

### **PUT** `/api/Address`
- **الوصف:** تحديث عنوان
- **المدخلات:** UpdateAddressDTO
- **المخرجات:** AddressDTO المحدث

### **DELETE** `/api/Address/{id}`
- **الوصف:** حذف عنوان
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 17. Doctor Specialization Controller (`/api/DoctorSpecialization`)

### **POST** `/api/DoctorSpecialization`
- **الوصف:** إنشاء تخصص طبيب جديد
- **المدخلات:** CreateDoctorSpecializationDTO
- **المخرجات:** DoctorSpecializationDTO مع معرف التخصص

### **GET** `/api/DoctorSpecialization/{id}`
- **الوصف:** الحصول على تخصص طبيب محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** DoctorSpecializationDTO

### **GET** `/api/DoctorSpecialization`
- **الوصف:** الحصول على جميع تخصصات الأطباء
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من DoctorSpecializationDTO

### **GET** `/api/DoctorSpecialization/doctor/{doctorId}`
- **الوصف:** الحصول على تخصصات طبيب محدد
- **المدخلات:** doctorId (Guid)
- **المخرجات:** قائمة من DoctorSpecializationDTO

### **GET** `/api/DoctorSpecialization/specialization/{specializationId}`
- **الوصف:** الحصول على أطباء تخصص محدد
- **المدخلات:** specializationId (Guid)
- **المخرجات:** قائمة من DoctorSpecializationDTO

### **DELETE** `/api/DoctorSpecialization/{id}`
- **الوصف:** حذف تخصص طبيب
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 18. Emergency Contact Controller (`/api/EmergencyContact`)

### **POST** `/api/EmergencyContact`
- **الوصف:** إنشاء جهة اتصال طارئة جديدة
- **المدخلات:** CreateEmergencyContactDTO
- **المخرجات:** EmergencyContactDTO مع معرف جهة الاتصال

### **GET** `/api/EmergencyContact/{id}`
- **الوصف:** الحصول على جهة اتصال طارئة محددة بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** EmergencyContactDTO

### **GET** `/api/EmergencyContact`
- **الوصف:** الحصول على جميع جهات الاتصال الطارئة
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من EmergencyContactDTO

### **PUT** `/api/EmergencyContact`
- **الوصف:** تحديث جهة اتصال طارئة
- **المدخلات:** UpdateEmergencyContactDTO
- **المخرجات:** EmergencyContactDTO المحدث

### **DELETE** `/api/EmergencyContact/{id}`
- **الوصف:** حذف جهة اتصال طارئة
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 19. Insurance Info Controller (`/api/InsuranceInfo`)

### **POST** `/api/InsuranceInfo`
- **الوصف:** إنشاء معلومات تأمين جديدة
- **المدخلات:** CreateInsuranceInfoDTO
- **المخرجات:** InsuranceInfoDTO مع معرف المعلومات

### **GET** `/api/InsuranceInfo/{id}`
- **الوصف:** الحصول على معلومات تأمين محددة بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** InsuranceInfoDTO

### **GET** `/api/InsuranceInfo`
- **الوصف:** الحصول على جميع معلومات التأمين
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من InsuranceInfoDTO

### **PUT** `/api/InsuranceInfo`
- **الوصف:** تحديث معلومات التأمين
- **المدخلات:** UpdateInsuranceInfoDTO
- **المخرجات:** InsuranceInfoDTO المحدث

### **DELETE** `/api/InsuranceInfo/{id}`
- **الوصف:** حذف معلومات التأمين
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 20. Invoice Item Controller (`/api/invoiceitem`)

### **POST** `/api/invoiceitem/CreateInvoiceItem`
- **الوصف:** إنشاء عنصر فاتورة جديد
- **المدخلات:** CreateInvoiceItemDto
- **المخرجات:** رسالة نجاح

### **GET** `/api/invoiceitem/GetAllInvoiceItems`
- **الوصف:** الحصول على جميع عناصر الفواتير مع pagination
- **المدخلات:** pageSize (int), pageNumber (int)
- **المخرجات:** قائمة من InvoiceItemDto

### **GET** `/api/invoiceitem/GetInvoiceItemById/{id}`
- **الوصف:** الحصول على عنصر فاتورة محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** InvoiceItemDto

### **PUT** `/api/invoiceitem/UpdateInvoiceItem`
- **الوصف:** تحديث عنصر فاتورة
- **المدخلات:** id (Guid), UpdateInvoiceItemDto
- **المخرجات:** InvoiceItemDto المحدث

### **DELETE** `/api/invoiceitem/DeleteInvoiceItem/{id}`
- **الوصف:** حذف عنصر فاتورة
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 21. Medical Record Controller (`/api/MedicalRecord`)

### **POST** `/api/MedicalRecord`
- **الوصف:** إنشاء سجل طبي جديد
- **المدخلات:** CreateMedicalRecordDTO
- **المخرجات:** MedicalRecordDTO مع معرف السجل

### **GET** `/api/MedicalRecord/{id}`
- **الوصف:** الحصول على سجل طبي محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** MedicalRecordDTO

### **GET** `/api/MedicalRecord`
- **الوصف:** الحصول على جميع السجلات الطبية
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من MedicalRecordDTO

### **GET** `/api/MedicalRecord/patient/{patientId}`
- **الوصف:** الحصول على السجلات الطبية لمريض محدد
- **المدخلات:** patientId (string)
- **المخرجات:** قائمة من MedicalRecordDTO

### **GET** `/api/MedicalRecord/doctor/{doctorId}`
- **الوصف:** الحصول على السجلات الطبية لطبيب محدد
- **المدخلات:** doctorId (Guid)
- **المخرجات:** قائمة من MedicalRecordDTO

### **PUT** `/api/MedicalRecord`
- **الوصف:** تحديث سجل طبي
- **المدخلات:** UpdateMedicalRecordDTO
- **المخرجات:** MedicalRecordDTO المحدث

### **DELETE** `/api/MedicalRecord/{id}`
- **الوصف:** حذف سجل طبي
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 22. Medication Category Controller (`/api/MedicationCategory`)

### **POST** `/api/MedicationCategory`
- **الوصف:** إنشاء فئة دواء جديدة
- **المدخلات:** CreateMedicationCategoryDTO
- **المخرجات:** MedicationCategoryDTO مع معرف الفئة

### **GET** `/api/MedicationCategory/{id}`
- **الوصف:** الحصول على فئة دواء محددة بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** MedicationCategoryDTO

### **GET** `/api/MedicationCategory`
- **الوصف:** الحصول على جميع فئات الأدوية
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من MedicationCategoryDTO

### **GET** `/api/MedicationCategory/medicine/{medicineId}`
- **الوصف:** الحصول على فئات دواء محدد
- **المدخلات:** medicineId (Guid)
- **المخرجات:** قائمة من MedicationCategoryDTO

### **GET** `/api/MedicationCategory/category/{categoryId}`
- **الوصف:** الحصول على أدوية فئة محددة
- **المدخلات:** categoryId (Guid)
- **المخرجات:** قائمة من MedicationCategoryDTO

### **PUT** `/api/MedicationCategory`
- **الوصف:** تحديث فئة دواء
- **المدخلات:** UpdateMedicationCategoryDTO
- **المخرجات:** MedicationCategoryDTO المحدث

### **DELETE** `/api/MedicationCategory/{id}`
- **الوصف:** حذف فئة دواء
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 23. Prescription Item Controller (`/api/Prescriptionitem`)

### **POST** `/api/Prescriptionitem/CreatePrescriptionItem`
- **الوصف:** إنشاء عنصر وصفة طبية جديد
- **المدخلات:** CreatePrescriptionItemDto
- **المخرجات:** رسالة نجاح

### **GET** `/api/Prescriptionitem/GetAllPrescriptionItems`
- **الوصف:** الحصول على جميع عناصر الوصفات الطبية مع pagination
- **المدخلات:** pageSize (int), pageNumber (int)
- **المخرجات:** قائمة من PrescriptionItemDto

### **GET** `/api/Prescriptionitem/GetPrescriptionItemById/{id}`
- **الوصف:** الحصول على عنصر وصفة طبية محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** PrescriptionItemDto

### **PUT** `/api/Prescriptionitem/UpdatePrescriptionItem`
- **الوصف:** تحديث عنصر وصفة طبية
- **المدخلات:** UpdatePrescriptionItemDto
- **المخرجات:** PrescriptionItemDto المحدث

### **DELETE** `/api/Prescriptionitem/DeletePrescriptionItem/{id}`
- **الوصف:** حذف عنصر وصفة طبية
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 24. Receptionist Controller (`/api/Receptionist`)

### **POST** `/api/Receptionist`
- **الوصف:** إنشاء موظف استقبال جديد
- **المدخلات:** CreateReceptionistDTO
- **المخرجات:** ReceptionistDTO مع معرف الموظف

### **GET** `/api/Receptionist/{id}`
- **الوصف:** الحصول على موظف استقبال محدد بالمعرف
- **المدخلات:** id (Guid)
- **المخرجات:** ReceptionistDTO

### **GET** `/api/Receptionist/user/{userId}`
- **الوصف:** الحصول على موظف استقبال بمستخدم محدد
- **المدخلات:** userId (string)
- **المخرجات:** ReceptionistDTO

### **GET** `/api/Receptionist`
- **الوصف:** الحصول على جميع موظفي الاستقبال
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من ReceptionistDTO

### **GET** `/api/Receptionist/department/{department}`
- **الوصف:** الحصول على موظفي استقبال قسم محدد
- **المدخلات:** department (string)
- **المخرجات:** قائمة من ReceptionistDTO

### **PUT** `/api/Receptionist`
- **الوصف:** تحديث موظف استقبال
- **المدخلات:** UpdateReceptionistDTO
- **المخرجات:** ReceptionistDTO المحدث

### **DELETE** `/api/Receptionist/{id}`
- **الوصف:** حذف موظف استقبال
- **المدخلات:** id (Guid)
- **المخرجات:** رسالة نجاح

---

## 25. Weather Forecast Controller (`/WeatherForecast`)

### **GET** `/WeatherForecast`
- **الوصف:** الحصول على توقعات الطقس (للاختبار فقط)
- **المدخلات:** لا يوجد
- **المخرجات:** قائمة من WeatherForecast

---

## ملاحظات مهمة:

1. **جميع الـ endpoints تتطلب JWT authentication** باستثناء register و login
2. **جميع التواريخ في تنسيق ISO 8601 (UTC)**
3. **جميع الرسائل باللغة العربية**
4. **يمكن استخدام query parameters للفلترة والترتيب**
5. **جميع الـ IDs من نوع GUID** باستثناء User IDs التي تكون string
6. **الـ pagination متاح لجميع الـ GET endpoints** التي تدعمه

---

## Models المستخدمة:

### PaginatedDoctorsResponse
```json
{
  "doctors": [
    {
      "id": "guid",
      "firstName": "string",
      "lastName": "string",
      "email": "string",
      "phone": "string",
      "specialization": "string",
      "licenseNumber": "string",
      "medicalSchool": "string",
      "yearsOfExperience": 0,
      "bio": "string",
      "profileImage": "string",
      "startTime": "time",
      "endTime": "time",
      "maxPatientsPerDay": 0,
      "isActive": true,
      "createdAt": "datetime",
      "updatedAt": "datetime"
    }
  ],
  "pageNumber": 1,
  "pageSize": 10,
  "totalCount": 50,
  "totalPages": 5,
  "hasPreviousPage": false,
  "hasNextPage": true
}
```

**إجمالي عدد الـ endpoints: 120+ endpoint**
