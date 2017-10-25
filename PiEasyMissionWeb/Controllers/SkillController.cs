using System;
using System.Collections.Generic;
using System.Linq;
using PiEasyMission.Service.Repositories;
using System.Web;
using System.Web.Mvc;
using PiEasyMission.Data.Infrastructure;
using PiEasyMissionWeb.Models;
using PiEasyMission.Domain.Entities;

namespace PiEasyMissionWeb.Controllers
{
    public class SkillController : Controller
    {
        SkillService skserv = null;
        IUnitOfWork iuwk = null;

        public SkillController()
        {
            skserv = new SkillService();
        }

        
        // GET: Skill
        public ActionResult Index()
        {
            List<SkillModels> sklist = new List<SkillModels>();

            if (ModelState.IsValid)
            {
                foreach (var item in skserv.getAllSkill())
                {
                    SkillModels SM = new SkillModels();

                    SM.SkillId = item.SkillId;
                    SM.SkillName = item.SkillName;
                    SM.SkillLevel = item.SkillLevel;
                    

                    sklist.Add(SM);
                }

                return View(sklist);
            }

            return View(sklist);
        }

        // GET: Skill/Details/5
        public ActionResult Details(int id)
        {
            Skill s = skserv.GetById(id);
            SkillModels skm = new SkillModels

            {
                SkillName = s.SkillName,
                SkillLevel = s.SkillLevel
            };
            return View(skm);
        }

        // GET: Skill/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skill/Create
        [HttpPost]
        public ActionResult Create(SkillModels s)
        {

            if (ModelState.IsValid)
            {
                Skill sk = new Skill
                {
                    
                    SkillName = s.SkillName,
                    SkillLevel = s.SkillLevel

                };

                skserv.createSkill(sk);
                skserv.Commit();
            }



            return RedirectToAction("Index");



        }

        // GET: Skill/Edit/5
        public ActionResult Edit(int id)
        {
            Skill sl = skserv.GetById(id);

            SkillModels sm = new SkillModels();


            sm.SkillName = sl.SkillName;
            sm.SkillLevel = sl.SkillLevel;


            return View(sm);
        }

        // POST: Skill/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SkillModels collection)
        {
            try
            {
                Skill s = skserv.getSkillById(id);
                //s.SkillId = collection.SkillId;
                s.SkillName = collection.SkillName;
                s.SkillLevel = collection.SkillLevel;
                
                skserv.updateSkill(s);
                skserv.Commit();
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Edit", "Skill");

            }
        }

        // GET: Skill/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Skill/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, SkillModels collection)
        {
            try
            {
                // TODO: Add delete logic here
                Skill s = skserv.getSkillById(id);
                //s.SkillId = collection.SkillId;
                skserv.deleteSkill(s);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult OrderByName()
        {
            IEnumerable<Skill> Skills = skserv.getAllSkill();

            var Skill = from c in Skills
                      orderby c.SkillName ascending
                      select c;
            return View(Skill);
        }
    }
}
