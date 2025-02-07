using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FinalAssignment.CountryApi;
using Newtonsoft.Json;
using RestSharp;

namespace FinalAssignment
{
    public class StoreManagement
    {
        private List<Store> stores = new List<Store>();
        private List<string> countries = new List<string>();
        private const string filePath = "stores.json";
        private const string apiUrl = "https://restcountries.com/v3.1/all?fields=name";

        public StoreManagement()
        {
            LoadCountries();
            LoadStores();
        }



        public void SaveStoresToFile()
        {
            File.WriteAllText(filePath, JsonConvert.SerializeObject(stores, Formatting.Indented));
        }

        public void UpdateIncome()
        {
            Console.Write("Enter store name: ");
            string name = Console.ReadLine();
            var store = stores.FirstOrDefault(s => s.StoreName.Equals(name, StringComparison.OrdinalIgnoreCase));
            if (store == null)
            {
                Console.WriteLine("Store not found.");
            }
            else
            {
                Console.Write("Enter new income: ");
                if (!decimal.TryParse(Console.ReadLine(), out decimal newIncome) || newIncome <= 0)
                {
                    Console.WriteLine("Invalid income.");
                    return;
                }
                store.Income = newIncome;
                Console.WriteLine("Income updated successfully.");
            }
        }

        public void AssignTypes()
        {
            Console.Write("Enter Store Name: ");
            string storeName = Console.ReadLine();

            Store store = stores.FirstOrDefault(e => e.StoreName.Equals(storeName, StringComparison.OrdinalIgnoreCase));
            if (store == null)
            {
                Console.WriteLine("Store not found.");
                return;
            }

            Console.Write("Asign Store Type: ");
            string storeType = Console.ReadLine();

            store.AssignedTypes.Add(storeType);
            Console.WriteLine("Store type assigned successfully.");
        }

        public void RemoveStore()
        {
            Console.Write("Enter store name to be removed:");
            string name = Console.ReadLine();
            var store = stores.FirstOrDefault(s => s.StoreName.Equals(name, StringComparison.OrdinalIgnoreCase));

            stores.Remove(store);
        }

        public void AddStore()
        {
            Console.Write("Enter store name:");
            string name = Console.ReadLine();

            if (IsDuplicatedStoreName(name))
            {
                Console.WriteLine("Duplicated store name");
                return;
            }

            Console.Write("Enter income:");
            if (!IsValidIncome(out decimal income))
            {
                Console.WriteLine("Invalid income.");
                return;
            }


            Console.WriteLine("Select location:");
            for (int i = 0; i < countries.Count; i++)
                Console.WriteLine($"{i + 1}. {countries[i]}");
            if (!IsValidCountry(out string selectedCountry))
            {
                Console.WriteLine("Invalid country.");
                return;
            }
            stores.Add(new Store { StoreName = name, Income = income, Location = new CountryName { Common = selectedCountry }, AssignedTypes = new List<string>() });
            Console.WriteLine("Store added successfully.");
        }
        private void LoadStores()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                stores = JsonConvert.DeserializeObject<List<Store>>(json);
            }
        }

        private void LoadCountries()
        {
            var client = new RestClient(apiUrl);
            var request = new RestRequest();
            var response = client.Execute<List<Country>>(request);
            if (response.IsSuccessful && response.Data != null)
            {
                countries = response.Data.Select(c => c.Name.Common).ToList();

            }
        }

        private bool IsDuplicatedStoreName(string name)
        {
            return stores.Any(s => s.StoreName.Equals(name, StringComparison.OrdinalIgnoreCase)) ? true : false;

        }

        private bool IsValidIncome(out decimal income)
        {
            return (!decimal.TryParse(Console.ReadLine(), out income) || income <= 0) ? false : true;

        }

        private bool IsValidCountry(out string selectedCountry)
        {
            selectedCountry = null;
            if (!int.TryParse(Console.ReadLine(), out int countryIndex) || countryIndex < 1 || countryIndex > countries.Count)
            {
                return false;
            }
            selectedCountry = countries[countryIndex - 1];
            return true;
        }
    }
}