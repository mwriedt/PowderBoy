using System;

namespace MyGame
{
    public class Map
    {
        private Particle[,] particleArray;
        
        public Map ()
        {
            particleArray = new Particle[400, 300]; 
        }
        
        public Particle[,] ParticleArray
        {
            get
            {
                return particleArray;
            }
            set
            {
                particleArray = value;
            }
        }
    }
}

