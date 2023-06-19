using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto_gamer.Models
{
    public class Equipe
    {
        [Key] //DATA ANNOTION - IdEquipe
        public int IdEquipe { get; set; }

        public string Nome { get; set; }

        public string Imagem { get; set; }

        //Referncia que a classe equipe vai ter acesso a collection "Jogador"
        public ICollection<Jogador> Jogador {get; set;}
    }
} 