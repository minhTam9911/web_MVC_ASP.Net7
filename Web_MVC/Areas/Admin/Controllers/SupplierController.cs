using Microsoft.AspNetCore.Mvc;
using PlantNestBackEnd.Helpers;
using System;
using Web_MVC.Models;
using Web_MVC.Services;

namespace Web_MVC.Areas.Admin.Controllers;
[Area("admin")]
[Route("admin/supplier")]
public class SupplierController : Controller
{
    private SupplierService supplierService;
    public SupplierController(SupplierService supplierService)
    {
        this.supplierService = supplierService;
    }
    [Route("index")]
    [Route("")]
    public IActionResult Index()
    {
        ViewBag.suppliers = supplierService.findAll();
        return View("index");
    }

    [Route("add")]
    [HttpGet]
    public IActionResult IndexAdd()
    {
        var supplier = new Supplier();
        return View("add", supplier);
    }

    [Route("add")]
    [HttpPost]
    public IActionResult Add(Supplier supplier)
    {

        if (supplier.Name == null)
        {
            TempData["error-name"] = "The Name is required";
            TempData["msg"] = "error";
            return RedirectToAction("add");


        }
        else
        {
            if (supplierService.create(supplier))
            {
                TempData["msg"] = "success";
                return RedirectToAction("add");
            }
            else
            {
                TempData["msg"] = "error";
                return RedirectToAction("add");
            }
        }

    }
    [Route("delete/{id}")]
    [HttpGet]
    public IActionResult Delete(int id)
    {
        if (supplierService.delete(id))
        {
            TempData["msg"] = "success";
            return RedirectToAction("index");
        }
        else
        {
            TempData["msg"] = "error";
            return RedirectToAction("index");
        }
    }

    [Route("update/{id}")]
    [HttpGet]
    public IActionResult Update(int id)
    {
        var supplier = supplierService.findById(id);
        return View("update",supplier);
    }

    [Route("updateSave")]
    [HttpPost]
    public IActionResult updateSave(Supplier supplier)
    {


        if (supplier.Name == null)
        {
            TempData["error-name"] = "The Name is required";
            TempData["msg"] = "error";
            return RedirectToAction("update",new { id = supplier.Id });


        }

        if (supplierService.update(supplier))
        {
            TempData["msg"] = "success";
            return RedirectToAction("index");
        }
        else
        {
            TempData["msg"] = "error";
            return RedirectToAction("index");
        }
    }
}
