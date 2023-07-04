using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkGame.Managers;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkGame.Scenes
{
    public class MainMenuScene : Scene
    {
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

        public override void Render(GameTime pGameTime, SpriteBatch pSpriteBatch)
        {
            Debug.WriteLine("Render");
        }

        public override void Update(GameTime pGameTime)
        {
            Debug.WriteLine("Update");
        }
    }
}
