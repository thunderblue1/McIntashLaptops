# McIntash Laptops

McIntash Laptops is a ficticious computer manufacturer that wishes to provide product catalog information to retailers.
Their need for a web application to Create, Read, Update and Delete products as well as their need to make the product information available by way of REST API is met by the implementation of this project.
McIntash Laptops also sells products in the "Shop" section of this web application and payments are processed by Stripe.

---
# Metadata

### Author: John Keen
### Application Name: McIntashLaptops
### Project Github Location: https://github.com/thunderblue1/McIntashLaptops.git

## Table of Contents

[Project Overview](#Project-Overview)
- [What is the McIntash Laptops Project?](#What-is-the-McIntash-Laptops-Project?)
- [Who made this?](#Who-made-this?)

[Project Design](#Project-Design)
- [Site Map](#Site-Map)
- [Wireframes](#Wireframes)
- [Security Matrix](#Security-Matrix)
- [Top Down System Design](#Top-Down-System-Design)
- [Use Case](#Use-Case)
- [User Stories](#User-Stories)
- [Database Design](#Database-Design)
- [Rest API](#Rest-API)

[Project UML](#Project-UML)

[Coding References](#Coding-References)

[Project Implementation Details](#Project-Implementation-Details)

[How to Run this Web Application](#How-to-Run-this-Web-Application)

---

# Project Overview

## What is the McIntash Laptops Project?

McIntash laptops is a product catalog and simple e-commerce website.  It allows laptop managers to login and utilize CRUD functionality.
Anyone who registers as a user can use the "Shop" portion of the site and payments are processed by means of Stripe.
Product information is available to retailers by means of REST API endpoints.

### Who made this?

John Keen made this as a senior project with the knowledge and experience he gained from his Grand Canyon University education.

[Back to Table of Contents](#Table-of-Contents)

---
# Project Design

### Site Map

![SiteMap](<./Project Documents/images/SiteMap.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### Wireframes

![UI1](<./Project Documents/images/UI1.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI2](<./Project Documents/images/UI2.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI3](<./Project Documents/images/UI3.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI4](<./Project Documents/images/UI4.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI5](<./Project Documents/images/UI5.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI6](<./Project Documents/images/UI6.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI7](<./Project Documents/images/UI7.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI8](<./Project Documents/images/UI8.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI9](<./Project Documents/images/UI9.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI10](<./Project Documents/images/UI10.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI11](<./Project Documents/images/UI11.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI12](<./Project Documents/images/UI12.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI13](<./Project Documents/images/UI13.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI14](<./Project Documents/images/UI14.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI15](<./Project Documents/images/UI15.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI16](<./Project Documents/images/UI16.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![UI17](<./Project Documents/images/UI17.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### Security Matrix

![SecurityMatrix](<./Project Documents/images/SecurityMatrix.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### Top Down System Design

![TopDownDesign](<./Project Documents/images/TopDown.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### Use Case

![UseCase](<./Project Documents/images/UseCase.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### User Stories

List of requirements

- As a user, I would like to be able to register a new account so that I can login.
- As a user, I would to be able to login so that I can access the features of the website.
- As a user, I would like to be able to logout so that I can protect data that may be vital to me or my company.
- As a Laptop Manger, I would like to be able to switch between a table view and a card view so that I can easily find what I am looking for and ensure that the information and image for the laptop is correct.
- As a Laptop Manager, I would like to be able to search for laptops so that I can quickly find a laptop that needs to be edited or deleted.
- As a Laptop Manger, I would like to be able to click a button that loads a create form so that I can create a laptop entry in the catalog.
- As a Laptop Manager, I would like to be able to click a button that loads an edit form so that I can quickly edit a laptop entry.
- As a Laptop Manager, I would like to be able to click a delete button so that I can delete a laptop entry.
- As a Laptop Manager, I would like to be able to click a details button so that I can navigate to a page with the full details and full description for a laptop entry.
- As a Laptop Manager, I would like to be able to see the same search results while switching between table and card view so that I can readily find the information I am looking for.
- As a Manager, I would like to be able to register a new user so that I can get an employee started.
- As a Manager, I would like to be able to create or delete user roles so that I can add roles for new pages that require authorization for a particular role or remove roles that were only needed for pages that have been removed from the web application. 
- As a Manager, I would like to be able to assign or unassign roles for a user so that I can manage who has access to particular features of the site.
- As a Manager, I would like to be able to search for users so that I can quickly find a particular user.
- As a retailer, I would like to be able to consume a REST API so that I can display the manufacturers data on my website.
- As a Customer, I would like to be able search for a particular laptop so that I can find a laptop of interest.
- As a Customer, I would like to be able to click a button that navigates to a full details page of a laptop entry so that I can learn more about a particular laptop.
- As a Customer, I would like to be able to add an item to the cart from the products page so that I can add more than one item to the cart.
- As a Customer, I would like to see the items in my cart so that I can know what I am purchasing.
- As a Customer, I would like to be able to add or remove items in the cart so that I can manage what I am purchasing without having to navigate to a previous page.
- As a Customer, I would like to be able to checkout so that I can complete my order

[Back to Table of Contents](#Table-of-Contents)

### Database Design

The McIntash Laptops web application connects to the database in two ways.
The first way is that it leverages Microsofts SqlClient in the DAO.
The second way is that it uses the Entity Framework while connecting to the database for the Identity framework.
If in doubt which Dacpac to use try the AzureMcIntashLaptops.dacpac file to recreate the database using the publish feature.

![AllLaptops](<./Project Documents/images/ERDiagram.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### REST API

##### Route: GET /api/
##### DAO method: +Index(): IEnumerable\<LaptopModel\>
##### Purpose: Return all products from database

![AllLaptops](<./Project Documents/images/RESTAPI-Index.jpg>)

##### Route: GET /api/searchresults/:searchTerm
##### DAO method: +Index(): IEnumerable\<LaptopModel\>
##### Purpose: Return products with fields matching the search term

![SearchLaptops](<./Project Documents/images/RESTAPI-SearchResults.jpg>)

##### Route: GET /api/showonelaptop/:Id
##### DAO method: +Index(): LaptopModel
##### Purpose: Return a product with a matching id

![ShowOneLaptop](<./Project Documents/images/RESTAPI-ShowOneLaptop.jpg>)

[Back to Table of Contents](#Table-of-Contents)

---
### Project UML

![ApplicationUser](<./Project Documents/images/UML1.jpg>)
![ModelsUML](<./Project Documents/images/UML2.jpg>)
![ServicesUML](<./Project Documents/images/UML3.jpg>)
![ControllersUML](<./Project Documents/images/UML4.jpg>)

[Back to Table of Contents](#Table-of-Contents)

---

# Coding References

[Back to Table of Contents](#Table-of-Contents)

---
# Implementation Details

[Back to Table of Contents](#Table-of-Contents)

---
# How to Run this Web Application

1. Download Microsoft Visual Studio (Community Edition is Free)
2. Clone the project by going to "Git" in the menu and then "Clone Repository"
3. Open the SQL Server Object Explorer by clicking on "View" in the menu then clicking on "SQL Server Object Explorer"
4. Create a new database named McIntash.
- Click on the "local (SQL Server ..." and right click on "Databases."  Then click "Add New Database"
5. Right click on the new "McIntash" database and select "Publish Data-tier Application"
6. Click "Browse" and navigate to the project folder entitled "McIntashLaptops"
7. Select AzureMcIntashLaptops.dacpac then click "Open."  Then click "Publish"
8. Wait until the output is finished and green checkmarks show up in the output.
9. Click on the arrow next to the database.  In the bottom right should be a properties window.
10. Scroll down to "Connection String" and double click until the box to the right is highlighted.
- Press the "CTRL" and "C" buttons simultaneously.
- If the connection string does not work then copy the following:
Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=McIntash;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
12. Use the "Solution Explorer" to the right to navigate to "Services/LaptopDAO.cs"
13. Select everything between the double quotes that is the string being assigned to "connectionString"
14. Press the "CTRL" and "V" buttons simultaneously.
15. Use the Solution Explorer to navigate to "Services/CheckoutDAO.cs"
16. Select everything between the double quotes that is the string being assigned to "connectionString"
17. Press the "CTRL" and "V" buttons simultaneously.
18. Use the Solution Explorer to navigate to "appsettings.json"
19. Select the line with "ApplicationDbContextConnection" and replace it with the following:
"ApplicationDbContextConnection": "Server=(localdb)\\mssqllocaldb;Database=McIntash;Trusted_Connection=True;MultipleActiveResultSets=true"
20. Click the "Save All" button that looks like two blue floppy disks in the top left corner of the application.
21. Click the green play button to the left of "McIntashLaptops" at the top of the program.

At this point the application should run.
You should be able to click "Login" and login using the following credentials:

Email: Manager@gmail.com
Password: PlayHard2!

For setting up Stripe to process purchases then please see the following section.

[Back to Table of Contents](#Table-of-Contents)

--- 

##### Setup Stripe



[Back to Table of Contents](#Table-of-Contents)

---
