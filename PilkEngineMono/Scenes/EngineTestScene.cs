using PilkEngineMono.Managers;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.Scenes
{
    public class EngineTestScene : Scene
    {
        public EngineTestScene(SceneManager pSceneManager) : base(pSceneManager)
        {

        }

        public override void Close()
        {
            Debug.WriteLine("TEST");
        }

        public override void Initialize()
        {
            Debug.WriteLine("TEST");
        }

        public override void Render()
        {
            Debug.WriteLine("TEST");
        }

        public override void Update()
        {
            Debug.WriteLine("TEST");
        }
    }
}
