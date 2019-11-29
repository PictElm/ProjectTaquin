using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Solver2.Graph;

namespace Solver2.Taquin
{
    public class TaquinNode : INode<TaquinGame.Move>
    {
        public int GCost
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int HCost
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public TaquinGame.Move MoveFromParent
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public INode<TaquinGame.Move> Parent
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public int TotalCost
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public void Attach(INode<TaquinGame.Move> child, TaquinGame.Move moveFromParentToChild)
        {
            throw new NotImplementedException();
        }

        public int Heuristics(INode<TaquinGame.Move> final)
        {
            throw new NotImplementedException();
        }

        public List<INode<TaquinGame.Move>> Nexts(INode<TaquinGame.Move> restrMustMatch = null)
        {
            throw new NotImplementedException();
        }

        public bool SameAs(INode<TaquinGame.Move> mate)
        {
            throw new NotImplementedException();
        }
    }
}
