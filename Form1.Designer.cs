namespace RoboPitStop
{
    partial class Form1
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnImportarProdutos = new System.Windows.Forms.Button();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnGetPedidos = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.dataAte = new System.Windows.Forms.DateTimePicker();
            this.dataDe = new System.Windows.Forms.DateTimePicker();
            this.FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.btnFile = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtEstoque = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.EstoqueDialog = new System.Windows.Forms.OpenFileDialog();
            this.txtversao = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnImportarProdutos
            // 
            this.btnImportarProdutos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.btnImportarProdutos, "btnImportarProdutos");
            this.btnImportarProdutos.Name = "btnImportarProdutos";
            this.btnImportarProdutos.UseVisualStyleBackColor = false;
            this.btnImportarProdutos.Click += new System.EventHandler(this.btnImportarProdutos_Click);
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.Azure;
            this.txtLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            resources.ApplyResources(this.txtLog, "txtLog");
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            // 
            // btnGetPedidos
            // 
            this.btnGetPedidos.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.btnGetPedidos, "btnGetPedidos");
            this.btnGetPedidos.Name = "btnGetPedidos";
            this.btnGetPedidos.UseVisualStyleBackColor = false;
            this.btnGetPedidos.Click += new System.EventHandler(this.btnGetPedidos_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            resources.ApplyResources(this.button2, "button2");
            this.button2.Name = "button2";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // dataAte
            // 
            resources.ApplyResources(this.dataAte, "dataAte");
            this.dataAte.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataAte.Name = "dataAte";
            // 
            // dataDe
            // 
            resources.ApplyResources(this.dataDe, "dataDe");
            this.dataDe.CalendarMonthBackground = System.Drawing.Color.Azure;
            this.dataDe.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dataDe.Name = "dataDe";
            // 
            // FileDialog
            // 
            resources.ApplyResources(this.FileDialog, "FileDialog");
            this.FileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.FileDialog_FileOk);
            // 
            // btnFile
            // 
            this.btnFile.BackColor = System.Drawing.Color.MidnightBlue;
            resources.ApplyResources(this.btnFile, "btnFile");
            this.btnFile.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnFile.Name = "btnFile";
            this.btnFile.UseVisualStyleBackColor = false;
            this.btnFile.Click += new System.EventHandler(this.btnFile_Click);
            // 
            // txtFile
            // 
            this.txtFile.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.txtFile, "txtFile");
            this.txtFile.Name = "txtFile";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grip;
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.BackColor = System.Drawing.Color.Azure;
            this.groupBox1.Controls.Add(this.btnFile);
            this.groupBox1.Controls.Add(this.txtFile);
            this.groupBox1.Controls.Add(this.btnImportarProdutos);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            this.groupBox1.UseCompatibleTextRendering = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Azure;
            this.groupBox2.Controls.Add(this.dataDe);
            this.groupBox2.Controls.Add(this.btnGetPedidos);
            this.groupBox2.Controls.Add(this.dataAte);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.Azure;
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.txtEstoque);
            this.groupBox3.Controls.Add(this.button2);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.ForeColor = System.Drawing.Color.MidnightBlue;
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.MidnightBlue;
            resources.ApplyResources(this.button1, "button1");
            this.button1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button1.Name = "button1";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtEstoque
            // 
            this.txtEstoque.BackColor = System.Drawing.Color.Azure;
            resources.ApplyResources(this.txtEstoque, "txtEstoque");
            this.txtEstoque.Name = "txtEstoque";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // EstoqueDialog
            // 
            resources.ApplyResources(this.EstoqueDialog, "EstoqueDialog");
            this.EstoqueDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.EstoqueDialog_FileOk);
            // 
            // txtversao
            // 
            resources.ApplyResources(this.txtversao, "txtversao");
            this.txtversao.Name = "txtversao";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Azure;
            this.Controls.Add(this.txtversao);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtLog);
            this.Name = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnImportarProdutos;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.Button btnGetPedidos;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.DateTimePicker dataAte;
        private System.Windows.Forms.DateTimePicker dataDe;
        private System.Windows.Forms.OpenFileDialog FileDialog;
        private System.Windows.Forms.Button btnFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtEstoque;
        private System.Windows.Forms.OpenFileDialog EstoqueDialog;
        private System.Windows.Forms.Label txtversao;
    }
}

