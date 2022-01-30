
namespace EscánerDML
{
    partial class Form
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvOutput = new System.Windows.Forms.DataGridView();
            this.cbxOpciones = new System.Windows.Forms.ComboBox();
            this.btnEscanear = new System.Windows.Forms.Button();
            this.rtbInput = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvOutput
            // 
            this.dgvOutput.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOutput.Location = new System.Drawing.Point(12, 192);
            this.dgvOutput.Name = "dgvOutput";
            this.dgvOutput.Size = new System.Drawing.Size(447, 347);
            this.dgvOutput.TabIndex = 0;
            // 
            // cbxOpciones
            // 
            this.cbxOpciones.FormattingEnabled = true;
            this.cbxOpciones.Location = new System.Drawing.Point(12, 154);
            this.cbxOpciones.Name = "cbxOpciones";
            this.cbxOpciones.Size = new System.Drawing.Size(285, 21);
            this.cbxOpciones.TabIndex = 1;
            // 
            // btnEscanear
            // 
            this.btnEscanear.Location = new System.Drawing.Point(303, 154);
            this.btnEscanear.Name = "btnEscanear";
            this.btnEscanear.Size = new System.Drawing.Size(156, 22);
            this.btnEscanear.TabIndex = 2;
            this.btnEscanear.Text = "button1";
            this.btnEscanear.UseVisualStyleBackColor = true;
            this.btnEscanear.Click += new System.EventHandler(this.btnEscanear_Click);
            // 
            // rtbInput
            // 
            this.rtbInput.Location = new System.Drawing.Point(12, 15);
            this.rtbInput.Name = "rtbInput";
            this.rtbInput.Size = new System.Drawing.Size(447, 124);
            this.rtbInput.TabIndex = 3;
            this.rtbInput.Text = "";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(471, 551);
            this.Controls.Add(this.rtbInput);
            this.Controls.Add(this.btnEscanear);
            this.Controls.Add(this.cbxOpciones);
            this.Controls.Add(this.dgvOutput);
            this.Name = "Form";
            this.Text = "Escaner DML";
            this.Load += new System.EventHandler(this.Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOutput)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOutput;
        private System.Windows.Forms.ComboBox cbxOpciones;
        private System.Windows.Forms.Button btnEscanear;
        private System.Windows.Forms.RichTextBox rtbInput;
    }
}

