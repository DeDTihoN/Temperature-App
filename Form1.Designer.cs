using MaterialSkin.Controls;

namespace CityTemperature
{
    partial class Form1
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

        // Инициализация компонентов формы 
        private void InitializeComponent()
        {
            this.CityNameBox = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.ResultButton = new MaterialSkin.Controls.MaterialRaisedButton();
            this.ResultLabel = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();

            this.CityNameBox.Depth = 0;
            this.CityNameBox.Hint = "";
            this.CityNameBox.Location = new System.Drawing.Point(107, 79);
            this.CityNameBox.MouseState = MaterialSkin.MouseState.HOVER;
            this.CityNameBox.Name = "CityNameBox";
            this.CityNameBox.PasswordChar = '\0';
            this.CityNameBox.SelectedText = "";
            this.CityNameBox.SelectionLength = 0;
            this.CityNameBox.SelectionStart = 0;
            this.CityNameBox.Size = new System.Drawing.Size(166, 23);
            this.CityNameBox.TabIndex = 0;
            this.CityNameBox.Text = "Введите город";
            this.CityNameBox.UseSystemPasswordChar = false;
            // Добавление обработчиков событий для CityNameBox 
            this.CityNameBox.Click += new System.EventHandler(this.CityNameBox_Click);
            

            // Настройка ResultButton и добавления обработчика события 
            this.ResultButton.Depth = 0;
            this.ResultButton.Location = new System.Drawing.Point(132, 127);
            this.ResultButton.MouseState = MaterialSkin.MouseState.HOVER;
            this.ResultButton.Name = "ResultButton";
            this.ResultButton.Primary = true;
            this.ResultButton.Size = new System.Drawing.Size(124, 52);
            this.ResultButton.TabIndex = 1;
            this.ResultButton.Text = "получить текущую температуру";
            this.ResultButton.UseVisualStyleBackColor = true;
            this.ResultButton.Click += new System.EventHandler(this.button1_Click);
            

            // Настройка ResultLabel 
            this.ResultLabel.AutoSize = true;
            this.ResultLabel.Depth = 0;
            this.ResultLabel.Font = new System.Drawing.Font("Roboto", 11F);
            this.ResultLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.ResultLabel.Location = new System.Drawing.Point(12, 202);
            this.ResultLabel.MouseState = MaterialSkin.MouseState.HOVER;
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(0, 19);
            this.ResultLabel.TabIndex = 2;
            
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 272);
            // Добавление компонентов на форму 
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.ResultButton);
            this.Controls.Add(this.CityNameBox);
            this.Name = "Form1";
            this.Text = "Температура города";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSingleLineTextField CityNameBox;
        private MaterialRaisedButton ResultButton;
        private MaterialLabel ResultLabel;
    }
}

