using PiedraPapelTijera.VistaModelo;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PiedraPapelTijera.Vista
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Principal : ContentPage
    {
        private PrincipalVistaModelo _vistaModelo;

        public Principal()
        {
            InitializeComponent();
            _vistaModelo = new PrincipalVistaModelo();
            BindingContext = _vistaModelo;
        }
    }
}