using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.Scenes;
using PilkEngineMono.EntityComponent;
using PilkEngineMono.Managers;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mime;
using PilkEngineMono.Systems;
using Microsoft.Xna.Framework.Input;

namespace PilkGameMono.Scenes
{
    public class MainMenuScene : Scene
    {
        ISystem mSystemRender;

        public MainMenuScene(SceneManager pSceneManager) : base(pSceneManager) 
        { 
        
        }

        public override void Close()
        {
            Debug.WriteLine("Close");
        }

        public override void Initialize()
        {
            Debug.WriteLine("Initialize");
        }

        public override void Render()
        {
            SystemManager.ActionRenderSystems();

            Debug.WriteLine("Render");
        }

        public override void Update()
        {
            SystemManager.ActionUpdateSystems();

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                ComponentManager.RemoveComponent(typeof(ComponentTransform), "test2");

            Debug.WriteLine("Update");
        }
    }
}
