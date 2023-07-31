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
    /// Lógica de interacción para EmpleadoSupAdmin.xaml
    /// </summary>
    public partial class EmpleadoSupAdmin : Page
    {
        public EmpleadoSupAdmin()
        {
            InitializeComponent();
            GetEmpleados();
            GetemplecapaTable();
        }
        EmpleadoServices services = new EmpleadoServices();
        public void GetEmpleados()
        {
            selectcargo.ItemsSource = services.GetCargos();
            selectcargo.DisplayMemberPath = "Nombre";
            selectcargo.SelectedValuePath = "PkCargo";
        }
        public void GetemplecapaTable()
        {
            UserTable.ItemsSource = services.ReadEmpleado();
        }
        private void btn_edit_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = new Empleado();

            empleado = (sender as FrameworkElement).DataContext as Empleado; //Esta funcion traera la selecion de la fila 

            txt_PkEmpleado.Text = empleado.PkEmpleado.ToString();
            txt_nombre.Text = empleado.Nombre.ToString();
            txt_paterno.Text = empleado.ApellidoPaterno.ToString(); 
            txt_materno.Text = empleado.ApellidoMaterno.ToString(); 
            txt_fechanacimiento.Text = empleado.FechaNacimiento.ToString(); 
            txt_direccion.Text = empleado.Direccion.ToString(); 
            txt_telefono.Text = empleado.Telefono.ToString(); 
            txt_email.Text = empleado.Email.ToString(); 
            txt_salario.Text = empleado.Salario.ToString();
            selectcargo.SelectedValue = empleado.CargoId;
        }

        private void btn_eliminar_Click(object sender, RoutedEventArgs e)
        {
            Empleado empleado = (sender as FrameworkElement).DataContext as Empleado;
            services.DeleteEmpleado(empleado.PkEmpleado);
            GetemplecapaTable();
        }

        private void btn_guardar_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txt_PkEmpleado.Text == "")
                {

                    if (!String.IsNullOrEmpty(txt_nombre.Text) && !String.IsNullOrEmpty(txt_paterno.Text) && !String.IsNullOrEmpty(txt_materno.Text)
                        && !String.IsNullOrEmpty(txt_fechanacimiento.Text) && !String.IsNullOrEmpty(txt_telefono.Text) && !String.IsNullOrEmpty(txt_email.Text)
                        && !String.IsNullOrEmpty(txt_salario.Text) && !String.IsNullOrEmpty(selectcargo.Text) && !String.IsNullOrEmpty(txt_direccion.Text))
                    {
                        //Empleado cargos = new Empleado()
                        //{
                        //    Nombre = txt_nombre.Text,
                        //    ApellidoPaterno = txt_paterno.Text,
                        //    ApellidoMaterno = txt_materno.Text,
                        //    Direccion = txt_direccion.Text,
                        //    FechaNacimiento = DateTime.Parse(txt_fechanacimiento.Text),
                        //    Telefono = txt_telefono.Text,
                        //    Email = txt_email.Text,
                        //    Salario = int.Parse(txt_salario.Text),
                        //    CargoId = int.Parse(selectcargo.SelectedValue.ToString()),
                        //};
                        //services.AddEmpleado(cargos);
                        //txt_nombre.Clear();
                        //txt_paterno.Clear();
                        //txt_direccion.Clear();
                        //txt_materno.Clear();
                        //txt_salario.Clear();
                        //txt_email.Clear();
                        //txt_fechanacimiento.Clear();
                        //txt_PkEmpleado.Clear();
                        //txt_telefono.Clear();
                        //selectcargo.SelectedIndex = -1;
                        //MessageBox.Show("Agregado correctamente");
                        //GetemplecapaTable();
                        string formatoFecha = "dd-MM-yyyy";
                        string fechaNacimientoStr = txt_fechanacimiento.Text;

                        DateTime fechaNacimiento;

                        // Intenta analizar la cadena en la fecha utilizando el formato especificado
                        if (DateTime.TryParseExact(fechaNacimientoStr, formatoFecha, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out fechaNacimiento))
                        {
                            // Si la fecha se pudo analizar correctamente, entonces tiene el formato correcto.
                            // Aquí puedes continuar con el resto del código.
                            Empleado cargos = new Empleado()
                            {
                                Nombre = txt_nombre.Text,
                                ApellidoPaterno = txt_paterno.Text,
                                ApellidoMaterno = txt_materno.Text,
                                Direccion = txt_direccion.Text,
                                FechaNacimiento = fechaNacimiento, // Asignamos el valor de la fecha validada al objeto Empleado.
                                Telefono = txt_telefono.Text,
                                Email = txt_email.Text,
                                Salario = int.Parse(txt_salario.Text),
                                CargoId = int.Parse(selectcargo.SelectedValue.ToString()),
                            };
                            services.AddEmpleado(cargos);
                            txt_nombre.Clear();
                            txt_paterno.Clear();
                            txt_direccion.Clear();
                            txt_materno.Clear();
                            txt_salario.Clear();
                            txt_email.Clear();
                            txt_fechanacimiento.Clear();
                            txt_PkEmpleado.Clear();
                            txt_telefono.Clear();
                            selectcargo.SelectedIndex = -1;
                            MessageBox.Show("Agregado correctamente");
                            GetemplecapaTable();
                        }
                        else
                        {
                            // Si la fecha no pudo analizarse correctamente, entonces no tiene el formato esperado (dd-MM-yyyy).
                            // Aquí puedes mostrar un mensaje de error al usuario o realizar cualquier otra acción que consideres adecuada.
                            MessageBox.Show("Fecha de nacimiento no válida. Asegúrate de ingresarla en formato dd-MM-yyyy.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("LLena todos los campos");
                    }
                }
                else
                {

                    if (!String.IsNullOrEmpty(txt_nombre.Text) && !String.IsNullOrEmpty(txt_paterno.Text) && !String.IsNullOrEmpty(txt_materno.Text)
                        && !String.IsNullOrEmpty(txt_fechanacimiento.Text) && !String.IsNullOrEmpty(txt_telefono.Text) && !String.IsNullOrEmpty(txt_email.Text)
                        && !String.IsNullOrEmpty(txt_salario.Text) && !String.IsNullOrEmpty(selectcargo.Text))
                    {
                        Empleado cargos = new Empleado()
                        {
                            Nombre = txt_nombre.Text,
                            ApellidoPaterno = txt_paterno.Text,
                            ApellidoMaterno = txt_materno.Text,
                            Direccion = txt_direccion.Text,
                            FechaNacimiento = DateTime.Parse(txt_fechanacimiento.Text),
                            Telefono = txt_telefono.Text,
                            Email = txt_email.Text,
                            Salario = int.Parse(txt_salario.Text),
                            CargoId = int.Parse(selectcargo.SelectedValue.ToString()),
                        };
                        services.UpdateEmpleado(int.Parse(txt_PkEmpleado.Text), cargos);
                        GetemplecapaTable();
                        txt_nombre.Clear();
                        txt_direccion.Clear();
                        txt_paterno.Clear();
                        txt_salario.Clear();    
                        txt_materno.Clear();
                        txt_email.Clear();
                        txt_fechanacimiento.Clear();
                        txt_PkEmpleado.Clear();
                        txt_telefono.Clear();
                        selectcargo.SelectedIndex = -1;
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
