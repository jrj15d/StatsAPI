using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using SQLite;
using CsvHelper;
using BaseballDB.Tables;
using StatsDB.Tables;

namespace BaseballDB
{
    /// <summary>
    /// Sqllite database for baseball data
    /// </summary>
    public class BaseballDatabase
    {
        private readonly string DB_NAME = "baseballdatabank";
        private string csvPath;
        private SQLiteConnection connection;

        public IEnumerable<PlayerTable> Players
        {
            get
            {
                var players = connection.Query<PlayerTable>("SELECT * FROM Player");

                foreach (var player in players)
                    yield return player;
            }
        }

        public IEnumerable<BattingTable> PlayerBatting(string playerId)
        {
            var batting = connection.Query<BattingTable>($"SELECT * FROM Batting WHERE PlayerID = '{playerId}'");
            return batting.ToArray();
        }

        public BaseballDatabase(string csvPath)
        {
            this.csvPath = csvPath;
            connection = new SQLiteConnection($"{DB_NAME}.db");

            var res = connection.CreateTable<PlayerTable>();
            var res2 = connection.CreateTable<BattingTable>();

            if (res == 0)
                InitPlayers();
            if (res2 == 0)
                InitBatting();
        }

        private void InitPlayers()
        {
            // Get CSV records
            var records = ParsePlayerRecords().ToList();

            // Get PlayerDTOs
            var players = new List<PlayerTable>();
            foreach (var record in records)
                players.Add(record.DTO);

            // Insert PlayerDTOs into DB
            try
            {
                int res = connection.InsertAll(players);
                Console.WriteLine($"[InitPlayers] Inserted {res} players");
            } catch (Exception e)
            {
                Console.WriteLine("Insert Error");
            }

        }
        private void InitBatting()
        {
            // Get CSV records
            var records = ParseBattingRecords().ToList();

            // Get BattingDTOs
            var batting = new List<BattingTable>();
            foreach (var record in records)
                batting.Add(record.DTO);

            // Insert BattingDTOs into DB
            try
            {
                int res = connection.InsertAll(batting);
                Console.WriteLine($"[InitBatting] Inserted {res} batting records");
            }
            catch (Exception e)
            {
                Console.WriteLine("Insert Error");
            }
        }
        private IEnumerable<PlayerRecord> ParsePlayerRecords()
        {
            using (var reader = new StreamReader($"{csvPath}\\People.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<PlayerRecord>().ToList();
                return records;
            }
        }
        private IEnumerable<BattingRecord> ParseBattingRecords()
        {
            using (var reader = new StreamReader($"{csvPath}\\Batting.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<BattingRecord>().ToList();
                return records;
            }
        }

    }


    /// <summary>
    /// Represents a single record from People.csv
    /// </summary>
    internal class PlayerRecord
    {
        public PlayerRecord() { }
        public PlayerTable DTO
        {
            get
            {
                DateTime? birth = null;
                DateTime? debutDate = null;
                DateTime? finalDate = null;

                if (birthYear.HasValue && birthMonth.HasValue && birthDay.HasValue)
                    birth = new DateTime(Convert.ToInt32(birthYear), Convert.ToInt32(birthMonth), Convert.ToInt32(birthDay));

                if (debut != "")
                    debutDate = new DateTime(Convert.ToInt32(debut.Split('-')[0]), Convert.ToInt32(debut.Split('-')[1]), Convert.ToInt32(debut.Split('-')[2]));

                if (finalGame != "")
                    finalDate = new DateTime(Convert.ToInt32(finalGame.Split('-')[0]), Convert.ToInt32(finalGame.Split('-')[1]), Convert.ToInt32(finalGame.Split('-')[2]));

                byte? t = null, b = null;
                if (this.throws.HasValue)
                    t = (byte)this.throws.Value;
                if (this.bats.HasValue)
                    b = (byte)this.bats.Value;

                return new PlayerTable()
                {
                    PlayerId = this.playerID,
                    RetroId = this.retroID,
                    BbrefId = this.bbrefID,
                    Weight = this.weight,
                    Height = this.height,
                    Throws = t,
                    Bats = b,
                    NameLast = this.nameLast,
                    NameFirst = this.nameFirst,
                    BirthCountry = this.birthCountry,
                    DateBirth = birth,
                    DateDebut = debutDate,
                    DateFinalGame = finalDate
                };
            }
        }
        public string playerID { get; set; }
        public ushort? birthYear { get; set; }
        public ushort? birthMonth { get; set; }
        public ushort? birthDay { get; set; }
        public string? birthCountry { get; set; }
        public string? birthState { get; set; }
        public string? birthCity { get; set; }
        public ushort? deathYear { get; set; }
        public ushort? deathMonth { get; set; }
        public ushort? deathDay { get; set; }
        public string? deathCountry { get; set; }
        public string? deathState { get; set; }
        public string? deathCity { get; set; }
        public string? nameFirst { get; set; }
        public string? nameLast { get; set; }
        public string? nameGiven { get; set; }
        public ushort? weight { get; set; }
        public ushort? height { get; set; }
        public char? bats { get; set; }
        public char? throws { get; set; }
        public string? debut { get; set; }
        public string? finalGame { get; set; }
        public string? retroID { get; set; }
        public string? bbrefID { get; set; }

    }
    internal class BattingRecord
    {
        public BattingRecord() { }

        public BattingTable DTO
        {
            get
            {
                var table = new BattingTable();
                table.PlayerID = playerID;
                table.TeamID = teamID;
                table.LeagueID = lgID;
                table.YearID = yearID;
                table.Stint = stint;
                table.G = G;
                table.AB = AB;
                table.R = R;
                table.H = H;
                table.Doubles = B2;
                table.Triples = B3;
                table.HR = HR;
                table.RBI = RBI;
                table.SB = SB;
                table.CS = CS;
                table.BB = BB;
                table.SO = SO;
                table.IBB = IBB;
                table.HBP = HBP;
                table.SH = SH;
                table.SF = SF;
                table.GIDP = GIDP;
                return table;
            }
        }
        public string playerID { get; set; }
        public ushort? yearID { get; set; }
        public ushort? stint { get; set; }
        public string? teamID { get; set; }
        public string? lgID { get; set; }
        public ushort? G { get; set; }
        public ushort? AB { get; set; }
        public ushort? R { get; set; }
        public ushort? H { get; set; }
        public ushort? B2 { get; set; }
        public ushort? B3 { get; set; }
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

    [Table("Pitching")]
    internal class PitchingRecord
    {
        public PitchingRecord() { }

        public string playerID { get; set; }
        public ushort? yearID { get; set; }
        public ushort? stint { get; set; }
        public string? teamID { get; set; }
        public string? lgID { get; set; }
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
        public ushort? BAOpp { get; set; }
        public ushort? ERA { get; set; }
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
