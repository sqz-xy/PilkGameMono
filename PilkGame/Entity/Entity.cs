using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkGame.Entity
{
    public sealed class Entity
    {     
        public string Name { get; }
        private List<IComponent> Components;         
        //ComponentTypes mask;

        public Entity(string pName)
        {
            Name = pName;
            Components = new List<IComponent>();
        }

        /// <summary>Adds a single component</summary>
        public void AddComponent(IComponent component)
        {
            Debug.Assert(component != null, "Component cannot be null");

            Components.Add(component);
        }

        public T GetComponent<T>(Type pComponentType)
        {
            return (T)Components.Find(component => component.GetType() == pComponentType);
        }

        public ReadOnlyCollection<IComponent> GetComponents()
        {
            return Components.AsReadOnly();
        }
    }
}
