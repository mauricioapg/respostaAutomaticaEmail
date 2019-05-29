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
using System.Text.RegularExpressions;

namespace ServicosWindowsRespostaEmail
{
    class MeuServico
    {
        private List<Email> listaEmails = new List<Email>();
        private string hostname = "outlook.office365.com";
        private int port = 995;
        private bool useTls = true;
        private string username = "contato@ceb.g12.br";
        private string password = "C&b28101972";
        public List<string> idsLidos = new List<string>();
        private string caminhoArquivo = Path.GetFullPath("emails_respondidos.txt");

        public void Start()
        {
            var timer = new Timer();
            timer.Interval = 1000; //a cada 1 segundo o programa é executado novamente
            timer.Elapsed += new ElapsedEventHandler(EnviarRespostaAtuomatica_Tick);
            timer.Enabled = true;
            Console.WriteLine("Serviço iniciado...");
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
                    /*
                     *  Classe que conecta e autentica com o e-mail contato@ceb.g12.br  
                     */
                    mail.Connect(hostname, port, useTls);
                    mail.Authenticate(username, password);
                    int contadorMensagem = mail.GetMessageCount();
                    listaEmails.Clear();

                    for (int i = contadorMensagem; i > 0; i--)
                    {
                        /*
                         *  Percorre os e-mails da caixa de entrada e pega algumas informações:
                         *  - ID do e-mail
                         *  - Assunto (para verificar se deve ou não responder)
                         *  - Remetente
                         *  - Data de recebimento da mensagem
                         *  Ao final, aramzena as informações de cada mensagem numa Lista, na memória.
                         */
                        var popEmail = mail.GetMessage(i);

                        string mailText = string.Empty;
                        var popText = popEmail.FindFirstPlainTextVersion();
                        if (popText != null)
                            mailText = popText.GetBodyAsText();

                        listaEmails.Add(new Email()
                        {
                            Id = popEmail.Headers.MessageId,
                            Assunto = popEmail.Headers.Subject,
                            De = popEmail.Headers.From.Address,
                            Para = string.Join("; ", popEmail.Headers.To.Select(to => to.Address)),
                            Data = popEmail.Headers.Date,
                            ConteudoTexto = mailText
                        }
                    );
                    }

                    if (mail.GetMessageCount() > 0)
                    {
                        /*
                         * Enquanto tiver e-mails na caixa de entrada, o programa faz o seguinte:
                         * - Pega o ID de cada mensagem e faz uma varredura no arquivo "emails_respondidos.txt", localizado no servidor
                         * - Se o ID NÃO CONSTAR no arquivo, o programa ENVIA uma resposta automática, de acordo com o assunto recebido.
                         * - Adiciona o e-mail enviado à lista de e-mails respondidos.
                         * - Se o ID CONSTAR, ignora a mensagem e NÃO ENVIA a resposta.
                         */
                        using (SmtpClient objSmtp = new SmtpClient(hostname, 587))
                        {
                            objSmtp.EnableSsl = true;
                            objSmtp.Credentials = new NetworkCredential(username, password);

                            idsLidos = File.ReadLines(caminhoArquivo).ToList();

                            foreach (Email item in listaEmails)
                            {
                                if (!idsLidos.Contains(item.Id))
                                {
                                    if (item.Assunto == "Contato do Site - \"Matrícula mais de um segmento\"")
                                    {
                                        Escrever(item.Id, item.Data);
                                        objSmtp.Send(Mensagens.GerarMensagemDefault(username, ObterRemetente(item.ConteudoTexto), ObterResposta(item.Assunto)));
                                        Console.WriteLine("Respostas enviadas...");
                                    }
                                    else if (item.Assunto == "Contato do Site - \"Matrícula Berçário\"")
                                    {
                                        Escrever(item.Id, item.Data);
                                        objSmtp.Send(Mensagens.GerarMensagemBercario(username, ObterRemetente(item.ConteudoTexto), ObterResposta(item.Assunto)));
                                        Console.WriteLine("Respostas enviadas...");
                                    }
                                    else if (item.Assunto == "Contato do Site - \"Matrícula Infantil\"")
                                    {
                                        Escrever(item.Id, item.Data);
                                        objSmtp.Send(Mensagens.GerarMensagemInfantil(username, ObterRemetente(item.ConteudoTexto), ObterResposta(item.Assunto)));
                                        Console.WriteLine("Respostas enviadas...");
                                    }
                                    else if (item.Assunto == "Contato do Site - \"Matrícula Fundamental 1\"")
                                    {
                                        Escrever(item.Id, item.Data);
                                        objSmtp.Send(Mensagens.GerarMensagemFundamental_1(username, ObterRemetente(item.ConteudoTexto), ObterResposta(item.Assunto)));
                                        Console.WriteLine("Respostas enviadas...");
                                    }
                                    else if (item.Assunto == "Contato do Site - \"Matrícula Fundamental 2\"")
                                    {
                                        Escrever(item.Id, item.Data);
                                        objSmtp.Send(Mensagens.GerarMensagemFundamental_2(username, ObterRemetente(item.ConteudoTexto), ObterResposta(item.Assunto)));
                                        Console.WriteLine("Respostas enviadas...");
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        //private void Escrever(string idEmail, string dataEnvio)
        //{
        //    StreamWriter escrever = File.AppendText(caminhoArquivo);
        //    escrever.WriteLine(idEmail + " " + dataEnvio);
        //    //escrever.WriteLine("E-mail recebido em: " + dataEnvio);
        //    //var inicioRemetente = corpoMensagem.IndexOf('-', corpoMensagem.IndexOf('-') + 1); //início da demarcação '-'
        //    //var remetente = corpoMensagem.Substring(inicioRemetente + 1, corpoMensagem.IndexOf('-', inicioRemetente + 1) - inicioRemetente - 1);
        //    //escrever.WriteLine("Remetente: " + remetente);
        //    //escrever.WriteLine("-----------------------------------------------------------------------------------------------------------------");
        //    escrever.Close();
        //    //return remetente; //além de escrever no arquivo .txt, o método retorna o e-mail extraído do corpo da mensagem
        //}

        private void Escrever(string idEmail, string dataEnvio)
        {
            StreamWriter escrever = File.AppendText(caminhoArquivo);
            escrever.WriteLine(idEmail);
            escrever.WriteLine(dataEnvio);
            escrever.Close();
        }
        //Este método pega o e-mail do remetente que deve estar no corpo da mensagem, entre os "<>".
        private string ObterRemetente(string corpoMensagem)
        {
            Regex expressao = new Regex(@"\<[^\}]+?\>");
            Match match = expressao.Match(corpoMensagem);
            var inicioRemetente = match.Value.IndexOf('<');
            var remetente = match.Value.Substring(inicioRemetente + 1, match.Value.IndexOf('>', inicioRemetente + 1) - inicioRemetente - 1);
            return remetente;

            //OPÇÂO ANTIGA
            //var inicioRemetente = corpoMensagem.IndexOf('-', corpoMensagem.IndexOf('-') + 1); //início da demarcação '-'
            //var remetente = corpoMensagem.Substring(inicioRemetente + 1, corpoMensagem.IndexOf('-', inicioRemetente + 1) - inicioRemetente - 1);
        }

        private string ObterResposta(string assunto)
        {
            string respostaPadrao = "Resposta Automática - " + assunto;
            return respostaPadrao;
        }

        public void Stop()
        {
            Console.WriteLine("Serviço encerrado...");
        }
    }
}
