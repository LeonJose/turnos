using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Data;
using System.Data.SqlClient;

namespace WpfApplication1
{
    class Espera : Conexion
    {
      
        #region Atributos
      private int _id;
      private string _nombre;
      private string _numero;
      private DateTime _fecha;
      private DateTime _horaLlegada;
      private DateTime _horaAtencion;
      private string _matricula;
      #endregion

        #region propiedades

      public int ID
      {
          get { return _id; }
          set { _id = value; }
      }
      public string Nombre
      {
          get { return _nombre; }
          set { _nombre = value; }
      }
      public string Numero
      {
          get { return _numero; }
          set { _numero = value; }
      }
      public DateTime Fecha
      {
          get { return _fecha; }
          set { _fecha = value; }
      }
      public DateTime HoraLlegada
      {
          get { return _horaLlegada; }
          set { _horaLlegada = value; }
      }
      public DateTime HoraAtencion
      {
          get { return _horaAtencion; }
          set { _horaAtencion = value; }
      }
      public string Matricula
      {
          get { return _matricula; }
          set { _matricula = value; }
      }
        #endregion

        #region constructor
      public Espera()
      {
          _id = 0;
          _nombre = " ";
          _numero = " ";
          _fecha = new DateTime();
          _horaLlegada = new DateTime();
          _horaAtencion = new DateTime();
          _matricula = "";
      }
        #endregion 

    }
}
