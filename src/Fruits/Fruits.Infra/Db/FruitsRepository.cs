﻿using Fruits.Domain.Models;
using Fruits.Domain.Repositories;
using Fruits.Infra.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Fruits.Infra;

public class FruitsRepository(FruitsDbContext _context) : IFruitsRepository
{
    public async Task<Fruit> AddAsync(Fruit entity)
    {
        var result = await _context.Fruits.AddAsync(entity);

        return result.Entity;
    }

    public Fruit Update(Fruit entity)
    {
        var result = _context.Fruits.Update(entity);

        return result.Entity;
    }

    public async Task<Fruit?> GetByIdAsync(int id)
    {
        return await _context.Fruits.FindAsync(id);
    }

    public async Task<IEnumerable<Fruit>> ListAsync(int pageNumber, int pageSize)
    {
        return await _context.Fruits
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
    }

    public void Remove(Fruit entity)
    {
        _context.Fruits.Remove(entity);
    }
}
