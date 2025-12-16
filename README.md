# 🚗 GARAGE | Second-Hand E-Commerce Platform

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![Status](https://img.shields.io/badge/status-Active-success.svg)
![NET](https://img.shields.io/badge/.NET%20Core-5.0%2F6.0-purple)

**Garage** is a C2C (Consumer-to-Consumer) e-commerce web application where users can list their second-hand items, interact with sellers via a Q&A system, and make purchase offers via email notifications.

Built with **ASP.NET Core MVC** and **Entity Framework Core**, following the N-Tier Architecture.

---

## 📸 Screenshots

| Home Page | Product Details |
|-----------|-----------------|
| ![Home](https://dummyimage.com/600x400/000/fff&text=Home+Page+Screenshot) | ![Details](https://dummyimage.com/600x400/000/fff&text=Product+Details+Screenshot) |

---

## 🌟 Key Features

### 🛒 Product Management
* **CRUD Operations:** Users can list, edit, and delete their own products.
* **Image Handling:** Product images are stored via URL/File upload.
* **Categories:** Products are organized by categories (Electronics, Vehicles, etc.).

### 💬 Interactive Q&A System
* **Ask a Question:** Potential buyers can ask questions on the product page.
* **Seller-Only Replies:** Only the owner of the product can reply to questions. Replies are visually nested and highlighted.

### 📩 Offer System & Notifications
* **Make an Offer:** Buyers can send price offers directly via the "Make Offer" button.
* **SMTP Email Integration:** The system automatically sends a detailed email to the seller with the buyer's contact info when an offer is made.

### 🔐 User & Security
* **Authentication:** Cookie-based authentication using `ClaimsIdentity`.
* **Authorization:** Role-based access control (only owners can edit/delete their data).
* **Profile Management:** Users can update their profile photo, password, and bio.

### 🎨 Dynamic UI
* **Carousel:** Dynamic slider showcasing featured or latest products.
* **Responsive Design:** Fully responsive UI using Bootstrap 5.

---

## 🛠 Technology Stack

* **Backend:** C#, ASP.NET Core MVC
* **ORM:** Entity Framework Core (Code First)
* **Database:** MS SQL Server
* **Frontend:** HTML5, CSS3, Bootstrap 5, JavaScript
* **Architecture:** N-Tier Architecture (Entity, DataAccess, Business, Presentation Layers)
* **Tools:** Visual Studio, SSMS

---

## 🚀 Getting Started

Follow these steps to run the project locally.

### 1. Clone the Repository
```bash
git clone [https://github.com/YnsBahadir/Garage.git](https://github.com/YnsBahadir/Garage.git)
