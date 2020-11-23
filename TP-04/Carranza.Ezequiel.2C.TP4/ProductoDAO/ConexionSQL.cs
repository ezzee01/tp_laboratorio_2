using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;

namespace ProductoDAO
{
    public class ConexionSQL
    {
        private SqlConnection conexion;
        private string connectionString;

        public ConexionSQL()
        {
            this.connectionString = @"Server=EZE-PC\SQLEXPRESS;Database=ProductosElectronicosDB;Trusted_Connection=True;";
            this.conexion = new SqlConnection(connectionString);
        }

        public void AgregarProducto(Producto producto)
        {
            try
            {
                string command = "INSERT INTO Productos(NombreDeProducto, Descripcion, Codigo, Precio) " + $"VALUES (@NombreDeProducto, @Descripcion, @Codigo, @Precio)";
                SqlCommand sqlCommand = new SqlCommand(command, this.conexion);

                sqlCommand.Parameters.AddWithValue("NombreDeProducto", producto.NombreProducto);
                sqlCommand.Parameters.AddWithValue("Descripcion", producto.Descripcion);
                sqlCommand.Parameters.AddWithValue("Codigo", producto.Codigo);
                sqlCommand.Parameters.AddWithValue("Precio", producto.Precio);

                this.conexion.Open();

                sqlCommand.ExecuteNonQuery();
            }
            finally
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                {
                    this.conexion.Close();
                }
            }
        }

        public List<Producto> ListarProductos()
        {
            using (SqlConnection sqlConnection = new SqlConnection(this.connectionString))
            {
                string command = "SELECT * FROM Productos";

                SqlCommand sqlCommand = new SqlCommand(command, sqlConnection);
                sqlConnection.Open();

                SqlDataReader reader = sqlCommand.ExecuteReader();

                List<Producto> productos = new List<Producto>();

                while (reader.Read())
                {
                    int id = (int)reader["id"];
                    string nombreDeProducto = (string)reader["NombreDeProducto"];
                    string codigo = (string)reader["Codigo"];

                    string descripcion = null;

                    if (reader["Descripcion"] != DBNull.Value)
                    {
                        descripcion = (string)reader["Descripcion"];
                    }

                    int precio = (int)reader["Precio"];

                    Producto producto = new Producto(nombreDeProducto, descripcion, codigo, precio);
                    productos.Add(producto);
                }

                return productos;
            }
        }
    }
}
