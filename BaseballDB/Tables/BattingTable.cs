using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace StatsDB.Tables
{
    [Table("Batting")]
    public class BattingTable
    {
        [PrimaryKey, AutoIncrement]
        public long BattingId { get; set; }
        [NotNull]
        public string PlayerID { get; set; }
        public ushort? YearID { get; set; }
        public ushort? Stint { get; set; }
        public string? TeamID { get; set; }
        public string? LeagueID { get; set; }
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
    }
}
