using System;
using System.Collections.Generic;
using SpectrumCC.Interfaces;
using SQLite.Net.Attributes;

namespace SpectrumCC.Users
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string UserName { get; set; }
        [MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(255)]
        public string PhoneNumber { get; set; }
        [MaxLength(255)]
        public string ServiceStartDate { get; set; }
    }
}
