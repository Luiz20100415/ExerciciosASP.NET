using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ExerciciosASP.NET.Models
{
    public class Evento
    {
        public int Id {get; set;}

        [StringLength(80, MinimumLength =5, ErrorMessage = "Nome deve ter entre 5 e 80 caracteres.")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        public string Nome {get; set;} = string.Empty;

        [MinLength(5, ErrorMessage = "A descrição deve ter no mínimo 10 caracteres.")]
        [Required(ErrorMessage = "Descrição obrigatória")]
        public string Descricao {get; set;} = string.Empty;

        [StringLength(100, MinimumLength =3, ErrorMessage = "O local deve ter entre 3 e 100 caracteres.")]
        [Required(ErrorMessage = "O local é obrigatório")]
        public string Local {get; set;} = string.Empty;
        public DateTime DataEvento {get; set;}

        [Range(1, 1000, ErrorMessage = "Quantidades de vagas entre 1 e 1000.")]
        public int QuantidadesVagas {get; set;} 
        public decimal ValorIngresso {get; set;}
    }
}