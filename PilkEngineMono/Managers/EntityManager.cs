using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.Managers
{
    public static class EntityManager
    {
        private static List<string> mGUIDs = new List<string>();

        public static bool CreateEntity(string pName)
        {
            if (HasEntity(pName))
            {
                Debug.WriteLine("Entity Already Exists");
                return false;
            }

            mGUIDs.Add(pName);
            return true;
        }

        public static bool DeleteEntity(string pName) 
        {
            return mGUIDs.Remove(pName);
        }

        public static bool HasEntity(string pName)
        {
            return mGUIDs.Contains(pName);
        }

        public static void ClearEntities()
        {
            mGUIDs.Clear();
        }
    }
}
