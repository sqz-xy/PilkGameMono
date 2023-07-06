using PilkEngineMono.EntityComponent;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.Systems
{
    public abstract class System : ISystem
    {
        public abstract string Name { get; }

        public abstract void OnAction(Entity pEntity);
    }
}
