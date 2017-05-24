namespace plotTool
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

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ServerIPText = new System.Windows.Forms.TextBox();
            this.ServerPortText = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connectButton = new System.Windows.Forms.Button();
            this.PlotButton = new System.Windows.Forms.Button();
            this.PlottingListBox = new System.Windows.Forms.CheckedListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IP:";
            // 
            // ServerIPText
            // 
            this.ServerIPText.Location = new System.Drawing.Point(82, 16);
            this.ServerIPText.Name = "ServerIPText";
            this.ServerIPText.Size = new System.Drawing.Size(150, 20);
            this.ServerIPText.TabIndex = 1;
            // 
            // ServerPortText
            // 
            this.ServerPortText.Location = new System.Drawing.Point(298, 16);
            this.ServerPortText.Name = "ServerPortText";
            this.ServerPortText.Size = new System.Drawing.Size(100, 20);
            this.ServerPortText.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Port:";
            // 
            // connectButton
            // 
            this.connectButton.Location = new System.Drawing.Point(333, 209);
            this.connectButton.Name = "connectButton";
            this.connectButton.Size = new System.Drawing.Size(75, 23);
            this.connectButton.TabIndex = 4;
            this.connectButton.Text = "Connect";
            this.connectButton.UseVisualStyleBackColor = true;
            this.connectButton.Click += new System.EventHandler(this.connectButton_Click);
            // 
            // PlotButton
            // 
            this.PlotButton.Location = new System.Drawing.Point(333, 270);
            this.PlotButton.Name = "PlotButton";
            this.PlotButton.Size = new System.Drawing.Size(75, 23);
            this.PlotButton.TabIndex = 5;
            this.PlotButton.Text = "Plot";
            this.PlotButton.UseVisualStyleBackColor = true;
            this.PlotButton.Click += new System.EventHandler(this.PlotButton_Click);
            // 
            // PlottingListBox
            // 
            this.PlottingListBox.FormattingEnabled = true;
            this.PlottingListBox.Location = new System.Drawing.Point(44, 89);
            this.PlottingListBox.Name = "PlottingListBox";
            this.PlottingListBox.Size = new System.Drawing.Size(188, 244);
            this.PlottingListBox.TabIndex = 6;
            this.PlottingListBox.SelectedIndexChanged += new System.EventHandler(this.PlottingListBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 384);
            this.Controls.Add(this.PlottingListBox);
            this.Controls.Add(this.PlotButton);
            this.Controls.Add(this.connectButton);
            this.Controls.Add(this.ServerPortText);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerIPText);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Plotting Tool";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ServerIPText;
        private System.Windows.Forms.TextBox ServerPortText;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connectButton;
        private System.Windows.Forms.Button PlotButton;
        private System.Windows.Forms.CheckedListBox PlottingListBox;
    }
}

