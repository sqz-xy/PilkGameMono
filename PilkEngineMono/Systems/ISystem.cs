using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.Systems
{
    public interface ISystem
    {
        void GetComponents();
        void OnAction();
    }
}
