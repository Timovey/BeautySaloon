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

        public Dictionary<int, string> ClientProcedures { get; set; }

        public Dictionary<int, DateTime> ClientPurchases { get; set; }

        public Dictionary<int, DateTime> ClientVisits { get; set; }
    }
}
