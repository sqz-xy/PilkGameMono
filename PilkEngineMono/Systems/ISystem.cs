using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PilkEngineMono.EntityComponent;

namespace PilkEngineMono.Systems
{
    public interface ISystem
    {
        void OnAction(Entity pEntity);
    }
}
