using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RG_SqlLite.Models;
using SQLite;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace RG_SqlLite
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Elemento : ContentPage
    {
        public int idSel;
        private SQLiteAsyncConnection con;

        IEnumerable<Estudiante> borrar;
        IEnumerable<Estudiante> actualizar;


        public Elemento(int id )
        {
            InitializeComponent();
            idSel = id;
            con = DependencyService.Get<Database>().GetConnection();
          //  txtNombre.Text = nombre;

        }

        public static IEnumerable<Estudiante> borrar1(SQLiteConnection db, int id) {

            return db.Query<Estudiante>("Delete from Estudiante where id = ?", id);

        }

        public static IEnumerable<Estudiante> actualizar1(SQLiteConnection db, int id, string nombre, string usuario, string contrasenia) 
        {
            return db.Query<Estudiante>("update Estudiante set nombre =?, Usuario= ?, Contrasenia = ?", nombre, usuario, contrasenia);

        }


        private void btnEliminar_Clicked(object sender, EventArgs e)
        {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "uisrael.db3");
            var db = new SQLiteConnection(databasePath);
            borrar = borrar1(db, idSel);
            DisplayAlert("Mensaje", "Dato Eliminado", "Cerrar");
            Navigation.PushAsync(new ConsultaRegistro());
        }

        private void btnActualizar_Clicked(object sender, EventArgs e)
        {
            try
            {
                var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),"uisrael.db3");
                var db = new SQLiteConnection(databasePath);
                actualizar = actualizar1(db, idSel, txtNombre.Text, txtUsuario.Text, txtClave.Text);
                DisplayAlert("Mensaje", "Dato Actualizado", "Cerrar");
                Navigation.PushAsync(new ConsultaRegistro());


            }
            catch (Exception ex)
            {

                DisplayAlert("Mensaje", ex.Message, "Cerrar");
            }
        }
    }
}