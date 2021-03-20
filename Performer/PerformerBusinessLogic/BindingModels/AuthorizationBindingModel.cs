using System;
using System.Collections.Generic;
using System.Text;

namespace PerformerBusinessLogic.BindingModels
{
    public class AuthorizationBindingModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    }
}
