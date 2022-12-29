namespace TouchCore
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.CloseButton = new System.Windows.Forms.Button();
            this.ChangeButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.NewButton = new System.Windows.Forms.Button();
            this.Rocker = new System.Windows.Forms.Button();
            this.RockerButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.RockerButton)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.Transparent;
            this.CloseButton.BackgroundImage = global::TouchCore.Properties.Resources.Close;
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseButton.Location = new System.Drawing.Point(13, 13);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(60, 60);
            this.CloseButton.TabIndex = 0;
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // ChangeButton
            // 
            this.ChangeButton.BackColor = System.Drawing.Color.Transparent;
            this.ChangeButton.BackgroundImage = global::TouchCore.Properties.Resources.Move;
            this.ChangeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ChangeButton.Location = new System.Drawing.Point(79, 13);
            this.ChangeButton.Name = "ChangeButton";
            this.ChangeButton.Size = new System.Drawing.Size(60, 60);
            this.ChangeButton.TabIndex = 1;
            this.ChangeButton.UseVisualStyleBackColor = false;
            this.ChangeButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = global::TouchCore.Properties.Resources.button;
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(504, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 60);
            this.button2.TabIndex = 2;
            this.button2.Text = "A";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunction);
            this.button2.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunction);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.BackgroundImage = global::TouchCore.Properties.Resources.button;
            this.button3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(570, 211);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(60, 60);
            this.button3.TabIndex = 3;
            this.button3.Text = "S";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunction);
            this.button3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunction);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Transparent;
            this.button4.BackgroundImage = global::TouchCore.Properties.Resources.button;
            this.button4.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button4.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(636, 211);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(60, 60);
            this.button4.TabIndex = 4;
            this.button4.Text = "D";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunction);
            this.button4.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunction);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Transparent;
            this.button5.BackgroundImage = global::TouchCore.Properties.Resources.button;
            this.button5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button5.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(570, 145);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(60, 60);
            this.button5.TabIndex = 5;
            this.button5.Text = "W";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MouseDownFunction);
            this.button5.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MouseUpFunction);
            // 
            // NewButton
            // 
            this.NewButton.BackColor = System.Drawing.Color.Transparent;
            this.NewButton.BackgroundImage = global::TouchCore.Properties.Resources.New;
            this.NewButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.NewButton.Location = new System.Drawing.Point(145, 13);
            this.NewButton.Name = "NewButton";
            this.NewButton.Size = new System.Drawing.Size(60, 60);
            this.NewButton.TabIndex = 6;
            this.NewButton.UseVisualStyleBackColor = false;
            // 
            // Rocker
            // 
            this.Rocker.BackColor = System.Drawing.Color.Transparent;
            this.Rocker.BackgroundImage = global::TouchCore.Properties.Resources.rocker;
            this.Rocker.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Rocker.Location = new System.Drawing.Point(13, 138);
            this.Rocker.Name = "Rocker";
            this.Rocker.Size = new System.Drawing.Size(300, 300);
            this.Rocker.TabIndex = 7;
            this.Rocker.UseVisualStyleBackColor = false;
            this.Rocker.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LeftRockerMouseDown);
            this.Rocker.MouseMove += new System.Windows.Forms.MouseEventHandler(this.LeftRockerMouseMove);
            this.Rocker.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LeftRockerMouseUp);
            // 
            // RockerButton
            // 
            this.RockerButton.BackColor = System.Drawing.Color.Transparent;
            this.RockerButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.RockerButton.Image = global::TouchCore.Properties.Resources.RockerButton;
            this.RockerButton.Location = new System.Drawing.Point(131, 257);
            this.RockerButton.Name = "RockerButton";
            this.RockerButton.Size = new System.Drawing.Size(60, 60);
            this.RockerButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.RockerButton.TabIndex = 8;
            this.RockerButton.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TouchCore.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.RockerButton);
            this.Controls.Add(this.Rocker);
            this.Controls.Add(this.NewButton);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.ChangeButton);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Main";
            this.RightToLeftLayout = true;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RockerButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Button ChangeButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button NewButton;
        private System.Windows.Forms.Button Rocker;
        private System.Windows.Forms.PictureBox RockerButton;
    }
}

