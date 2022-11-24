using Cliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Servidor.Services
{
    public class ServidorService
    {

        HttpListener listener = new();
        public event Action<Orden>? PedidoRecibido;

        public ServidorService()
        {
            listener.Prefixes.Add("http://*:4566/comanda/");

        }

        public void Iniciar()
        {
            if (!listener.IsListening)
            {
                listener.Start();
                listener.BeginGetContext(ContextoRecibido, null);
            }
        }

        private void ContextoRecibido(IAsyncResult ar)
        {
            var context = listener.EndGetContext(ar);
            listener.BeginGetContext(ContextoRecibido, null);

            if (context.Request.Url != null)
            {
                if (context.Request.HttpMethod == "POST" && (context.Request.Url.LocalPath == "/comanda/orden"))
                {
                    var stream = new StreamReader(context.Request.InputStream);
                    var json = stream.ReadToEnd();
                    Orden? orden = JsonConvert.DeserializeObject<Orden>(json);

                    if (orden != null)
                    {
                        PedidoRecibido?.Invoke(orden);
                        context.Response.StatusCode = 200;
                    }
                    else
                    {
                        context.Response.StatusCode = 404;
                    }

                    context.Response.Close();
                }
                else
                {
                    context.Response.StatusCode = 404;
                    context.Response.Close();
                }

                context.Response.Close();

            }
        }
    }
}
