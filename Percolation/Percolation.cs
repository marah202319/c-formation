using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Percolation
{
    public class Percolation
    {
        private readonly bool[,] _open;
        private readonly bool[,] _full;
        private readonly int _size;
        private bool _percolate;

        public Percolation(int size)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(size), size, "Taille de la grille négative ou nulle.");
            }

            _open = new bool[size, size];
            _full = new bool[size, size];
            _size = size;
        }

        public bool IsOpen(int i, int j)
        {
            if (i < 0 || j<0 || i>= _size || j>= _size)
            {
                return false;
            }
            return _open[i,j];
           // throw new NotImplementedException();
        }

        private bool IsFull(int i, int j)
        {
            if (i < 0 || j<0 || i>= _size || j>= _size)
            {
                return false;
            }
            return _full[i,j];
           // throw new NotImplementedException();
        }
        public bool Percolate()
        {
            for(int i=0; i< _size; i++)
            {
                if (IsFull(_size, i))
                {
                    return true;
                }

            }
            return false;
        }

        private List<KeyValuePair<int, int>> CloseNeighbors(int i, int j)
        {
            var voisin = new List<KeyValuePair<int, int>>();
            if( i-1 >= 0)
            {
                voisin.Add(KeyValuePair<int,int>(i-1,j));
            }
            if( j-1 >= 0)
            {
                voisin.Add(KeyValuePair<int,int>(i,j-1));
            }
            if( i+1 < _size)
            {
                voisin.Add(KeyValuePair<int,int>(i+1,j));
            }
            if( j+1 < _size)
            {
                voisin.Add(KeyValuePair<int,int>(i,j+1));
            }

            return voisin;
           // throw new NotImplementedException();
        }

        public void Open(int i, int j)
        {
            _open[i,j]= true
            if (i != 0)
            {
                var voisinpro = CloseNeighbors(i,j);
                foreach(var voisins in voisinpro)
                {
                    if(IsFull(voisins.Key, voisins.Value))
                    {
                        _full[i,j] = true;
                        verifvoisins(i,j);
                    }
                }
                
            }
            else
            {
                _full[i,j]=true;
                verifvoisins(i,j);

            }
            //throw new NotImplementedException();
        }
        public void verifvoisins(int i,int j)
        {
            var voisin = CloseNeighbors(i,j);
            foreach(var voisins in voisin)
            {
                if(!IsFull(voisins.Key,voisins.Value)&& IsOpen(voisins(voisins.Key, voisins.Value){
                    _full[voisins.Key,voisins.Value]=true;
                    verifvoisins(voisins.Key,voisins.Value);
                }

            }
        }
    }
}
