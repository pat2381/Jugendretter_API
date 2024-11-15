﻿using Jugendretter_API.Models;
using Jugendretter_API.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Jugendretter_API.Database
{
    public class UserRepository : IUserRepository
    {
        private readonly JugendretterDBContext context;

        public UserRepository( JugendretterDBContext _context)
        {
            context = _context;
        }

        public async Task<User> Create(User user)
        {
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;

        }

        public async Task Delete(int ID)
        {
            var UserToDelete = await context.Users.FindAsync(ID);
            context.Users.Remove(UserToDelete!);
            await context.SaveChangesAsync();

        }

        public async Task<List<User>> Get()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> Get(int ID)
        {
           
            return await context.Users!.FindAsync(ID);
           
        }

        public async Task Update(User user)
        {
            context.Entry(user).State = EntityState.Modified;
            await context.SaveChangesAsync();
        }
    }
}
