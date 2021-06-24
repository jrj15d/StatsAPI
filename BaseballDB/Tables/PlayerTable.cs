using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using SQLite;

namespace BaseballDB.Tables
{
    [Table("Player")]
    public class PlayerTable
    {
        [PrimaryKey]
        public string PlayerId { get; set; }
        public string? RetroId { get; set; }
        public string? BbrefId { get; set; }
        public ushort? Weight { get; set; }
        public ushort? Height { get; set; }
        public byte? Throws { get; set; }
        public byte? Bats { get; set; }
        public string? NameLast { get; set; }
        public string? NameFirst { get; set; }
        public string? BirthCountry { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFinalGame { get; set; }
    }
}
