namespace KeyReBind {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MainStatus = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.MainView = new System.Windows.Forms.TableLayoutPanel();
            this.ControlView = new System.Windows.Forms.TableLayoutPanel();
            this.Bind = new System.Windows.Forms.Button();
            this.UnBind = new System.Windows.Forms.Button();
            this.ConsoleView = new System.Windows.Forms.TextBox();
            this.MainStatus.SuspendLayout();
            this.MainView.SuspendLayout();
            this.ControlView.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainStatus
            // 
            this.MainStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.MainStatus.Location = new System.Drawing.Point(0, 277);
            this.MainStatus.Name = "MainStatus";
            this.MainStatus.Size = new System.Drawing.Size(436, 22);
            this.MainStatus.TabIndex = 0;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(10, 17);
            this.StatusLabel.Text = " ";
            // 
            // MainView
            // 
            this.MainView.ColumnCount = 1;
            this.MainView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.MainView.Controls.Add(this.ControlView, 0, 1);
            this.MainView.Controls.Add(this.ConsoleView, 0, 0);
            this.MainView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainView.Location = new System.Drawing.Point(0, 0);
            this.MainView.Margin = new System.Windows.Forms.Padding(1);
            this.MainView.Name = "MainView";
            this.MainView.RowCount = 2;
            this.MainView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.MainView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13F));
            this.MainView.Size = new System.Drawing.Size(436, 277);
            this.MainView.TabIndex = 1;
            // 
            // ControlView
            // 
            this.ControlView.ColumnCount = 2;
            this.ControlView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlView.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.ControlView.Controls.Add(this.Bind, 0, 0);
            this.ControlView.Controls.Add(this.UnBind, 1, 0);
            this.ControlView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ControlView.Location = new System.Drawing.Point(1, 241);
            this.ControlView.Margin = new System.Windows.Forms.Padding(1);
            this.ControlView.Name = "ControlView";
            this.ControlView.RowCount = 1;
            this.ControlView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ControlView.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.ControlView.Size = new System.Drawing.Size(434, 35);
            this.ControlView.TabIndex = 0;
            // 
            // Bind
            // 
            this.Bind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bind.Location = new System.Drawing.Point(2, 2);
            this.Bind.Margin = new System.Windows.Forms.Padding(2);
            this.Bind.Name = "Bind";
            this.Bind.Size = new System.Drawing.Size(213, 31);
            this.Bind.TabIndex = 0;
            this.Bind.Text = "Bind";
            this.Bind.UseVisualStyleBackColor = true;
            this.Bind.Click += new System.EventHandler(this.Bind_Click);
            // 
            // UnBind
            // 
            this.UnBind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UnBind.Location = new System.Drawing.Point(219, 2);
            this.UnBind.Margin = new System.Windows.Forms.Padding(2);
            this.UnBind.Name = "UnBind";
            this.UnBind.Size = new System.Drawing.Size(213, 31);
            this.UnBind.TabIndex = 1;
            this.UnBind.Text = "UnBind";
            this.UnBind.UseVisualStyleBackColor = true;
            this.UnBind.Click += new System.EventHandler(this.UnBind_Click);
            // 
            // ConsoleView
            // 
            this.ConsoleView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConsoleView.Location = new System.Drawing.Point(2, 2);
            this.ConsoleView.Margin = new System.Windows.Forms.Padding(2);
            this.ConsoleView.Multiline = true;
            this.ConsoleView.Name = "ConsoleView";
            this.ConsoleView.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ConsoleView.Size = new System.Drawing.Size(432, 236);
            this.ConsoleView.TabIndex = 1;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 299);
            this.Controls.Add(this.MainView);
            this.Controls.Add(this.MainStatus);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.MainStatus.ResumeLayout(false);
            this.MainStatus.PerformLayout();
            this.MainView.ResumeLayout(false);
            this.MainView.PerformLayout();
            this.ControlView.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip MainStatus;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabel;
        private System.Windows.Forms.TableLayoutPanel MainView;
        private System.Windows.Forms.TableLayoutPanel ControlView;
        private System.Windows.Forms.Button Bind;
        private System.Windows.Forms.Button UnBind;
        private System.Windows.Forms.TextBox ConsoleView;
    }
}