using System;
using SwinGameSDK;
using System.Collections.Generic;

namespace MyGame
{
    public class ParticleDust : Particle
    {       
        public ParticleDust(int locationX, int locationY, Map mapArray) : base(locationX, locationY, mapArray)
        {
            TypeKind = Type.Dust;
        }

        #region implemented abstract members of Particle
        public override void Draw ()
        {
            SwinGame.FillRectangle (Color.SandyBrown, LocationX * 2, LocationY * 2, 2, 2);
        }

        public override void Gravity (cDir dir) 
        {
            Random r = new Random ();
            int choice = r.Next (2);
            if (Check != true)
            {
                if ((dir & cDir.Bottom) == cDir.Bottom)
                {
                    if (ParticleMap.ParticleArray[LocationX, LocationY + 1].TypeKind == Type.Liquid)
                    {
                        Swap(this, ParticleMap.ParticleArray[LocationX, LocationY + 1]);
                    }
                    else
                    {
                        switch (choice)
                        {
                            case 0:
                                if ((dir & cDir.BottomLeft) != cDir.BottomLeft && ((dir & cDir.Left) != cDir.Left))
                                {
                                    LocationX--;
                                    LocationY++;
                                }
                                else if ((dir & cDir.BottomRight) != cDir.BottomRight && ((dir & cDir.Right) != cDir.Right))
                                {
                                    LocationX++;
                                    LocationY++;
                                }
                                break;
                            case 1:
                                if ((dir & cDir.BottomRight) != cDir.BottomRight && ((dir & cDir.Right) != cDir.Right))
                                {
                                    LocationX++;
                                    LocationY++;
                                }
                                else if ((dir & cDir.BottomLeft) != cDir.BottomLeft && ((dir & cDir.Left) != cDir.Left))
                                {
                                    LocationX--;
                                    LocationY++;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }
                else if ((dir & cDir.Bottom) != cDir.Bottom)
                {
                    LocationY++;
                }

                if (StoreX != LocationX || StoreY != LocationY)
                {
                    if ((LocationX <= -1) || (LocationX >= 400) || (LocationY <= -1) || (LocationY >= 300))
                    {
    
                    }
                    else
                    {
                        ParticleMap.ParticleArray.SetValue (this, LocationX, LocationY);
                        ParticleMap.ParticleArray.SetValue (null, StoreX, StoreY);         
                        StoreX = LocationX;
                        StoreY = LocationY;
                    }
                }   
            }
            Check = true;
        }
        #endregion
    }
}

