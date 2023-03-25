using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab.EF.MVC.Controllers
{
    public class CategoriesController : Controller
    {
        private CategoriesLogic _categoriesLogic = new CategoriesLogic();
        // GET: Categories
        public ActionResult Index()
        {
            List<Categories> categories = _categoriesLogic.GetAll();

            List<CategoriesViewModel> categoriesView = categories.Select(c => new CategoriesViewModel
            {
                ID = c.CategoryID, 
                CategoryName = c.CategoryName,
                Description = c.Description,
            }).ToList();
            return View(categoriesView);
        }

        public ActionResult Insert(int? id)
        {
            CategoriesViewModel model = new CategoriesViewModel();
            if (id == null)
            {
                return View(model);
            }
            Categories category = _categoriesLogic.GetById((int)id);
            model.ID = category.CategoryID;
            model.CategoryName = category.CategoryName;
            model.Description = category.Description;
            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(CategoriesViewModel model)
        {
            if(ModelState.IsValid)
            {
                try
                { 
                    if (model.ID == 0)
                    {
                        _categoriesLogic.Add(new Categories
                        {
                            CategoryID = _categoriesLogic.GetLastId() + 1,
                            CategoryName = model.CategoryName,
                            Description = model.Description
                        });

                        return RedirectToAction("Index");
                    }
                    _categoriesLogic.Update(new Categories { CategoryID = model.ID, CategoryName = model.CategoryName, Description = model.Description });
                    return RedirectToAction("index");
                }
                catch (DbEntityValidationException)
                {
                    return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "Todos los campos obligatorios deben ser completados" });
                }
                catch (NotFoundDBException)
                {
                    return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "No se encontró lo que intentabas editar" });
                }
            } else
            {
                return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "Los datos ingresados no son válidos" });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _categoriesLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "No se pudo eliminar debido a que está siendo utilizada por otra tabla" });
            }
            catch(NotFoundDBException)
            {
                return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "No se encontró lo que intentabas eliminar" });
            }
        }
    }
}