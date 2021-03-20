using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace PerformerBusinessLogic.ViewModels
{
    /// <summary>
	/// Клиент
	/// </summary>
	public class ClientViewModel
    {
        public int Id { get; set; }
        [DisplayName("Имя")]
        public string ClientName { get; set; }
        [DisplayName("Фамилия")]
        public string ClientSurame { get; set; }
        [DisplayName("Почта")]
        public string Mail { get; set; }
        [DisplayName("Телефон")]
        public string Tel { get; set; }

        public Dictionary<int, (string, int)> ClientProcedures { get; set; }
        public Dictionary<int, (string, int)> ClientPurchases { get; set; }
        public Dictionary<int, (string, int)> ClientVisits { get; set; }
    }
}
