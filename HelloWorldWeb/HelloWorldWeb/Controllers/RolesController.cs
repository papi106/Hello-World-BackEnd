using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorldWeb.Controllers
{
    public class RolesController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: RolesController
        public ActionResult Index()
        {
            return this.View(this.roleManager.Roles);
        }

        // GET: RolesController/Create
        public ActionResult Create()
        {
            return this.View(new IdentityRole());
        }

        // POST: RolesController/Create
        [HttpPost]
        public async Task<ActionResult> Create(IdentityRole role)
        {
            try
            {
                await this.roleManager.CreateAsync(role);
                return this.RedirectToAction(nameof(this.Index));
            }
            catch
            {
                return this.View();
            }
        }
    }
}
