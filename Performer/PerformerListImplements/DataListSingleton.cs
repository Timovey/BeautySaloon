using System.Collections.Generic;
using PerformerListImplements.Models;

namespace PerformerListImplements
{
    public class DataListSingleton
    {
        private static DataListSingleton instance;
        public List<Client> Clients { get; set; }
        public List<Procedure> Procedures { get; set; }
        public List<Purchase> Purchases { get; set; }
        public List<Visit> Visits { get; set; }

        private DataListSingleton()
        {
            Clients = new List<Client>();
            Procedures = new List<Procedure>();
            Purchases = new List<Purchase>();
            Visits = new List<Visit>();
        }
        public static DataListSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new DataListSingleton();
            }
            return instance;
        }
    }
}
