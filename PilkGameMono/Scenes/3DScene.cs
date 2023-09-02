using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.Managers;
using PilkEngineMono.Scenes;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Vector3 = Microsoft.Xna.Framework.Vector3;

namespace PilkGameMono.Scenes
{
    public class _3DScene : Scene
    {
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
