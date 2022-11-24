using Cliente.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Cliente.Services
{
    public class ClienteService
    {
        HttpClient cliente = new HttpClient();

        public ClienteService()
        {
            cliente.BaseAddress = new Uri("https://6141-187-209-255-62.ngrok.io/votacion/");
        }

        //public async Task<Pregunta> GetPregunta()
        //{
        //    HttpResponseMessage response = await cliente.GetAsync("pregunta");
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string json = await response.Content.ReadAsStringAsync();
        //        Pregunta p = JsonConvert.DeserializeObject<Pregunta>(json);
        //        return p;
        //    }
        //    else
        //    {
        //        return null;
        //    }

        //}

        public async Task OrdenarPost(Orden o)
        {
            var json = JsonConvert.SerializeObject(o);
            var response = await cliente.PostAsync("ordenar", new StringContent(json, Encoding.UTF8, "application/json"));
            response.EnsureSuccessStatusCode();
        }
    }
}
