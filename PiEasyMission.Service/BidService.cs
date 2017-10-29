using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiEasyMission.Service.Interfaces;
using PiEasyMission.Domain.Entities;
using System.Data.Entity;
using PiEasyMission.Data.Infrastructure;
using ServicesPattern;

namespace PiEasyMission.Service.Repositories
{
    public class BidService : Service<Bid> , IBidService
    {
        public static IDataBaseFactory dbFactory;
        public static IUnitOfWork myUnit;
        MemberService ms = null;

        public BidService() : base(myUnit)
        {
            dbFactory = new DataBaseFactory();
            myUnit = new UnitOfWork(dbFactory);
            ms = new MemberService();
        }

        public void createBid(Bid i)
        {
            string filtred = filterComment(i.Description);
            i.Description = filtred;

            myUnit.getRepository<Bid>().Add(i);
            myUnit.Commit();
        }


        /*--------------Filtre des Mots sur l'annonce ----------------*/
        public string filterComment(string comment)
        {
            ICollection<string> listCommnt = comment.Split(' ').ToList();
            ICollection<string> listCommntNew = new List<string>();
            foreach (string e in listCommnt)
            {
                if (e.ToLower().Contains("fuck"))
                    listCommntNew.Add("****");
                else if (e.ToLower().Contains("bitch"))
                    listCommntNew.Add("****");
                else if (e.ToLower().Contains("merde"))
                    listCommntNew.Add("****");
                else if (e.ToLower().Contains("shit"))
                    listCommntNew.Add("****");
                else
                    listCommntNew.Add(e);
            }
            string result = "";
            foreach (string e in listCommntNew)
                result = result + e + " ";
            return result;
        }

        public void deleteBid(Bid i)
        {
            myUnit.getRepository<Bid>().Delete(i);
            myUnit.Commit() ;
        }

        public void deleteBidById(int id)
        {
            Bid i = myUnit.getRepository<Bid>().GetById(id);
            myUnit.getRepository<Bid>().Delete(i);
            myUnit.Commit();
        }

        public List<Bid> getAllBid()
        {
            return myUnit.getRepository<Bid>().getAll().ToList();
        }

        public Bid getBidById(int id)
        {
            return myUnit.getRepository<Bid>().GetById(id);
        }

       

        public void updateBid(Bid i)
        {
            myUnit.getRepository<Bid>().Update(i);
            myUnit.Commit();
        }

        public List<Bid> findBidBySkill(string Skill)
        {
            return (GetMany(c => c.SkillName.ToLower().Contains(Skill)).ToList());

        }

        /*-------------- Les membres qui le même skill Name de  l'annonce --------*/
        public List<Member> getMemberBySkill(string skillname)
        {
            //var b = from member1 in ms.getAllMember()
            //        from Bid1 in getAllBid()
            //        where member1.MemberId == Bid1.MemberId
            //        where skillname == member1.Skills.Select(e => e.SkillName).First()
            //        select member1;
 
            var d = getAllBid();
            List<Member> members = myUnit.getRepository<Member>().getAll().ToList();

            List<Member> membersFound = new List<Member>();
           //foreach (Bid bidd in d)
           // {
         //     members = myUnit.getRepository<Member>().GetMany(m => m.MemberId == bidd.MemberId
           //     ).ToList();
                
            foreach (var member in members)
                {
                    if (member.skills == skillname)

                        //Skills.Select(s => s.SkillName).First() == skillname)
                    {    membersFound.Add(member); }

            }
            // }
            
            return membersFound;
        }


    }
}
