# InternalBookingSystem
Internal Resource Booking System built with ASP.NET Core Razor Pages and SQL Server LocalDB.

This application allows employees to view and book shared resources such as meeting rooms, vehicles, and equipment. It includes full CRUD functionality for Resources and Bookings, booking conflict validation, and a dashboard with live statistics.

---

## 🚀 Features

### ✔ Resource Management
- Create, view, edit, and delete resources.
- Manage fields: Name, Description, Location, Capacity, Availability.
- View upcoming bookings per resource.

### ✔ Booking Management
- Create, edit, view, delete bookings.
- Date-time inputs using `datetime-local`.
- Resource dropdown (unavailable resources are disabled).
- Full booking conflict validation:
  A booking cannot overlap with another booking for the same resource.

### ✔ Dashboard (Advanced)
- Total resources
- Total bookings
- Bookings today
- Bookings this week
- Next upcoming booking
- Upcoming bookings list

### ✔ Technology Used
- ASP.NET Core Razor Pages (.NET 6+)
- Entity Framework Core
- SQL Server LocalDB
- Bootstrap 5

---

## ⚙️ Setup Instructions

### 1. Clone or extract the project
