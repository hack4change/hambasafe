using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Hambasafe.Api.Models.v1;
using Hambasafe.DataLayer.Entities;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Hambasafe.Api.Controllers.v1
{
    [Route("v1/[controller]")]
    public class InvitationsController 
    {
        IMapper Mapper;
        public InvitationsController( IMapper mapper) 
        {
            Mapper = mapper;
        }

        [AllowAnonymous]
        [Route("create-invitation"), HttpPost]
        public async Task<HttpStatusCode> CreateInvitation(InvitationModel invitationModel)
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
               await dataContext.SaveChangesAsync();

                return HttpStatusCode.OK;
           
        }

        [AllowAnonymous]
        [Route("invitations-invitee"), HttpPost]
        public async Task<List<InvitationModel>> GetInvitationsByUserInvitee(int userid)
        {
        
                var dataContext = new HambasafeDataContext();
                var invitations = Mapper.Map<List<Invitation>, List<InvitationModel >> (dataContext.Invitations.Where(e => e.InviteeUserId == userid).ToList());
              

                return  invitations;
           
        }

        [AllowAnonymous]
        [Route("invitations-invitor"), HttpPost]
        public async Task<List<InvitationModel>> GetInvitationsByUserInvitor(int userid)
        {
                var dataContext = new HambasafeDataContext();
                var invitations = Mapper.Map<List<Invitation>, List<InvitationModel>>(dataContext.Invitations.Where(e => e.InvitorUserId == userid).ToList());
                return  invitations;
            
        }
    }
}
