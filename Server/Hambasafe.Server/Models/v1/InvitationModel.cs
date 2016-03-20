using Entities = Hambasafe.DataAccess.Entities;

namespace Hambasafe.Server.Models.v1
{
    public class InvitationModel
    {
        public InvitationModel()
        {
        }

        public InvitationModel(Entities.Invitation dbInvitation)
        {
            InvitationId = dbInvitation.InvitationId;
            InvitorUserId = dbInvitation.InvitorUserId;
            InviteeUserId = dbInvitation.InviteeUserId;
            EventId = dbInvitation.EventId;
            OptionalEmailInvitee = dbInvitation.OptionalEmailInvitee;
            Status = dbInvitation.Status;
            Comment = dbInvitation.Comment;
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