using Microsoft.AspNetCore.Mvc;
using PartyApp.Business.Concrete;
using PartyApp.Entity.Concrete;
using PartyApp.MVC.Models;
using PartyApp.Shared.ViewModels;
using System.Diagnostics;

namespace PartyApp.MVC.Controllers
{
    public class HomeController : Controller
    {

        private readonly InvitationService _invitationService;
        private readonly ParticipantsService _participantsService;

        public HomeController(InvitationService invitationService, ParticipantsService participantsService)
        {
            _invitationService = invitationService;
            _participantsService = participantsService;
        }

        public IActionResult Index()
        {
            var invitations = _invitationService.GetAll();
            return View(invitations);
        }
        public IActionResult Join(int id)
        {
            var i = _invitationService.GetById(id);
            var p = _participantsService.GetAllByInvitationId(id);
            var count = p.Count();
            JoinViewModel joinViewModel = new()
            {
                Invitation = i,
                Participants = p,
                CountOfParticipants = count
            };
            return View(joinViewModel);
        }



        [HttpPost]
        public IActionResult Join(AddParticipantViewModel model, int invitationId)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var i = _invitationService.GetById(invitationId);
            var p = _participantsService.GetAllByInvitationId(invitationId);
            var count = p.Count();
            JoinViewModel joinViewModel = new()
            {
                Invitation = i,
                Participants = p,
                CountOfParticipants = count
            };
            return View(joinViewModel);
        }

        [HttpPost]
        public IActionResult Ahmet(AddParticipantViewModel model, int invitationId)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            var i = _invitationService.GetById(invitationId);
            var p = _participantsService.GetAllByInvitationId(invitationId);
            var count = p.Count();
            JoinViewModel joinViewModel = new()
            {
                Invitation = i,
                Participants = p,
                CountOfParticipants = count
            };
            return View(joinViewModel);
        }

    }
    }

