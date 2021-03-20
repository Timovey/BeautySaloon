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
                if (client.ClientName.Contains(model.ClientName) && client.ClientSurame.Contains(model.ClientSurame))
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
                    && client.ClientSurame.Contains(model.ClientSurame)))
                {
                    return CreateModel(client);
                }
            }
            return null;
        }
        public void Insert(ClientBindingModel model)
        {
            Client tempClient = new Client { Id = 1 };
            foreach (var client in source.Clients)
            {
                if (client.Id >= tempClient.Id)
                {
                    tempClient.Id = client.Id + 1;
                }
            }
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
            client.ClientSurame = model.ClientSurame;
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
                if (client.ClientProcedures.ContainsKey(procedure.Key))
                {
                    client.ClientProcedures[procedure.Key] =
                    model.ClientProcedures[procedure.Key].Item2;
                }
                else
                {
                    client.ClientProcedures.Add(procedure.Key,
                    model.ClientProcedures[procedure.Key].Item2);
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
                if (client.ClientPurchases.ContainsKey(purchase.Key))
                {
                    client.ClientPurchases[purchase.Key] =
                    model.ClientPurchases[purchase.Key].Item2;
                }
                else
                {
                    client.ClientPurchases.Add(purchase.Key,
                    model.ClientPurchases[purchase.Key].Item2);
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
                if (client.ClientVisits.ContainsKey(visit.Key))
                {
                    client.ClientVisits[visit.Key] =
                    model.ClientVisits[visit.Key].Item2;
                }
                else
                {
                    client.ClientVisits.Add(visit.Key,
                    model.ClientVisits[visit.Key].Item2);
                }
            }

            return client;
        }
        private ClientViewModel CreateModel(Client client)
        {
            Dictionary<int, (string, int)> clientProcedures = new
            Dictionary<int, (string, int)>();
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
                clientProcedures.Add(cp.Key, (procedureName, cp.Value));
            }


            //Dictionary<int, (string, int)> clientPurchases = new
            //Dictionary<int, (string, int)>();
            //foreach (var pc in client.ClientPurchases)
            //{
            //    string procedureName = string.Empty;
            //    foreach (var purchase in source.Purchases)
            //    {
            //        if (pc.Key == purchase.Id)
            //        {
            //            procedureName = purchase.;
            //            break;
            //        }
            //    }
            //    clientProcedures.Add(cp.Key, (procedureName, cp.Value));
            //}

            return new ClientViewModel
            {
               Id = client.Id,
               ClientName = client.ClientName,
               ClientSurame = client.ClientSurame,
               Mail = client.Mail,
               Tel = client.Tel
            };
        }
    }
}
