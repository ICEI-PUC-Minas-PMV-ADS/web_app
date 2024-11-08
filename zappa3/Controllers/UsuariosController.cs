﻿using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using zappa3.Models;

namespace zappa3.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly AppDbContext _context;
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var dados = await _context.Usuarios.ToListAsync();
            return View(dados);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Usuario usuario)
        {

            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                return NotFound();

            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Usuario usuario) 
        {
            if (id != usuario.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(usuario);

        }

        public async Task<IActionResult> Details(int id) 
        {
            if (id == null)
                return NotFound();
            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
                return NotFound();
            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            return View(dados);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (id == null)
                return NotFound();
            var dados = await _context.Usuarios.FindAsync(id);

            if (dados == null)
                return NotFound();

            _context.Usuarios.Remove(dados);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

    }

}

