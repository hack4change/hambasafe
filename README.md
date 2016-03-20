Hambasafe Application
=====================

The Hambasafe Application repository consists of two main solutions located in the Client and Server folders.

Server
------
Server code for the Hambasafe application.  Application architecture consists of a 3-tier model consisting of:
- Hamba.Server
Azure hosted WebAPI at [HambasafeDev.azurewebsites.net](http://hambasafedev.azurewebsites.net/api/): `http://hambasafedev.azurewebsites.net/api/`

- Hamba.Logic
Business Logic layer responsible for translating DataAccess models to models in the WebApi Layer

- Hamba.DataAccess
Data Access layer responsible for performing CRUD operations on the SQL Azure hosted database.  Entity Framework (EF6) is used as the translating ORM.
