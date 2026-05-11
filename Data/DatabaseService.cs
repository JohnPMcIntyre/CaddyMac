using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;
using CaddyMac.Models;

namespace CaddyMac.Data
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _db;

        public DatabaseService(string dbPath)
        {
            _db = new SQLiteAsyncConnection(dbPath);

            _db.CreateTableAsync<User>().Wait();
            _db.CreateTableAsync<Round>().Wait();
        }

        // USER METHODS

        public Task<int> AddUser(User user)
        {
            return _db.InsertAsync(user);
        }

        public Task<User> GetUser(string username)
        {
            return _db.Table<User>()
                      .FirstOrDefaultAsync(u => u.Username == username);
        }

        // ROUND METHODS

        public Task<int> AddRound(Round round)
        {
            return _db.InsertAsync(round);
        }

        public Task<List<Round>> GetRounds(string username)
        {
            return _db.Table<Round>()
                      .Where(r => r.Username == username)
                      .ToListAsync();
        }
    }
}
