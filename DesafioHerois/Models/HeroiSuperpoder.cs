using System;

namespace SuperHeroApi.Models
{
    public class HeroiSuperpoder
    {
        public int HeroiId { get; set; }
        public Heroi Heroi { get; set; }

        public int SuperpoderId { get; set; }
        public Superpoder Superpoder { get; set; }
    }
}
