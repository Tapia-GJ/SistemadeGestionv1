using ProyectoGestion_Ta.Entities;
using ProyectoGestion_Ta.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoGestion_Ta.Pages
{
    /// <summary>
    /// Lógica de interacción para CapacitacionUsuario.xaml
    /// </summary>
    public partial class CapacitacionUsuario : Page
    {
        public CapacitacionUsuario()
        {
            InitializeComponent();
            GetCapacitacion();
        }
        EmpleadoCapacitacionServices servicesemplecapa = new EmpleadoCapacitacionServices();
        CapacitacionServices servicescapacitacion = new CapacitacionServices();
        public void GetCapacitacion()
        {
            selectCapacitacion.ItemsSource = servicescapacitacion.GetCapacitaciones();
            selectCapacitacion.DisplayMemberPath = "TipoCapacitacion";
            selectCapacitacion.SelectedValuePath = "PkCapacitacion";
        }
        public void GetemplecapaTable( int id)
        {
            UserTable.ItemsSource = servicesemplecapa.Read(id);
        }

        //Cargo cargos = (sender as FrameworkElement).DataContext as Cargo;
        //services.Delete(cargos.PkCargo);
        //    GetCargosTable();
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            EmpleadoCapacitacion id = (sender as FrameworkElement).DataContext as EmpleadoCapacitacion;
            MessageBox.Show($"{id.EmpleadoId}");
            servicesemplecapa.Delete(int.Parse(selectCapacitacion.SelectedValue.ToString()), id.EmpleadoId);
            GetemplecapaTable(int.Parse(selectCapacitacion.SelectedValue.ToString()));
        }

        private void selectCapacitacion_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            GetemplecapaTable(int.Parse(selectCapacitacion.SelectedValue.ToString()));
        }
    }
}
