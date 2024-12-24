How to RUN the solution :
Solution is a WebApi implememnted in .Net Core 8.0. As user interface you have a swagger when you run the solution automatically for testing the endpoints.
Has been prepared for being dockerized and deployed in kubernettes system.

Run the solution with :

	- IIS Expreess local machine, just punch launch button with IIS Express option selected.
	- Unit test solution.
	- Docker-compose.

Endpoints :

	- CRUD endpoints for albums and photos (Create, Read, Update and Delete)
	- Get filtered albums (by title)
	- Get filtered photos (by title or by album identifier)
	- Save all albums and photos comming from API call into SQL Server data local base (mdf file also atached in this same solution, also init sql script is added in migrations layer).

Improvements to be done if I would have more time :

	- Implement a front end user interface (maybe using windows forms or react), then I would have the option as required in tech requirements test calling albums/photos API from front end side.
	- It was not implemented in Visual Basic language. It has been implemented in C# because is is the Language i most dominate and I want to do my best i can in this test.
	It is not an issue learn viasual basic, just some little days.