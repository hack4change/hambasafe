#REST API Documentation

##Major Entities

###Users

- `/v1/users/`
- `/v1/users?id=1`
- `/v1/users?username="peter"`


###Events

- `/v1/events/`
- `/v1/events?id=1`
- `/v1/events?created-by-user="peter"`
- `/v1/events?attended-by-user="peter"`
- `/v1/events?suburb="rondebosch"`




##Attributes/Types

###EventType

- `/v1/eventtypes`


###Address Attributes

- `/v1/provinces`
- `/v1/cities`
- `/v1/cities?province="Western Cape"`
- `/v1/suburbs`
- `/v1/suburbs?city="Cape Town"`
