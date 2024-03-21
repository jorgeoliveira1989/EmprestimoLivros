using System.ComponentModel.DataAnnotations;

namespace EmprestimoLivros.Models
{
    public class EmprestimosModel
    { 
        public int Id { get; set; }

        [Required(ErrorMessage ="Indique o nome de quem alugou")]
        public string Alugou  { get; set; }

        [Required(ErrorMessage = "Indique o nome de quem emprestou")]
        public string Emprestou  { get; set; }

        [Required(ErrorMessage = "Indique o nome do livro")]
        public string Livro { get; set; }
        public DateTime DataUltimaAtualizacao { get; set; } = DateTime.Now;
    }
}
