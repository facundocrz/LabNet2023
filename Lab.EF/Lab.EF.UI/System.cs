using Lab.EF.Entities;
using Lab.EF.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab.EF.UI
{
    public class System
    {
        public void Menu()
        {
            Console.WriteLine("Bienvenido al sistema");
            bool salir = false;
            while (!salir)
            {
                Console.Clear();
                Console.WriteLine("Opción 1: Listar categorias");
                Console.WriteLine("Opción 2: Listar shippers");
                Console.WriteLine("Opción 3: Agregar una categoría");
                Console.WriteLine("Opción 4: Modificar descripción de una categoría");
                Console.WriteLine("Opción 5: Eliminar una categoría");
                Console.WriteLine("Opción 6: Salir");
                int opcion = this.LeerNumero();
                switch (opcion)
                {
                    case 1:
                        this.ListarCategorias();
                        break;
                    case 2:
                        this.ListarShippers();
                        break;
                    case 3:
                        this.AgregarCategoria();
                        break;
                    case 4:
                        this.ModificarDescripcionCategoria();
                        break;
                    case 5:
                        this.EliminarCategoria();
                        break;
                    case 6:
                        salir = true;
                        break;
                    default:
                        Console.WriteLine("Elegí una opción entre 1 y 6");
                        break;
                }
            }
        }

        private void MostrarCategorias()
        {
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            foreach (var category in categoriesLogic.GetAll())
            {
                Console.WriteLine($"{category.CategoryID}: {category.CategoryName}, descripción: {category.Description}");
            }
        }
        private void ListarCategorias()
        {
            Console.Clear();
            try
            {
                this.MostrarCategorias();
            } 
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla volver al menu");
                Console.ReadKey();
            }
            
        }

        private void ListarShippers()
        {
            Console.Clear();
            ShippersLogic shippersLogic = new ShippersLogic();
            foreach(var shipper in shippersLogic.GetAll())
            {
                Console.WriteLine($"{shipper.ShipperID}: {shipper.CompanyName}, phone: {shipper.Phone}");
            }
            Console.WriteLine("Presione una tecla volver al menu");
            Console.ReadKey();
        }

        private void AgregarCategoria()
        {
            Console.Clear();
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            Console.Write("Ingresá el nombre de la categoria: ");
            string nombreCat  = Console.ReadLine();
            Console.Write("Ingresá la descripción: ");
            string descCat = Console.ReadLine();
            try
            {
                categoriesLogic.Add(new Categories
                {
                    CategoryID = categoriesLogic.GetLastId() + 1,
                    CategoryName = nombreCat,
                    Description = descCat
                });
                Console.WriteLine("Se agregó la categoria correctamente");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla volver al menu");
                Console.ReadKey();
            }
        }

        private void ModificarDescripcionCategoria()
        {
            Console.Clear();
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            Console.WriteLine("Elegí la categoría a modificar");
            this.MostrarCategorias();
            int id = this.LeerNumero();
            Console.Write("Ingresá la nueva descripción: ");
            string newDesc = Console.ReadLine();
            try
            {
                categoriesLogic.Update(new Categories
                {
                    CategoryID = id,
                    Description = newDesc
                });
                Console.WriteLine("Se actualizó correctamente");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Presione una tecla volver al menu");
                Console.ReadKey();
            }
            
        }

        private void EliminarCategoria()
        {
            Console.Clear();
            CategoriesLogic categoriesLogic = new CategoriesLogic();
            Console.WriteLine("Elegí la categoría a eliminar");
            this.MostrarCategorias();
            int id = this.LeerNumero();
            try
            {
                categoriesLogic.Delete(id);
                Console.WriteLine("Se eliminó correctamente");
            }
            catch (NotFoundDBException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("No se puede borrar debido a que es clave foranea en otra tabla");
            }
            finally
            {
                Console.WriteLine("Presione una tecla volver al menu");
                Console.ReadKey();
            }
        }

        

        private int LeerNumero()
        {
            int num;
            while (true)
            {
                try
                {
                    Console.Write("Ingrese un número que corresponda: ");
                    num = int.Parse(Console.ReadLine());
                    return num;
                }
                catch (Exception)
                {
                    Console.WriteLine("Seguro ingresó una letra o no ingreso nada!");
                }
            }
        }
    }
}
