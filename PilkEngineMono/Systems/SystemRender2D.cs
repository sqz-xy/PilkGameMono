using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.EntityComponent;
using PilkEngineMono.Managers;

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace PilkEngineMono.Systems
{
    public class SystemRender2D : ISystem
    {
        public Dictionary<string, IComponent> mTransforms;
        public Dictionary<string, IComponent> mSprites;
        

        public SystemRender2D() 
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

                    var panelWidth = sprite.Width / sprite.SpriteCount;

                    // Fix rotation centering
                    SceneManager.SpriteBatch.Draw(sprite.Texture, trans.Position, sprite.SourceRect, sprite.Colour, trans.Rotation, new Vector2(originX + trans.Position.X, originY + trans.Position.Y), trans.Scale, SpriteEffects.None, trans.Layer);
                  
                    if (sprite.Timer > sprite.Interval)
                    {
                        if (sprite.CurrentPanel == sprite.SpriteCount)
                        {
                            sprite.SourceRect = new Rectangle(0, 0, panelWidth, sprite.Height);
                            sprite.CurrentPanel = 0;
                        }
                        else
                        {
                            sprite.SourceRect = new Rectangle(0, 0, panelWidth * sprite.CurrentPanel, sprite.Height);
                            sprite.CurrentPanel++;
                        }
                    }
                    sprite.Timer += (float)SceneManager.GameTime.ElapsedGameTime.Milliseconds;
                }
            }
        }
    }
}
