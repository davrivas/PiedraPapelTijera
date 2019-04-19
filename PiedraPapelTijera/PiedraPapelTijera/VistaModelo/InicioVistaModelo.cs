using PiedraPapelTijera.Modelo;
using System.Collections.ObjectModel;

namespace PiedraPapelTijera.VistaModelo
{
    public class InicioVistaModelo
    {
        public ObservableCollection<Opcion> Opciones { get; private set; }
        public ObservableCollection<Jugador> Jugadores { get; set; }

        public InicioVistaModelo()
        {
            Opciones = new ObservableCollection<Opcion>
            {
                new Opcion
                {
                    Nombre = "Piedra",
                    NombreArchivo = "piedra.png"
                },
                new Opcion
                {
                    Nombre = "Papel",
                    NombreArchivo = "papel.png"
                },
                new Opcion
                {
                    Nombre = "Tijera",
                    NombreArchivo = "tijera.png"
                }
            };
            Jugadores = new ObservableCollection<Jugador>
            {
                new Jugador
                {
                     EsHumano = true
                },
                new Jugador
                {
                    EsHumano = false
                }
            };
        }
    }
}
