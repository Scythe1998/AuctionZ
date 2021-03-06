using System;
using System.Collections.Generic;
using ApplicationCore.Entities;

namespace ApplicationCore.Interfaces
{
    public interface IBidRepository : IRepository<Bid>
    {
        Bid GetLastBidForLot(int lotId);
        IEnumerable<Bid> GetAllBidsForLotWithUsers(int lotId);
        IEnumerable<Bid> GetAllBidsForUser(int userId);
    }
}