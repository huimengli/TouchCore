namespace TouchCore
{
    partial class Mouse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Mouse));
            this.LeftMouse = new System.Windows.Forms.Button();
            this.RightMouse = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // LeftMouse
            // 
            resources.ApplyResources(this.LeftMouse, "LeftMouse");
            this.LeftMouse.Name = "LeftMouse";
            this.LeftMouse.UseVisualStyleBackColor = true;
            // 
            // RightMouse
            // 
            resources.ApplyResources(this.RightMouse, "RightMouse");
            this.RightMouse.Name = "RightMouse";
            this.RightMouse.UseVisualStyleBackColor = true;
            // 
            // ExitButton
            // 
            resources.ApplyResources(this.ExitButton, "ExitButton");
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.UseVisualStyleBackColor = true;
            // 
            // Mouse
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.RightMouse);
            this.Controls.Add(this.LeftMouse);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Mouse";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Resize += new System.EventHandler(this.Mouse_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LeftMouse;
        private System.Windows.Forms.Button RightMouse;
        private System.Windows.Forms.Button ExitButton;
    }
}