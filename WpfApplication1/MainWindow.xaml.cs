﻿using System;
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
using System.Globalization;

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        public bool matricula = true;
        public CultureInfo lenguaje = new CultureInfo("es-ES");

        public MainWindow()
        {
            InitializeComponent();
            headerlogo();
            txtNombre.Focus();
        }
        private void headerlogo()
        {
            Image _image = new Image();
            BitmapImage _bi = new BitmapImage();
            _bi.BeginInit();
            _bi.UriSource = new System.Uri("pack://application:,,,/Recursos/imagenes/1.png");
            _bi.EndInit();
            _image.Source = _bi;
            ImageBrush _ib = new ImageBrush();
            _ib.ImageSource = _bi;
            rt_imagen.Fill = _ib;
        }

        //boton cancelar
        private void btnCancelar_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnRegistro_Click_2(object sender, RoutedEventArgs e)
        {
            Espera es = new Espera();
            if (matricula)
            {
                Alumno a = new Alumno(txtNombre.Text);
                if (a.Nombre != "")
                {
                    string s = Listados.ObtenerNumero().ToString();
                    string num = (lenguaje.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)).Substring(0, 2).ToUpper() + "" + s.PadLeft(4, '0').ToString();
                    es.Nombre = a.Nombre + " " + a.Apaterno + " " + a.Amaterno;
                    es.Numero = num;
                    es.Fecha = DateTime.Now;
                    es.HoraLlegada = DateTime.Now;
                    es.HoraAtencion = DateTime.Now;
                    es.Matricula = a.Matricula;
                    if (es.AgregarEspera())
                    {
                        es.GenerarTicket();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar la espera. Intentalo nuevamente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {
                    MessageBox.Show("No es una matricula valida");
                }
            }
            else
            {
                if (txtNombre.Text != "")
                {
                    string s = Listados.ObtenerNumero().ToString();
                    string num = (lenguaje.DateTimeFormat.GetDayName(DateTime.Now.DayOfWeek)).Substring(0, 2).ToUpper() + "" + s.PadLeft(4, '0').ToString();
                    es.Nombre = txtNombre.Text;
                    es.Numero = num;
                    es.Fecha = DateTime.Now;
                    es.HoraLlegada = DateTime.Now;
                    es.HoraAtencion = DateTime.Now;
                    if (es.AgregarEspera())
                    {
                        es.GenerarTicket();
                    }
                    else
                    {
                        MessageBox.Show("No se pudo registrar la espera. Intentalo nuevamente", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
        }
    }
}







/* if(e.Agregar)
 {

 }*/