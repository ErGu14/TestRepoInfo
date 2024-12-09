using Microsoft.EntityFrameworkCore;
using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete.Repositories
{
    public class ParticipantRepository
    {
        private readonly AppDbContext _appDbContext;

        public ParticipantRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Participant> GetAll()
        {
            var participants = _appDbContext.Participants.ToList();


            return participants;
        }
        public List<Participant> GetAll(int invitationId)
        {
            
            //Databaseden tüm Participantsları çekip döndüreceğiz 
            var participants =
                _appDbContext
                .Participants
                .Include(x => x.InvitationParticipants)//sql serverdeki join metodunun burdaki karşılığı 
                .ThenInclude(ip => ip.Invitation)    // dahil etmek
                .ToList();

            return participants;
        }

        public Participant GetById(int id)
        {
            var Participant = _appDbContext.Participants.Where(x => x.Id == id).FirstOrDefault();
            return Participant;
        }
        public void Create(Participant Participant)
        {
            _appDbContext.Participants.Add(Participant);
            _appDbContext.SaveChanges();

        }
        public void Update(Participant Participant)
        {
            _appDbContext.Participants.Update(Participant);
            _appDbContext.SaveChanges();
        }
        public void Delete(Participant Participant)
        {
            _appDbContext.Participants.Remove(Participant);
            _appDbContext.SaveChanges();
        }
    }
}
