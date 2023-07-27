using ProyectoGestion_Ta.Entities;
using ProyectoGestion_Ta.Services;
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

namespace ProyectoGestion_Ta.Pages
{
    /// <summary>
    /// Lógica de interacción para Usuarios.xaml
    /// </summary>
    public partial class Usuarios : Page
    {
        public Usuarios()
        {
            InitializeComponent();
            GetUserTable();
            GetRoles();
        }
        UsuarioServices services = new UsuarioServices();
        public void GetUserTable()
        {
            UserTable.ItemsSource = services.ReadUsers();
        }
        public void GetRoles()
        {
            selectRol.ItemsSource = services.GetRoles();
            selectRol.DisplayMemberPath = "Nombre";
            selectRol.SelectedValuePath = "PkRol";
        }
        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Usuario usuario = new Usuario();

            usuario = (sender as FrameworkElement).DataContext as Usuario; //Esta funcion traera la selecion de la fila 

            txt_PKUser.Text = usuario.PkUsuario.ToString();
            txt_nombre.Text = usuario.Nombre.ToString();
            txt_username.Text = usuario.UserName.ToString();
            txt_contraseña.Text = usuario.Password.ToString();
            selectRol.SelectedValue = usuario.FkRol.Value;
        }
        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = (sender as FrameworkElement).DataContext as Usuario;
            services.Delete(user.PkUsuario);
            GetUserTable();
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_PKUser.Text == "")
                {

                    if (!String.IsNullOrEmpty(txt_nombre.Text) && !String.IsNullOrEmpty(txt_username.Text) && !String.IsNullOrEmpty(txt_contraseña.Text)
                        && !String.IsNullOrEmpty(selectRol.Text))
                    {
                        Usuario usuario = new Usuario()
                        {
                            Nombre = txt_nombre.Text,
                            UserName = txt_username.Text,
                            Password = txt_contraseña.Text,
                            FkRol = int.Parse(selectRol.SelectedValue.ToString()),
                        };
                        services.AddUser(usuario);
                        txt_nombre.Clear();
                        txt_username.Clear();
                        txt_contraseña.Clear();
                        selectRol.SelectedIndex = -1;
                        MessageBox.Show("Agregado correctamente");
                        GetUserTable();
                    }
                    else
                    {
                        MessageBox.Show("LLena todos los campos");
                    }
                }
                else
                {

                    if (!String.IsNullOrEmpty(txt_nombre.Text) && !String.IsNullOrEmpty(txt_username.Text) && !String.IsNullOrEmpty(txt_contraseña.Text)
                        && !String.IsNullOrEmpty(selectRol.Text))
                    {
                        Usuario usernew = new Usuario()
                        {
                            Nombre = txt_nombre.Text,
                            UserName = txt_username.Text,
                            Password = txt_contraseña.Text,
                            FkRol = int.Parse(selectRol.SelectedValue.ToString()),
                        };
                        services.Update(int.Parse(txt_PKUser.Text), usernew);
                        GetUserTable();
                        txt_nombre.Clear();
                        txt_username.Clear();
                        txt_contraseña.Clear();
                        selectRol.SelectedIndex = -1;
                    }
                    else
                    {
                        MessageBox.Show("Llena todos los campos");
                    }
                }
            }
            catch (Exception f)
            {

                throw new Exception("Error" + f.Message);
            }
        }
    }
}
