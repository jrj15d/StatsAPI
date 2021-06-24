using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;

namespace StatsMobile.ViewModels
{
    [QueryProperty(nameof(PlayerId), nameof(PlayerId))]
    class PlayerDetailViewModel : BaseViewModel
    {
        private string playerId;
        private string lastName;
        private string firstName;
        private string weight;
        private string height;
        private string bats;
        private string throws;
        private string birthCountry;
        private string birthDate;
        private string debutDate;

        public string Id { get; set; }

        public string LastName
        {
            get => lastName;
            set => SetProperty(ref lastName, value);
        }

        public string FirstName
        {
            get => firstName;
            set => SetProperty(ref firstName, value);
        }
        public string Weight
        {
            get => weight;
            set => SetProperty(ref weight, value);
        }
        public string Height
        {
            get => height;
            set => SetProperty(ref height, value);
        }
        public string Throws
        {
            get => throws;
            set => SetProperty(ref throws, value);
        }
        public string Bats
        {
            get => bats;
            set => SetProperty(ref bats, value);
        }
        public string BirthCountry
        {
            get => birthCountry;
            set => SetProperty(ref birthCountry, value);
        }
        public string DebutDate
        {
            get => debutDate;
            set => SetProperty(ref debutDate, value);
        }
        public string BirthDate
        {
            get => birthDate;
            set => SetProperty(ref birthDate, value);
        }

        public string PlayerId
        {
            get
            {
                return playerId;
            }
            set
            {
                playerId = value;
                LoadItemId(value);
            }
        }

        public async void LoadItemId(string playerId)
        {
            try
            {
                var item = await PlayerStore.GetItemAsync(playerId);
                Id = item.PlayerId;
                FirstName = item.NameFirst;
                LastName = item.NameLast;
                Weight = item.Weight.ToString();
                Height = item.Height.ToString();
                Throws = item.Throws.ToString();
                Bats = item.Bats.ToString();
                BirthCountry = item.BirthCountry;
                BirthDate = item.DateBirth.ToString();
                DebutDate = item.DateDebut.ToString();
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Item");
            }
        }
    }
}
