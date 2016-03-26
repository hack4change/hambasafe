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
using AutoMapper;

namespace Hambasafe.Server.Controllers.v1
{
    [RoutePrefix("v1")]
    public class InvitationsController : ApiControllerBase
    {
        IMapper Mapper;
        public InvitationsController(IConfigurationService configuration, ITableStorageService tableStorage, IMapper mapper) :
            base(configuration, tableStorage)
        {
            Mapper = mapper;
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

               // dataContext.Invitations.Add(invitationEntity);
                dataContext.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("invitations-invitee"), HttpPost]
        public async Task<HttpResponseMessage> GetInvitationsByUserInvitee(int userid)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                var invitations = Mapper.Map<List<Invitation>, List<InvitationModel >> (dataContext.Invitations.Where(e => e.InviteeUserId == userid).ToList());
              

                return Request.CreateResponse(HttpStatusCode.OK, invitations);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }

        [AllowAnonymous]
        [Route("invitations-invitor"), HttpPost]
        public async Task<HttpResponseMessage> GetInvitationsByUserInvitor(int userid)
        {
            try
            {
                var dataContext = new HambasafeDataContext();
                var invitations = Mapper.Map<List<Invitation>, List<InvitationModel>>(dataContext.Invitations.Where(e => e.InvitorUserId == userid).ToList());

                return Request.CreateResponse(HttpStatusCode.OK, invitations);
            }
            catch (Exception error)
            {
                return HandleError(error);
            }
        }
    }
}
