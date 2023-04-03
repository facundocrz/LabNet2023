using Lab.EF.Entities;
using Lab.EF.Logic;
using Lab.EF.WebApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Lab.EF.WebApi.Controllers
{
    public class CategoriesController : ApiController
    {
        private CategoriesLogic _categoriesLogic = new CategoriesLogic();

        // GET api/categories
        public IHttpActionResult Get()
        {
            try
            {
                List<Categories> categories = _categoriesLogic.GetAll();
                List<CategoriesViewModel> categoriesView = categories.Select(c => new CategoriesViewModel
                {
                    ID = c.CategoryID,
                    CategoryName = c.CategoryName,
                    Description = c.Description,
                }).ToList();
                return Ok(categoriesView);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }

        }

        // GET api/categories/5
        public IHttpActionResult Get(int id)
        {
            try
            {
                if(id == 0)
                {
                    return BadRequest("El id es requerido");
                }
                Categories category = _categoriesLogic.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                CategoriesViewModel model = new CategoriesViewModel();
                model.ID = category.CategoryID;
                model.CategoryName = category.CategoryName;
                model.Description = category.Description;
                return Ok(model);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // POST api/categories
        public IHttpActionResult Post([FromBody] CategoriesViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Los datos ingresados no son válidos");
                }
                Categories category = new Categories
                {
                    CategoryID = _categoriesLogic.GetLastId() + 1,
                    CategoryName = model.CategoryName,
                    Description = model.Description
                };
                _categoriesLogic.Add(category);
                return Ok(category);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        // PUT api/categories/5
        public IHttpActionResult Put(int id, [FromBody] CategoriesViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Los datos ingresados no son válidos");
                }
                _categoriesLogic.Update(new Categories { CategoryID = id, CategoryName = model.CategoryName, Description = model.Description });
                Categories category = _categoriesLogic.GetById(id);
                return Ok(category);
            }
            catch(NotFoundDBException)
            {
                return NotFound();
            }
            catch(Exception ex) 
            {
                return InternalServerError(ex);
            }
        }

        // DELETE api/categories/5
        public IHttpActionResult Delete(int id)
        {
            try
            {
                _categoriesLogic.Delete(id);
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