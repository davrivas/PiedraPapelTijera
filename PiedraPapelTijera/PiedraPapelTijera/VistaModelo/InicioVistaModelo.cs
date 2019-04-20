using PiedraPapelTijera.Modelo;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Forms;

namespace PiedraPapelTijera.VistaModelo
{
    public class InicioVistaModelo
    {
        public Opcion Piedra { get; private set; }
        public Opcion Papel { get; private set; }
        public Opcion Tijera { get; private set; }
        private readonly IList<Opcion> _opciones;

        public Jugador Humano { get; private set; }
        public Jugador Maquina { get; private set; }

        public ICommand ComandoEscogerOpcion { get; private set; }

        public bool YaEscogio { get; private set; }

        public InicioVistaModelo()
        {
            Piedra = new Opcion
            {
                Nombre = "Piedra",
                NombreArchivo = "piedra.png"
            };
            Papel = new Opcion
            {
                Nombre = "Papel",
                NombreArchivo = "papel.png"
            };
            Tijera = new Opcion
            {
                Nombre = "Tijera",
                NombreArchivo = "tijera.png"
            };
            _opciones = new List<Opcion> { Piedra, Papel, Tijera };

            Humano = new Jugador { EsHumano = true };
            Maquina = new Jugador { EsHumano = false };

            ComandoEscogerOpcion = new Command<object>(EscogerOpcion);

            YaEscogio = Humano.Opcion != null;
        }

        private void EscogerOpcion(object obj)
        {
            var opcion = obj as Opcion;
            Humano.Opcion = opcion;
            YaEscogio = true;

            MaquinaEscoge();
        }

        private void MaquinaEscoge()
        {
            var random = new Random();
            int indiceOpcion = random.Next(_opciones.Count);
            Maquina.Opcion = _opciones[indiceOpcion];

            ComprobarOpcion();
        }

        private void ComprobarOpcion()
        {
            if (Humano.Opcion.Equals(Piedra))
            {
                if (Maquina.Opcion.Equals(Papel))
                {
                    // perdió
                }
                else if (Maquina.Opcion.Equals(Tijera))
                {
                    // ganó
                }
                else
                {
                    // empató
                }
            }
            else if (Humano.Opcion.Equals(Papel))
            {
                if (Maquina.Opcion.Equals(Piedra))
                {
                    // ganó
                }
                else if (Maquina.Opcion.Equals(Tijera))
                {
                    // perdió
                }
                else
                {
                    // empató
                }
            }
            else
            {
                if (Maquina.Opcion.Equals(Piedra))
                {
                    // perdió
                }
                else if (Maquina.Opcion.Equals(Papel))
                {
                    // ganó
                }
                else
                {
                    // empató
                }
            }
        }
    }
}
