using ProyectoGestion_Ta.Services;
using ProyectoGestion_Ta.Windows;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoGestion_Ta
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        UsuarioServices services = new UsuarioServices();
        private void btn_Cerrar_Click(object sender, RoutedEventArgs e)
        {
            App.Current.Shutdown();
        }

        private void btn_min_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Minimized;
            }
            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Minimized;
            }
        }

        private void btn_login_Click(object sender, RoutedEventArgs e)
        {
            string user = txt_username.Text;
            string pasword = txt_password.Password.ToString();
            var responser = services.Login(user, pasword);
            if (responser != null && responser.Roles.Nombre == "Administrador")
            {
                SuperUsuario supusuario = new SuperUsuario();
                Close();
                supusuario.Show();
            }
            else if (responser != null && responser.Roles.Nombre == "UsuarioNormal")
            {
                UsuarioWindow usuario = new UsuarioWindow();
                Close();
                usuario.Show();
            }
            else
            {
                MessageBox.Show("Usuario o Contraseña Incorrecta");
            }



        }
    }
}
