using PartyApp.Data.Concrete.Repositories;
using PartyApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Business.Concrete
{
    public class ParticipantsService
    {
        private readonly ParticipantRepository _participantRepository;

        public ParticipantsService(ParticipantRepository participantRepository)
        {
            _participantRepository = participantRepository;
        }
        public List<ParticipantViewModel> GetAllByInvitationId(int invitationId)
        {
            var participants = _participantRepository.GetAll(invitationId);
            var result = participants.Select(x => new ParticipantViewModel
            {
                Id = x.Id,
                FullName = x.FullName,
                Email = x.Email,
                Age = x.Age,
                NumberOfPeople = x.NumberOfPeople,
                PhoneNumber = x.PhoneNumber,
                Invitations = x.InvitationParticipants.Select(ip => new InvitationViewModel
                {
                    Id = ip.Invitation.Id,
                    EventName = ip.Invitation.EventName,
                    EventDate = ip.Invitation.EventDate                   
                }).ToList()
            }).ToList();
            return result;

        }
        public List<ParticipantViewModel> GetAll()
        {
            var participants = _participantRepository.GetAll();
            var pViewModel = participants.Select(p => new ParticipantViewModel
            {
                Id = p.Id,
                FullName = p.FullName,
                Age = p.Age,
                NumberOfPeople = p.NumberOfPeople,
                PhoneNumber = p.PhoneNumber,
                Email = p.Email
                

            }).ToList();
            return pViewModel;
        }



    }
}
