using Microsoft.DirectX;
using Microsoft.DirectX.DirectInput;
using System.Drawing;
using TGC.Core.Direct3D;
using TGC.Core.Example;
using TGC.Core.Geometry;
using TGC.Core.Input;
using TGC.Core.SceneLoader;
using TGC.Core.Textures;
using TGC.Core.Utils;

namespace Los_Demoledores.Model
{
    public class TwistedModel : TgcExample
    {
        public TwistedModel(string mediaDir, string shadersDir) : base(mediaDir, shadersDir)
        {
            Category = Game.Default.Category;
            Name = Game.Default.Name;
            Description = Game.Default.Description;
        }

        private TgcMesh mesh { get; set; }
        private TgcScene scene { get; set; }
        private TgcPlane veredaIzq { get; set; }
        private TgcPlane calle { get; set; }
        private TgcPlane veredaDer { get; set; }

        public override void Init()
        {
            var d3dDevice = D3DDevice.Instance.Device;

            //var texturaPastoIzq = TgcTexture.createTexture(D3DDevice.Instance.Device, MediaDir + "Texturas\\pasto.jpg");
            //veredaIzq = new TgcPlane(new Vector3(50, 0, -900), new Vector3(1000, 0f, 1000), TgcPlane.Orientations.XZplane, texturaPastoIzq);
            //var texturaCalle = TgcTexture.createTexture(D3DDevice.Instance.Device, MediaDir + "Texturas\\paredRugosa.jpg");
            //calle = new TgcPlane(new Vector3(50, 0, 900), new Vector3(-100, 0f, -2000), TgcPlane.Orientations.XZplane, texturaCalle);
            //var texturaPastoDer = TgcTexture.createTexture(D3DDevice.Instance.Device, MediaDir + "Texturas\\pasto.jpg");
            //veredaDer = new TgcPlane(new Vector3(-50, 0, 900), new Vector3(-1000, 0f, -2000), TgcPlane.Orientations.XZplane, texturaPastoDer);

            scene = new TgcSceneLoader().loadSceneFromFile(MediaDir + "Ciudad\\Ciudad-TgcScene.xml");

            mesh = new TgcSceneLoader().loadSceneFromFile(MediaDir + "\\Camioneta\\Camioneta-TgcScene.xml").Meshes[0];
            mesh.AutoTransformEnable = true;
            mesh.Scale = new Vector3(0.5f, 0.5f, 0.5f);

            var cameraPosition = new Vector3(0, 120, 180);
            var lookAt = Vector3.Empty;
            Camara.SetCamera(cameraPosition, new Vector3(0, 20, 0));
        }

        public override void Update()
        {
            PreUpdate();
        }

        public override void Render()
        {
            PreRender();

            //veredaIzq.render();
            //calle.render();
            //veredaDer.render();

            mesh.UpdateMeshTransform();
            mesh.render();
            scene.renderAll();

            PostRender();
        }

        public override void Dispose()
        {
            //veredaIzq.dispose();
            //calle.dispose();
            //veredaDer.dispose();

            mesh.dispose();
            scene.disposeAll();
        }
    }
}
