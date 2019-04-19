using PiedraPapelTijera.VistaModelo;
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
    }
}