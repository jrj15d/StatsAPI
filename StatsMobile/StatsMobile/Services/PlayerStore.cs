using Newtonsoft.Json;
using StatsMobile.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StatsMobile.Services
{
    class PlayerStore : IDataStore<Player>
    {
        public List<Player> Players { get; private set; }

        public PlayerStore()
        {
            Players = new List<Player>();
        }
        public Task<bool> AddItemAsync(Player item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetItemAsync(string id)
        {
            if (Players is List<Player>)
            {
                foreach (var player in Players)
                {
                    if (player.PlayerId == id)
                        return Task.FromResult(player);
                }
            }
            return Task.FromResult(new Player { });
        }

        public Task<IEnumerable<Player>> GetItemsAsync(bool forceRefresh = false)
        {
            if (forceRefresh == true)
                RequestPlayers();
            return Task.FromResult((IEnumerable<Player>)Players);
        }

        public Task<bool> UpdateItemAsync(Player item)
        {
            throw new NotImplementedException();
        }

        private async void RequestPlayers()
        {
            var request = new WebRequestHandler();
            var json = await request.Get("http://192.168.1.173/StatsAPI/api/players/active");

            Players = JsonConvert.DeserializeObject<List<Player>>(json);
        }
    }
}
