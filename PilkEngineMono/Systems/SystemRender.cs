using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.EntityComponent;
using PilkEngineMono.Managers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PilkEngineMono.Systems
{
    public class SystemRender : ISystem
    {
        public Dictionary<string, IComponent> mTransforms;
        public Dictionary<string, IComponent> mSprites;     

        public SystemRender() 
        {
            // References
            mTransforms = ComponentManager.GetComponents(typeof(ComponentTransform));
            mSprites = ComponentManager.GetComponents(typeof(ComponentSprite));
        }

        public void OnAction()
        {
            foreach (var transform in mTransforms)
            {
                if (mSprites.ContainsKey(transform.Key))
                {
                    var trans = (ComponentTransform)transform.Value;
                    var sprite = (ComponentSprite)mSprites[transform.Key];

                    // Rewrite this
                    SceneManager.SpriteBatch.Begin();
                    SceneManager.SpriteBatch.Draw(sprite.Texture, trans.Position, sprite.Colour);
                    SceneManager.SpriteBatch.End();
                }
            }
        }
    }
}
