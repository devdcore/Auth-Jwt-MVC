using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Auth_Jwt_MVC.Controllers
{
    public class Security_Controller : Controller
    {
        private string GenerateJSONWebToken(string username)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("LlavedeSeguridad"));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim("Issuer", "Shiv"),
                new Claim("Admin", "true"),
                new Claim(JwtRegisteredClaimNames.UniqueName, username)
            };

            var token = new JwtSecurityToken("Shiv",
                "Shiv",
                claims,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        // GET: SecurityController
        public ActionResult Index()
        {
            return View();
        }

        // GET: SecurityController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SecurityController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecurityController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SecurityController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SecurityController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SecurityController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SecurityController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
