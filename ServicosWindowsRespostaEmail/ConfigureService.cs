﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace ServicosWindowsRespostaEmail
{
    class ConfigureService
    {
        internal static void Configure()
        {
            HostFactory.Run(configure =>
            {
                configure.Service<MeuServico>(service =>
                {
                    service.ConstructUsing(s => new MeuServico());
                    service.WhenStarted(s => s.Start());
                    service.WhenStopped(s => s.Stop());
                });
                //Configure a Conta que o serviço do Windows usa para rodar
                configure.RunAsLocalSystem();
                configure.SetServiceName("ResponderAutomaticamente");
                configure.SetDisplayName("Resposta automática CEB");
                configure.SetDescription("Serviço de resposta automática às solicitações de novas matrículas vindas do site do CEB");
            });
        }
    }
}
