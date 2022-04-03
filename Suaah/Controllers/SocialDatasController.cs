﻿#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Suaah.Data;
using Suaah.Models;

namespace Suaah.Controllers
{
    public class SocialDatasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SocialDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SocialDatas
        public async Task<IActionResult> Index()
        {
            return View(await _context.SocialData.ToListAsync());
        }

        // GET: SocialDatas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialData = await _context.SocialData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialData == null)
            {
                return NotFound();
            }

            return View(socialData);
        }

        // GET: SocialDatas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SocialDatas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SocialName,Link")] SocialData socialData)
        {
            if (ModelState.IsValid)
            {
                _context.Add(socialData);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(socialData);
        }

        // GET: SocialDatas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialData = await _context.SocialData.FindAsync(id);
            if (socialData == null)
            {
                return NotFound();
            }
            return View(socialData);
        }

        // POST: SocialDatas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SocialName,Link")] SocialData socialData)
        {
            if (id != socialData.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(socialData);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SocialDataExists(socialData.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(socialData);
        }

        // GET: SocialDatas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var socialData = await _context.SocialData
                .FirstOrDefaultAsync(m => m.Id == id);
            if (socialData == null)
            {
                return NotFound();
            }

            return View(socialData);
        }

        // POST: SocialDatas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var socialData = await _context.SocialData.FindAsync(id);
            _context.SocialData.Remove(socialData);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SocialDataExists(int id)
        {
            return _context.SocialData.Any(e => e.Id == id);
        }
    }
}
