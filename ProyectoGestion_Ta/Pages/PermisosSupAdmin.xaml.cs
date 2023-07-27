using ProyectoGestion_Ta.Entities;
using ProyectoGestion_Ta.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica de interacción para PermisosSupAdmin.xaml
    /// </summary>
    public partial class PermisosSupAdmin : Page
    {
        public PermisosSupAdmin()
        {
            InitializeComponent();
            GetUserTable();
            GetREmpleado();
        }
        PermisoServices services = new PermisoServices();
        public void GetUserTable()
        {
            UserTable.ItemsSource = services.ReadPermisos();
        }
        public void GetREmpleado()
        {
            selectempleado.ItemsSource = services.GetREmpleado();
            selectempleado.DisplayMemberPath = "PkEmpleado";
            selectempleado.SelectedValuePath = "PkEmpleado";
        }
        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Permiso permiso = new Permiso();

            permiso = (sender as FrameworkElement).DataContext as Permiso; //Esta funcion traera la selecion de la fila 

            txt_PkPermiso.Text = permiso.PkPermiso.ToString();
            txt_FechaSolicitud.Text = permiso.FechaSoli.ToString();
            txt_Motivo.Text = permiso.Motivo.ToString();
            txt_FechaIni.Text = permiso.FechaIni.ToString();
            txt_FechaFin.Text = permiso.FechaFin.ToString();
            selectempleado.SelectedValue = permiso.EmpleadoId;
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Permiso user = (sender as FrameworkElement).DataContext as Permiso;
            services.Delete(user.PkPermiso);
            GetUserTable();
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
             
                if (txt_PkPermiso.Text == "")
                {

                    if (!String.IsNullOrEmpty(txt_Motivo.Text) && !String.IsNullOrEmpty(txt_FechaIni.Text) && !String.IsNullOrEmpty(txt_FechaFin.Text))
                    {
                        
                            Permiso permiso = new Permiso()
                            {
                                Motivo = txt_Motivo.Text,
                                FechaSoli = DateTime.UtcNow,
                                FechaIni = DateTime.Parse(txt_FechaIni.Text),
                                FechaFin = DateTime.Parse(txt_FechaFin.Text),
                                EmpleadoId = int.Parse(selectempleado.SelectedValue.ToString()),
                            };
                            services.AddPermiso(permiso);
                            txt_PkPermiso.Clear();
                            txt_Motivo.Clear();
                            txt_FechaSolicitud.Clear();
                            txt_FechaFin.Clear();
                            txt_FechaIni.Clear();
                            selectempleado.SelectedIndex = -1;
                            MessageBox.Show("Agregado correctamente");
                            GetUserTable();
                            // Resto de tu código para agregar el objeto "Permiso" y limpiar los campos.
                        
                        
                    }
                    else
                    {
                        MessageBox.Show("LLena todos los campos");
                    }
                }
                else
                {

                    if (!String.IsNullOrEmpty(txt_Motivo.Text) && !String.IsNullOrEmpty(txt_FechaIni.Text) && !String.IsNullOrEmpty(txt_FechaFin.Text))
                    {
                        Permiso usernew = new Permiso()
                        {
                            Motivo = txt_Motivo.Text,
                            FechaSoli = DateTime.Now,
                            FechaIni = DateTime.Parse(txt_FechaIni.Text),
                            FechaFin = DateTime.Parse(txt_FechaFin.Text),
                            EmpleadoId = int.Parse(selectempleado.SelectedValue.ToString()),
                        };
                        services.Update(int.Parse(txt_PkPermiso.Text), usernew);
                        GetUserTable();
                        txt_PkPermiso.Clear();
                        txt_Motivo.Clear();
                        txt_FechaSolicitud.Clear();
                        txt_FechaFin.Clear();
                        txt_FechaIni.Clear();
                        selectempleado.SelectedIndex = -1;
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
