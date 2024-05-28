# McIntash Laptops

McIntash Laptops is a ficticious computer manufacturer that wishes to provide product catalog information to retailers.
Their need for a web application to Create, Read, Update and Delete products as well as their need to make the product information available by way of REST API is met by the implementation of this project.
McIntash Laptops also sells products in the "Shop" section of this web application and payments are processed by Stripe.

---
# Metadata

### Author: John Keen
### Application Name: McIntashLaptops
### Project Github Location: https://github.com/thunderblue1/McIntashLaptops.git

## Contents


[link](#Project-Overview)

- What is the McIntash Laptops Project?
- Who made this?

### Project Design
- Site Map
- Wireframes
- Security Matrix
- Top Down System Design
- Use Case
- User Stories
- Database Design
- Rest API
### Project UML
### Coding References
### Project Implementation Details
### How to Run this Project
[link](#How-to-Run-this-Project)

---

# Project Overview

## What is the McIntash Laptops Project?

McIntash laptops is a product catalog and simple e-commerce website.  It allows laptop managers to login and utilize CRUD functionality.
Anyone who registers as a user can use the "Shop" portion of the site and payments are processed by means of Stripe.
Product information is available to retailers by means of REST API endpoints.

### Who made this?

John Keen made this as a senior project with the knowledge and experience he gained from his Grand Canyon University education.


---
# Project Design

### Site Map

![SiteMap](<./Project Documents/images/SiteMap.jpg>)

### Wireframes

![UI1](<./Project Documents/images/UI1.jpg>)
![UI2](<./Project Documents/images/UI2.jpg>)
![UI3](<./Project Documents/images/UI3.jpg>)
![UI4](<./Project Documents/images/UI4.jpg>)
![UI5](<./Project Documents/images/UI5.jpg>)
![UI6](<./Project Documents/images/UI6.jpg>)
![UI7](<./Project Documents/images/UI7.jpg>)
![UI8](<./Project Documents/images/UI8.jpg>)
![UI9](<./Project Documents/images/UI9.jpg>)
![UI10](<./Project Documents/images/UI10.jpg>)
![UI11](<./Project Documents/images/UI11.jpg>)
![UI12](<./Project Documents/images/UI12.jpg>)
![UI13](<./Project Documents/images/UI13.jpg>)
![UI14](<./Project Documents/images/UI14.jpg>)
![UI15](<./Project Documents/images/UI15.jpg>)
![UI16](<./Project Documents/images/UI16.jpg>)
![UI17](<./Project Documents/images/UI17.jpg>)


### Security Matrix

![SecurityMatrix](<./Project Documents/images/SecurityMatrix.jpg>)

### Top Down System Design

![TopDownDesign](<./Project Documents/images/TopDown.jpg>)

### Use Case

![UseCase](<./Project Documents/images/UseCase.jpg>)

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

### Database Design

The McIntash Laptops web application connects to the database in two ways.
The first way is that it leverages Microsofts SqlClient in the DAO.
The second way is that it uses the Entity Framework while connecting to the database for the Identity framework.

![AllLaptops](<./Project Documents/images/RESTAPI-Index.jpg>)
![AllLaptops](<./Project Documents/images/RESTAPI-Index.jpg>)

### REST API

##### Route: GET /api/
##### DAO method: +Index(): IEnumerable\<LaptopModel\>
##### Purpose: Return all products from database

![AllLaptops](<./Project Documents/images/RESTAPI-Index.jpg>)

##### Route: GET /api/searchresults/:searchTerm
##### DAO method: +Index(): IEnumerable\<LaptopModel\>
##### Purpose: Return products with fields matching the search term

![SearchLaptops](<./Project Documents/images/SearchResults.jpg>)

##### Route: GET /api/showonelaptop/:Id
##### DAO method: +Index(): LaptopModel
##### Purpose: Return a product with a matching id

![ShowOneLaptop](<./Project Documents/images/ShowOneLaptop.jpg>)

---
### Project UML

![](<./Project Documents/images/UML1.jpg>)
![](<./Project Documents/images/UML2.jpg>)
![](<./Project Documents/images/UML3.jpg>)
![](<./Project Documents/images/UML4.jpg>)



---

# Coding References


---
# Implementation Details


---
# How to Run this Project

![](<./.jpg>)

---
