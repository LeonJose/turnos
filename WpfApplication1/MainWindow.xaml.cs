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

namespace WpfApplication1
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool matricula = true;
        public MainWindow()
        {
            InitializeComponent();
            headerlogo();
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
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Espera es = new Espera();
            if (matricula){
                Alumno a = new Alumno(txtNombre.Text);
                if(a.Nombre!="")
                {
                    es.Nombre = a.Nombre + " " + a.Apaterno + " " + a.Amaterno;
                    //es.Numero = a.
                    es.HoraLlegada = DateTime.Now;
                    es.HoraAtencion = DateTime.Now;

                    //hora.toString("yyyy-MM-dd"); ("hh:mm:ss")
                
                   /* if(e.Agregar)
                    {

                    }*/
                }
                else
                {
                    MessageBox.Show("No se pudo registrar");
                }
            }
            else
            {
                    es.Nombre = txtNombre.Text;
                    //es.Numero = 
                    es.HoraLlegada = DateTime.Now;
                    es.HoraAtencion = DateTime.Now;
            }

        }

        private void cli(object sender, MouseEventArgs e)
        {
            lbltitulo.Content = "Ingrese su nombre";
            matricula = false;
        }
    }
}
