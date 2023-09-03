using PilkEngineMono.Systems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.Managers
{
    public enum SystemType
    {
        RENDER,
        UPDATE
    }

    public static class SystemManager
    {
        private static List<ISystem> mRenderSystems;
        private static List<ISystem> mUpdateSystems;

        public static bool AddSystem(ISystem pSystem, SystemType pSystemType)
        {
            if (pSystemType == SystemType.RENDER)
            {
                return AddSystem(pSystem, mRenderSystems);
            }

            else if (pSystemType == SystemType.UPDATE)
            {
                return AddSystem(pSystem, mUpdateSystems);
            }

            return false;
        }

        public static bool RemoveSystem(ISystem pSystem, SystemType pSystemType)
        {
            if (pSystemType == SystemType.RENDER)
            {
                return RemoveSystem(pSystem, mRenderSystems);
            }

            else if (pSystemType == SystemType.UPDATE)
            {
                return RemoveSystem(pSystem, mUpdateSystems);
            }

            return false;
        }

        private static bool AddSystem(ISystem pSystem,  List<ISystem> pListToAddTo) 
        {
            if (!ContainsSystem(pSystem, pListToAddTo))
            {
                mRenderSystems.Add(pSystem);
                return true;
            }
            return false;
        }

        private static bool RemoveSystem(ISystem pSystem, List<ISystem> pListToAddTo)
        {
            if (!ContainsSystem(pSystem, pListToAddTo))
            {
                mRenderSystems.Remove(pSystem);
                return true;
            }
            return false;
        }
        private static bool ContainsSystem(ISystem pSystem, List<ISystem> pListToCheck)
        {
            if (pListToCheck.Contains(pSystem))
                return true;

            return false;
        }

        public static void ActionRenderSystems()
        {
            foreach (ISystem pSystem in mRenderSystems)
            {
                pSystem.OnAction();
            }
        }

        public static void ActionUpdateSystems()
        {
            foreach (ISystem pSystem in mUpdateSystems)
            {
                pSystem.OnAction();
            }
        }
    }
}
