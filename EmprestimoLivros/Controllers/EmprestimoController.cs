using EmprestimoLivros.Data;
using EmprestimoLivros.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmprestimoLivros.Controllers
{
    public class EmprestimoController : Controller
    {

        readonly private ApplicationDbContext _basedados;

        public EmprestimoController(ApplicationDbContext basedados)
        {
            _basedados = basedados;
        }

        public IActionResult Index()
        {
            IEnumerable<EmprestimosModel> emprestimos = _basedados.Emprestimos;
            return View(emprestimos);
        }

        public IActionResult Registar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registar(EmprestimosModel emprestimos) 
        {
            if (ModelState.IsValid)
            {
                _basedados.Emprestimos.Add(emprestimos);
                _basedados.SaveChanges();

                TempData["MensagemSucesso"] = "Registo realizado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Falhou a criar um registo!";

            return View();
        }

        public IActionResult editar(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }

            EmprestimosModel emprestimos = _basedados.Emprestimos.FirstOrDefault(x => x.Id == id); 
            
            if(emprestimos == null)
            {
                return NotFound();
            }

            return View(emprestimos);
        }

        [HttpPost]
        public IActionResult editar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _basedados.Emprestimos.Update(emprestimo);
                _basedados.SaveChanges();

                TempData["MensagemSucesso"] = "Edição realizada com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Edição falhou!";

            return View(emprestimo);
        }

        public IActionResult apagar(int? id)
        {
            
            if (id == null || id == 0) 
            {
                return NotFound();
            }

            EmprestimosModel emprestimo = _basedados.Emprestimos.FirstOrDefault(x => x.Id == id);

            if(emprestimo == null)
            {
                return NotFound();
            }

            return View(emprestimo);
        }

        [HttpPost]
        public IActionResult apagar(EmprestimosModel emprestimo)
        {
            if (ModelState.IsValid)
            {
                _basedados.Emprestimos.Remove(emprestimo);
                _basedados.SaveChanges();

                TempData["MensagemSucesso"] = "Registo apagado com sucesso!";

                return RedirectToAction("Index");
            }

            TempData["MensagemErro"] = "Registo não foi apagado!";

            return View(emprestimo);
        }
    }
}
