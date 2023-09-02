using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using PilkEngineMono.Managers;
using PilkEngineMono.Scenes;

using System;
using System.Collections.Generic;
using System.Linq;
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

        BasicEffect basicEffect;

        VertexPositionColor[] triangleVertices;
        VertexBuffer vertexBuffer;

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
            camPos = new Vector3(0f, 0f, -100f);
            projMat = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45f),mSceneManager.GraphicsDevice.DisplayMode.AspectRatio,1f, 1000f);
            viewMat = Matrix.CreateLookAt(camPos, camTarget,new Vector3(0f, 1f, 0f));// Y up
            worldMat = Matrix.CreateWorld(camTarget, Vector3.Forward, Vector3.Up);

            //BasicEffect
            basicEffect = new BasicEffect(mSceneManager.GraphicsDevice);
            basicEffect.Alpha = 1f;

            basicEffect.LightingEnabled = false;
     
            //Geometry  - a simple triangle about the origin
            triangleVertices = new VertexPositionColor[3];
            triangleVertices[0] = new VertexPositionColor(new Vector3(0, 20, 0), Color.Red);
            triangleVertices[1] = new VertexPositionColor(new Vector3(-20, -20, 0), Color.Green);
            triangleVertices[2] = new VertexPositionColor(new Vector3(20, -20, 0), Color.Blue);

            //Vert buffer
            vertexBuffer = new VertexBuffer(mSceneManager.GraphicsDevice, typeof( VertexPositionColor), 3, BufferUsage.WriteOnly);
            vertexBuffer.SetData<VertexPositionColor>(triangleVertices);
        }

        public override void Render()
        {
            basicEffect.Projection = projMat;
            basicEffect.View = viewMat;
            basicEffect.World = worldMat;

            mSceneManager.GraphicsDevice.Clear(Color.CornflowerBlue);
            mSceneManager.GraphicsDevice.SetVertexBuffer(vertexBuffer);

            RasterizerState rasterizerState = new RasterizerState();
            rasterizerState.CullMode = CullMode.None;
            mSceneManager.GraphicsDevice.RasterizerState = rasterizerState;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.
                    Passes)
            {
                pass.Apply();
                mSceneManager.GraphicsDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);
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
