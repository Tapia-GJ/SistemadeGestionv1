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
    /// Lógica de interacción para Roles.xaml
    /// </summary>
    public partial class Roles : Page
    {
        public Roles()
        {
            InitializeComponent();
            GetRolesTable();
        }
        RolServices services= new RolServices();
        public void GetRolesTable()
        {
            UserTable.ItemsSource = services.ReadRoles();
        }
        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Rol rols = new Rol();

            rols = (sender as FrameworkElement).DataContext as Rol; //Esta funcion traera la selecion de la fila 

            txt_PkRol.Text = rols.PkRol.ToString();
            txt_nombre.Text = rols.Nombre.ToString();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Rol rol = (sender as FrameworkElement).DataContext as Rol;
            services.Delete(rol.PkRol);
            GetRolesTable();
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_PkRol.Text == "")
                {

                    if (!String.IsNullOrEmpty(txt_nombre.Text) && !String.IsNullOrEmpty(txt_nombre.Text))
                    {
                        Rol rols = new Rol()
                        {
                            Nombre = txt_nombre.Text,
                        };
                        services.AddRol(rols);
                        txt_nombre.Clear();
                        MessageBox.Show("Agregado correctamente");
                        GetRolesTable();
                    }
                    else
                    {
                        MessageBox.Show("LLena todos los campos");
                    }
                }
                else
                {

                    if (!String.IsNullOrEmpty(txt_nombre.Text))
                    {
                        Rol rols = new Rol()
                        {
                            Nombre = txt_nombre.Text,
                        };
                        services.Update(int.Parse(txt_PkRol.Text), rols);
                        GetRolesTable();
                        txt_nombre.Clear();
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
