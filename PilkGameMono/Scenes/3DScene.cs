using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.EntityComponent;
using PilkEngineMono.Managers;
using PilkEngineMono.Scenes;
using PilkEngineMono.Systems;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Vector2 = Microsoft.Xna.Framework.Vector2;
using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace PilkGameMono.Scenes
{
    public class _3DScene : Scene
    {
        ISystem mSystemRender;

        Vector3 camTarget;
        Vector3 camPos;
        Matrix projMat;
        Matrix viewMat;
        Matrix worldMat;

        Model model;

        bool orbit = true;

        public _3DScene(SceneManager pSceneManager) : base(pSceneManager)
        {

        }

        public override void Close()
        {

        }

        public override void Initialize()
        {
            camTarget = new Vector3(0f, 0f, 0f);
            camPos = new Vector3(0f, 0f, 20f);
            projMat = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45), 800f / 480f, 0.1f, 100f);
            viewMat = Matrix.CreateLookAt(new Vector3(0, 0, 10), new Vector3(0, 0, 0), Vector3.UnitY);
            worldMat = Matrix.CreateTranslation(new Vector3(0, 0, 0));

            model = mSceneManager.Content.Load<Model>("cube");

            // TEX

            ComponentManager.RegisterComponentType(typeof(ComponentTransform));
            ComponentManager.RegisterComponentType(typeof(ComponentSprite));

            mSystemRender = new SystemRender2D();
            SystemManager.AddSystem(mSystemRender, SystemType.RENDER);

            EntityManager.CreateEntity("randy");
            Texture2D randy = mSceneManager.Content.Load<Texture2D>("nakedgun0"); // 274 tall, 265 wide
            ComponentTransform trans2 = new ComponentTransform(new Vector2(1800.0f, 750.0f), new Vector2(2.0f, 2.0f), 0.0f, 1.0f);
            ComponentSprite sprite2 = new ComponentSprite(randy, Color.White, new Rectangle(0, 0, 256, 273), 4, 50);
            ComponentManager.AddComponent(typeof(ComponentTransform), "randy", trans2);
            ComponentManager.AddComponent(typeof(ComponentSprite), "randy", sprite2);
        }

        public override void Render()
        {
            foreach (ModelMesh mesh in model.Meshes)
            {
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.World = worldMat;
                    effect.View = viewMat;
                    effect.Projection = projMat;
                }
                mesh.Draw();
            }

            mSystemRender.OnAction();
        }

        public override void Update()
        {
            if (orbit)
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(1f));
                camPos = Vector3.Transform(camPos, rotationMatrix);
            }

            viewMat = Matrix.CreateLookAt(camPos, camTarget, Vector3.Up);
        }
    }
}
