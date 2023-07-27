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
    /// Lógica de interacción para PuestoSupAdmin.xaml
    /// </summary>
    public partial class PuestoSupAdmin : Page
    {
        public PuestoSupAdmin()
        {
            InitializeComponent();
            GetCargosTable();
        }
        CargoServices services = new CargoServices();
        public void GetCargosTable()
        {
            UserTable.ItemsSource = services.ReadCargos();
        }
        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Cargo cargos = new Cargo();

            cargos = (sender as FrameworkElement).DataContext as Cargo; //Esta funcion traera la selecion de la fila 

            txt_PkCargo.Text = cargos.PkCargo.ToString();
            txt_nombre.Text = cargos.Nombre.ToString();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Cargo cargos = (sender as FrameworkElement).DataContext as Cargo;
            services.Delete(cargos.PkCargo);
            GetCargosTable();
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_PkCargo.Text == "")
                {

                    if (!String.IsNullOrEmpty(txt_nombre.Text))
                    {
                        Cargo cargos = new Cargo()
                        {
                            Nombre = txt_nombre.Text,
                        };
                        services.AddCargo(cargos);
                        txt_nombre.Clear();
                        MessageBox.Show("Agregado correctamente");
                        GetCargosTable();
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
                        Cargo cargos = new Cargo()
                        {
                            Nombre = txt_nombre.Text,
                        };
                        services.Update(int.Parse(txt_PkCargo.Text), cargos);
                        GetCargosTable();
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
