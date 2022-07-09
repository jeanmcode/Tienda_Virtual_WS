using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Tienda_Virtual.Models;
 

namespace Tienda_Virtual
{
    /// <summary>
    /// Descripción breve de TiendaVirtualWS
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class TiendaVirtualWS : System.Web.Services.WebService
    {

        
        //Instanciamos el contexto donde tenemos los datos
        ApplicationDbContext db = new ApplicationDbContext();


        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }

        [WebMethod]
        public bool Logueo(string UserName, string Password )
        {

            return Validar(UserName,Password);

        }

        private bool Validar(string UserName, string Password)
        {


            var result = HttpContext.Current.GetOwinContext().Get<ApplicationSignInManager>().PasswordSignIn(UserName, Password, false, false);

            if(result == SignInStatus.Success)
            {

                return true;

            }

            else
            {

                return false;
            }



        }



        [WebMethod]
        public List<ProductoSW> GetProductosByCategoria(int id)
        {

            //se regresa una lista de productos que esten asociados al id de una Categoria
            return db.Productos.Where(x => x.CategoriaId == id).Select(


                x => new ProductoSW()

                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio,
                    Imagen = x.Imagen

                }).ToList();// se hace una definicion explicita, asignandole los valores de la producto
                            //que esta en Modelo a la clase ProductosWS que esta en el servicio web

        }


        [WebMethod]
        public bool SetProducto(string codigo, string descripcion, double precio, byte[] imagen, int CategoriaId )
        {

            Producto producto = new Producto();

            producto.Codigo = codigo;
            producto.Descripcion = descripcion;
            producto.Precio = precio;
            producto.CategoriaId = CategoriaId;
            producto.Imagen = imagen;

            db.Productos.Add(producto);

            if (db.SaveChanges() > 0)
            {
                return true;

            }


            else { return false; }

        }


        [WebMethod]
        public List<ProductoSW> GetProductos(int id)
        {

            //se regresa una lista de productos que esten asociados al id de una Categoria
            return db.Productos.Where(x => x.Id == id + 1).Select(


                x => new ProductoSW()

                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,
                    Precio = x.Precio,
                    Imagen = x.Imagen

                }).ToList();// se hace una definicion explicita, asignandole los valores de la producto
                            //que esta en Modelo a la clase ProductosWS que esta en el servicio web

        }



        [WebMethod]
        public List<CategoriaSW> GetCategoria()
        {

            //se regresa una lista de categorias que esten asociados al id de una Categoria
            return db.Categorias.Where(x => x.Id != -1).Select(


                x => new CategoriaSW()

                {
                    Id = x.Id,
                    Codigo = x.Codigo,
                    Descripcion = x.Descripcion,

                }).ToList();// se hace una definicion explicita, asignandole los valores de la producto
                            //que esta en Modelo a la clase ProductosWS que esta en el servicio web

        }





        //Definimos la clase porque el servicio no puede interpretar
        //las clases que estan en el modelo

        public class ProductoSW
        {

            public int Id { get; set; }

            public string Codigo { get; set; }

            public string Descripcion { get; set; }

            public double Precio { get; set; }

            public byte[] Imagen { get; set; }


            public int CategoriaId { get; set; }
        }





        public class CategoriaSW
        {

            public int Id { get; set; }


            public string Codigo { get; set; }


            public string Descripcion { get; set; }

        }


    }
    }


