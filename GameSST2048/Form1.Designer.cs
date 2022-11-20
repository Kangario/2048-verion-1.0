namespace GameSST2048
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.gameControl = new GameProject.GameControl();
            this.SuspendLayout();
            // 
            // gameControl
            // 
            this.gameControl.Location = new System.Drawing.Point(9, 10);
            this.gameControl.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.gameControl.Name = "gameControl";
            this.gameControl.Size = new System.Drawing.Size(399, 300);
            this.gameControl.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 343);
            this.Controls.Add(this.gameControl);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "MainForm";
            this.Text = "GameSST2048";
            this.ResumeLayout(false);

        }

        #endregion

        private GameProject.GameControl gameControl;
    }
}

