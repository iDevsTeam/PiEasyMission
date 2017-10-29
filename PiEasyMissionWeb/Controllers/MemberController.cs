using PiEasyMission.Domain.Entities;
using PiEasyMission.Service.Repositories;
using PiEasyMissionWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mail;
using System.Net.Mail;
using System.Web.Mvc;

namespace PiEasyMissionWeb.Controllers
{
    public class MemberController : Controller
    {
        MemberService ms = null;
        public MemberController()
        {
            ms = new MemberService();
        }
        // GET: Member
        public ActionResult Index()
        {
            IEnumerable <MemberModels> members = TempData["members"] as IEnumerable<MemberModels>;
            return View(members);
        }

        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            Member p = ms.GetById(id);
            MemberModels pm = new MemberModels

            {
                firstName = p.firstName,
                lastName = p.lastName,
                phone_num = p.phone_num,
                email = p.email,
                skills = p.skills,
               
            };


            return View(pm);

        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Member/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Member/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Member/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }


        public ActionResult Contacter()
        {
            MemberModels m = new MemberModels();
            string subject = "EasyMission";
            string body = "Bonjour, Vous avez le Skill que je cherche, je vous choisis pour echanger un service avec vous si vous êtes interesser";


            string FromMail = "easymission1@gmail.com";
            string emailTo = "yasminebeya.bennani@esprit.tn";
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.mailgun.org");
            mail.From = new MailAddress(FromMail);
            mail.To.Add(emailTo);
            mail.Subject = subject;
            mail.IsBodyHtml = true;
            mail.Body = body;
            SmtpServer.Port = 25;
            SmtpServer.Credentials = new System.Net.NetworkCredential("postmaster@sandboxaf272db71ba142ac9942b71f85bfbab8.mailgun.org", "d3f64c9fd19ecc97d4dcfce5ca658371");
            SmtpServer.EnableSsl = false;
            SmtpServer.Send(mail);
            return RedirectToAction("Index", "Bid");

        }
    }
}
