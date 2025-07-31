using System;
using Microsoft.EntityFrameworkCore;
using HandsOnLab.BO;

namespace HandsOnLab.DAL;

public class DealerDAL : IDealer
{
    private readonly AutomotiveDB3Context _context;
    public DealerDAL(AutomotiveDB3Context context)
    {
        _context = context;
    }

    public Dealer Create(Dealer item)
    {
        throw new NotImplementedException();
    }

    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<Dealer> GetAll()
    {
        var results = _context.Dealers.OrderBy(d => d.Name).ToList();
        return results;
    }

    public Dealer GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Dealer Update(Dealer item)
    {
        throw new NotImplementedException();
    }
}
