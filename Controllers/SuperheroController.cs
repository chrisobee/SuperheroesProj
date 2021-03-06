﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Superheroes.Data;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext _context;

        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET: Superhero
        public IActionResult Index()
        {
            var superheroes = _context.Superheroes.ToList();

            return View(superheroes);
        }

        // GET: Superhero/Details/5
        public IActionResult Details(int id)
        {
            var superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();

            return View(superhero);
        }

        // GET: Superhero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Superhero superhero)
        {
            try
            {
                _context.Superheroes.Add(superhero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Edit/5
        public IActionResult Edit(int id)
        {
            return View();
        }

        // POST: Superhero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Superhero superhero)
        {
            try
            {
                var superheroToEdit = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
                superheroToEdit.Name = superhero.Name;
                superheroToEdit.AlterEgo = superhero.AlterEgo;
                superheroToEdit.PrimaryAbility = superhero.PrimaryAbility;
                superheroToEdit.SecondaryAbility = superhero.SecondaryAbility;
                superheroToEdit.Catchphrase = superhero.Catchphrase;
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Superhero/Delete/5
        public IActionResult Delete(int id)
        {
            var superhero = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();

            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, Superhero superhero)
        {
            try
            {
                var superheroToDelete = _context.Superheroes.Where(s => s.Id == id).SingleOrDefault();
                _context.Remove(superheroToDelete);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}