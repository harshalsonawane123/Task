using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class NodesController : Controller
    {
        private readonly NodeDbContext _context;

        public NodesController(NodeDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
              return _context.Nodes != null ? 
                          View(await _context.Nodes.ToListAsync()) :
                          Problem("Entity set 'NodeDbContext.Nodes'  is null.");
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Nodes == null)
            {
                return NotFound();
            }

            var node = await _context.Nodes
                .FirstOrDefaultAsync(m => m.nodeId == id);
            if (node == null)
            {
                return NotFound();
            }

            return View(node);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("nodeId,nodeName,parentNodeId,isActive,startdate")] Node node)
        {
            if (ModelState.IsValid)
            {
                _context.Add(node);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(node);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Nodes == null)
            {
                return NotFound();
            }

            var node = await _context.Nodes.FindAsync(id);
            if (node == null)
            {
                return NotFound();
            }
            return View(node);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("nodeId,nodeName,parentNodeId,isActive,startdate")] Node node)
        {
            if (id != node.nodeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(node);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NodeExists(node.nodeId))
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
            return View(node);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Nodes == null)
            {
                return NotFound();
            }

            var node = await _context.Nodes
                .FirstOrDefaultAsync(m => m.nodeId == id);
            if (node == null)
            {
                return NotFound();
            }

            return View(node);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Nodes == null)
            {
                return Problem("Entity set 'NodeDbContext.Nodes'  is null.");
            }
            var node = await _context.Nodes.FindAsync(id);
            if (node != null)
            {
                _context.Nodes.Remove(node);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NodeExists(int id)
        {
          return (_context.Nodes?.Any(e => e.nodeId == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> NodeModelTree()
        {
            List<Node> activeNodes = await _context.Nodes.Where(m => m.isActive == true).Cast<Node>().ToListAsync();
            if (activeNodes == null)
            {
                return NotFound();
            }
            else
            {
                List<NodeViewModel> tree = FillRecursive(activeNodes, null);

                return View(tree);
            }
        }

        private static List<NodeViewModel> FillRecursive(List<Node> flatObjects, int? parentId = null)
        {
            return flatObjects.Where(x => x.parentNodeId.Equals(parentId)).Select(item => new NodeViewModel
            {
                nodeName = item.nodeName,
                nodeId = item.nodeId,
                children = FillRecursive(flatObjects, item.nodeId)
            }).ToList();
        }

        public ActionResult NodeModelTree1()
        {
            return View();
        }
    }
}
