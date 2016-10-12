using System;
using SwinGameSDK;

namespace MyGame
{
    public class ParticleSolid : Particle
    {
        public ParticleSolid(int locationX, int locationY, Map mapArray) : base(locationX, locationY, mapArray)
        {
            TypeKind = Type.Solid;
        }
        
        
        #region implemented abstract members of Particle
        public override void Draw ()
        {
            SwinGame.FillRectangle (Color.Black, LocationX * 2, LocationY * 2, 2, 2);
        }
        public override void Gravity (cDir dir)
        {
            
            
        }
        #endregion
    }
}

