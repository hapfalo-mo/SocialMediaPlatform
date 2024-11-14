# SocialMediaPlatform
## 📖 Overview
Context: This is a test project and it show the functions as a community where users can share and upload about their favorites, it also help find new friends - other users who have mutual hobbies and activities.
In addition, users could follow other users to observe activities of their followers in community despite of gender, career, age, location and so on.

---

## 🌐 Demo
Because this project is built and ran in local environment, so you can read below instructions to run this project.  
Or see below main screens of the project

![Login Screen](https://i.ibb.co/pnP7Lnf/login.png)  
![Signup Screen](https://i.ibb.co/dQjnGHR/signup.png)
![Welcome Screen](https://i.ibb.co/4dY73fB/welcome.png)
![Selection Screen](https://i.ibb.co/HTZ1HZX/selection.png)
![Home Screen](https://i.ibb.co/Bc8WM4G/main.png)

---

## ✨ Functions
- Function 1: Login (By username and passowrd)
- Function 2: Signup (Signup Form)
- Function 3: Choose Favorite
- Function 4: Create Post 
- Function 5: Like Post
- Function 6: Comment on Posts
- Function 7: Follow User
- Function 8: Find User (Not Complete)
- Function 9: Chat (Not Complete)

---

## 🚀 Getting Started

### Prerequisites

#### System Requirements (Back-end)
- **Language**: C# (.NET 8)
- **Framework**: ASP.NET Core (Main)

##### Libraries and Packages
- **Main Project**:
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Design`
  - `Microsoft.EntityFrameworkCore.Tools`
  - `Npgsql.EntityFrameworkCore.PostgreSQL` (for PostgreSQL database support)
  - `Swashbuckle.AspNetCore` (for Swagger documentation)

- **Project "Models"**:
  - `AutoMapper` (for object mapping)
  - `Microsoft.AspNetCore.Authentication.JwtBearer` (for JWT authentication)
  - `Microsoft.AspNetCore.Mvc.Core`
  - `Microsoft.EntityFrameworkCore`
  - `Microsoft.EntityFrameworkCore.Design`
  - `Microsoft.EntityFrameworkCore.Tools`
  - `Microsoft.Extensions.Configuration`
  - `Microsoft.Extensions.Configuration.Json`
  - `Npgsql.EntityFrameworkCore.PostgreSQL`

- **Other Libraries**:
  - `Microsoft.AspNetCore.Authentication.JwtBearer`
  - `Microsoft.AspNetCore.Mvc.Abstractions`
  - `Microsoft.IdentityModel.JsonWebTokens`
  - `System.IdentityModel.Tokens.Jwt` (for token handling)

#### System Requirements (Front-end)
- **Node.js** (Version 14 or higher is recommended)
- **Package Manager**: npm or yarn

##### Front-End Dependencies
The front-end dependencies are managed in `package.json`. Below is a summary of the main dependencies:

- **Core Libraries**:
  - `react`: ^18.3.1
  - `react-dom`: ^18.3.1
  - `react-router-dom`: ^6.27.0 (for routing)

- **UI & Styling**:
  - `@fortawesome/fontawesome-free`: ^6.6.0 (for icons)
  - `antd`: ^5.21.6 (Ant Design for UI components)
  - `tailwindcss`: ^3.4.14 (for utility-first CSS)

- **Utility Libraries**:
  - `axios`: ^1.7.7 (for API requests)
  - `firebase`: ^11.0.1 (for authentication or real-time features)
  - `jwt-decode`: ^4.0.0 (for decoding JWT tokens)
  - `react-toastify`: ^10.0.6 (for notifications)

##### Development Dependencies
- **Build & Tooling**:
  - `vite`: ^5.4.10 (for fast development and build)
  - `@vitejs/plugin-react`: ^4.3.3 (for React support in Vite)

- **Linting & Formatting**:
  - `eslint`: ^9.13.0
  - `eslint-plugin-react`: ^7.37.2
  - `eslint-plugin-react-hooks`: ^5.0.0
  - `eslint-plugin-react-refresh`: ^0.4.14

- **CSS Processing**:
  - `autoprefixer`: ^10.4.20
  - `postcss`: ^8.4.47


## Installation

### Clone the Repositories

First, clone both the front-end and back-end repositories:

```bash
# Clone the front-end repository
git clone https://github.com/hapfalo-mo/SocialMediaPlatform_FrontEnd.git
cd SocialMediaPlatform_FrontEnd

# Clone the back-end repository in a separate folder
cd ..
git clone https://github.com/hapfalo-mo/SocialMediaPlatform.git

LarionProject_BESolution/
├── LarionProject_BE/           # Main backend project folder
│   ├── LarionProject_BE.csproj  # Project file for main backend
│   ├── Controllers/             # API controllers for handling requests
│   ├── Models/                  # Core models (may also refer to separate Models project)
│   ├── Services/                # Business logic and service layer
│   ├── Repositories/            # Data access layer
│   └── Program.cs               # Entry point for the application
├── Models/                      # Models project (shared entities and data models)
│   ├── Models.csproj            # Project file for models
│   └── Entities/                # Entity classes (data models)
├── Services/                    # Additional services project
│   ├── Services.csproj          # Project file for services
│   └── ServiceImplementations/   # Service implementations
├── Settings/                    # Settings project for configuration
│   ├── Settings.csproj          # Project file for settings
│   └── ConfigurationFiles/      # Configuration files, e.g., appsettings.json
└── LarionProject_BESolution.sln # Solution file

📜 License
This project is licensed under the MIT License - see the LICENSE file for details.

---

📞 Contact
For any inquiries, please contact:

Email: chuongnguyen16112002@gmail.com
LinkedIn: https://www.linkedin.com/in/sanchez-chuong/




