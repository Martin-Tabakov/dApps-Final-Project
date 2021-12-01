using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Meeting_Room_Booking.Database;
using Meeting_Room_Booking.Models.Entities;

namespace Meeting_Room_Booking.Controllers
{
    public class BoardRoomsController : Controller
    {
        private readonly DatabaseContext _context;

        public BoardRoomsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: BoardRooms
        public async Task<IActionResult> Index()
        {
            return View(await _context.BoardRooms.ToListAsync());
        }

        // GET: BoardRooms/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardRoom = await _context.BoardRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardRoom == null)
            {
                return NotFound();
            }

            return View(boardRoom);
        }

        // GET: BoardRooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BoardRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Location,Name,OpenTime,CloseTime,IsInMaintanance,Capacity")] BoardRoom boardRoom)
        {
            if (ModelState.IsValid)
            {
                boardRoom.Id = Guid.NewGuid();
                _context.Add(boardRoom);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(boardRoom);
        }

        // GET: BoardRooms/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardRoom = await _context.BoardRooms.FindAsync(id);
            if (boardRoom == null)
            {
                return NotFound();
            }
            return View(boardRoom);
        }

        // POST: BoardRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Location,Name,OpenTime,CloseTime,IsInMaintanance,Capacity")] BoardRoom boardRoom)
        {
            if (id != boardRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(boardRoom);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BoardRoomExists(boardRoom.Id))
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
            return View(boardRoom);
        }

        // GET: BoardRooms/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var boardRoom = await _context.BoardRooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (boardRoom == null)
            {
                return NotFound();
            }

            return View(boardRoom);
        }

        // POST: BoardRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var boardRoom = await _context.BoardRooms.FindAsync(id);
            _context.BoardRooms.Remove(boardRoom);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BoardRoomExists(Guid id)
        {
            return _context.BoardRooms.Any(e => e.Id == id);
        }
    }
}
