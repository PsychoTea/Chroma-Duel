using System;
using System.ComponentModel;
using System.Windows.Forms;
using Corale.Colore.Core;
using k = Corale.Colore.Razer.Keyboard.Key;
using System.Threading;

namespace Chroma_Duel
{
    public partial class Form1 : Form
    {
        #region Variables
        private IKeyboard keyboard = Keyboard.Instance;
        int sleep = 100;
        int r = 50;
        int g = 50;
        int b = 50;
        Color backgroundCol = new Color(50, 50, 50);
        NotifyIcon notifyIcon = new NotifyIcon();

        MenuItem progNameMenuItem = new MenuItem("Chroma Duel by PsychoTea");
        MenuItem showMenuItem = new MenuItem("Show");
        MenuItem quitMenuItem = new MenuItem("Quit");
        ContextMenu contextMenu = new ContextMenu();
        #endregion

        public Form1()
        {
            InitializeComponent();
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);

            keyboard.SetAll(backgroundCol);
            backgroundWorker1.RunWorkerAsync();

            contextMenu.MenuItems.Add(progNameMenuItem);
            contextMenu.MenuItems.Add(showMenuItem);
            contextMenu.MenuItems.Add(quitMenuItem);

            notifyIcon.Icon = new System.Drawing.Icon("Icon.ico");
            notifyIcon.Text = "Chroma Duel";
            notifyIcon.ContextMenu = contextMenu;
            notifyIcon.Visible = true;

            notifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            showMenuItem.Click += ShowMenuItem_Click;
            quitMenuItem.Click += QuitMenuItem_Click;
        }

        #region Notify Icon
        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void ShowMenuItem_Click(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
            this.ShowInTaskbar = true;
        }

        private void QuitMenuItem_Click(object sender, EventArgs e) => this.Close();
        #endregion

        #region Events
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            numericUpDown1.Value = trackBar1.Value;
            sleep = trackBar1.Value;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            trackBar1.Value = Decimal.ToInt32(numericUpDown1.Value);
            sleep = Decimal.ToInt32(numericUpDown1.Value);
        }

        private void textBoxR_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxR.Text, out r);
            backgroundCol = new Color(CheckRange(r), g, b);
        }

        private void textBoxG_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxG.Text, out g);
            backgroundCol = new Color(r, CheckRange(g), b);
        }

        private void textBoxB_TextChanged(object sender, EventArgs e)
        {
            Int32.TryParse(textBoxB.Text, out b);
            backgroundCol = new Color(r, g, CheckRange(b));
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) => Logic();

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) => backgroundWorker1.RunWorkerAsync();

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState) this.Hide();
        }
        #endregion

        #region Functions
        int CheckRange(int val)
        {
            if (val > 256) val = 256;
            else if (val < 256) val = 0;
            return val;
        }

        void OnProcessExit(object sender, EventArgs e)
        {
            keyboard.SetAll(Color.Black);
            backgroundWorker1.Dispose();
            notifyIcon.Dispose();
        }

        void Logic()
        {
            //Feat. really shitty manual animations. 473 lines of it.
            #region Logic
            keyboard.SetAll(backgroundCol);

            keyboard.SetKey(k.M, Color.Red);
            keyboard.SetKey(k.K, Color.Red);
            keyboard.SetKey(k.O, Color.Red);
            keyboard.SetKey(k.P, Color.Red);
            keyboard.SetKey(k.OemMinus, Color.Blue);
            keyboard.SetKey(k.OemLeftBracket, Color.Blue);
            keyboard.SetKey(k.OemSemicolon, Color.Blue);
            keyboard.SetPosition(4, 12, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemLeftBracket, backgroundCol);
            keyboard.SetKey(k.D0, Color.Blue);
            keyboard.SetKey(k.P, Color.Blue);
            keyboard.SetKey(k.OemMinus, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemMinus, backgroundCol);
            keyboard.SetKey(k.O, backgroundCol);
            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetKey(k.M, backgroundCol);
            keyboard.SetKey(k.D0, backgroundCol);
            keyboard.SetKey(k.P, backgroundCol);
            keyboard.SetKey(k.D6, Color.Red);
            keyboard.SetKey(k.Y, Color.Red);
            keyboard.SetKey(k.H, Color.Red);
            keyboard.SetKey(k.N, Color.Red);
            keyboard.SetKey(k.O, Color.Blue);
            keyboard.SetKey(k.D9, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D9, backgroundCol);
            keyboard.SetKey(k.O, backgroundCol);
            keyboard.SetKey(k.D6, backgroundCol);
            keyboard.SetKey(k.Y, backgroundCol);
            keyboard.SetKey(k.H, backgroundCol);
            keyboard.SetKey(k.N, backgroundCol);
            keyboard.SetKey(k.D0, Color.Blue);
            keyboard.SetKey(k.P, Color.Blue);
            keyboard.SetKey(k.D2, Color.Red);
            keyboard.SetKey(k.E, Color.Red);
            keyboard.SetKey(k.F, Color.Red);
            keyboard.SetKey(k.B, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D2, backgroundCol);
            keyboard.SetKey(k.E, backgroundCol);
            keyboard.SetKey(k.F, backgroundCol);
            keyboard.SetKey(k.B, backgroundCol);
            keyboard.SetKey(k.OemSemicolon, backgroundCol);
            keyboard.SetPosition(4, 12, backgroundCol);
            keyboard.SetKey(k.L, Color.Blue);
            keyboard.SetKey(k.OemPeriod, Color.Blue);
            keyboard.SetKey(k.Z, Color.Red);
            keyboard.SetKey(k.X, Color.Red);
            keyboard.SetKey(k.C, Color.Red);
            keyboard.SetKey(k.V, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.Z, backgroundCol);
            keyboard.SetKey(k.X, backgroundCol);
            keyboard.SetKey(k.C, backgroundCol);
            keyboard.SetKey(k.V, backgroundCol);
            keyboard.SetKey(k.P, backgroundCol);
            keyboard.SetKey(k.L, backgroundCol);
            keyboard.SetKey(k.OemPeriod, backgroundCol);
            keyboard.SetKey(k.O, Color.Blue);
            keyboard.SetKey(k.K, Color.Blue);
            keyboard.SetKey(k.OemComma, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemComma, backgroundCol);
            keyboard.SetKey(k.M, Color.Blue);
            keyboard.SetKey(k.C, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D0, backgroundCol);
            keyboard.SetKey(k.O, backgroundCol);
            keyboard.SetKey(k.I, backgroundCol);
            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetKey(k.OemComma, Color.Blue);
            keyboard.SetKey(k.L, Color.Blue);
            keyboard.SetKey(k.OemSemicolon, Color.Blue);
            keyboard.SetKey(k.X, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.L, backgroundCol);
            keyboard.SetKey(k.OemComma, backgroundCol);
            keyboard.SetKey(k.OemSemicolon, backgroundCol);
            keyboard.SetKey(k.K, Color.Blue);
            keyboard.SetKey(k.O, Color.Blue);
            keyboard.SetKey(k.D0, Color.Blue);
            keyboard.SetKey(k.V, Color.Red);
            keyboard.SetKey(k.B, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D0, backgroundCol);
            keyboard.SetKey(k.O, backgroundCol);
            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetKey(k.C, backgroundCol);
            keyboard.SetKey(k.V, backgroundCol);
            keyboard.SetKey(k.B, backgroundCol);
            keyboard.SetKey(k.J, Color.Blue);
            keyboard.SetKey(k.U, Color.Blue);
            keyboard.SetKey(k.D7, Color.Blue);
            keyboard.SetKey(k.D, Color.Red);
            keyboard.SetKey(k.R, Color.Red);
            keyboard.SetKey(k.D5, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D5, backgroundCol);
            keyboard.SetKey(k.R, backgroundCol);
            keyboard.SetKey(k.D, Color.Red);
            keyboard.SetKey(k.J, Color.Red);
            keyboard.SetKey(k.U, Color.Red);
            keyboard.SetKey(k.J, backgroundCol);
            keyboard.SetKey(k.U, backgroundCol);
            keyboard.SetKey(k.D7, backgroundCol);
            keyboard.SetKey(k.H, Color.Blue);
            keyboard.SetKey(k.T, Color.Blue);
            keyboard.SetKey(k.D4, Color.Blue);
            keyboard.SetKey(k.D, backgroundCol);
            keyboard.SetKey(k.S, Color.Red);
            keyboard.SetKey(k.W, Color.Red);
            keyboard.SetKey(k.D2, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D2, backgroundCol);
            keyboard.SetKey(k.W, backgroundCol);
            keyboard.SetKey(k.D4, backgroundCol);
            keyboard.SetKey(k.T, backgroundCol);
            keyboard.SetKey(k.H, backgroundCol);
            keyboard.SetKey(k.N, Color.Blue);
            keyboard.SetKey(k.G, Color.Blue);
            keyboard.SetKey(k.F, Color.Blue);
            keyboard.SetKey(k.E, Color.Red);
            keyboard.SetKey(k.D3, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.F, backgroundCol);
            keyboard.SetKey(k.G, backgroundCol);
            keyboard.SetKey(k.D3, backgroundCol);
            keyboard.SetKey(k.E, backgroundCol);
            keyboard.SetKey(k.S, backgroundCol);
            keyboard.SetKey(k.D, Color.Red);
            keyboard.SetKey(k.R, Color.Red);
            keyboard.SetKey(k.D5, Color.Red);
            keyboard.SetKey(k.B, Color.Blue);
            keyboard.SetKey(k.V, backgroundCol);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.B, backgroundCol);
            keyboard.SetKey(k.N, backgroundCol);
            keyboard.SetKey(k.M, backgroundCol);
            keyboard.SetKey(k.X, backgroundCol);
            keyboard.SetKey(k.D, backgroundCol);
            keyboard.SetKey(k.R, backgroundCol);
            keyboard.SetKey(k.D5, Color.Red);
            keyboard.SetKey(k.D5, backgroundCol);
            keyboard.SetKey(k.OemPeriod, Color.Blue);
            keyboard.SetKey(k.S, Color.Red);
            keyboard.SetKey(k.E, Color.Red);
            keyboard.SetKey(k.D4, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetPosition(4, 12, Color.Blue);
            keyboard.SetKey(k.S, backgroundCol);
            keyboard.SetKey(k.D, Color.Red);
            keyboard.SetKey(k.F3, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.F3, backgroundCol);
            keyboard.SetKey(k.E, backgroundCol);
            keyboard.SetKey(k.D, backgroundCol);
            keyboard.SetKey(k.OemApostrophe, Color.Blue);
            keyboard.SetKey(k.R, Color.Red);
            keyboard.SetKey(k.F, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetPosition(4, 12, backgroundCol);
            keyboard.SetKey(k.OemApostrophe, backgroundCol);
            keyboard.SetKey(k.OemSemicolon, Color.Blue);
            keyboard.SetKey(k.OemLeftBracket, Color.Blue);
            keyboard.SetKey(k.OemEquals, Color.Blue);
            keyboard.SetKey(k.R, backgroundCol);
            keyboard.SetKey(k.D4, Color.Red);
            keyboard.SetKey(k.D4, backgroundCol);
            keyboard.SetKey(k.T, Color.Red);
            keyboard.SetKey(k.D6, Color.Red);
            keyboard.SetKey(k.F5, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemSemicolon, backgroundCol);
            keyboard.SetKey(k.OemLeftBracket, backgroundCol);
            keyboard.SetKey(k.OemEquals, backgroundCol);
            keyboard.SetKey(k.F, backgroundCol);
            keyboard.SetKey(k.T, backgroundCol);
            keyboard.SetKey(k.D6, backgroundCol);
            keyboard.SetKey(k.F5, backgroundCol);
            keyboard.SetKey(k.L, Color.Blue);
            keyboard.SetKey(k.P, Color.Blue);
            keyboard.SetKey(k.G, Color.Red);
            keyboard.SetKey(k.Y, Color.Red);
            keyboard.SetKey(k.D7, Color.Red);
            keyboard.SetKey(k.D8, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.L, backgroundCol);
            keyboard.SetKey(k.P, backgroundCol);
            keyboard.SetKey(k.G, backgroundCol);
            keyboard.SetKey(k.Y, backgroundCol);
            keyboard.SetKey(k.D7, backgroundCol);
            keyboard.SetKey(k.D8, backgroundCol);
            keyboard.SetKey(k.I, Color.Blue);
            keyboard.SetKey(k.D7, Color.Blue);
            keyboard.SetKey(k.B, Color.Red);
            keyboard.SetKey(k.N, Color.Red);
            keyboard.SetKey(k.J, Color.Red);
            keyboard.SetKey(k.K, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.I, backgroundCol);
            keyboard.SetKey(k.D7, backgroundCol);
            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetKey(k.J, backgroundCol);
            keyboard.SetKey(k.N, backgroundCol);
            keyboard.SetKey(k.H, Color.Red);
            keyboard.SetKey(k.D8, Color.Red);
            keyboard.SetKey(k.K, Color.Blue);
            keyboard.SetKey(k.U, Color.Blue);
            keyboard.SetKey(k.D6, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D8, backgroundCol);
            keyboard.SetKey(k.D6, backgroundCol);
            keyboard.SetKey(k.U, backgroundCol);
            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetKey(k.H, backgroundCol);
            keyboard.SetKey(k.OemComma, Color.Blue);
            keyboard.SetKey(k.J, Color.Blue);
            keyboard.SetKey(k.G, Color.Red);
            keyboard.SetKey(k.Y, Color.Red);
            keyboard.SetKey(k.D7, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.J, backgroundCol);
            keyboard.SetKey(k.OemComma, backgroundCol);
            keyboard.SetKey(k.K, Color.Blue);
            keyboard.SetKey(k.U, Color.Blue);
            keyboard.SetKey(k.D6, Color.Blue);
            keyboard.SetKey(k.G, backgroundCol);
            keyboard.SetKey(k.Y, backgroundCol);
            keyboard.SetKey(k.D7, backgroundCol);
            keyboard.SetKey(k.H, Color.Red);
            keyboard.SetKey(k.D8, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D6, backgroundCol);
            keyboard.SetKey(k.D8, backgroundCol);
            keyboard.SetKey(k.U, backgroundCol);
            keyboard.SetKey(k.H, backgroundCol);
            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetKey(k.L, Color.Blue);
            keyboard.SetKey(k.I, Color.Blue);
            keyboard.SetKey(k.D7, Color.Blue);
            keyboard.SetKey(k.N, Color.Red);
            keyboard.SetKey(k.J, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.L, backgroundCol);
            keyboard.SetKey(k.I, backgroundCol);
            keyboard.SetKey(k.D7, backgroundCol);
            keyboard.SetKey(k.N, backgroundCol);
            keyboard.SetKey(k.J, backgroundCol);
            keyboard.SetKey(k.H, Color.Red);
            keyboard.SetKey(k.D8, Color.Red);
            keyboard.SetKey(k.K, Color.Blue);
            keyboard.SetKey(k.U, Color.Blue);
            keyboard.SetKey(k.D6, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D6, backgroundCol);
            keyboard.SetKey(k.U, backgroundCol);
            keyboard.SetKey(k.D8, backgroundCol);
            keyboard.SetKey(k.B, backgroundCol);
            keyboard.SetKey(k.H, backgroundCol);
            keyboard.SetKey(k.OemPeriod, backgroundCol);
            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetPosition(4, 12, Color.Blue);
            keyboard.SetKey(k.L, Color.Blue);
            keyboard.SetKey(k.I, Color.Blue);
            keyboard.SetKey(k.V, Color.Red);
            keyboard.SetKey(k.G, Color.Red);
            keyboard.SetKey(k.Y, Color.Red);
            keyboard.SetKey(k.D7, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.L, backgroundCol);
            keyboard.SetKey(k.I, backgroundCol);
            keyboard.SetKey(k.OemSemicolon, Color.Blue);
            keyboard.SetKey(k.O, Color.Blue);
            keyboard.SetKey(k.D9, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.O, backgroundCol);
            keyboard.SetKey(k.D9, backgroundCol);
            keyboard.SetKey(k.P, Color.Blue);
            keyboard.SetKey(k.D0, Color.Blue);
            keyboard.SetKey(k.V, backgroundCol);
            keyboard.SetKey(k.G, backgroundCol);
            keyboard.SetKey(k.Y, backgroundCol);
            keyboard.SetKey(k.D7, backgroundCol);
            keyboard.SetKey(k.C, Color.Red);
            keyboard.SetKey(k.D, Color.Red);
            keyboard.SetKey(k.R, Color.Red);
            keyboard.SetKey(k.D5, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D0, backgroundCol);
            keyboard.SetKey(k.P, backgroundCol);
            keyboard.SetKey(k.OemSemicolon, backgroundCol);
            keyboard.SetKey(k.R, backgroundCol);
            keyboard.SetKey(k.D5, Color.Red);
            keyboard.SetKey(k.D5, backgroundCol);
            keyboard.SetKey(k.W, Color.Red);
            keyboard.SetKey(k.D2, Color.Red);
            keyboard.SetKey(k.OemApostrophe, Color.Blue);
            keyboard.SetKey(k.OemRightBracket, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemRightBracket, backgroundCol);
            keyboard.SetKey(k.OemApostrophe, backgroundCol);
            keyboard.SetKey(k.C, backgroundCol);
            keyboard.SetKey(k.D, backgroundCol);
            keyboard.SetKey(k.D2, backgroundCol);
            keyboard.SetKey(k.Q, Color.Red);
            keyboard.SetKey(k.E, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.Q, backgroundCol);
            keyboard.SetKey(k.W, backgroundCol);
            keyboard.SetKey(k.S, Color.Red);
            keyboard.SetKey(k.Z, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.Z, backgroundCol);
            keyboard.SetKey(k.S, backgroundCol);
            keyboard.SetKey(k.E, backgroundCol);
            keyboard.SetKey(k.D, Color.Red);
            keyboard.SetKey(k.C, Color.Red);
            keyboard.SetKey(k.C, backgroundCol);
            keyboard.SetKey(k.V, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.V, backgroundCol);
            keyboard.SetKey(k.F, Color.Red);
            keyboard.SetKey(k.T, Color.Red);
            keyboard.SetKey(k.Y, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.F, backgroundCol);
            keyboard.SetKey(k.T, backgroundCol);
            keyboard.SetKey(k.Y, backgroundCol);
            keyboard.SetKey(k.E, Color.Red);
            keyboard.SetKey(k.D3, Color.Red);
            keyboard.SetKey(k.F1, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.E, backgroundCol);
            keyboard.SetKey(k.D3, backgroundCol);
            keyboard.SetKey(k.F1, backgroundCol);
            keyboard.SetKey(k.W, Color.Red);
            keyboard.SetKey(k.D1, Color.Red);
            keyboard.SetKey(k.Escape, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.Escape, backgroundCol);
            keyboard.SetKey(k.D, backgroundCol);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.W, backgroundCol);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemPeriod, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemComma, Color.Blue);
            keyboard.SetKey(k.M, Color.Blue);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemComma, backgroundCol);
            keyboard.SetKey(k.M, backgroundCol);
            keyboard.SetKey(k.K, Color.Blue);
            keyboard.SetKey(k.J, Color.Blue);
            keyboard.SetKey(k.D1, backgroundCol);
            keyboard.SetKey(k.F1, Color.Red);
            keyboard.SetKey(k.D3, Color.Red);
            keyboard.SetKey(k.E, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.OemPeriod, backgroundCol);
            keyboard.SetKey(k.J, backgroundCol);
            keyboard.SetKey(k.L, Color.Blue);
            keyboard.SetKey(k.D3, backgroundCol);
            keyboard.SetKey(k.F1, backgroundCol);
            keyboard.SetKey(k.D4, Color.Red);
            keyboard.SetKey(k.F3, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.K, backgroundCol);
            keyboard.SetKey(k.L, backgroundCol);
            keyboard.SetPosition(4, 12, backgroundCol);
            keyboard.SetKey(k.OemSemicolon, Color.Blue);
            keyboard.SetKey(k.O, Color.Blue);
            keyboard.SetKey(k.D8, Color.Blue);
            keyboard.SetKey(k.F3, backgroundCol);
            keyboard.SetKey(k.D4, backgroundCol);
            keyboard.SetKey(k.E, backgroundCol);
            keyboard.SetKey(k.D6, Color.Red);
            keyboard.SetKey(k.T, Color.Red);
            keyboard.SetKey(k.F, Color.Red);

            Thread.Sleep(sleep);

            keyboard.SetKey(k.D6, backgroundCol);
            keyboard.SetKey(k.T, backgroundCol);
            keyboard.SetKey(k.F, backgroundCol);
            keyboard.SetKey(k.D8, backgroundCol);
            keyboard.SetKey(k.D9, Color.Blue);
            keyboard.SetPosition(4, 12, Color.Blue);
            keyboard.SetKey(k.K, Color.Red);
            keyboard.SetKey(k.M, Color.Red);
            keyboard.SetKey(k.D0, Color.Red);

            Thread.Sleep(sleep);
            #endregion
        }
        #endregion
    }
}