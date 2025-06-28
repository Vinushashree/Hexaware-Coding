using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class Repository<T> : IRepository<T> where T : class
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<T> _dbSet;

    public Repository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public IEnumerable<T> GetAll()
    {
        return _dbSet.ToList();
    }

    public T GetById(object id)
    {
        return _dbSet.Find(id);
    }

    public void Insert(T obj)
    {
        _dbSet.Add(obj);
    }

    public void Update(T obj)
    {
        _dbSet.Attach(obj);
        _context.Entry(obj).State = EntityState.Modified;
    }

    public void Delete(object id)
    {
        T existing = _dbSet.Find(id);
        if (existing != null)
            _dbSet.Remove(existing);
    }

    public void Save()
    {
        _context.SaveChanges();
    }
}
