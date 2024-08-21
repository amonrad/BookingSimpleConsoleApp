# BookingSimpleConsoleApp


## Overview

**BookingSimpleConsoleApp** is a simple console-based application designed for managing bookings, including meeting scheduling and client management. This application uses an object-oriented approach to handle various aspects of booking management efficiently.


## Features

- **Bookable Entities**: Manage different types of bookable resources (e.g., locations, employees and clients).
- **Meeting Scheduling**: Schedule and manage meetings, including duration and participants.
- **Display Management**: Handle the display of information to the user.


## Getting Started

### Prerequisites

- [.NET SDK](https://dotnet.microsoft.com/download) (version 6.0 or higher recommended)
- [Visual Studio Code](https://code.visualstudio.com/) (or any other code editor)

### Installation

1. **Clone the repository**:
```bash
git clone https://github.com/yourusername/BookingSimpleConsoleApp.git
```

2. **Navigate to the project directory**:
```bash
cd BookingSimpleConsoleApp
```

3. **Restore the project dependencies**:
```bash
dotnet restore
```


## Usage

1. **Build the project**:
```bash
dotnet build
```

2. **Run the application**:
```bash
dotnet run
```


## Project Structure

### Root Folder
- **Program.cs**: Entry point of the application.
- **factory.cs**: Contains factory classes for creating instances of different entities.

### UI
- **reception.cs**: Manages the booking reception and processing.
- **NewBookingsForm.cs**: Form for creating new bookings.
- **MeetingDuration.cs**: Enum that defines the duration of meetings.
- **HandleBooking.cs**: Handles various booking operations.
- **Display.cs**: Manages the display of information to the user.
- **DataCollectionForm.cs**: Form for collecting and managing data input.

### Bookables
- **Bookable.cs**: Defines the base class for bookable entities.
- **Client.cs**: Defines the client entity and its properties.
- **Employee.cs**: Defines the employee entity and its properties.
- **Location.cs**: Defines the location entity and its properties.
- **Meeting.cs**: Defines the meeting entity and its properties.

- **Interfaces**: Various interfaces for implementing the core functionality.


## License
This project is licensed under the MIT License - see the LICENSE file for details.
