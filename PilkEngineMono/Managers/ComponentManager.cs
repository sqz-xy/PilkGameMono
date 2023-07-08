using Microsoft.VisualBasic;

using PilkEngineMono.EntityComponent;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.Managers
{
    public class ComponentManager
    {
        // String = Name of Component for registering
        // Value = Dictionary of the entity its linked to and the component
        public static Dictionary<Type, Dictionary<string, IComponent>> mComponentRegistry = new Dictionary<Type, Dictionary<string, IComponent>>();

        public static bool RegisterComponentType(Type pComponentType)
        {
            if (mComponentRegistry.ContainsKey(pComponentType))
            {
                Debug.WriteLine("Component with same name already registered");
                return false;
            }

            mComponentRegistry.Add(pComponentType, new Dictionary<string, IComponent>());
            return true;
        }

        public static bool AddComponent(Type pComponentType, string pEntityName, IComponent pComponent)
        {
            if (!EntityManager.HasEntity(pEntityName))
            {
                Debug.WriteLine("Entity doesn't exist");
                return false;
            }

            Dictionary<string, IComponent> dict;
            mComponentRegistry.TryGetValue(pComponentType, out dict);

            if (dict == null)
            {
                Debug.WriteLine("Component type not registered");
                return false;
            }
            dict.Add(pEntityName, pComponent);
            return true;
        }

        public static Dictionary<string, IComponent> GetComponents(Type pComponentType)
        {
            if (HasComponent(pComponentType))
            {
                return mComponentRegistry[pComponentType];
            }

            return null;
        }

        public static bool UnregisterComponentType(Type pComponentType)
        {
            return mComponentRegistry.Remove(pComponentType);
        }

        public static bool HasComponent(Type pComponentType)
        {
            return mComponentRegistry.ContainsKey(pComponentType);
        }
    }
}
