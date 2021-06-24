using StatsDB.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StatsAPI.Models
{
    public class Pitching
    {
        public Pitching() { }
        public Pitching(PitchingTable table)
        {
            PitchingID = table.PitchingID;
            PlayerID = table.PlayerID;
            YearID = table.YearID;
            Stint = table.Stint;
            TeamID = table.TeamID;
            LgID = table.LgID;
            W = table.W;
            L = table.L;
            G = table.G;
            GS = table.GS;
            CG = table.CG;
            SHO = table.SHO;
            SV = table.SV;
            IPouts = table.IPouts;
            H = table.H;
            ER = table.ER;
            HR = table.HR;
            BB = table.BB;
            SO = table.SO;
            BAOpp = table.BAOpp;
            ERA = table.ERA;
            IBB = table.IBB;
            WP = table.WP;
            HBP = table.HBP;
            BK = table.BK;
            BFP = table.BFP;
            GF = table.GF;
            R = table.R;
            SH = table.SH;
            SF = table.SF;
            GIDP = table.GIDP;

        }

        public long PitchingID { get; set; }
        public string PlayerID { get; set; }
        public ushort? YearID { get; set; }
        public ushort? Stint { get; set; }
        public string? TeamID { get; set; }
        public string? LgID { get; set; }
        public ushort? W { get; set; }
        public ushort? L { get; set; }
        public ushort? G { get; set; }
        public ushort? GS { get; set; }
        public ushort? CG { get; set; }
        public ushort? SHO { get; set; }
        public ushort? SV { get; set; }
        public ushort? IPouts { get; set; }
        public ushort? H { get; set; }
        public ushort? ER { get; set; }
        public ushort? HR { get; set; }
        public ushort? BB { get; set; }
        public ushort? SO { get; set; }
        public float? BAOpp { get; set; }
        public float? ERA { get; set; }
        public ushort? IBB { get; set; }
        public ushort? WP { get; set; }
        public ushort? HBP { get; set; }
        public ushort? BK { get; set; }
        public ushort? BFP { get; set; }
        public ushort? GF { get; set; }
        public ushort? R { get; set; }
        public ushort? SH { get; set; }
        public ushort? SF { get; set; }
        public ushort? GIDP { get; set; }
    }
}
