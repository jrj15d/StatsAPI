using StatsMobile.Models;
using StatsMobile.Services;
using StatsMobile.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StatsMobile.ViewModels
{
    class PlayersViewModel : BaseViewModel
    {
        private Player _selectedPlayer;
        public ObservableCollection<Player> Players { get; }
        public Command LoadPlayersCommand { get; }
        public Command AddPlayerCommand { get; }
        public Command<Player> PlayerTapped { get; }

        public PlayersViewModel()
        {
            Title = "Browse Players";
            Players = new ObservableCollection<Player>();
            LoadPlayersCommand = new Command(async () => await ExecuteLoadPlayersCommand());

            PlayerTapped = new Command<Player>(OnPlayerSelected);

            AddPlayerCommand = new Command(OnAddPlayer);
        }

        async Task ExecuteLoadPlayersCommand()
        {
            IsBusy = true;

            try
            {
                Players.Clear();
                var players = await PlayerStore.GetItemsAsync(true);
                foreach (var player in players)
                {
                    Players.Add(player);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPlayer = null;
        }

        public Player SelectedPlayer
        {
            get => _selectedPlayer;
            set
            {
                SetProperty(ref _selectedPlayer, value);
                OnPlayerSelected(value);
            }
        }

        private async void OnAddPlayer(object obj)
        {
        }

        async void OnPlayerSelected(Player player)
        {
            if (player == null)
                return;

            // This will push the PlayerDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(PlayerDetailPage)}?{nameof(PlayerDetailViewModel.PlayerId)}={player.PlayerId}");
        }
    }
}
