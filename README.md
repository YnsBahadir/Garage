<div align="center">
  
  <h1>🛍️ GARAGE</h1>
  <h3>Premium Second-Hand E-Commerce Platform</h3>
  
  <p>
    <b>C2C Trade</b> • <b>Offer System</b> • <b>Question-Answer Interaction</b>
  </p>

  <p>
    <a href="https://github.com/YnsBahadir/Garage/graphs/contributors">
      <img src="https://img.shields.io/github/contributors/YnsBahadir/Garage?style=for-the-badge&color=blue" alt="Contributors" />
    </a>
    <a href="https://github.com/YnsBahadir/Garage/network/members">
      <img src="https://img.shields.io/github/forks/YnsBahadir/Garage?style=for-the-badge&color=orange" alt="Forks" />
    </a>
    <a href="https://github.com/YnsBahadir/Garage/stargazers">
      <img src="https://img.shields.io/github/stars/YnsBahadir/Garage?style=for-the-badge&color=yellow" alt="Stars" />
    </a>
    <a href="https://github.com/YnsBahadir/Garage/blob/main/LICENSE">
      <img src="https://img.shields.io/github/license/YnsBahadir/Garage?style=for-the-badge&color=green" alt="License" />
    </a>
  </p>
</div>

---

## 📖 About The Project

**Garage** is a robust **C2C (Consumer-to-Consumer)** e-commerce web application. It empowers users to list their second-hand items, interact deeply with sellers via a specialized Q&A system, and negotiate prices through an email-integrated offer mechanism.

Built with the power of **ASP.NET Core MVC** and **Entity Framework Core**, strictly following **N-Tier Architecture** principles for scalability and maintainability.

## 🛠️ Tech Stack & Tools

This project was developed using the following technologies:

<table>
  <tr>
    <td width="20%" align="center" valign="middle">
      <img src="https://raw.githubusercontent.com/orhun/orhun/refs/heads/master/assets/ratatui-spin-dark.gif#gh-dark-mode-only" width="100%">
      <img src="https://raw.githubusercontent.com/orhun/orhun/refs/heads/master/assets/ratatui-spin-light.gif#gh-light-mode-only" width="100%">
    </td>
    <td width="80%" valign="middle">
      <table align="center">
        <tr>
          <th align="center">Backend</th>
          <th align="center">Frontend</th>
          <th align="center">Database & Tools</th>
        </tr>
        <tr>
          <td align="center">
            <img src="https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white" alt="C#">
          </td>
          <td align="center">
            <img src="https://img.shields.io/badge/html5-%23E34F26.svg?style=for-the-badge&logo=html5&logoColor=white" alt="HTML5">
          </td>
          <td align="center">
            <img src="https://img.shields.io/badge/Microsoft%20SQL%20Server-CC2927?style=for-the-badge&logo=microsoft%20sql%20server&logoColor=white" alt="SQL Server">
          </td>
        </tr>
        <tr>
          <td align="center">
            <img src="https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white" alt=".NET">
          </td>
          <td align="center">
            <img src="https://img.shields.io/badge/css3-%231572B6.svg?style=for-the-badge&logo=css3&logoColor=white" alt="CSS3">
          </td>
          <td align="center">
            <img src="https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white" alt="Visual Studio">
          </td>
        </tr>
        <tr>
          <td align="center">
            <img src="https://img.shields.io/badge/Entity%20Framework-512BD4?style=for-the-badge&logo=.net&logoColor=white" alt="Entity Framework">
          </td>
          <td align="center">
            <img src="https://img.shields.io/badge/bootstrap-%238511FA.svg?style=for-the-badge&logo=bootstrap&logoColor=white" alt="Bootstrap">
          </td>
          <td align="center">
            <img src="https://img.shields.io/badge/git-%23F05033.svg?style=for-the-badge&logo=git&logoColor=white" alt="Git">
          </td>
        </tr>
      </table>
    </td>
  </tr>
</table>
## 📸 Screenshots

Views from the project interface:

<div align="center">
  
| 🏠 Home | 🔍 Product Details | ⚙️ My listings |
| :---: | :---: | :---: |
| <img src="https://github.com/YnsBahadir/Garage/blob/main/Picture/Screenshot%202025-12-18%20231705.png" width="300" /> | <img src="https://github.com/YnsBahadir/Garage/blob/main/Picture/Screenshot%202025-12-18%20231835.png" width="300" /> | <img src="https://github.com/YnsBahadir/Garage/blob/main/Picture/Screenshot%202025-12-18%20231904.png" width="300" />|
| 🔍 Creating New Listings | ⚙️ Account Information | ⚙️ Admin Panel |
| <img src="https://github.com/YnsBahadir/Garage/blob/main/Picture/Screenshot%202025-12-18%20231924.png" width="300" /> | <img src="https://github.com/YnsBahadir/Garage/blob/main/Picture/Screenshot%202025-12-18%20231948.png" width="300" /> | <img src="https://github.com/YnsBahadir/Garage/blob/main/Picture/Screenshot%202025-12-18%20232051.png" width="300" /> |

</div>

---

## 🌟 Key Features

### 🛒 Product Management
> Full control over your inventory.
* **CRUD Operations:** Users can list, edit, and delete their own products securely.
* **Image Handling:** Supports both URL-based and File Upload image storage.
* **Categories:** Organized browsing with categories like Electronics, Vehicles, etc.

### 💬 Interactive Q&A System
> Communicate before you buy.
* **Ask a Question:** Potential buyers can leave public questions on product pages.
* **Seller-Only Replies:** Replies are restricted to the product owner, visually highlighted for clarity.

### 📩 Offer System & Notifications
> Smart negotiation tools.
* **Make an Offer:** A dedicated button allows buyers to propose a price.
* **SMTP Integration:** Sellers receive instant, detailed email notifications with buyer contact info upon receiving an offer.

### 🔐 Security & Architecture
> Built on solid foundations.
* **Authentication:** Secure Cookie-based auth using `ClaimsIdentity`.
* **Authorization:** Role-based access (Owners can only edit their own data).
* **N-Tier Architecture:** Clean separation of concerns (Entity, DataAccess, Business, Presentation Layers).

---

## 📂 Project Structure

```text
Garage/
├── BusinessLayer/       # Business Logic & Validation Rules (Managers)
├── DataAccessLayer/     # Database Context & Repositories (EF Core)
├── EntityLayer/         # Concrete Classes & Database Tables
├── Garage/              # Presentation Layer (Controllers, Views, ViewModels)
└── ...
