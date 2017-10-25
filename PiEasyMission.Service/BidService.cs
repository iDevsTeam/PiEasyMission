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

        public BidService() : base(myUnit)
        {
            dbFactory = new DataBaseFactory();
            myUnit = new UnitOfWork(dbFactory);
        }

        public void createBid(Bid i)
        {
            myUnit.getRepository<Bid>().Add(i);
            myUnit.Commit();
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

    }
}
