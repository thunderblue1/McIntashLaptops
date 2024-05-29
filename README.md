# McIntash Laptops

McIntash Laptops is a ficticious computer manufacturer that wishes to provide product catalog information to retailers.
Their need for a web application to Create, Read, Update and Delete products as well as their need to make the product information available by way of REST API is met by the implementation of this project.
McIntash Laptops also sells products in the "Shop" section of this web application and payments are processed by Stripe.

At the time of the creation of this Web Application it was hosted at the following address:
https://mcintash.azurewebsites.net

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

[Setup Stripe for this Web Application](#Setup-Stripe-for-this-Web-Application)

---

# Project Overview

## What is the McIntash Laptops Project?

McIntash laptops is a product catalog and simple e-commerce website.  It allows laptop managers to login and utilize CRUD functionality.
Anyone who registers as a user can use the "Shop" portion of the site and payments are processed by means of Stripe.
Product information is available to retailers by means of REST API endpoints.
A user with the Manager role can add the LaptopManager role to an existing user so that they can leverage the CRUD functionality of the site.
Once a role is added to a user, the user must log out and then back in to access the CRUD functionality of the site.
The web application is built on ASP.NET MVC.  It uses the Identity Framework in order to manage access to certain controllers using roles.
It uses jQuery to asynchronously call actions and update content on the page such as cards or table rows.
Stripe is used to process payments and a purchase (the total bill) and orders (laptops purchased) are saved upon a successful Stripe payment.

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

The following matrix demonstrates that users with the Manager role can create roles and assign roles to users.
A user with the LaptopManager role has access to CRUD functionality.
A user without a role can only make purchases in the Shop section of the Web Application.
Only allowing a user the privileges they need in order to do their job is the principle of least privilege.
This concept is illustrated in the following security matrix:

![SecurityMatrix](<./Project Documents/images/SecurityMatrix.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### Top Down System Design

The following shows how the Web Application was designed to allow the user to access certain functionality while performing the expected tasks associated with each role.

![TopDownDesign](<./Project Documents/images/TopDown.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### Use Case

The following shows how each user is expected to use the application based on their assigned role.

![UseCase](<./Project Documents/images/UseCase.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### User Stories

List of functional requirements

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
The first way is that it leverages Microsofts SqlClient in the DAOs.
The second way is that it uses the Entity Framework while connecting to the database for the Identity framework.
If in doubt which Dacpac to use try the AzureMcIntashLaptops.dacpac file to recreate the database using the publish feature.

![AllLaptops](<./Project Documents/images/ERDiagram.jpg>)

[Back to Table of Contents](#Table-of-Contents)

### REST API

The REST API intentionally has only three endpoints.  None of the endpoints can Create, Update or Delete products.
This is because retailers are not expected to Create, Update or Delete products and not having endpoints for this functionality helps ensure the integrity of the data in the database.
All of the endpoints return the data in JSON format.
The first endpoint is designed to return all of the products in the database.
The second endpoint is designed to return all products that match a search term in one of the products fields.
The third endpoint can be used to access a single product by the id of the product.

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

[Back to Table of Contents](#Table-of-Contents)

![ModelsUML](<./Project Documents/images/UML2.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![ServicesUML](<./Project Documents/images/UML3.jpg>)

[Back to Table of Contents](#Table-of-Contents)

![ControllersUML](<./Project Documents/images/UML4.jpg>)

[Back to Table of Contents](#Table-of-Contents)

---

# Coding References

Authorization to access a controllers or it's methods is controlled by the use of tags.
The Authorize tag is how ASP.NET controls authorized access to controllers or actions.

The following code is how my application allows a user with the LaptopManager role to access the CRUD functionality of the Web Application.

![AuthorizeLaptopManager](<./Project Documents/images/Coding-AuthorizeController.jpg>)

If a controller is added and needs to be protected then an attribute tag similar to the code reference needs to be added to the controller.

You will also need to create a role and add it to a user for that controller to be accessed:

1. A role can be created by logging in as a user with the "Manager" role such as the Manager@gmail.com account with a password of "PlayHard2!".
2. Then click on "Hello Manager@gmail.com!">"Manage Roles">"Create New Role"
3. Insert the name of the new role and click "Create."
4. Then click on "Hello Manager@gmail.com!">"Manage Users Roles">"Manage Roles" next to the user you wish to add the role to.
5. Click "Add" next to the role you created.
6. Logout and log back in as the user you wish to use to access the new controller


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

# Setup Stripe for this Web Application

1. Create a Stripe account, login and ensure you are in "Test mode"
2. Click in search and type "API Keys"
3. Select Developers>API Keys
4. Click the publishable key to copy it
5. Use the Solution Explorer to navigate to "appsettings.json"
6. Replace the text in double quotes after "PublishableKey": with your publishable key
7. Go back to stripe and click "reveal test key" and then continue.
8. Click to copy the "Secret key" and then go back to "appsettings.json"
9. Replace the text in double quotes after "SecretKey": with your secret key
10. Click the "Save All" button that looks like two floppy disks in the top left corner of Microsoft Visual Studio

Now you need to setup the webhook

##### What is a webhook?

Once Stripe accepts a payment, my application has no way of knowing whether or not a payment has been successfully processed.
What if I wanted to create an order to ship the product to the customer only after a payment was successfully processed?
For this reason, Stripe offers webhooks that allow us to hook into the state of payments in their application.
When an event in Stripe occurs, such as a payment successfully processes, Stripe will send the event to an endpoint in the web application.
My application catches the event and checks if a payment was processed correctly then fulfills the order.


##### Setting up the webhook for the application on a local machine

1. Download and install Stripe CLI: https://docs.stripe.com/stripe-cli
2. Login to Stripe CLI in a command prompt or terminal:
stripe login
3. Issue the following command, in a command prompt or terminal, with the correct port number for your Web Application:
stripe listen --forward-to https://localhost:7085/webhook
4. Copy your signing secret that looks like the following:
whsec_bf0af38039a01b66cd8f2babf3a7b79fddd571830ac16bcccb9a855bbb8a1ef6
5. Use the Solution Explorer in Microsoft Visual Studio to navigate to "Controllers/ShopController.cs"
8. At the bottom of the file is the "/webhook" endpoint
9. Replace the string being assigned to WEBHOOK_SECRET with your webhook secret.  Example:
const string WEBHOOK_SECRET = "whsec_bf0af38039a01b66cd8f2babf3a7b79fddd571830ac16bcccb9a855bbb8a1ef6";
10. Click "Save All" button that looks like two floppy disks
11. If the command prompt is still open then Stripe is forwarding events to the webhook of your application
- Run the application, add items to the cart and then checkout
- Use card: 4242 4242 4242 4242 for payment success
12. Right click on the database "McIntash" and select "New Query ..."
13. Insert the following code into the new query box and click the empty green arrow just under the query tab:

select * from purchase
join orders
on purchase.PurchaseNumber=orders.PurchaseNumber
where 1=1;

This should show the orders with the purchase information such as the payment intent, user name and purchase date.
If you see data then Stripe successfully sent a "payment intent succeeded" event to the web application.


##### Setting up a webhook for the application hosted in the cloud

1. Login to Stripe
2. Search for "webhook" and click on "Developers>Webhooks"
3. Click "Add endpoint" and then enter your domain name followed by /webhook.  Example:
https://mcintash.azurewebsites.net/webhook
4. Click "select events"
5. Search for "payment intent succeeded"
6. Click the checkbox next to "payment_intent.succeeded"
7. Click "Add events"
8. Click "Add endpoint"
9. Click on "Signing secret"
10. Select the text under "Signing secret" and press CTRL+C
11. Use the Solution Explorer to navigate to "Controllers/ShopController.cs"
12. At the bottom of the page is a string called WEBHOOK_SECRET
13. Replace the text in the WEBHOOK_SECRET string by selecting the text and pressing CTRL+V.  Example:
const string WEBHOOK_SECRET = "whsec_llFNP0oIe4DY45dEyixnM0KwJTWZW0dS";
14. Click the "Save All" button that looks like two floppy disks at the top left of Microsoft Visual Studio
15. Right click the project and click "Publish" then proceed with the normal Publishing of the project
- or click Git>Commit, enter a commit message and click "Commit All" then click Git>Push if you used CI/CD for your project. 

The webhook should be successfully setup and Stripe will send payment intent success events to your webhook.

[Back to Table of Contents](#Table-of-Contents)

---
