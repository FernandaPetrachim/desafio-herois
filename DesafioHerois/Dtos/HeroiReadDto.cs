using System;
using System.Collections.Generic;

namespace SuperHeroApi.Dtos
{
    public class HeroiReadDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string NomeHeroi { get; set; }
        public DateTime DataNascimento { get; set; }
        public float Altura { get; set; }
        public float Peso { get; set; }
        public List<string> Superpoderes { get; set; }
    }
}
