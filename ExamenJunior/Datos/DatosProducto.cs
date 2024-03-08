using ExamenJunior.Models;
using System.Data.SqlClient;
using System.Data;

namespace ExamenJunior.Datos
{
	public class DatosProducto
	{

		public List<Product> Listar()
		{
			var oLista = new List<Product>();

			var cn = new Conexion();

			using(var conexion = new SqlConnection(cn.getCadenaSQL()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("SP_ListaProductos", conexion);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{
						oLista.Add(new Product
						{
							ProductId = dr["ProductId"].ToString(),
							refProductCategory = new ProductCategory
							{
								CategoryDescription = dr["CategoryDescription"].ToString()
							},
							ProductDescription = dr["ProductDescription"].ToString(),
							Stock = Convert.ToInt32(dr["Stock"]),
							Price = (decimal)(dr["Price"]),
							HaveECDiscount = (bool)dr["HaveECDiscount"],
							IsActive = (bool)dr["IsActive"]
						});
					}
				}
			}
			return oLista;
		}

		public Product Obtener(string ProductId)
		{
			var oProducto = new Product();

			var cn = new Conexion();

			using (var conexion = new SqlConnection(cn.getCadenaSQL()))
			{
				conexion.Open();
				SqlCommand cmd = new SqlCommand("SP_Obtener", conexion);
				cmd.Parameters.AddWithValue("ProductId", ProductId);
				cmd.CommandType = CommandType.StoredProcedure;

				using (var dr = cmd.ExecuteReader())
				{
					while (dr.Read())
					{

						oProducto.ProductId = dr["ProductId"].ToString();
						oProducto.refProductCategory = new ProductCategory
						{
							CategoryProductId = Convert.ToInt32(dr["CategoryProductId"])
						};
						oProducto.ProductDescription = dr["ProductDescription"].ToString();
						oProducto.Stock = Convert.ToInt32(dr["Stock"]);
						oProducto.Price = (decimal)(dr["Price"]);
						oProducto.HaveECDiscount = (bool)dr["HaveECDiscount"];
						oProducto.IsActive = (bool)dr["IsActive"];

					}
				}
			}
			return oProducto;
		}

		public bool Guardar(Product oProducto)
		{
			bool respuesta;

			try
			{

				var cn = new Conexion();

				using (var conexion = new SqlConnection(cn.getCadenaSQL()))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("SP_GuardarProducto", conexion);
					cmd.Parameters.AddWithValue("ProductId", oProducto.ProductId);
					cmd.Parameters.AddWithValue("CategoryProductId", oProducto.refProductCategory.CategoryProductId);
					cmd.Parameters.AddWithValue("ProductDescription", oProducto.ProductDescription);
					cmd.Parameters.AddWithValue("Stock", oProducto.Stock);
					cmd.Parameters.AddWithValue("Price", oProducto.Price);
					cmd.Parameters.AddWithValue("HaveECDiscount", oProducto.HaveECDiscount);
					cmd.Parameters.AddWithValue("IsActive", oProducto.IsActive);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
				}
				respuesta = true;
			}
			catch (Exception e)
			{
				string error = e.Message;
				respuesta=false;
			}

			return respuesta;
		}

		public bool Editar(Product oProducto)
		{
			bool respuesta;

			try
			{

				var cn = new Conexion();

				using (var conexion = new SqlConnection(cn.getCadenaSQL()))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("SP_EditarProducto", conexion);
					cmd.Parameters.AddWithValue("ProductId", oProducto.ProductId);
					cmd.Parameters.AddWithValue("CategoryDescription", oProducto.refProductCategory.CategoryDescription);
					cmd.Parameters.AddWithValue("ProductDescription", oProducto.ProductDescription);
					cmd.Parameters.AddWithValue("Stock", oProducto.Stock);
					cmd.Parameters.AddWithValue("Price", oProducto.Price);
					cmd.Parameters.AddWithValue("HaveECDiscount", oProducto.HaveECDiscount);
					cmd.Parameters.AddWithValue("IsActive", oProducto.IsActive);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
				}
				respuesta = true;
			}
			catch (Exception e)
			{
				string error = e.Message;
				respuesta = false;
			}

			return respuesta;
		}

		public bool Eliminar(string ProductId)
		{
			bool respuesta;

			try
			{
				var oProducto = new Product();

				var cn = new Conexion();

				using (var conexion = new SqlConnection(cn.getCadenaSQL()))
				{
					conexion.Open();
					SqlCommand cmd = new SqlCommand("SP_EliminarProducto", conexion);
					cmd.Parameters.AddWithValue("ProductId", ProductId);
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.ExecuteNonQuery();
				}
				respuesta = true;
			}
			catch (Exception e)
			{
				string error = e.Message;
				respuesta = false;
			}

			return respuesta;
		}

        public Product ObtenerParaEditar(string ProductId)
        {
            var oProducto = new Product();

            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("SP_ObtenerParaEditar", conexion);
                cmd.Parameters.AddWithValue("ProductId", ProductId);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {

                        oProducto.ProductId = dr["ProductId"].ToString();
						oProducto.refProductCategory = new ProductCategory
						{
							CategoryDescription = dr["CategoryDescription"].ToString()
                        };
                        oProducto.ProductDescription = dr["ProductDescription"].ToString();
                        oProducto.Stock = Convert.ToInt32(dr["Stock"]);
                        oProducto.Price = (decimal)(dr["Price"]);
                        oProducto.HaveECDiscount = (bool)dr["HaveECDiscount"];
                        oProducto.IsActive = (bool)dr["IsActive"];

                    }
                }
            }
            return oProducto;
        }
    }
}
