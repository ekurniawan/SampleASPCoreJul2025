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
        try
        {
            _context.Dealers.Add(item);
            _context.SaveChanges();
            return item;
        }
        catch (System.Exception ex)
        {
            throw new ArgumentException($"An error occurred while creating the dealer. {ex.Message}", ex);
        }
    }

    public void Delete(int id)
    {
        try
        {
            var dealer = _context.Dealers.Find(id);
            if (dealer == null)
            {
                throw new KeyNotFoundException($"Dealer with ID {id} not found.");
            }
            _context.Dealers.Remove(dealer);
            _context.SaveChanges();
        }
        catch (System.Exception ex)
        {
            throw new ArgumentException($"An error occurred while deleting the dealer. {ex.Message}", ex);
        }
    }

    public IEnumerable<Dealer> GetAll()
    {
        var results = _context.Dealers.OrderBy(d => d.Name).ToList();
        return results;
    }

    public Dealer GetById(int id)
    {
        var result = _context.Dealers
            .FirstOrDefault(d => d.DealerId == id);
        if (result == null)
        {
            throw new KeyNotFoundException($"Dealer with ID {id} not found.");
        }
        return result;
    }

    public Dealer Update(Dealer item)
    {
        try
        {
            _context.Dealers.Update(item);
            _context.SaveChanges();
            return item;
        }
        catch (System.Exception ex)
        {
            throw new ArgumentException($"An error occurred while updating the dealer. {ex.Message}", ex);
        }
    }
}
