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

        protected override void OnAppearing()
        {
            base.OnAppearing();

            MessagingCenter.Subscribe<InicioVistaModelo>(_vistaModelo, InicioVistaModelo.MensajeResultado, MostrarMensaje);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<InicioVistaModelo>(_vistaModelo, InicioVistaModelo.MensajeResultado);
        }

        private async void MostrarMensaje(InicioVistaModelo obj)
        {
            await DisplayAlert("Resultado", obj.Resultado, "Cancelar");
        }
    }
}