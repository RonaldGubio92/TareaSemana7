using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public partial class ConsultaRegistro : ContentPage
    {
        private SQLiteAsyncConnection con;
        private ObservableCollection<Estudiante> tablaEstudiante;

        public ConsultaRegistro()
        {
            InitializeComponent();
            con = DependencyService.Get<Database>().GetConnection();
            NavigationPage.SetHasBackButton(this, false);
            Datos();


        }

        public async void Datos() 
        {
            var Resultado = await con.Table<Estudiante>().ToListAsync();
            tablaEstudiante = new ObservableCollection<Estudiante>(Resultado);
            ListaEstudiantes.ItemsSource = tablaEstudiante;
        
        }
        private void ListaEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var Obj = (Estudiante)e.SelectedItem;
            var item = Obj.Id.ToString();

          
            var itemSeleccionado = Convert.ToInt32(item );
          
            


            try
            {
                Navigation.PushAsync(new Elemento(itemSeleccionado));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}