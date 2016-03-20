using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Hambasafe.Server.Services.Configuration;
using Hambasafe.Server.Services.TableStorage;
using System.Threading.Tasks;
using Hambasafe.DataAccess.Entities;
using Hambasafe.Server.Models.v1;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class InvitationsController : ApiControllerBase
    {
        public InvitationsController(IConfigurationService configuration, ITableStorageService tableStorage) :
            base(configuration, tableStorage)
        {
        }

        [AllowAnonymous]
        [Route("create-invitation"), HttpPost]
        public async Task<HttpResponseMessage> CreateInvitation(InvitationModel invitationModel)
        {
            try
            {
                var dataContext = new HambasafeDataContext();

                var invitationEntity = new Invitation()
                {
                    InvitorUserId = invitationModel.InvitorUserId,
                    InviteeUserId = invitationModel.InviteeUserId,
                    EventId = invitationModel.EventId,
                    OptionalEmailInvitee = invitationModel.OptionalEmailInvitee,
                    Status = invitationModel.Status,
                    Comment = invitationModel.Comment
                };

                dataContext.Invitations.Add(invitationEntity);

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
