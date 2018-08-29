using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Timers;
using System.IO;
using OpenPop.Mime;
using OpenPop.Pop3;

namespace ServicosWindowsRespostaEmail
{
    class MeuServico
    {
        private List<Email> listaEmails = new List<Email>();
        private string hostname = "seudominio.dominio.com";
        private int port = 995;
        private bool useTls = true;
        private string username = "seuemail@email.com.br";
        private string password = "suasenha";
        public List<string> idsLidos = new List<string>();
        private string caminhoArquivo = Path.GetFullPath("emails_respondidos.txt");

        public void Start()
        {
            var timer = new Timer();
            timer.Interval = 1000; //a cada 1 segundo
            timer.Elapsed += new ElapsedEventHandler(EnviarRespostaAtuomatica_Tick);
            timer.Enabled = true;
            Console.WriteLine("Serviço iniciado...");
        }

        public static List<Message> BuscarMensagemNaoLidas(string hostname, int port, bool useTls, string username, string password, List<string> seenUids)
        {
            // The client disconnects from the server when being disposed
            using (Pop3Client client = new Pop3Client())
            {
                // Connect to the server
                client.Connect(hostname, port, useTls);

                // Authenticate ourselves towards the server
                client.Authenticate(username, password);

                // Fetch all the current uids seen
                List<string> uids = client.GetMessageUids();

                // Create a list we can return with all new messages
                List<Message> newMessages = new List<Message>();

                // All the new messages not seen by the POP3 client
                for (int i = 0; i < uids.Count; i++)
                {
                    string currentUidOnServer = uids[i];
                    if (!seenUids.Contains(currentUidOnServer))
                    {
                        // We have not seen this message before.
                        // Download it and add this new uid to seen uids

                        // the uids list is in messageNumber order - meaning that the first
                        // uid in the list has messageNumber of 1, and the second has 
                        // messageNumber 2. Therefore we can fetch the message using
                        // i + 1 since messageNumber should be in range [1, messageCount]
                        Message unseenMessage = client.GetMessage(i + 1);

                        // Add the message to the new messages
                        newMessages.Add(unseenMessage);

                        // Add the uid to the seen uids, as it has now been seen
                        seenUids.Add(currentUidOnServer);
                    }
                }

                // Return our new found messages
                return newMessages;
            }
        }

        private void EnviarRespostaAtuomatica_Tick(object sender, ElapsedEventArgs e)
        {
            /*
             *    LENDO OS E-MAILS QUE CHEGAM NA CAIXA DE ENTRADA
             */
            try
            {
                using (var mail = new OpenPop.Pop3.Pop3Client())
                {
                    mail.Connect(hostname, port, useTls);
                    mail.Authenticate(username, password);
                    int contadorMensagem = mail.GetMessageCount();
                    listaEmails.Clear();

                    for (int i = contadorMensagem; i > 0; i--)
                    {
                        var popEmail = mail.GetMessage(i);
                        listaEmails.Add(new Email() //ARMAZENA AS INFORMAÇÕES DOS E-MAILS EM UMA LISTA
                        {
                            Id = popEmail.Headers.MessageId,
                            Assunto = popEmail.Headers.Subject,
                            De = popEmail.Headers.From.Address,
                            Para = string.Join("; ", popEmail.Headers.To.Select(to => to.Address)),
                        }
                    );
                    }

                    if (mail.GetMessageCount() > 0)
                    {
                        using (SmtpClient objSmtp = new SmtpClient(hostname, 587))
                        {
                            objSmtp.EnableSsl = true;
                            objSmtp.Credentials = new NetworkCredential(username, password);

                            idsLidos = File.ReadLines(caminhoArquivo).ToList();

                            foreach (Email item in listaEmails)
                            {
                                if (!idsLidos.Contains(item.Id))
                                {                                    
                                    if (item.Assunto == "Matrícula")
                                    {
                                        Escrever(item.Id);
                                        objSmtp.Send(GerarMensagem("seuemail@email.com.br", item.De, "Resposta automática de e-mail"));
                                        Console.WriteLine("Respostas enviadas...");
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Não há novas mensagens...");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void Escrever(string idEmail)
        {
            StreamWriter escrever = File.AppendText(caminhoArquivo);
            escrever.WriteLine(idEmail);
            escrever.Close();
        }

        private MailMessage GerarMensagem(string remetente, string destinatario, string assunto)
        {
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(remetente);
            mail.To.Add(new MailAddress(destinatario));
            mail.Subject = assunto;
            mail.IsBodyHtml = true;
            mail.Body =
            "<html>" +
                "<head>" +
                    "<title>resposta_default_kit_v2</title>" +
                "</head>" +
                "<body bgcolor = '#FFFFFF' leftmargin = '0' topmargin = '0' marginwidth = '0' marginheight = '0'>" +
                     "<center>" +
                         "<table id = 'Tabela_01' width = '900' height = '1572' border = '0' cellpadding = '0' cellspacing = '0'>" +
                             "<tr>" +
                                "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_v2_01.gif' width = '900' height = '175' alt = ''>" +
                                "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_v2_02.jpg' width = '900' height = '295' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_v2_03.gif' width = '900' height = '1' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_v2_04.gif' width = '900' height = '222' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                              "<tr>" +
                                  "<td>" +
                                    "<img src = 'http://www.ceb.g12.br/img/resposta_default_kit_v2_05.gif' width = '900' height = '879' alt = ''>" +
                                  "</td>" +
                              "</tr>" +
                         "</table>" +
                     "</center>" +
                 "</body>" +
            "</html>";
            return mail;
        }

        public void Stop()
        {
            Console.WriteLine("Serviço encerrado...");
        }
    }
}
