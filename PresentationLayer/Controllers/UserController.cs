﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PresentationLayer.Models;

namespace PresentationLayer.Controllers
{
    
    public class UserController : Controller
    {
        UserManager<UserViewModel> _userManager;

        public UserController(UserManager<UserViewModel> userManager)
        {
            _userManager = userManager;
        }
        [Authorize(Roles = "admin,moderator")]
        public IActionResult Index() => View(_userManager.Users.ToList());
        [Authorize(Roles = "admin,moderator")]
        public IActionResult Create() => View();
        [Authorize(Roles = "admin,moderator")]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = new UserViewModel { Email = model.Email, UserName = model.Email, Img = model.Img };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        [Authorize]
        public async Task<IActionResult> Edit(string id)
        {
            UserViewModel user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, Img = user.Img };
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserViewModel user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    user.Img = model.Img;

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            UserViewModel user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                IdentityResult result = await _userManager.DeleteAsync(user);
            }
            return RedirectToAction("Index");
        }
    }
}