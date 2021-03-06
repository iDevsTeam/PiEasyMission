﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PiEasyMissionWeb.Models;
using PiEasyMission.Service.Repositories;
using PiEasyMission.Domain.Entities;
using PiEasyMission.Data.Infrastructure;
using System.Net;
using PagedList;


namespace PiEasyMissionWeb.Controllers
{
    public class BidController : Controller
    {
        BidService bs = null;
        SkillService sk = null;
        MemberService ms = null;
        
        public BidController()
        {
            bs = new BidService();
            sk = new SkillService();
            ms = new MemberService();
        }
        // GET: Bid
        public ActionResult Index(/*int page = 1, int pageSize = 4*/)
        {

           List<BidModels> list = new List<BidModels>();
            //PagedList<BidModels> model = new PagedList<BidModels>(list, page, pageSize);
            if (ModelState.IsValid)
            {
                foreach (var item in bs.getAllBid())
                {
                    BidModels PVM = new BidModels();

                    PVM.BidId = item.BidId;
                    PVM.StartDate = item.StartDate;
                    PVM.EndDate = item.EndDate;
                    PVM.Category = item.Category;
                    PVM.City = item.City;
                    PVM.Description = item.Description;
                    PVM.Type = item.Type;


                    list.Add(PVM);
                }

                return View(list);
            }
            return View(list);
        }

        // GET: Bid/Details/5
        public ActionResult Details(int id)
        {
            Bid p = bs.GetById(id);
            BidModels pm = new BidModels

            {
                Description = p.Description,
                Type = p.Type,
                Category = p.Category,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                SkillName = p.SkillName,
                City = p.City
            };


            return View(pm);
        }

        // GET: Bid/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bid/Create ----------------AJOUT ----------------------------
        [HttpPost]
        public ActionResult Create(BidModels b)
        {
            if (ModelState.IsValid)
            {
                Bid p = new Bid
                {
                    Type = b.Type,
                    Description = b.Description,
                    Category = b.Category,
                    EndDate = b.EndDate,
                    StartDate = b.StartDate,
                    City = b.City,
                    SkillName = b.SkillName,
                    MemberId = 7,
                  

                };
                bs.createBid(p);
                bs.Commit();

            }

           
            List<MemberModels> md = new List<MemberModels>();
            foreach (var item in bs.getMemberBySkill(b.SkillName))
            {
                MemberModels PVM = new MemberModels();

                PVM.firstName = item.firstName;
                PVM.lastName = item.lastName;
                PVM.email = PVM.email;
                PVM.skills = PVM.skills;
                md.Add(PVM);
            }
            TempData["members"] = md;

            return RedirectToAction("Index","Member");
        }

        // GET: Bid/Edit/5
        public ActionResult Edit(int id)
        {
            Bid p = bs.GetById(id);

            BidModels pm = new BidModels();


            pm.Description = p.Description;
            pm.Category = p.Category;
            pm.Type = p.Type;
            pm.StartDate = p.StartDate;
            pm.EndDate = p.EndDate;
            pm.City = p.City;
            pm.SkillName = p.SkillName;

            return View(pm);
        }

        // POST: Bid/Edit/5
        [HttpPost]
        public ActionResult Edit(int id , BidModels collection)
        {
            try
            {
                Bid p = bs.GetById(id);
                p.BidId = collection.BidId;
                p.StartDate = collection.StartDate;
                p.EndDate = collection.EndDate;
                p.Description = collection.Description;
                p.SkillName = collection.SkillName;


                bs.Update(p);
                return RedirectToAction("Index");

            }
            catch (Exception)
            {
                return RedirectToAction("Edit", "Bid");

            }
        }

        // GET: Bid/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bid/Delete/5
        [HttpPost]
        public ActionResult Delete(int id,FormCollection cl)
        {
            try
            {
                Bid p = bs.getBidById(id);
               

                bs.deleteBid(p);
                bs.Commit();
                return RedirectToAction("index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult OrderByName()
        {
            IEnumerable<Bid> Bids = bs.getAllBid();

            var Bid = from c in Bids
                       orderby c.Type ascending
                       select c;
            return View(Bid);
        }
        public ActionResult getBidBySkills()
        {
            IEnumerable<Skill> skills = sk.getAllSkill();
            IEnumerable<Bid> bids = bs.getAllBid();


            var skill = from c in skills
                        join b in bids
                       on c.SkillName equals b.SkillName
                        select c;
            return View(skill);
        }

       
       
             public ActionResult getMemberBySkill()
        {

            var b = from member1 in ms.getAllMember()
                    from Bid1 in bs.getAllBid()
                    where member1.MemberId == Bid1.MemberId
                    where Bid1.SkillName == member1.Skills.Select(e => e.SkillName).First()
                    select member1;

            return View(b);
        }
       

    }
    }

