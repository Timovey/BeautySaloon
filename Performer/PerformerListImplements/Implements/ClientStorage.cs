using PerformerBusinessLogic.BindingModels;
using PerformerBusinessLogic.Interfaces;
using PerformerBusinessLogic.ViewModels;
using PerformerListImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PerformerListImplements.Implements
{
    public class ClientStorage : IClientStorage
    {
        private readonly DataListSingleton source;
        public ClientStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<ClientViewModel> GetFullList()
        {
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                result.Add(CreateModel(client));
            }
            return result;
        }
        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ClientViewModel> result = new List<ClientViewModel>();
            foreach (var client in source.Clients)
            {
                if (client.Login.Contains(model.Login))
                {
                    result.Add(CreateModel(client));
                }
            }
            return result;
        }
        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var client in source.Clients)
            {
                if (client.Id == model.Id || (client.ClientName.Contains(model.ClientName) 
                    && client.ClientSurame.Contains(model.ClientSurname)))
                {
                    return CreateModel(client);
                }
            }
            return null;
        }
        public void Insert(ClientBindingModel model)
        {
            Client tempClient = new Client { Id = 1,
            ClientProcedures = new Dictionary<int, int>(),
            ClientPurchases = new Dictionary<int, int>(),
            ClientVisits = new Dictionary<int, int>()};
            foreach (var client in source.Clients)
            {
                if (client.Id >= tempClient.Id)
                {
                    tempClient.Id = client.Id + 1;
                }
            }
            model.ClientPurchases = new Dictionary<int, DateTime>();
            model.ClientProcedures = new Dictionary<int, string>();
            model.ClientVisits = new Dictionary<int, DateTime>();
            source.Clients.Add(CreateModel(model, tempClient));
        }
        public void Update(ClientBindingModel model)
        {
            Client tempClient = null;
            foreach (var client in source.Clients)
            {
                if (client.Id == model.Id)
                {
                    tempClient = client;
                }
            }
            if (tempClient == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempClient);
        }
        public void Delete(ClientBindingModel model)
        {
            for (int i = 0; i < source.Clients.Count; ++i)
            {
                if (source.Clients[i].Id == model.Id.Value)
                {
                    source.Clients.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientName = model.ClientName;
            client.ClientSurame = model.ClientSurname;
            client.Mail = model.Mail;
            client.Tel = model.Tel;
            client.Login = model.Login;
            client.Password = model.Password;


            // удаляем убранные
            foreach (var key in client.ClientProcedures.Keys.ToList())
            {
                if (!model.ClientProcedures.ContainsKey(key))
                {
                    client.ClientProcedures.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var procedure in model.ClientProcedures)
            {
                if (!client.ClientProcedures.ContainsKey(procedure.Key))
                {
                    client.ClientProcedures.Add(procedure.Key,
               procedure.Key);
                } 
            }

            // удаляем убранные
            foreach (var key in client.ClientPurchases.Keys.ToList())
            {
                if (!model.ClientPurchases.ContainsKey(key))
                {
                    client.ClientPurchases.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var purchase in model.ClientPurchases)
            {
                if (!client.ClientPurchases.ContainsKey(purchase.Key))
                {
                    client.ClientPurchases[purchase.Key] =
                   purchase.Key;
                }
               
            }


            // удаляем убранные
            foreach (var key in client.ClientVisits.Keys.ToList())
            {
                if (!model.ClientVisits.ContainsKey(key))
                {
                    client.ClientVisits.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var visit in model.ClientVisits)
            {
                if (!client.ClientVisits.ContainsKey(visit.Key))
                {
                    client.ClientVisits[visit.Key] =
                    visit.Key;
                }
            }

            return client;
        }
        private ClientViewModel CreateModel(Client client)
        {
            Dictionary<int, string> clientProcedures = new
            Dictionary<int, string>();
            foreach (var cp in client.ClientProcedures)
            {
                string procedureName = string.Empty;
                foreach (var procedure in source.Procedures)
                {
                    if (cp.Key == procedure.Id)
                    {
                        procedureName = procedure.ProcedureName;
                        break;
                    }
                }
                clientProcedures.Add(cp.Key, procedureName);
            }


            Dictionary<int, DateTime> clientPurchases = new
            Dictionary<int, DateTime>();
            foreach (var cp in client.ClientPurchases)
            {
                DateTime purchaseDate = DateTime.MinValue;
                foreach (var purchase in source.Purchases)
                {
                    if (cp.Key == purchase.Id)
                    {
                        purchaseDate = purchase.Date;
                        break;
                    }
                }
                clientPurchases.Add(cp.Key, purchaseDate);
            }

            Dictionary<int, DateTime> clientVisits = new
            Dictionary<int, DateTime>();
            foreach (var cv in client.ClientVisits)
            {
                DateTime visitDate = DateTime.MinValue;
                foreach (var visit in source.Visits)
                {
                    if (cv.Key == visit.Id)
                    {
                        visitDate = visit.Date;
                        break;
                    }
                }
                clientPurchases.Add(cv.Key, visitDate);
            }

            return new ClientViewModel
            {
               Id = client.Id,
               ClientName = client.ClientName,
               ClientSurame = client.ClientSurame,
               Mail = client.Mail,
               Tel = client.Tel,
               
            };
        }
    }
}
