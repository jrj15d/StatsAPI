using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsDB.Tables
{
    [Table("Pitching")]
    public class PitchingTable
    {
        [PrimaryKey, AutoIncrement]
        public long PitchingID { get; set; }
        [NotNull]
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
