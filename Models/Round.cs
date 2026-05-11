using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SQLite;

namespace CaddyMac.Models
{
    public class Round
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string CourseName { get; set; }

        public int Score { get; set; }

        public DateTime DatePlayed { get; set; }

        public string Username { get; set; }
    }
}
