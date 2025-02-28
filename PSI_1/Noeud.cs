using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSI
{
    public class Noeud
    {
        private int id;
        private Point position;

        public int Id { get { return id; } }
        public Point Position { get { return position; } }

        public Noeud(int id, Point position)
        {
            this.id = id;
            this.position = position;
            
        }
    }
}