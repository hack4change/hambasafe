set IDENTITY_INSERT Invitation ON;

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (301, 1, 2, 201, null, '2016-03-19 00:00:00', 'invited', null);

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (302, 1, 3, 201, null, '2016-03-19 00:00:00', 'accepted', null);

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (303, 1, 4, 201, null, '2016-03-19 00:00:00', 'accepted', null);

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (304, 1, 5, 201, null, '2016-03-19 00:00:00', 'cancelled', 'Sorry guys, I cannot make it. My kid is sick!');

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (305, 6, 7, 202, null, '2016-03-19 00:00:00', 'invited', null);

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (306, 6, 8, 202, null, '2016-03-19 00:00:00', 'accepted', null);

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (307, 6, 9, 202, null, '2016-03-19 00:00:00', 'accepted', null);

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (308, 6, 10, 202, null, '2016-03-19 00:00:00', 'cancelled', 'Sorry guys, I have injured myself!');

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (309, 4, 5, 202, null, '2016-03-19 00:00:00', 'accepted', null);

insert into Invitation (InvitationId, InvitorUserId, InviteeUserId, EventId, OptionalEmailInvitee, DateCreated, Status, StatusReason) values (310, 4, 6, 202, null, '2016-03-19 00:00:00', 'accepted', null);

set IDENTITY_INSERT Invitation OFF;