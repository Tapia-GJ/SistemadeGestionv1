using ProyectoGestion_Ta.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoGestion_Ta.Windows
{
    /// <summary>
    /// Lógica de interacción para SuperUsuario.xaml
    /// </summary>
    public partial class SuperUsuario : Window
    {
        public SuperUsuario()
        {
            InitializeComponent();
            SAview.NavigationService.Navigate(new HomeSupAdmin());
        }
        private void btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void btn_rol_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new Roles());
        }

        private void btn_usuario_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new Usuarios());
        }

        private void btn_empleado_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new EmpleadoSupAdmin());
        }

        private void btn_cargo_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new PuestoSupAdmin());
        }

        private void btn_permisos_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new PermisosSupAdmin());
        }

        private void btn_capacitacion_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new CapacitacionSupAdmin());
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {

            MainWindow inicio = new MainWindow();
            this.Close();
            inicio.Show();
        }
    }
}
