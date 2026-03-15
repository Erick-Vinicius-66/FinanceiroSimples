using FinanceiroSimples.Data;
using FinanceiroSimples.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceiroSimples.Controllers
{
    public class FinanceiroController : Controller
    {
        
        private readonly ApplicationDbContext _context;
        public FinanceiroController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            
            var lancamentos = _context.Lançamento.ToList();

            ViewBag.TotalReceitas = lancamentos.Where(x => x.Tipo == "Receita").Sum(x => x.Valor);
            
            ViewBag.TotalDespesas = lancamentos.Where(x => x.Tipo == "Despesa").Sum(x => x.Valor);
            
            ViewBag.Saldo = ViewBag.TotalReceitas - ViewBag.TotalDespesas;


            return View(lancamentos);
        
        }
    
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Lançamento lançamento)
        {
            if (ModelState.IsValid)
            {
                _context.Lançamento.Add(lançamento);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lançamento);
        }

    
        public IActionResult Delete(int id)
        {
            var lançamento = _context.Lançamento.FirstOrDefault(x => x.Id == id);
        
            if (lançamento == null) return NotFound();

            return View(lançamento);

        }

        [HttpPost]
        public IActionResult DeleteConfirmed(int id)
        {
            var lançamento = _context.Lançamento.FirstOrDefault(x => x.Id == id);
        
            if(lançamento != null)
            {
                _context.Lançamento.Remove(lançamento);
                _context.SaveChanges();
                
            }

            return RedirectToAction("Index");


        }
    }
}
