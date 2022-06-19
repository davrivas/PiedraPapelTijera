using MvvmHelpers;
using PiedraPapelTijera.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using Xamarin.Forms;

namespace PiedraPapelTijera.VistaModelo
{
    public class InicioVistaModelo : ObservableObject
    {
        private const string NombrePiedra = "Piedra";
        private const string NombrePapel = "Papel";
        private const string NombreTijera = "Tijera";
        private const string Victoria = nameof(Victoria);
        private const string Empate = nameof(Empate);
        private const string Derrota = nameof(Derrota);
        private readonly Random _random = new Random();

        public const string MensajeResultado = nameof(MensajeResultado);
        public string Resultado { get; private set; }

        public Opcion Piedra { get; }
        public Opcion Papel { get; }
        public Opcion Tijera { get; }
        private IList<Opcion> _opciones;

        public Jugador Humano { get; }
        public Jugador Maquina { get; }

        public ICommand PiedraComando { get; }
        public ICommand PapelComando { get; }
        public ICommand TijeraComando { get; }

        public bool YaEscogio { get; private set; }

        private int _puntaje;

        public int Puntaje
        {
            get { return _puntaje; }
            set {
                SetProperty(ref _puntaje, value);
            }
        }

        public InicioVistaModelo()
        {
            Piedra = new Opcion
            {
                Nombre = NombrePiedra,
                NombreArchivo = "piedra.png"
            };
            Papel = new Opcion
            {
                Nombre = NombrePapel,
                NombreArchivo = "papel.png"
            };
            Tijera = new Opcion
            {
                Nombre = NombreTijera,
                NombreArchivo = "tijera.png"
            };
            _opciones = new List<Opcion> { Piedra, Papel, Tijera };

            Humano = new Jugador { EsHumano = true };
            Maquina = new Jugador { EsHumano = false };

            PiedraComando = new Command<string>(EscogerOpcion);
            PapelComando = new Command<string>(EscogerOpcion);
            TijeraComando = new Command<string>(EscogerOpcion);

            YaEscogio = Humano.Opcion != null;
            Puntaje = 0;
        }

        private void EscogerOpcion(string opcion)
        {
            Humano.Opcion = _opciones.First(x => x.Nombre == opcion);
            YaEscogio = true;
            MaquinaEscoge();
        }

        private void MaquinaEscoge()
        {
            var indiceOpcion = _random.Next(_opciones.Count);
            var opcion = _opciones[indiceOpcion];
            Maquina.Opcion = opcion;

            ComprobarOpcion();
        }

        private void ComprobarOpcion()
        {
            Resultado = $"{Maquina.Opcion.Nombre}: ";

            if (Humano.Opcion.Nombre == Maquina.Opcion.Nombre)
            {
                Resultado = Empate;
                Puntaje++;
            }
            else
            {
                switch (Humano.Opcion.Nombre)
                {
                    case NombrePiedra:
                        switch (Maquina.Opcion.Nombre)
                        {
                            case NombrePapel:
                                Resultado += Derrota;
                                break;
                            case NombreTijera:
                                Resultado += Victoria;
                                Puntaje += 3;
                                break;
                        }
                        break;
                    case NombrePapel:
                        switch (Maquina.Opcion.Nombre)
                        {
                            case NombrePiedra:
                                Resultado += Victoria;
                                Puntaje += 3;
                                break;
                            case NombreTijera:
                                Resultado += Derrota;
                                break;
                        }
                        break;
                    case NombreTijera:
                        switch (Maquina.Opcion.Nombre)
                        {
                            case NombrePiedra:
                                Resultado += Derrota;
                                break;
                            case NombrePapel:
                                Resultado += Victoria;
                                Puntaje += 3;
                                break;
                        }
                        break;
                }
            }

            MessagingCenter.Send(this, MensajeResultado);
        }
    }
}
