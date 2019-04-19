using PiedraPapelTijera.Modelo;
using System.Collections.ObjectModel;

namespace PiedraPapelTijera.VistaModelo
{
    public class InicioVistaModelo
    {
        public ObservableCollection<Opcion> Opciones { get; private set; }
        public Jugador Humano { get; private set; }
        public Jugador Maquina { get; private set; }

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
            Humano = new Jugador { EsHumano = true };
            Maquina = new Jugador { EsHumano = false };
        }
    }
}
