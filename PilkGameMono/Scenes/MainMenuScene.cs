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
            Texture2D tex = mSceneManager.Content.Load<Texture2D>("img8");

            bool test = EntityManager.CreateEntity("test");

            ComponentManager.RegisterComponentType(typeof(ComponentTransform));
            ComponentManager.RegisterComponentType(typeof(ComponentSprite));

            ComponentTransform trans = new ComponentTransform(new Vector2(400.0f, 400.0f), new Vector2(0.5f, 0.5f), 0.0f, 1.0f);
            ComponentSprite sprite = new ComponentSprite(tex, Color.White);

            ComponentManager.AddComponent(typeof(ComponentTransform), "test", trans);
            ComponentManager.AddComponent(typeof(ComponentSprite), "test", sprite);

            mSystemRender = new SystemRender2D();
            SystemManager.AddSystem(mSystemRender, SystemType.RENDER);

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
