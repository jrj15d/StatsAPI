using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Models
{
    public class Player
    {
        public Player() { }

        public Player(BaseballDB.Tables.PlayerTable table)
        {
            char? throws = null, bats = null;
            if (!(table.Throws is null))
                throws = (char)table.Throws;
            if (!(table.Bats is null))
                bats = (char)table.Bats;

            PlayerId = table.PlayerId;
            RetroId = table.RetroId;
            BbrefId = table.BbrefId;
            Weight = table.Weight;
            Height = table.Height;
            Throws = throws;
            Bats = bats;
            NameLast = table.NameLast;
            NameFirst = table.NameFirst;
            BirthCountry = table.BirthCountry;
            DateBirth = table.DateBirth;
            DateDebut = table.DateDebut;
            DateFinalGame = table.DateFinalGame;

        }

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

        public override string ToString()
        {
            return $"{NameLast}, {NameFirst} ({PlayerId})";
        }
    }
}
