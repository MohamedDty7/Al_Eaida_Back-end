# User Management API Documentation

## Overview
This document describes the comprehensive user management features in the Al-Eaida backend API, including CRUD operations, role-based filtering, status management, and enhanced user information display.

**Important:** All user endpoints now include complete user information including roles, creation date, and last login time.

## Base URL
```
https://localhost:7000/api/auth
```

## Authentication
All endpoints require JWT authentication. Include the token in the Authorization header:
```
Authorization: Bearer <your-jwt-token>
```

## Endpoints

### Basic User Endpoints

#### Get All Users
**GET** `/getallusers`

Returns all users with their roles, creation date, and last login time.

**Response:**
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

#### Get User by ID
**GET** `/getbyid/{id}`

Returns a specific user with their roles, creation date, and last login time.

**Parameters:**
- `id` (string): The user ID

**Response:**
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

### User Management Endpoints

#### Update User
**PUT** `/users/{userId}`

Updates user information (username, email, phone, address).

**Parameters:**
- `userId` (string): The user ID

**Request Body:**
```json
{
  "userName": "newusername",
  "email": "newemail@example.com",
  "phone": "9876543210",
  "address": "New Address"
}
```

**Response:**
```json
{
  "message": "تم تحديث بيانات المستخدم بنجاح",
  "user": {
    "id": "user-id",
    "email": "newemail@example.com",
    "userName": "newusername",
    "phone": "9876543210",
    "role": ["Admin"],
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z",
    "lastLoginAt": "2024-01-15T10:30:00Z"
  }
}
```

#### Delete User
**DELETE** `/users/{userId}`

Deletes a user from the system.

**Parameters:**
- `userId` (string): The user ID

**Response:**
```json
{
  "message": "تم حذف المستخدم بنجاح",
  "success": true
}
```

#### Change Password
**PUT** `/users/{userId}/change-password`

Changes user password.

**Parameters:**
- `userId` (string): The user ID

**Request Body:**
```json
{
  "currentPassword": "oldpassword",
  "newPassword": "newpassword123",
  "confirmPassword": "newpassword123"
}
```

**Response:**
```json
{
  "message": "تم تغيير كلمة المرور بنجاح",
  "success": true
}
```

### Advanced User Management Endpoints

#### Get All Users with Roles
**GET** `/users/with-roles`

Returns all users with their assigned roles.

**Response:**
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

#### Get Users by Role
**GET** `/users/role/{role}`

Returns all users with a specific role.

**Parameters:**
- `role` (string): The role name (e.g., "Admin", "Doctor", "Receptionist")

**Response:**
```json
[
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
]
```

#### Get Users by Status
**GET** `/users/status/{isActive}`

Returns all users with a specific active status.

**Parameters:**
- `isActive` (boolean): true for active users, false for inactive users

**Response:**
```json
[
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
]
```

#### Get Users by Role and Status
**GET** `/users/role/{role}/status/{isActive}`

Returns all users with a specific role and status.

**Parameters:**
- `role` (string): The role name
- `isActive` (boolean): The active status

**Response:**
```json
[
  {
    "id": "user-id",
    "email": "user@example.com",
    "userName": "username",
    "phone": "1234567890",
    "role": ["Doctor"],
    "isActive": true,
    "createdAt": "2024-01-01T00:00:00Z",
    "lastLoginAt": "2024-01-15T10:30:00Z"
  }
]
```

#### Get User with Roles
**GET** `/users/{userId}/with-roles`

Returns a specific user with their roles.

**Parameters:**
- `userId` (string): The user ID

**Response:**
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

#### Toggle User Status
**PUT** `/users/{userId}/toggle-status`

Toggles the active status of a user (active ↔ inactive).

**Parameters:**
- `userId` (string): The user ID

**Response:**
```json
{
  "message": "تم تحديث حالة المستخدم بنجاح",
  "isActive": false
}
```

#### Set User Status
**PUT** `/users/{userId}/set-status`

Sets the active status of a user.

**Parameters:**
- `userId` (string): The user ID

**Request Body:**
```json
{
  "isActive": true
}
```

**Response:**
```json
{
  "message": "تم تحديث حالة المستخدم بنجاح",
  "isActive": true
}
```

## Authentication Endpoints

#### Register
**POST** `/register`

Registers a new user.

**Request Body:**
```json
{
  "username": "newuser",
  "email": "user@example.com",
  "password": "password123",
  "phone": "1234567890",
  "address": "User Address",
  "role": ["User"]
}
```

#### Login
**POST** `/login`

Authenticates a user and returns JWT token.

**Request Body:**
```json
{
  "email": "user@example.com",
  "password": "password123"
}
```

#### Refresh Token
**POST** `/refresh-token`

Refreshes the JWT token using refresh token.

**Request Body:**
```json
{
  "token": "jwt-token",
  "refreshToken": "refresh-token"
}
```

## Example Usage

### Update User
```bash
curl -X PUT "https://localhost:7000/api/auth/users/user-id" \
  -H "Authorization: Bearer <your-token>" \
  -H "Content-Type: application/json" \
  -d '{
    "userName": "newusername",
    "email": "newemail@example.com",
    "phone": "9876543210",
    "address": "New Address"
  }'
```

### Delete User
```bash
curl -X DELETE "https://localhost:7000/api/auth/users/user-id" \
  -H "Authorization: Bearer <your-token>"
```

### Change Password
```bash
curl -X PUT "https://localhost:7000/api/auth/users/user-id/change-password" \
  -H "Authorization: Bearer <your-token>" \
  -H "Content-Type: application/json" \
  -d '{
    "currentPassword": "oldpassword",
    "newPassword": "newpassword123",
    "confirmPassword": "newpassword123"
  }'
```

## Features Added

1. **Complete CRUD Operations**: Create, Read, Update, Delete users
2. **Role Display**: All user endpoints include user roles
3. **Role Filtering**: Filter users by specific roles
4. **Status Filtering**: Filter users by active/inactive status
5. **Combined Filtering**: Filter by both role and status
6. **Status Management**: Toggle or set user active status
7. **Password Management**: Change user passwords securely
8. **Arabic Support**: All error messages and responses in Arabic
9. **Enhanced User Info**: Complete user information with roles
10. **Login Tracking**: Track last login time for each user
11. **Creation Date**: Display user creation date
12. **Automatic Updates**: Last login time is automatically updated on login and token refresh
13. **Data Validation**: Comprehensive validation for all inputs
14. **Security**: Password verification and secure updates

## Notes

- All endpoints require authentication
- User status affects login capability (inactive users cannot log in)
- Role names are case-sensitive
- The system supports multiple roles per user
- All timestamps are in UTC format
- `lastLoginAt` is automatically updated when users log in or refresh their tokens
- `lastLoginAt` will be null for users who have never logged in
- `createdAt` shows when the user account was first created
- Email and username must be unique across all users
- Password changes require current password verification
- User deletion is permanent and cannot be undone





















