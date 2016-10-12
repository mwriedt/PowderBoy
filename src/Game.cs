using System;
using SwinGameSDK;
using System.Linq;

namespace MyGame
{
    [Flags]
    public enum cDir
    {
        TopRight = 1,
        Top = 2,
        TopLeft = 4,
        Left = 8,
        Right = 16,
        BottomRight = 32,
        Bottom = 64,
        BottomLeft = 128
    };
    
    public class Game
    {
        private int brush = 3;
        private Map map;
        private bool toggleGravity = true;
        
        private Type typeToAdd = Type.Dust;
        //TODO: 
        // Fix particles being stuck on screen,  
        // Dust is deleteing solids, must fix
        // Fix collsion,
        // Implement brush,
        // Dust particles are overwriting other particles when it comes into contact with them
        // Add Liquid
        // Add Gas,
        // 
        public Game ()
        {
            
            
        }

        public void CleanUp()
        {
            for (int i = 0; i < map.ParticleArray.GetLength(0); i++)
            {
                for (int j = 0; j < map.ParticleArray.GetLength(1); j++)
                {
                    if (map.ParticleArray[i, j] == null) continue;
                    if (map.ParticleArray[i,j].LocationX <= -1)
                    {
                        map.ParticleArray[i, j] = null;
                        continue;
                    }
                    if (map.ParticleArray[i,j].LocationX >= 400)
                    {
                        map.ParticleArray[i, j] = null;
                        continue;
                    }
                    if (map.ParticleArray[i, j].LocationY <= -1)
                    {
                        map.ParticleArray[i, j] = null;
                        continue;
                    }
                    if (map.ParticleArray[i, j].LocationY >= 300)
                    {
                        map.ParticleArray[i, j] = null;
                        continue;
                    }
                }
            }
        }

        public void ResetCheck()
        {
            foreach(Particle p in map.ParticleArray)
            {
                if (p != null)
                {
                    p.Check = false;
                }
            }
        }
        
        
        public void ChooseType()
        {
            if (SwinGame.KeyTyped(KeyCode.vk_s)) typeToAdd = Type.Solid ;
            if (SwinGame.KeyTyped(KeyCode.vk_g)) typeToAdd = Type.Gas ;
            if (SwinGame.KeyTyped(KeyCode.vk_d)) typeToAdd = Type.Dust ;
            if (SwinGame.KeyTyped(KeyCode.vk_l)) typeToAdd = Type.Liquid ;
        }
        
        public bool IsOdd(int value)
        {
            return value % 2 != 0;
        }
        
        public int GetLocation(int result)
        {
            if (result == 0)
            {
                return 0;
            }
            else if (IsOdd(result))
            {
                return ((result - 1)/2);
            }
            else
            {
                return (result / 2);   
            }
        }
        
        public void ChooseParticle(int xPos, int yPos, int i, int j)
        {
            if (map.ParticleArray [xPos + i, yPos + j] == null)
            {
                //particleArray [(int)SwinGame.MouseX (), (int)SwinGame.MouseY ()] = new Particle (SwinGame.MouseX (), SwinGame.MouseY ());
                switch (typeToAdd)
                {
                case Type.Dust:
                    map.ParticleArray[xPos+ i, yPos+ j] = new ParticleDust(xPos + i, yPos + j, map);
                    break;
                case Type.Solid:
                    map.ParticleArray  [xPos+ i, yPos + j] = new ParticleSolid (xPos + i, yPos + j, map);
                    break;
                case Type.Liquid:
                    map.ParticleArray [xPos + i, yPos + j] = new ParticleLiquid (xPos + i, yPos + j, map);
                    break;
                case Type.Gas:
                    map.ParticleArray [xPos + i, yPos + j] = new ParticleGas (xPos + i, yPos + j, map);
                    break;
                default:
                    break;
                }
            }
        }
        
        public void CheckLeftButton ()
        {
        
            ChooseType ();
            
            if (SwinGame.MouseDown (MouseButton.LeftButton))
            {
                int xPos = GetLocation((int)(SwinGame.MouseX ()));
                int yPos = GetLocation((int)(SwinGame.MouseY ()));
//                int j = 0;
//                int i = 0;
                if(brush <= 1)
                {
                     ChooseParticle (xPos, yPos, 0, 0);
                }
                
                for (int i = -brush; i < brush; i++)
                {
                    for (int j = -brush; j < brush; j++)
                    {

                        if ((xPos + i) <= -1) break;
                        if ((xPos + i) >= 400) break;
                        if ((yPos + j) <= -1) break;
                        if ((yPos + j) >= 300) break;
                        ChooseParticle (xPos, yPos, i, j);
                        
                        
                    }
                }
            }
        }
        
        public void CheckSpaceBar()
        {
            if(SwinGame.KeyTyped(KeyCode.vk_SPACE))
            {
                if (toggleGravity == true)
                {
                    toggleGravity = false;
                }
                else
                {
                    toggleGravity = true;
                }
            }
        }
        
        public void Swap(Particle p1, Particle p2) //Used lated for allowing dust to fall in liquid?
        {
            Particle pTemp;
            pTemp = p2;
//            p2 = p1;
  //          p1 = pTemp;
            p2.LocationX = p1.LocationX;
            p2.LocationY = p1.LocationY;
            p2.StoreX = p1.StoreX;
            p2.StoreY = p1.StoreY;
//            //p2 = p1;
            p1.LocationX = pTemp.LocationX;
            p1.LocationY = pTemp.LocationY;
            p1.StoreX = pTemp.StoreX;
            p1.StoreY = pTemp.StoreY;
            //p1 = pTemp;
        }

        public void CheckRightButton ()
        {
            if (SwinGame.MouseDown (MouseButton.RightButton))
            {
                int xPos = GetLocation((int)(SwinGame.MouseX ()));
                int yPos = GetLocation((int)(SwinGame.MouseY ()));
                for (int i = -brush; i < brush; i++)
                {
                    for (int j = -brush; j < brush; j++)
                    {
                        if ((xPos + i) <= -1) break;
                        if ((xPos + i) >= 400) break;
                        if ((yPos + j) <= -1) break;
                        if ((yPos + j) >= 300) break;
                        if (map.ParticleArray[xPos + i,yPos + j] == null)
                        {

                        }
                        else
                        {
                            //int test1 = xPos + i;
                            //int test2 = yPos + j;
                            map.ParticleArray[xPos + i, yPos + j] = null;
                        }
                    }
                }
            }
                
        }
        
        public void Can()
        {
            map.ParticleArray  [150,200] = new ParticleSolid (150,200, map);
            map.ParticleArray  [151,199] = new ParticleSolid (151,199, map);
            map.ParticleArray  [151,198] = new ParticleSolid (151,198, map);
            map.ParticleArray  [149,198] = new ParticleSolid (149,199, map);
            map.ParticleArray  [149,199] = new ParticleSolid (149,199, map);
            map.ParticleArray  [150,198] = new ParticleDust (150,198, map);
            map.ParticleArray  [150,199] = new ParticleLiquid (150,199, map);
            
            
        }
        
//        public static void MoveArrayValues (Particle p)
//        {
//            if (p.LocationX >= 800 || p.LocationY >= 600)
//            {
//                p = null;
//            }
//            else
//            {
//                //Console.WriteLine(p.Check.ToString());
//                if (p.Check != true)
//                {
//                    //particleArray [p.LocationX, p.LocationY] = p;
//                    particleArray.SetValue(p, p.LocationX, p.LocationY);
//                    //p.Check = false;
//                    //particleArray [p.StoreX, p.StoreY] = null;
//                    particleArray.SetValue(null, p.StoreX, p.StoreY);
//                    p.Check = true;
//
//                } 
//                else if (p.Check == true)  //if (p.LocationX != p.StoreX || p.LocationY != p.StoreY)
//                {
//                    p.StoreX = p.LocationX;
//                    p.StoreY = p.LocationY;
//                    //p.Check = true;
//                    //p.Check = false;
//                    
//                }
//            }
//        }
        
        
        public cDir Collision(Particle p)
        {
            cDir dir = new cDir();
            int x = 0;
            //int y = 0;
            for (int i = (int)(p.LocationX) - 1; i <= (int)(p.LocationX) + 1; i++)
            {
                x++;
                int y = 0;
                for (int j = (int)(p.LocationY) - 1; j <= (int)(p.LocationY) + 1; j++)
                {
                    if (i <= -1) break;
                    if (i >= 400) break;
                    if (j <= -1) break;
                    if (j >= 300) break;
                    y++;
                    
                    //Console.WriteLine (x.ToString () + y.ToString ());
                    if (map.ParticleArray[i,j] != null)
                    {
                        if (x == 1 && y == 1)
                        {
                            dir |= cDir.TopLeft;
                        }
                        if (x == 1 && y == 2)
                        {
                            dir |= cDir.Left;
                        }
                        if (x == 1 && y == 3)
                        {
                            dir |= cDir.BottomLeft;
                        }
                        if (x == 2 && y == 1)
                        {
                            dir |= cDir.Top;
                        }
                        if (x == 2 && y == 3)
                        {
                            dir |= cDir.Bottom;
                        }
                        if (x == 3 && y == 1)
                        {
                            dir |= cDir.TopRight;
                        }
                        if (x == 3 && y == 2)
                        {
                            dir |= cDir.Right;
                        }
                        if (x == 3 && y == 3)
                        {
                            dir |= cDir.BottomRight;
                        }
                    }
                }
            }
            return dir;
        }
        
        
        public void InitializeArray()
        {
            for (int i = 0; i < map.ParticleArray.GetLength (0); i++)
            {
                for (int j = 0; j < map.ParticleArray.GetLength (1); j++)
                {
                    map.ParticleArray [i, j] = null;
                }
            }    
        }
        
        public void CheckInput()
        {
            if (SwinGame.MouseClicked(MouseButton.WheelUpButton))
            {
                brush++;
            }
            if (SwinGame.MouseClicked(MouseButton.WheelDownButton))
            {
                brush--; if (brush < 0) brush = 0;
            }
            CheckSpaceBar ();
            CheckRightButton ();
            CheckLeftButton ();
        }
        
        public void ParticleLoop ()
        {
            foreach(Particle p in map.ParticleArray)
            {
                if (p == null) continue;
                if (p.GetType().Equals(Type.Solid)) continue;
                if (toggleGravity == false) continue;
                
                cDir dir = new cDir();

                dir = Collision (p);
                p.Gravity (dir);
            }
            
//            for (int i = 0; i < map.ParticleArray.GetLength (0); i++)
//            {
//                for (int j = 0; j < map.ParticleArray.GetLength (1); j++)
//                {
//                    if (map.ParticleArray[i, j] == null) continue;
//                    if (map.ParticleArray[i,j].GetType().Equals(Type.Solid)) continue;
//                    cDir dir = new cDir();
//    
//                    dir = Collision (map.ParticleArray[i,j]);
//                    map.ParticleArray[i,j].Gravity (dir);
//                }
//            }     
            ResetCheck();
        }
        
        public void Run ()
        {
            SwinGame.OpenGraphicsWindow ("GameMain", 800, 600);
            map = new Map ();
            
            //Run the game loop
            InitializeArray ();
            Can ();
            while (false == SwinGame.WindowCloseRequested ())
            {
                //Fetch the next batch of UI interaction
                SwinGame.ProcessEvents ();
                SwinGame.ClearScreen (Color.White);
                if (SwinGame.KeyTyped(KeyCode.vk_KP_ENTER))
                {
                    Console.WriteLine("help");
                }
                
                CheckInput ();
                ParticleLoop ();
                CleanUp(); // Need a better way to clean up particles
                foreach(Particle p in map.ParticleArray)
                {
                    if (p == null) continue;
                    p.Draw();
                }
                
                SwinGame.DrawRectangle(Color.Black, SwinGame.MouseX() - brush * 2, SwinGame.MouseY() - brush * 2, brush * 4, brush * 4);
                
                SwinGame.DrawFramerate (0, 0);
                SwinGame.RefreshScreen (60);
            }
        }   
    }
}

