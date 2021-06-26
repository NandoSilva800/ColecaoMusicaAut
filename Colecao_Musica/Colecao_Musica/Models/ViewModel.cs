using System;
using System.Collections.Generic;

namespace Colecao_Musica.Models
{
   


    public class ViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
   
}
