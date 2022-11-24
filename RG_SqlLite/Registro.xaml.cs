using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using SQLite;
using RG_SqlLite.Models;

namespace RG_SqlLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Registro : ContentPage
    {

        private SQLiteAsyncConnection con;
        public Registro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
        }

        private void btnGuardar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var datosRegistro = new Estudiante { Nombre = txtNombre.Text, Usuario = txtusuario.Text, Contrasenia = txtClave.Text };
                con.InsertAsync(datosRegistro);

                DisplayAlert("Mensaje", "Datos correctos", "Aceptar");

                txtNombre.Text = "";
                txtusuario.Text = "";
                txtClave.Text = "";
            }
            catch (Exception ex)
            {
                DisplayAlert("Mensaje",ex.Message,"Aceptar");
            }
        }

        private void brnSalir_Clicked(object sender, EventArgs e)
        {

            Navigation.PushAsync(new Login());
        }
    }
}