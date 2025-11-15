# Appointment Controller - Endpoints Documentation

## نظرة عامة
تم إضافة endpoints جديدة في `AppointmentController` لجلب المرضى والأطباء لاستخدامها في إنشاء المواعيد.

## الـ Endpoints الجديدة

### 1. جلب جميع المرضى
```
GET /api/Appointment/GetAllPatients
```
**الوصف:** يجلب قائمة بجميع المرضى المسجلين في النظام
**الاستجابة:**
```json
{
  "message": "تم استرجاع قائمة المرضى بنجاح",
  "patients": [
    {
      "id": "guid",
      "firstName": "اسم المريض",
      "lastName": "اسم العائلة",
      "email": "email@example.com",
      "phone": "+20123456789",
      "gender": "Male/Female",
      "dateOfBirth": "1990-01-01",
      "isActive": true
    }
  ]
}
```

### 2. جلب جميع الأطباء
```
GET /api/Appointment/GetAllDoctors
```
**الوصف:** يجلب قائمة بجميع الأطباء المسجلين في النظام
**الاستجابة:**
```json
{
  "message": "تم استرجاع قائمة الأطباء بنجاح",
  "doctors": [
    {
      "id": "guid",
      "firstName": "اسم الطبيب",
      "lastName": "اسم العائلة",
      "email": "doctor@example.com",
      "phone": "+20123456789",
      "specialization": "Cardiology",
      "isActive": true,
      "yearsOfExperience": 10
    }
  ]
}
```

### 3. جلب الأطباء النشطين فقط
```
GET /api/Appointment/GetActiveDoctors
```
**الوصف:** يجلب قائمة بالأطباء النشطين فقط (IsActive = true)
**الاستجابة:** نفس استجابة `GetAllDoctors` ولكن مع الأطباء النشطين فقط

### 4. جلب الأطباء حسب التخصص
```
GET /api/Appointment/GetDoctorsBySpecialization/{specialization}
```
**الوصف:** يجلب قائمة بالأطباء حسب تخصص معين
**المعاملات:**
- `specialization` (string): اسم التخصص (مثل "Cardiology", "Pediatrics")

**الاستجابة:**
```json
{
  "message": "تم استرجاع قائمة أطباء التخصص Cardiology بنجاح",
  "doctors": [
    {
      "id": "guid",
      "firstName": "اسم الطبيب",
      "lastName": "اسم العائلة",
      "specialization": "Cardiology",
      "isActive": true
    }
  ]
}
```

### 5. جلب بيانات نموذج المواعيد (شامل)
```
GET /api/Appointment/GetAppointmentFormData
```
**الوصف:** يجلب جميع البيانات المطلوبة لإنشاء موعد (المرضى، الأطباء، التخصصات)
**الاستجابة:**
```json
{
  "message": "تم استرجاع بيانات نموذج المواعيد بنجاح",
  "patients": [
    // قائمة المرضى
  ],
  "doctors": [
    // قائمة الأطباء النشطين
  ],
  "specializations": [
    "Cardiology",
    "Pediatrics",
    "Orthopedics"
  ]
}
```

## الاستخدام في Frontend

### 1. لملء قائمة المرضى في dropdown
```javascript
fetch('/api/Appointment/GetAllPatients')
  .then(response => response.json())
  .then(data => {
    // ملء dropdown المرضى
    data.patients.forEach(patient => {
      // إضافة خيار للمريض
    });
  });
```

### 2. لملء قائمة الأطباء في dropdown
```javascript
fetch('/api/Appointment/GetActiveDoctors')
  .then(response => response.json())
  .then(data => {
    // ملء dropdown الأطباء
    data.doctors.forEach(doctor => {
      // إضافة خيار للطبيب
    });
  });
```

### 3. لملء قائمة التخصصات
```javascript
fetch('/api/Appointment/GetAppointmentFormData')
  .then(response => response.json())
  .then(data => {
    // ملء dropdown التخصصات
    data.specializations.forEach(specialization => {
      // إضافة خيار للتخصص
    });
  });
```

### 4. لتصفية الأطباء حسب التخصص
```javascript
function filterDoctorsBySpecialization(specialization) {
  fetch(`/api/Appointment/GetDoctorsBySpecialization/${specialization}`)
    .then(response => response.json())
    .then(data => {
      // تحديث قائمة الأطباء
      updateDoctorsDropdown(data.doctors);
    });
}
```

## ملاحظات مهمة

1. **التوافق مع النظام الحالي:** هذه الـ endpoints تعمل مع النظام الحالي ولا تحتاج لتعديلات في قاعدة البيانات
2. **الأداء:** تم استخدام pagination في الخلفية لتحسين الأداء
3. **الأمان:** جميع الـ endpoints محمية بنفس نظام المصادقة المستخدم في النظام
4. **اللغة:** جميع الرسائل باللغة العربية
5. **التنسيق:** جميع التواريخ والأوقات بتنسيق صحيح بدون ثواني أو توقيت عالمي

## أمثلة على الاستخدام

### إنشاء موعد جديد
```javascript
// 1. جلب البيانات المطلوبة
const formData = await fetch('/api/Appointment/GetAppointmentFormData').then(r => r.json());

// 2. ملء النموذج
populateForm(formData);

// 3. عند إرسال النموذج
const appointmentData = {
  patientId: selectedPatientId,
  doctorId: selectedDoctorId,
  appointmentDate: "2024-10-01T10:00:00",
  time: "10:00",
  notes: "موعد متابعة",
  status: "Scheduled",
  userID: currentUserId
};

// 4. إرسال البيانات
fetch('/api/Appointment/CreateAppointment', {
  method: 'POST',
  headers: { 'Content-Type': 'application/json' },
  body: JSON.stringify(appointmentData)
});
```















