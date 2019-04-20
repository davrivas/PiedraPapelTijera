using PiedraPapelTijera.VistaModelo;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiedraPapelTijera.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inicio : ContentPage
    {
        private readonly InicioVistaModelo _vistaModelo;

        public Inicio()
        {
            InitializeComponent();
            _vistaModelo = new InicioVistaModelo();
            BindingContext = _vistaModelo;
        }

        private void SeleccionarOpcion(object sender, EventArgs e)
        {
            object opcionSeleccionada = pckOpciones.SelectedItem;
            _vistaModelo.ComandoEscogerOpcion.Execute(opcionSeleccionada);
        }
    }
}