﻿using System;
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
      private string impresora = "Microsoft XPS Document Writer";
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
        #region Metodos

      public bool AgregarEspera()
      {
          string instruccion = @"insert into Espera(esp_nombre, esp_numero, esp_fecha, esp_horaLlegada, esp_horaAtencion, esp_matricula) values 
  (@nombre, @num, @fec, @hLlegada, @hAtendido,@mat)";
          SqlCommand comandoSql = new SqlCommand(instruccion);
          comandoSql.Parameters.Add(new SqlParameter("@nombre", _nombre));
          comandoSql.Parameters.Add(new SqlParameter("@num", _numero));
          comandoSql.Parameters.Add(new SqlParameter("@fec", _fecha));
          comandoSql.Parameters.Add(new SqlParameter("@hLlegada", _horaLlegada));
          comandoSql.Parameters.Add(new SqlParameter("@hAtendido", _horaAtencion));
          comandoSql.Parameters.Add(new SqlParameter("@mat", _matricula));
          return EjecutarComando(comandoSql);
      }


      public void GenerarTicket()
      {
          try
          {
              //StreamReader stream = new StreamReader(@"./codigo.png");

              //PictureBox pb2 = new PictureBox();
              Ticket ticket = new Ticket();
              //pb2.Image = Image.FromStream(stream.BaseStream);
              ticket.AddTitulo("UTT");
              ticket.AddDatos("=================", "==================");
              ticket.AddDatos("Nombre:", Nombre);
              if (Matricula != "")
              {
                  ticket.AddDatos("Matricula:", Matricula);
              }
              ticket.AddDatos("Numero:", Numero);
              ticket.AddDatos("Fecha:", Fecha.ToString("MM-dd-yyyy"));
              ticket.AddDatos("Hora:", HoraLlegada.ToString("HH:mm:ss"));
              ticket.AddDatos("=================", "==================");
              //ticket.FooterImage = pb2.Image;
              ticket.PrintTicket(impresora);

              //ticket.PrintTicket();
              //stream.Close();

          }
          catch (Exception e)
          {
          }
      }

        #endregion

    }
}
