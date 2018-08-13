using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NaboPlannerAngular.Models.DB;

namespace NaboPlannerAngular.Controllers
{
    public class SongsController : Controller
    {
        private readonly nabo_planer_dbContext _context;

        public SongsController(nabo_planer_dbContext context)
        {
            _context = context;
        }

        // GET: Songs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Song.ToListAsync());
        }

        // GET: Songs/Details/5
        public async Task<IActionResult> Details(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .SingleOrDefaultAsync(m => m.PkSongId == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // GET: Songs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Songs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PkSongId,SongName,SongAuthor,Tags,VerseNumber,Chorus,Origin")] Song song)
        {
            if (ModelState.IsValid)
            {
                _context.Add(song);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(song);
        }

        // GET: Songs/Edit/5
        public async Task<IActionResult> Edit(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song.SingleOrDefaultAsync(m => m.PkSongId == id);
            if (song == null)
            {
                return NotFound();
            }
            return View(song);
        }

        // POST: Songs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(short id, [Bind("PkSongId,SongName,SongAuthor,Tags,VerseNumber,Chorus,Origin")] Song song)
        {
            if (id != song.PkSongId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(song);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SongExists(song.PkSongId))
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
            return View(song);
        }

        // GET: Songs/Delete/5
        public async Task<IActionResult> Delete(short? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = await _context.Song
                .SingleOrDefaultAsync(m => m.PkSongId == id);
            if (song == null)
            {
                return NotFound();
            }

            return View(song);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(short id)
        {
            var song = await _context.Song.SingleOrDefaultAsync(m => m.PkSongId == id);
            _context.Song.Remove(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SongExists(short id)
        {
            return _context.Song.Any(e => e.PkSongId == id);
        }
    }
}
