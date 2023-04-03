using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Lab.EF.WebApi.Controllers
{
    public class ShippersController : ApiController
    {
        private ShippersLogic _shippersLogic = new ShippersLogic();

        // GET api/shippers
        public IHttpActionResult Get()
        {
            try
            {
                List<Shippers> shippers = _shippersLogic.GetAll();
                List<ShippersViewModel> shippersView = shippers.Select(s => new ShippersViewModel
                {
                    ID = s.ShipperID,
                    CompanyName = s.CompanyName,
                    Phone = s.Phone,
                }).ToList();
                return Ok(shippersView);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET api/shippers/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest("El id es requerido");
                }
                Shippers shipper = _shippersLogic.GetById(id);
                if (shipper == null)
                {
                    return NotFound();
                }
                ShippersViewModel model = new ShippersViewModel();
                model.ID = shipper.ShipperID;
                model.CompanyName = shipper.CompanyName;
                model.Phone = shipper.Phone;
                return Ok(model);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/shippers
        public IHttpActionResult Post([FromBody] ShippersViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Los datos ingresados no son válidos");
                }
                Shippers shipper = new Shippers
                {
                    ShipperID = _shippersLogic.GetLastId() + 1,
                    CompanyName = model.CompanyName,
                    Phone = model.Phone
                };
                _shippersLogic.Add(shipper);
                return Ok(shipper);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/shippers/5
        public IHttpActionResult Put(int id, [FromBody] ShippersViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Los datos ingresados no son válidos");
                }
                _shippersLogic.Update(new Shippers { ShipperID = id, CompanyName = model.CompanyName, Phone = model.Phone });
                Shippers shipper = _shippersLogic.GetById(id);
                return Ok(shipper);
            }
            catch (NotFoundDBException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/shippers/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _shippersLogic.Delete(id);
                return Ok();
            }
            catch (NotFoundDBException)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }
    }
}