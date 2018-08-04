using System;
using System.Windows.Forms;

namespace KeyReBind {

    public partial class MainForm : Form {
        private Maneuver m;

        public MainForm() {
            InitializeComponent();

            Init();
        }

        private void Init() {
            string path = System.Reflection.Assembly.GetExecutingAssembly().Location;
            m = new Maneuver(System.IO.Path.GetDirectoryName(path) + @"\Setting.xml");

            SysCaller.Init();
            SysCaller.SetManeuver(m);

            StatusLabel.Text = @"フック ( 未 )";
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            if (SysCaller.IsHooking()) {
                SysCaller.UnHook();
            }
        }

        private void Bind_Click(object s, EventArgs e) {
            if (SysCaller.IsHooking()) {
                return;
            }

            StatusLabel.Text = @"フック ( 済 )";
            SysCaller.Hook();
        }

        private void UnBind_Click(object s, EventArgs e) {
            if (!SysCaller.IsHooking()) {
                return;
            }

            StatusLabel.Text = @"フック ( 未 )";
            SysCaller.UnHook();
        }
    }
}