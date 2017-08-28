using System;
using System.Threading;
using System.Windows.Forms;
using TGC.Core.Direct3D;
using TGC.Core.Example;
using TGC.Core.Input;
using TGC.Core.Shaders;
using TGC.Core.Sound;
using TGC.Core.Textures;
using Los_Demoledores.Model;

namespace Los_Demoledores.Form
{
    public partial class TwistedForm : System.Windows.Forms.Form
    {
        public TwistedForm()
        {
            InitializeComponent();
        }

        private TgcExample Modelo { get; set; }

        /// <summary>
        ///     Obtener o parar el estado del RenderLoop.
        /// </summary>
        private bool ApplicationRunning { get; set; }

        /// <summary>
        ///     Permite manejar el sonido.
        /// </summary>
        private TgcDirectSound DirectSound { get; set; }

        /// <summary>
        ///     Permite manejar los inputs de la computadora.
        /// </summary>
        private TgcD3dInput Input { get; set; }

        private void TwistedForm_Load(object sender, EventArgs e)
        {
            InitGraphics();

            Text = Modelo.Name + " - " + Modelo.Description;

            panel3D.Focus();

            InitRenderLoop();
        }

        private void TwistedForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ApplicationRunning)
            {
                ShutDown();
            }
        }

        public void InitGraphics()
        {
            ApplicationRunning = true;

            D3DDevice.Instance.InitializeD3DDevice(panel3D);

            Input = new TgcD3dInput();
            Input.Initialize(this, panel3D);

            DirectSound = new TgcDirectSound();
            DirectSound.InitializeD3DDevice(panel3D);

            var currentDirectory = Environment.CurrentDirectory + "\\";

            //Cargar shaders del framework
            TgcShaders.Instance.loadCommonShaders(currentDirectory + Game.Default.ShadersDirectory);

            Modelo = new TwistedModel(currentDirectory + Game.Default.MediaDirectory,
                currentDirectory + Game.Default.ShadersDirectory);

            //Cargar juego.
            ExecuteModel();
        }

        public void InitRenderLoop()
        {
            while (ApplicationRunning)
            {
                if (Modelo != null)
                {
                    if (ApplicationActive())
                    {
                        Modelo.Update();
                        Modelo.Render();
                    }
                    else
                    {
                        Thread.Sleep(100);
                    }
                }
                Application.DoEvents();
            }
        }

        public bool ApplicationActive()
        {
            if (ContainsFocus)
            {
                return true;
            }

            foreach (var form in OwnedForms)
            {
                if (form.ContainsFocus)
                {
                    return true;
                }
            }

            return false;
        }

        public void ExecuteModel()
        {
            try
            {
                Modelo.ResetDefaultConfig();
                Modelo.DirectSound = DirectSound;
                Modelo.Input = Input;
                Modelo.Init();
                panel3D.Focus();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Error en Init() del juego", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void StopCurrentExample()
        {
            if (Modelo != null)
            {
                Modelo.Dispose();
                Modelo = null;
            }
        }

        public void ShutDown()
        {
            ApplicationRunning = false;

            StopCurrentExample();

            D3DDevice.Instance.Dispose();
            TexturesPool.Instance.clearAll();
        }
    }
}
