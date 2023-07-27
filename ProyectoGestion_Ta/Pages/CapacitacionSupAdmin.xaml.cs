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
    /// Lógica de interacción para CapacitacionSupAdmin.xaml
    /// </summary>
    public partial class CapacitacionSupAdmin : Page
    {
        public CapacitacionSupAdmin()
        {
            InitializeComponent();
            GetCapacitacionTable();
        }
        CapacitacionServices services = new CapacitacionServices();
        public void GetCapacitacionTable()
        {
            UserTable.ItemsSource = services.ReadCapacitaciones();
        }
        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_PkCapacitacion.Text == "")
                {

                    if (!String.IsNullOrEmpty(txt_tipocapacitacion.Text) && !String.IsNullOrEmpty(txt_fechainicial.Text) && !String.IsNullOrEmpty(txt_fechafinal.Text))
                    {
                        Capacitacion capacitacion = new Capacitacion()
                        {
                            TipoCapacitacion = txt_tipocapacitacion.Text,
                            FechaIni = DateTime.Parse(txt_fechainicial.Text),
                            FechaFin = DateTime.Parse(txt_fechafinal.Text),
                        };
                        services.AddCapacitacion(capacitacion);
                        txt_tipocapacitacion.Clear();
                        txt_fechainicial.Clear();
                        txt_fechafinal.Clear();
                        MessageBox.Show("Agregado correctamente");
                        GetCapacitacionTable();
                    }
                    else
                    {
                        MessageBox.Show("LLena todos los campos");
                    }
                }
                else
                {

                    if (!String.IsNullOrEmpty(txt_tipocapacitacion.Text) && !String.IsNullOrEmpty(txt_fechainicial.Text) && !String.IsNullOrEmpty(txt_fechafinal.Text))
                    {
                        Capacitacion capacitacion = new Capacitacion()
                        {
                            TipoCapacitacion = txt_tipocapacitacion.Text,
                            FechaIni = DateTime.Parse(txt_fechainicial.Text),
                            FechaFin = DateTime.Parse(txt_fechafinal.Text),
                        };
                        services.Update(int.Parse(txt_PkCapacitacion.Text), capacitacion);
                        GetCapacitacionTable();
                        txt_tipocapacitacion.Clear();
                        txt_fechainicial.Clear();
                        txt_fechafinal.Clear();
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

        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Capacitacion capacitacion = new Capacitacion();

            capacitacion = (sender as FrameworkElement).DataContext as Capacitacion; //Esta funcion traera la selecion de la fila 

            txt_PkCapacitacion.Text = capacitacion.PkCapacitacion.ToString();
            txt_tipocapacitacion.Text = capacitacion.TipoCapacitacion.ToString();
            txt_fechainicial.Text = capacitacion.FechaIni.ToString();
            txt_fechafinal.Text = capacitacion.FechaFin.ToString();
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Usuario user = (sender as FrameworkElement).DataContext as Usuario;
            services.Delete(user.PkUsuario);
            GetCapacitacionTable();
        }
    }
}
