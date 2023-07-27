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
    /// Lógica de interacción para UsuarioWindow.xaml
    /// </summary>
    public partial class UsuarioWindow : Window
    {
        public UsuarioWindow()
        {
            InitializeComponent();
        }

        private void btn_empleado_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new EmpleadoUsuario());

        }

        private void btn_permisos_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new PermisoUsuario());
        }

        private void btn_capacitacion_Click(object sender, RoutedEventArgs e)
        {
            SAview.NavigationService.Navigate(new CapacitacionUsuario());
        }

        private void btn_salir_Click(object sender, RoutedEventArgs e)
        {
            MainWindow inicio = new MainWindow();
            this.Close();
            inicio.Show();
        }

        private void btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
                WindowState = WindowState.Minimized;
        }
    }
}
