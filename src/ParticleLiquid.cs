using System;
using SwinGameSDK;

namespace MyGame
{
    public class ParticleLiquid : Particle
    {
        private Random r;

        public ParticleLiquid(int locationX, int locationY, Map mapArray) : base(locationX, locationY, mapArray)
        {
            TypeKind = Type.Liquid;
            r = new Random ();
        }
        
        #region implemented abstract members of Particle
        public override void Draw ()
        {
            SwinGame.FillRectangle(Color.Blue, LocationX * 2, LocationY * 2, 2, 2);
            //SwinGame.DrawPixel(Color.Blue, LocationX * 2, LocationY * 2);
        }
        
        public override void Gravity (cDir dir)
        {
            
            
            //if (SwinGame.KeyTyped(KeyCode.vk_q)) Console.WriteLine("!");
            if (Check != true)
            {
                int choice = r.Next(2);
                //Console.WriteLine (choice.ToString ());
                if ((dir & cDir.Bottom) == cDir.Bottom)
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
                            else if ((dir & cDir.Left) != cDir.Left)
                            {
                                LocationX--;
                            }
                            else if ((dir & cDir.Right) != cDir.Right)
                            {
                                LocationX++;
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
                            else if ((dir & cDir.Right) != cDir.Right)
                            {
                                LocationX++;
                            }
                            else if ((dir & cDir.Left) != cDir.Left)
                            {
                                LocationX--;
                            }
                            break;
                        default:
                            break;
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
                        ParticleMap.ParticleArray.SetValue(this, LocationX, LocationY);
                        ParticleMap.ParticleArray.SetValue(null, StoreX, StoreY);
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

