using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerBusinessLogic.BindingModels
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class ClientBindingModel
    {
        public int? Id { get; set; }

        public string ClientName { get; set; }

        public string ClientSurame { get; set; }

        public string Mail { get; set; }

        public string Tel { get; set; }
        
        public string Login { get; set; }
        // Может и private
        public string Password { get; set; }

        public Dictionary<int, (string, int)> ClientProcedures { get; set; }

        public Dictionary<int, (string, int)> ClientPurchases { get; set; }

        public Dictionary<int, (string, int)> ClientVisits { get; set; }
    }
}
