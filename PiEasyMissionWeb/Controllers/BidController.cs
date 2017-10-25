using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PiEasyMissionWeb.Models;
using PiEasyMission.Service.Repositories;
using PiEasyMission.Domain.Entities;
using PiEasyMission.Data.Infrastructure;
using System.Net;

namespace PiEasyMissionWeb.Controllers
{
    public class BidController : Controller
    {
        BidService ise = null;
        SkillService sk = null;
       // MemberService ms = null;
        
        public BidController()
        {
            ise = new BidService();
        }
        // GET: Bid
        public ActionResult Index()
        {
            var l = ise.getAllBid();
            return View(l);
        }

        // GET: Bid/Details/5
        public ActionResult Details(int id)
        {
            var Bid = ise.getAllBid();
            List<Bid> lpm = new List<Bid>();
            foreach (var pm in Bid)
            {
                lpm.Add(new Bid
                {
                    Type = pm.Type,
                    Category = pm.Category,
                    Description = pm.Description,
                    City = pm.City

                });
                //recherche
                //if (!String.IsNullOrEmpty(searchString))
                //{
                //    lpm = lpm.Where(m => m.Type.Contains(searchString)).ToList();
                //}
            }

            return View(lpm);
        }

        // GET: Bid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bid/Create ----------------AJOUT ----------------------------
        [HttpPost]
        public ActionResult Create(Bid b)
        {
            if (ModelState.IsValid)
            {
                ise.createBid(b);

                return RedirectToAction("Index");
            }


            else

                return View();
        }

        // GET: Bid/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bid c = ise.getBidById(id);
            if (c == null)
            {
                return HttpNotFound();
            }

            return View(c);
        }

        // POST: Bid/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Bid b)
        {
            if (ModelState.IsValid)
            {
                ise.updateBid(b);
                return RedirectToAction("Index");
            }
            return View(b);
        }

        // GET: Bid/Delete/5
        public ActionResult Delete(int id)
        {
            ise.deleteBidById(id);
            var hs = ise.getAllBid();
            return RedirectToAction("index", hs);
        }

        // POST: Bid/Delete/5
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
        public ActionResult OrderByName()
        {
            IEnumerable<Bid> Bids = ise.getAllBid();

            var Bid = from c in Bids
                       orderby c.Type ascending
                       select c;
            return View(Bid);
        }
      /*  public ActionResult getBidBySkills()
        {
            IEnumerable<Skill> skills = sk.getAllSkill();
            IEnumerable<Bid> bids = bs.getAllBid();


            var skill = from c in skills
                        join b in bids
                       on c.SkillName equals b.SkillName
                        select c;
            return View(skill);
        }*/

        /*  public ActionResult getMemberBySkill()
          {
              IEnumerable<Member> members = ms.getAllMember();
              IEnumerable<Skill> skills = sk.getAllSkill();
              var member = from m in members
                            join c in skills
                            on m.skills equals c.SkillId
                           select m;
              return View(member);

          }*/
    }
}
