# ST10096757 - Monique Jackson - PROG 7111 - POE Part 2

Application Name:	AgriEnergy Connect


This application was developed in response to the growing need for sustainable agricultural practices and the integration of green energy solutions in South Africa. 
AgriEnergy Connect is an initiative that seeks to fill this need, and this initiative needs a web platform to bridge the gap between farmers and the supplier of green energy provider.

This prototype application showcases the general design, look and feel for the potential web platform, as well as designs and develops the basic database needed for the platform.
The prototype focuses on the two main user roles for the platform: 
				Employee and Farmer
And processes how those users are created and what application capabilities they can utilise.
The prototype also explores how products will be added to the database and how to filter data pertaining to products and Farmers.

This web platform was developed on Visual Studio Community 2022, using ASP.NET Core MVC (version 6), utilising SQL Server Management Studio with Entity Framework Core for database management.


This README looks into the application's components, database structure, and key methods. 


		## TABLE OF CONTENTS:

1.	Project Description
2.	Database Structure
3.	How to Use
4.	Step-by-step
5.	Additional Features


						## PROJECT DESCRIPTION

The purpose of this prototype is to showcase the basic functions and UI of the web platform, as well as the general flow or layout of the platform.
It works through the process of creating a user, whether it’s Employee or Farmer and logging that user into the platform where they are provided with functions based on their user roles.
Employee’s can make Farmer users and filter through Farmers.
Farmers can create products and filter through those products.

The data gets stored in a local database and can be manipulated by the user through the website interface.
The prototype is designed to begin the development of the ArgiEnergy Connect web platform’s initiative to provide sustainable farming.


						## DATABASE STRUCTURE

Database Disclaimer:

This project was set up using Individual Accounts, thus utilising Identities in ASP.NET.
This means that the User and Roles tables in the database was already set up upon creation.

There is no need to change the connect	ion string in the JSON, this application is created in Visual Studio.
To see the data stored in the database:
	1. Click the VIEW option on the top of the screen
	2. Select “SQL Server Object Explorer”

Apart from that, the Farmer and Products tables were added to the database.


						## HOW TO USE:

To make use of the AgriEnergy Connect platform, follow these steps:

1. Open Visual Studio
2. Open AngryEnergy project
3. Select TOOLS option at the top of the screen.

4. Go to “NuGet Package Manager” and select Package Manager Console.
5. Type “add-migration “new” by PM and click the enter button.
6. Type “update-database”

7. Run the application.
8. Register as an Employee, by filling is fields (See more on project step-by-step below)
9. Log into application.
10. Enjoy!

		

						## STEP-BY-STEP

Step 1:		Starting Up

	Once the Visual Studio is up and running, and the database is connected, RUN the program.
	This will open up the application in your default browser.

Step 2:		Employee Login & Register

	The first interface that greets the user is the LOGIN INTERFACE.
	Where the user - whether Employee or Farmer - would log into the application.

	If there is no user in the database, a user needs to be created.
	The first user that needs to be created is an Employee user (Note: Farmer user can only be created though the Employee user)

	Step 2.1:	Register Employee 

		To register an Employee, select the REGISTER link on the top right hand corner of the screen.
		This navigates the user to the REGISTER INTERFACE, where the user is prompted to create an account.

		The user needs to enter:
				- Email 		(Note: Emails need to be company issued - “@AgriEnergy.com” - or the account will not be processed.)
				- First Name
				- Last Name
				- Contact
				- Password
				- Confirm Password

		When the user has entered all the necessity information, that fulfils the requirements of that field, they can select the REGISTER button.
		This button immediately logs them into the system.

	Step 2.2: 	Login Employee

		To login the user - whether Employee or Farmer (should an account be created) - the user needs to enter:
				- Email
				- Password
		The user has the option to select “Remember me?”, which will allow them to shut down the application and re-enter it without having to re-enter 		their credentials

		The user will remain logged in for 30 minutes before they are “kicked out” and are required to log in again.

Step 3:		Employee Functions.

Once the Employee has logged in with their employee email address, they are navigated to the Home Screen.

On the Home Screen, they are presented with options for functions:
		- Add Farmer
		- View Farmers
		- Marketplace
		- Farm Hub
		
	Step 3.1:		Adding A Farmer
		
	Once the user selects the ADD FARMER button, they are taken to the ADD FARMER interface.
	Here they are prompted to enter the Farmer User details:
				- First Name
				- Last Name
				- Email Address
				- Contact Number
				- Address
				- Farm Type
	
	Once all of those areas are satisfied, the User selects the SUBMIT button.
	Farmer can make up a temporary password later.
	The user then select the RESET button which clears all fields to add another Farmer user.
	Should the user not want to create another Farmer user, they select the HOME link at the top left of the screen.


	Step 3.2:		Filtering a Farmer

	Back on the Home interface, the user can select the VIEW FARMER button, which takes them to the FILTER FARMERS interface.

	Here the user will be presented with a table detailing all the Farmers in the database.

	They have the option to filter these farmers based of the Product Categories of the products that the Farmers themselves have created, or by Farm 	Type.


	Step 3.3:		Marketplace/Farm Hub

	On the HOME interface, the user can select the VIEW MARKETPLACE button which will redirect them to prototype of the Marketplace Interface.
	Or, the user can select VIEW FARM HUB, which redirects them to the prototype of the Farm Hub Interfaces.
	These prototype are strictly for layout and UI purposes.
	None of the buttons or links are functional.

	They can return to HOME by clicking the HOME link at the top left of the screen.

Step 4:			Farmer Functions.

In order for the Farmer to access the functions of the platform, their profiles/accounts need to be made by the Employee.
Upon creation, the Farmer is given a temporary password that needed to be copied and saved externally. (More on this below)

	Step 4.1:		Login Farmer

		When the Farmer gets to the LOGIN interface, they need to enter:
				- email
				- made up temporary password

		Once they select the LOG IN button, they will be redirected to the RESET PASSWORD interface.

		Here they will be prompted create a new password and confirm that password.
		Once completed, they will select the RESET PASSWORD button, which will take them back to the LOGIN interface.

		This time when they log in, the need to use the password the had just created to access the platform.


Once the Farmer has logged in with their new password they are navigated to the HOME Screen.

On the HOME Screen, they are presented with options for functions:
		- Add Product
		- View Products
		- Marketplace
		- Farm Hub


	Step 4.2:		Adding A Product
		
	Once the user selects the ADD PRODUCT button, they are taken to the ADD PRODUCT interface.
	Here they are prompted to enter the products details:
				- Product Name
				- Select a Category
				- Select a Production Date
	
	Once all of those areas are satisfied, the User selects the ADD PRODUCT button.

	Should the user not want to create another Farmer user, they select the HOME link at the top left of the screen.


	Step 4.3:		Filtering a Product

	Back on the Home interface, the user can select the VIEW PRODUCT button, which takes them to the PRODUCTS interface.

	Here the user will be presented with a cards detailing all the Products in the database that they have created.

	They have the option to filter these products based of the Product Categories or by date of production.
	They can return to HOME by clicking the HOME link at the top left of the screen.


	Step 4.4:		Marketplace/Farm Hub

	On the HOME interface, the user can select the VIEW MARKETPLACE button which will redirect them to prototype of the Marketplace Interface.
	Or, the user can select VIEW FARM HUB, which redirects them to the prototype of the Farm Hub Interfaces.
	These prototype are strictly for layout and UI purposes.
	None of the buttons or links are functional.

	They can return to HOME by clicking the HOME link at the top left of the screen.

Step 5:			Logging out.

Users can log out at any point by selecting the LOGOUT link on the top right hand of the screen.


			## ADDITIONAL FEATURES

This prototype makes use of temporary passwords generated for Farmers to try and mimic when a user gets a temporary password sent to them via email.
Because this is a prototype and the emails used to develop this code is dummy emails, this was second best approach.

The prototype also tries for security by only allowing Employees to register using a “company issued” email.
	


			## AUTHOR:
Monique Jackson 

Thank you for READ-ing ME!

