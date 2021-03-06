﻿namespace Hambasafe.Api.Models.v1
{
    public class InvitationModel
    {
        public InvitationModel()
        {
        }

       

        public int? InvitationId { get; set; }

        public int? InvitorUserId { get; set; }

        public int? InviteeUserId { get; set; }

        public int? EventId { get; set; }

        public string OptionalEmailInvitee { get; set; }

        public string Status { get; set; }

        public string Comment { get; set; }
    }
}