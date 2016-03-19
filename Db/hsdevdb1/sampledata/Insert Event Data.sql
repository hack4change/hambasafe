--set IDENTITY_INSERT dbo.[Event] ON;

insert into [Event] (EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, MaxWaitingMinutes, DateCreated) 
values (201, 1, 101, 'Walk in the Newlands forrest.', '2016-03-19 07:30:00', '2016-03-19 08:30:00', 'Nice slow walk in the Newlands forrest.', 10, '2016-03-19 00:00:00');

insert into [Event] (EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, MaxWaitingMinutes, DateCreated)
values (202, 2, 102, 'Cycle from Camps Bay to Simonstown and back.', '2016-03-18 06:30:00', '2016-03-19 08:30:00', 'Nice easy ride from Camps Bay to Simonstown via Chapmans Peak and back. Will stop at Cafe Roux for a coffee.', 15, '2016-03-18 00:00:00');

insert into [Event] (EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, MaxWaitingMinutes, DateCreated)
values (203, 3, 103, 'Run up Lions Head.', '2016-03-19 05:45:00', '2016-03-19 08:30:00', 'Run up to the top of Lions Head to see the moon set and sun rise.', 10, '2016-03-17 00:00:00');

insert into [Event] (EventId, OwnerUserId, EventTypeId, Name, DateTimeStart, DateTimeEnd, Description, MaxWaitingMinutes, DateCreated) 
values (204, 4, 104, 'Walk from Rosebank station to UCT.', '2016-03-19 06:00:00', '2016-03-19 06:30:00', 'Looking for other UCT students to walk with me up to upper campus.', 2, '2016-03-17 00:00:00');

--set IDENTITY_INSERT dbo.[Event] OFF;