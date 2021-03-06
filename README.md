Hambasafe Application
=====================

Hi and Welcome!
---------------

The application can compile on any platform supported by [Cordova](https://cordova.apache.org/). 

The front-end (Client) development is in NodeJS: [Ionic](http://ionicframework.com/) and [AngularJS v1](https://angularjs.org/) and the latest work is currently in the [Queen](https://github.com/hack4change/hambasafe/tree/queen) branch. 

Development can be done on Mac, Windows and Linux - a Docker container containing all the dependencies was also set up and proved the quickest way to get off to a running start on Linux; the default Node environment on Windows and Mac had almost no issues. 

The official back-end (Server) is hosted on [Azure](https://azure.microsoft.com/en-us/) and the API is coded in .NET which you can do with the [free version of Visual Studio](https://www.visualstudio.com/en-us/products/visual-studio-dev-essentials-vs.aspx). 

Server
------
Server code for the Hambasafe application.  Application architecture consists of a 3-tier model consisting of:
- Hamba.Server
Azure hosted WebAPI at [HambasafeDev.azurewebsites.net](http://hambasafedev.azurewebsites.net/api/): `http://hambasafedev.azurewebsites.net/api/`

- Hamba.Logic
Business Logic layer responsible for translating DataAccess models to models in the WebApi Layer

- Hamba.DataAccess
Data Access layer responsible for performing CRUD operations on the SQL Azure hosted database.  Entity Framework (EF6) is used as the translating ORM.


Hack4change Movement
====================

This project was born during a 48h [hackathon](https://twitter.com/hashtag/hambasafe) at Workshop 17, Cape Town. Anyone and everyone is invited to join, collaborate, fork and contribute!

![Hackathon Team](/Hackathon Team.jpg?raw=true "Hackathon Team Photo")

Join us!
