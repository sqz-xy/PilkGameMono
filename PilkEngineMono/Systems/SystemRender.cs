using Microsoft.Xna.Framework;
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
            GetComponents();
        }

        public void GetComponents()
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

                    var originX = (sprite.Width * 0.5f);
                    var originY = (sprite.Width * 0.5f);

                    // Fix rotation centering
                    SceneManager.SpriteBatch.Begin();
                    SceneManager.SpriteBatch.Draw(sprite.Texture, trans.Position, null, sprite.Colour, trans.Rotation, new Vector2(originX + trans.Position.X, originY + trans.Position.Y), trans.Scale, SpriteEffects.None, trans.Layer);
                    SceneManager.SpriteBatch.End();
                }
            }
        }
    }
}
