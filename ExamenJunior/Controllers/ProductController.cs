using Microsoft.AspNetCore.Mvc;
using ExamenJunior.Datos;
using ExamenJunior.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ExamenJunior.Controllers
{
	public class ProductController : Controller
	{

		DatosProducto _ProductDatos = new DatosProducto();

		public IActionResult Listar()
		{
			//Muestra lista de productos
			var oLista = _ProductDatos.Listar();

			return View(oLista);
		}

		public IActionResult Guardar()
		{
			//Devuelve solo la vista
			return View();
		}

		[HttpPost]
		public IActionResult Guardar(Product product)
		{
			//Recibe un objeto y lo guarda en la BDD

			var respuesta = _ProductDatos.Guardar(product);

			if(respuesta)
				return RedirectToAction("Listar");
			else
				return View();

		}

        public IActionResult Editar(string ProductId)
        {
            //Devuelve solo la vista
			var oProducto = _ProductDatos.ObtenerParaEditar(ProductId);

            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Editar(Product oProduct)
        {
            var respuesta = _ProductDatos.Editar(oProduct);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(string ProductId)
        {
            
            var oProducto = _ProductDatos.Obtener(ProductId);
            return View(oProducto);
        }

        [HttpPost]
        public IActionResult Eliminar(Product oProduct)
        {
            var respuesta = _ProductDatos.Eliminar(oProduct.ProductId);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }
    }
}
