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

        private bool IsOpen(int i, int j)
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
            throw new NotImplementedException();
        }

        private void Open(int i, int j)
        {
            throw new NotImplementedException();
        }
    }
}
