using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PiEasyMission.Domain.Entities;
using System.Data.Entity;
using PiEasyMission.Service.Repositories;


namespace PiEasyMission.Service.Interfaces
{
    public interface IBidService : ServicesPattern.IService<Bid>
    {
        void createBid(Bid i);
        List<Bid> getAllBid();
        void updateBid(Bid i);
        Bid getBidById(int id);
        void deleteBid(Bid i);

        void deleteBidById(int id);
        List<Bid> findBidBySkill(string Skill);
    }
}
