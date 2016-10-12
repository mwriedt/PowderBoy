using System;
using System.Collections.Generic;
using SwinGameSDK;
//using System.Threading;

namespace MyGame
{
    public abstract class Particle : Game
    {
        private SwinGameSDK.Vector _location;
        private int _storeX;
        private int _storeY;
        private bool _check;
        //private bool _delete;
        private Map _map;
        private Type _type;
        //private cDir _dir;
        //public static int count = 0;

        
        public Particle (int locationX, int locationY, Map mapArray)
        {
            _location.X = (float)locationX;
            _location.Y = (float)locationY;
            _check = false;
            _storeX = locationX;
            _storeY = locationY;
            _map = mapArray;
            //_dir = Collision(this);
            //Interlocked.Increment(ref count);
            //Console.WriteLine (count.ToString ());

        }

        public bool Check
        {
            get
            {
                return _check;
            }
            set
            {
                _check = value;
            }
        }

        //public cDir cDir
        //{
        //    get
        //    {
        //        return _dir;
        //    }
        //    set
        //    {
        //        _dir = value;
        //    }
        //}

        public Map ParticleMap
        {
            get
            {
                return _map;
            }
        }

        public Type TypeKind
        {
            get
            {
                return _type;
            }
            set
            {
                _type = value;
            }
        }

        public int LocationX
        {
            get
            {
                return (int)_location.X;
            }
            set
            {
                _location.X = value;
            }
        }
        
        public int LocationY
        {
            get
            {
                return (int)_location.Y;
            }
            set
            {
                _location.Y = value;
            }
        }

        public int StoreX
        {
            get
            {
                return _storeX;
            }
            set
            {
                _storeX = value;
            }
        }

        public int StoreY
        {
            get
            {
                return _storeY;
            }
            set
            {
                _storeY = value;
            }
        }

        public abstract void Draw ();

        public abstract void Gravity (cDir dir);
    }
}

