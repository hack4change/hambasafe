set IDENTITY_INSERT EventType ON;

insert into EventType (EventTypeid, Name, Description) values (101, 'Recreational Walk','A recreational walk');

insert into EventType (EventTypeid, Name, Description) values (102, 'Road Ride','A recreational road ride');

insert into EventType (EventTypeid, Name, Description) values (103, 'Road Run','A recreational road run');

insert into EventType (EventTypeid, Name, Description) values (104, 'Commuter Walk','A commuter walk from A to B');

insert into EventType (EventTypeid, Name, Description) values (105, 'Trail run','A recreational trail run');

insert into EventType (EventTypeid, Name, Description) values (106, 'MTB Ride','A recreational mountain bike ride');

set IDENTITY_INSERT EventType OFF;