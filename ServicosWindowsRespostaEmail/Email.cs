using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicosWindowsRespostaEmail
{
    class Email
    {
        public string Id { get; set; }
        public string Assunto { get; set; }
        public string De { get; set; }
        public string Para { get; set; }
        public string ConteudoTexto { get; set; }
        public string ConteudoHtml { get; set; }
    }
}
