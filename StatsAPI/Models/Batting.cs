using StatsDB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Models
{
    public class Batting
    {
        public Batting() { }
        public Batting(BattingTable table)
        {
            PlayerId = table.PlayerID;
            YearId = table.YearID;
            Stint = table.Stint;
            TeamId = table.TeamID;
            LeagueId = table.LeagueID;
            G = table.G;
            AB = table.AB;
            R = table.R;
            H = table.H;
            Doubles = table.Doubles;
            Triples = table.Triples;
            HR = table.HR;
            RBI = table.RBI;
            SB = table.SB;
            CS = table.CS;
            BB = table.BB;
            SO = table.SO;
            IBB = table.IBB;
            HBP = table.HBP;
            SH = table.SH;
            SF = table.SF;
            GIDP = table.GIDP;

    }

        public string PlayerId { get; set; }
        public ushort? YearId { get; set; }
        public ushort? Stint { get; set; }
        public string? TeamId { get; set; }
        public string? LeagueId { get; set; }
        public ushort? G { get; set; }
        public ushort? AB { get; set; }
        public ushort? R { get; set; }
        public ushort? H { get; set; }
        public ushort? Doubles { get; set; }
        public ushort? Triples { get; set; }
        public ushort? HR { get; set; }
        public ushort? RBI { get; set; }
        public ushort? SB { get; set; }
        public ushort? CS { get; set; }
        public ushort? BB { get; set; }
        public ushort? SO { get; set; }
        public ushort? IBB { get; set; }
        public ushort? HBP { get; set; }
        public ushort? SH { get; set; }
        public ushort? SF { get; set; }
        public ushort? GIDP { get; set; }

        public override string ToString()
        {
            return $"{PlayerId}, {YearId} - ({G} games), ({AB} at bats)";
        }
    }
}
