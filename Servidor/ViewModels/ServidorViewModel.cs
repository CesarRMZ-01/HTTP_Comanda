using Cliente.Models;
using Servidor.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Servidor.ViewModels
{
    public class ServidorViewModel
    {
        public ObservableCollection<Orden> Orden { get; set; }

        ServidorService service = new();
        public Orden orden { get; set; }

        Dispatcher dispatcher;
        public ServidorViewModel()
        {
            orden = new Orden();

            dispatcher = Dispatcher.CurrentDispatcher;

            service.Iniciar();
            Orden = new();

            service.OrdenRecibida += Service_OrdenRecibida; ;
        }

        private void Service_OrdenRecibida(Orden obj)
        {
            dispatcher.Invoke(() =>
            {
                Orden.Add(obj);
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Orden)));
            });
        }

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
