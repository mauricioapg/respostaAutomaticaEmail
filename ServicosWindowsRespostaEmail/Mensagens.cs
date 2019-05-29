using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ServicosWindowsRespostaEmail
{
    class Mensagens
    {
        public static MailMessage GerarMensagemDefault(string remetente, string destinatario, string assunto)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = assunto;
            mail.IsBodyHtml = true;
            mail.Body =
            "<html>" +
                "<head>" +
                    "<title>resposta_default_kit</title>" +
                "</head>" +
                "<body bgcolor = '#FFFFFF' leftmargin = '0' topmargin = '0' marginwidth = '0' marginheight = '0'>" +
                     "<center>" +
                         "<table id = 'Tabela_01' width = '900' height = '1778' border = '0' cellpadding = '0' cellspacing = '0'>" +
                             "<tr>" +
                                "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_01.jpg' width = '900' height = '431' alt = ''>" +
                                "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_02.jpg' width = '900' height = '293' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_03.jpg' width = '900' height = '178' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_04.jpg' width = '900' height = '277' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_05.jpg' width = '900' height = '206' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_06.jpg' width = '900' height = '149' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_07.jpg' width = '900' height = '1' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_08.jpg' width = '900' height = '243' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                         "</table>" +
                     "</center>" +
                 "</body>" +
            "</html>";
            return mail;
        }

        public static MailMessage GerarMensagemBercario(string remetente, string destinatario, string assunto)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = assunto;
            mail.IsBodyHtml = true;
            mail.Body =
            "<html>" +
                "<head>" +
                    "<title>resposta_default_kit</title>" +
                "</head>" +
                "<body bgcolor = '#FFFFFF' leftmargin = '0' topmargin = '0' marginwidth = '0' marginheight = '0'>" +
                     "<center>" +
                         "<table id = 'Tabela_01' width = '900' height = '1280' border = '0' cellpadding = '0' cellspacing = '0'>" +
                             "<tr>" +
                                "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_bercario_kit_01.jpg' width = '900' height = '80' alt = ''>" +
                                "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_bercario_kit_02.jpg' width = '900' height = '490' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_bercario_kit_03.jpg' width = '900' height = '290' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_bercario_kit_04.jpg' width = '900' height = '420' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                         "</table>" +
                     "</center>" +
                 "</body>" +
            "</html>";
            return mail;
        }

        public static MailMessage GerarMensagemInfantil(string remetente, string destinatario, string assunto)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = assunto;
            mail.IsBodyHtml = true;
            mail.Body =
            "<html>" +
                "<head>" +
                    "<title>resposta_default_kit</title>" +
                "</head>" +
                "<body bgcolor = '#FFFFFF' leftmargin = '0' topmargin = '0' marginwidth = '0' marginheight = '0'>" +
                     "<center>" +
                         "<table id = 'Tabela_01' width = '900' height = '1180' border = '0' cellpadding = '0' cellspacing = '0'>" +
                             "<tr>" +
                                "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_ed_infantil_kit_01.jpg' width = '900' height = '80' alt = ''>" +
                                "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_ed_infantil_kit_02.jpg' width = '900' height = '490' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_ed_infantil_kit_03.jpg' width = '900' height = '294' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_ed_infantil_kit_04.jpg' width = '900' height = '316' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                         "</table>" +
                     "</center>" +
                 "</body>" +
            "</html>";
            return mail;
        }

        public static MailMessage GerarMensagemFundamental_1(string remetente, string destinatario, string assunto)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = assunto;
            mail.IsBodyHtml = true;
            mail.Body =
            "<html>" +
                "<head>" +
                    "<title>resposta_default_kit</title>" +
                "</head>" +
                "<body bgcolor = '#FFFFFF' leftmargin = '0' topmargin = '0' marginwidth = '0' marginheight = '0'>" +
                     "<center>" +
                         "<table id = 'Tabela_01' width = '900' height = '1145' border = '0' cellpadding = '0' cellspacing = '0'>" +
                             "<tr>" +
                                "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental1_kit_01.jpg' width = '900' height = '80' alt = ''>" +
                                "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental1_kit_02.jpg' width = '900' height = '493' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental1_kit_03.jpg' width = '900' height = '292' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental1_kit_04.jpg' width = '900' height = '280' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                         "</table>" +
                     "</center>" +
                 "</body>" +
            "</html>";
            return mail;
        }

        public static MailMessage GerarMensagemFundamental_2(string remetente, string destinatario, string assunto)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = assunto;
            mail.IsBodyHtml = true;
            mail.Body =
            "<html>" +
                "<head>" +
                    "<title>resposta_default_kit</title>" +
                "</head>" +
                "<body bgcolor = '#FFFFFF' leftmargin = '0' topmargin = '0' marginwidth = '0' marginheight = '0'>" +
                     "<center>" +
                         "<table id = 'Tabela_01' width = '900' height = '1231' border = '0' cellpadding = '0' cellspacing = '0'>" +
                             "<tr>" +
                                "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental2_kit_01.jpg' width = '900' height = '80' alt = ''>" +
                                "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental2_kit_02.jpg' width = '900' height = '492' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental2_kit_03.jpg' width = '900' height = '324' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_fundamental2_kit_04.jpg' width = '900' height = '335' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                         "</table>" +
                     "</center>" +
                 "</body>" +
            "</html>";
            return mail;
        }
    }
}
