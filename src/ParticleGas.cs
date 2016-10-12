using System;
using SwinGameSDK;

namespace MyGame
{
    public class ParticleGas : Particle
    {
        private Random r;
       
       
        public ParticleGas(int locationX, int locationY, Map mapArray) : base(locationX, locationY, mapArray)
        {
            TypeKind = Type.Gas;
            r = new Random ();
        }

        #region implemented abstract members of Particle
        public override void Draw ()
        {
            SwinGame.FillRectangle(Color.ForestGreen, LocationX * 2, LocationY * 2, 2, 2);
        }
        public override void Gravity (cDir dir)
        {
            bool dirTest = false;
            
            int choice = r.Next(1, 9);
            if (Check != true)
            {   
//                while (dirTest != true)
//                {


                    switch (choice)
                    {
                    case 1:
                        if (((dir & cDir.TopLeft) != cDir.TopLeft))
                        {
                            LocationX--;
                            LocationY--;
                            dirTest = true;
                        }
                        break;
                    case 2:
                        if (((dir & cDir.Top) != cDir.Top))
                        {
                            LocationY--;
                            dirTest = true;
                        }
                        break;
                    case 3:
                        if (((dir & cDir.TopRight) != cDir.TopRight))
                        {
                            LocationX++;
                            LocationY--;
                            dirTest = true;
                        }
                        break;
                    case 4:
                        if (((dir & cDir.Left) != cDir.Left))
                        {
                            LocationX--;
                            dirTest = true;
                        }
                        break;
                    case 5:
                        if (((dir & cDir.Right) != cDir.Right))
                        {
                            LocationX++;
                            dirTest = true;
                        }
                        break;
                    case 6:
                        if (((dir & cDir.BottomLeft) != cDir.BottomLeft))
                        {
                            LocationX--;
                            LocationY--;
                            dirTest = true;
                        }
                        break;
                    case 7:
                        if (((dir & cDir.Bottom) != cDir.Bottom))
                        {
                            LocationY--;
                            dirTest = true;
                        }
                        break;
                    case 8:
                        if (((dir & cDir.BottomRight) != cDir.BottomRight))
                        {
                            LocationX++;
                            LocationY--;
                            dirTest = true;
                        }
                        break;
                    default:
                        dirTest = true;
                        break;
                    }
              //}

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

