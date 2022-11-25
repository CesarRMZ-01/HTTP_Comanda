using Cliente.Models;
using Cliente.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Cliente.ViewModels
{
    internal class ClienteViewModel
    {
        HttpClient Cliente = new HttpClient();

        ClienteService Service = new ClienteService();
        Productos Producto;

        public ObservableCollection<Orden> Orden = new ObservableCollection<Orden>();


        public ICommand EnviarCommand { get; set; }
        public ClienteViewModel()
        {
            EnviarCommand = new Command(EnviarPedido);
        }

        private void EnviarPedido(object obj)
        {
            throw new NotImplementedException();
        }
    }
}
