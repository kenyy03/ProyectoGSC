using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Data.OracleClient;
using System.Configuration;
using System.Windows.Forms;

namespace DatosBU
{
    class ConexionOracle
    {
      
        public void conectar() 
        {
            OracleConnection conexion = new OracleConnection("Data Source = ProyectoVeterinaria;  PASSWORD=1234567; USER ID = caceres7w; ");
            conexion.Open();
            MessageBox.

      
        }
    }
}
 