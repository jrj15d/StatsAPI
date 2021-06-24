using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsClient.Pages
{
    public class PlayerDTO
    {
        public string PlayerId { get; set; }
        public string? RetroId { get; set; }
        public string? BbrefId { get; set; }
        public ushort? Weight { get; set; }
        public ushort? Height { get; set; }
        public char? Throws { get; set; }
        public char? Bats { get; set; }
        public string? NameLast { get; set; }
        public string? NameFirst { get; set; }
        public string? BirthCountry { get; set; }
        public DateTime? DateBirth { get; set; }
        public DateTime? DateDebut { get; set; }
        public DateTime? DateFinalGame { get; set; }
    }
}
