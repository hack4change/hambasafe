<<<<<<< HEAD
﻿#API - Data layer interactions

Results of discussion about responsibility split between API and data layer.

## API Layer
- will provide "view models" to the UI via a RESTful interface.
- view models will present/accept the data as needed by the UI; in other words the API matches the business case, and will not be 1:1 with the data model.
- the business logic will reside in this layer in order to keep the business logic completely separate from dependence on the Entity Framework.

##Data Layer
- will provide a data model for the API layer to interact with which requires no references in the API later code or project to the Entity Framework.
- will provide CRUD methods for the data model entities and a mechanism to wrap multiple entity updates/creates in an atomic transaction.
=======
﻿#API - Data layer interactions

Results of discussion about responsibility split between API and data layer.

## API Layer
- will provide "view models" to the UI via a RESTful interface.
- view models will present/accept the data as needed by the UI; in other words the API matches the business case, and will not be 1:1 with the data model.
- the business logic will reside in this layer in order to keep the business logic completely separate from dependence on the Entity Framework.

##Data Layer
- will provide a data model for the API layer to interact with which requires no references in the API later code or project to the Entity Framework.
- will provide CRUD methods for the data model entities and a mechanism to wrap multiple entity updates/creates in an atomic transaction.
>>>>>>> refs/remotes/origin/master
