using System.Collections.Generic;

namespace SuperHeroApi.Models
{
    public class Superpoder
    {
        public int Id { get; set; }
        public string SuperpoderNome { get; set; }
        public string Descricao { get; set; }

        public ICollection<HeroiSuperpoder> HeroisSuperpoderes { get; set; }
    }
}
