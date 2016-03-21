Hack4change Movement
====================

Hi and Welcome! This project was born during a 48h hackathon at Workshop 17, Cape Town. Anyone and everyone is invited to collaborate, fork and contribute!

The app can compile on any platform supported by Cordova. 

The front-end development is in NodeJS: Ionic and AngularJS and the latest work is currently in the Queen branch. 

During the course of the hackathon, we've set up many development environments - a Docker container containing all the dependencies was also set up and proved the quickest way to get off to a running start on Linux; the default Node environment on Windows and Mac had almost no issues. 

The back-end is hosted on Azure and the API is coded in .NET which you can do with the free version of Visual Studio. 

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
