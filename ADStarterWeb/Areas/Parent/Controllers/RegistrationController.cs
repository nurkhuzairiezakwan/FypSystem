﻿using Microsoft.AspNetCore.Mvc;
using ADStarter.Models.ViewModels;
using ADStarter.DataAccess.Data;
using ADStarter.Models;
using System.Security.Claims;
using ADStarter.DataAccess.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using ADStarter.DataAccess.Repository.IRepository;
using ADStarter.Models;
using ADStarter.Models.ViewModels;
using ADStarter.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ADStarterWeb.Areas.Parent.Controllers
{
    [Area("Parent")]
    public class RegistrationController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public RegistrationController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //PARENT FORM
        public IActionResult ParentForm()
        {

            return View();
        }


        [HttpPost]
        public IActionResult ParentForm(ADStarter.Models.Parent obj)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            obj.UserId = userId; // Set the user ID
            _unitOfWork.Parent.Add(obj);
            _unitOfWork.Save();
            TempData["success"] = "Parent Detail created successfully";
            TempData["parent_ID"] = obj.parent_ID; // Use double quotes for TempData keys
            return RedirectToAction("ChildForm");
        }

        //CHILD FORM

        public IActionResult ChildForm()
        {
            // Retrieve parent_ID from TempData
            if (TempData["parent_ID"] != null)
            {
                ViewBag.ParentID = TempData["parent_ID"];
                TempData.Keep("parent_ID"); // Retain the parent_ID in TempData
            }

            return View();
        }

        [HttpPost]
        public IActionResult ChildForm(ADStarter.Models.Child obj)
        {
            if (TempData["parent_ID"] != null)
            {
                var parent_ID = (int)TempData["parent_ID"];
                obj.parent_ID = parent_ID; // Set the parent ID

                _unitOfWork.Child.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Child Detail created successfully";
                TempData["c_myKid"] = obj.c_myKid; // Use double quotes for TempData keys
                return RedirectToAction("TreatmentHistoryForm");
            }

            // Handle the case when parent_ID is not available
            TempData["error"] = "Parent ID not found. Please try again.";
            return RedirectToAction("Index");
        }

        //TREATMENT HISTORY
        public IActionResult TreatmentHistoryForm()
        {
            // Retrieve parent_ID from TempData
            if (TempData["c_myKid"] != null)
            {
                ViewBag.cmyKid = TempData["c_myKid"];
                TempData.Keep("c_myKid"); // Retain the parent_ID in TempData
            }

            return View();
        }

        [HttpPost]
        public IActionResult TreatmentHistoryForm(ADStarter.Models.TreatmentHistory obj)
        {
            if (TempData["c_myKid"] != null)
            {
                var c_myKid = (string)TempData["c_myKid"];
                obj.c_myKid = c_myKid; // Set the parent ID

                _unitOfWork.TreatmentHistory.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Treatment History Detail created successfully";
                TempData["c_myKid"] = obj.c_myKid; // Use double quotes for TempData keys
                return RedirectToAction("Index");
            }

            // Handle the case when parent_ID is not available
            TempData["error"] = "Child MyKid not found. Please try again.";
            return RedirectToAction("Index");
        }






        //GET
        public IActionResult Edit(int? parent_ID)
            {
                if (parent_ID == null || parent_ID == 0)
                {
                    return NotFound();
                }
                ADStarter.Models.Parent? ParentFromDb = _unitOfWork.Parent.Get(u => u.parent_ID == parent_ID);
                //Category? categoryFromDb1 = _db.Categories.FirstOrDefault(u=>u.Id==id);
                //Category? categoryFromDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();

                if (ParentFromDb == null)
                {
                    return NotFound();
                }
                return View(ParentFromDb);
        }
        //POST
        [HttpPost]
        public IActionResult Edit(ADStarter.Models.Parent obj)
        {
            if (ModelState.IsValid)
            {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                obj.UserId = userId; // Set the user ID
                _unitOfWork.Parent.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "ParentDetail updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }


        //GET
        public IActionResult Delete(int? parent_ID)
            {
                if (parent_ID == null || parent_ID == 0)
                {
                    return NotFound();
                }
            ADStarter.Models.Parent? parentFromDb = _unitOfWork.Parent.Get(u => u.parent_ID == parent_ID);

            if (parentFromDb == null)
                {
                    return NotFound();
                }
                return View(parentFromDb);
            }

        //POST
            [HttpPost, ActionName("Delete")]
            public IActionResult DeletePOST(int? parent_ID)
            {
                ADStarter.Models.Parent? obj = _unitOfWork.Parent.Get(u => u.parent_ID == parent_ID);
                if (obj == null)
                {
                    return NotFound();
                }
                _unitOfWork.Parent.Remove(obj);
                _unitOfWork.Save();
                TempData["success"] = "ParentDetail deleted successfully";
                return RedirectToAction("Index");
            }
        }
    }
