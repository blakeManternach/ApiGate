# ApiGate

<h4>Summary</h4>
<p>Api written to provide CRUD endpoints for different -gate controversies (https://en.wikipedia.org/wiki/List_of_-gate_scandals_and_controversies).  The API also contains a web scraping project (ApiGate/WebScraping) written in python that scrapes all controversies from the above wikipedia page, then posts them to the api through an endpoint that allows batch adding a group of “gates”, and ultimately saves them to a sql server instance.  This project practices “Clean Architecture” and the MediatR Pattern (https://github.com/jasontaylordev/CleanArchitecture ). This project also contains a testing project that demonstrates unit and integration testing.  All data is contained and modified through sql server and entity framework core.</p>

<h4>Technologies Used</h4>
<p>C#, .Net Core, Restful API, Entity Framework, MediatR, AutoMapper, CQRS, Clean Architecture, Swagger, SQL Server, Unit Testing, Integration Testing, Python, Web Scraping, git</p>
