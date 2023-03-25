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
    public class ShippersController : Controller
    {
        private ShippersLogic _shippersLogic = new ShippersLogic();
        // GET: Categories
        public ActionResult Index()
        {
            List<Shippers> shippers = _shippersLogic.GetAll();

            List<ShippersViewModel> model = shippers.Select(s => new ShippersViewModel
            {
                ID = s.ShipperID,
                CompanyName = s.CompanyName,
                Phone = s.Phone,
            }).ToList();
            return View(model);
        }

        public ActionResult Insert(int? id)
        {
            ShippersViewModel model = new ShippersViewModel();
            if (id == null)
            {
                return View(model);
            }
            Shippers shipper = _shippersLogic.GetById((int)id);
            model.ID = shipper.ShipperID;
            model.CompanyName = shipper.CompanyName;
            model.Phone = shipper.Phone;
            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(ShippersViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ID == 0)
                    {
                        _shippersLogic.Add(new Shippers
                        {
                            ShipperID = _shippersLogic.GetLastId() + 1,
                            CompanyName = model.CompanyName,
                            Phone = model.Phone
                        });

                        return RedirectToAction("Index");
                    }
                    _shippersLogic.Update(new Shippers { ShipperID = model.ID, CompanyName = model.CompanyName, Phone = model.Phone });
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
            }
            else
            {
                return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "Los datos ingresados no son válidos" });
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                _shippersLogic.Delete(id);
                return RedirectToAction("Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "No se pudo eliminar debido a que está siendo utilizada por otra tabla" });
            }
            catch (NotFoundDBException)
            {
                return RedirectToAction("Index", "Error", new ErrorViewModel { Message = "No se encontró lo que intentabas eliminar" });
            }
        }
    }
}