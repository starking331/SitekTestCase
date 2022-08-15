namespace SitekTestCase
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pathRkk = new System.Windows.Forms.TextBox();
            this.selectPathRkk = new System.Windows.Forms.Button();
            this.selectPathRecourse = new System.Windows.Forms.Button();
            this.pathRecourse = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.resultGrid = new System.Windows.Forms.DataGridView();
            this.Executor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountRkk = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountRecourse = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AmountDocument = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrderNum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.algorythmTimeLable = new System.Windows.Forms.Label();
            this.saveReport = new System.Windows.Forms.Button();
            this.algorythmTimeValue = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pathRkk
            // 
            this.pathRkk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pathRkk.Location = new System.Drawing.Point(12, 12);
            this.pathRkk.Name = "pathRkk";
            this.pathRkk.PlaceholderText = "Файл РКК";
            this.pathRkk.Size = new System.Drawing.Size(574, 23);
            this.pathRkk.TabIndex = 0;
            // 
            // selectPathRkk
            // 
            this.selectPathRkk.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectPathRkk.Location = new System.Drawing.Point(592, 12);
            this.selectPathRkk.Name = "selectPathRkk";
            this.selectPathRkk.Size = new System.Drawing.Size(196, 23);
            this.selectPathRkk.TabIndex = 1;
            this.selectPathRkk.Text = "Выбрать файл РКК";
            this.selectPathRkk.UseVisualStyleBackColor = true;
            this.selectPathRkk.Click += new System.EventHandler(this.selectPathRkk_Click);
            // 
            // selectPathRecourse
            // 
            this.selectPathRecourse.Location = new System.Drawing.Point(592, 41);
            this.selectPathRecourse.Name = "selectPathRecourse";
            this.selectPathRecourse.Size = new System.Drawing.Size(196, 23);
            this.selectPathRecourse.TabIndex = 3;
            this.selectPathRecourse.Text = "Выбрать файл с обращениями";
            this.selectPathRecourse.UseVisualStyleBackColor = true;
            this.selectPathRecourse.Click += new System.EventHandler(this.selectPathRecourse_Click);
            // 
            // pathRecourse
            // 
            this.pathRecourse.Location = new System.Drawing.Point(12, 41);
            this.pathRecourse.Name = "pathRecourse";
            this.pathRecourse.PlaceholderText = "Файл с обращениями";
            this.pathRecourse.Size = new System.Drawing.Size(574, 23);
            this.pathRecourse.TabIndex = 2;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.startButton.Enabled = false;
            this.startButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.startButton.Location = new System.Drawing.Point(12, 70);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(776, 41);
            this.startButton.TabIndex = 4;
            this.startButton.Text = "Запустить Алгоритм";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resultGrid
            // 
            this.resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.resultGrid.BackgroundColor = System.Drawing.SystemColors.ButtonShadow;
            this.resultGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.resultGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Executor,
            this.AmountRkk,
            this.AmountRecourse,
            this.AmountDocument});
            this.resultGrid.Location = new System.Drawing.Point(12, 117);
            this.resultGrid.Name = "resultGrid";
            this.resultGrid.RowTemplate.Height = 25;
            this.resultGrid.Size = new System.Drawing.Size(776, 286);
            this.resultGrid.TabIndex = 5;
            // 
            // Executor
            // 
            this.Executor.HeaderText = "Ответсвенный исполнитель";
            this.Executor.Name = "Executor";
            // 
            // AmountRkk
            // 
            this.AmountRkk.HeaderText = "Количество неисполненных входящих документов";
            this.AmountRkk.Name = "AmountRkk";
            // 
            // AmountRecourse
            // 
            this.AmountRecourse.HeaderText = "Количество неисполненных письменных обращений граждан";
            this.AmountRecourse.Name = "AmountRecourse";
            // 
            // AmountDocument
            // 
            this.AmountDocument.HeaderText = "Общее количество документов и обращений";
            this.AmountDocument.Name = "AmountDocument";
            // 
            // OrderNum
            // 
            this.OrderNum.HeaderText = "№ п.п.";
            this.OrderNum.Name = "OrderNum";
            // 
            // algorythmTimeLable
            // 
            this.algorythmTimeLable.AutoSize = true;
            this.algorythmTimeLable.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.algorythmTimeLable.Location = new System.Drawing.Point(12, 416);
            this.algorythmTimeLable.Name = "algorythmTimeLable";
            this.algorythmTimeLable.Size = new System.Drawing.Size(236, 25);
            this.algorythmTimeLable.TabIndex = 6;
            this.algorythmTimeLable.Text = "Время работы алгоритма:";
            // 
            // saveReport
            // 
            this.saveReport.Enabled = false;
            this.saveReport.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.saveReport.Location = new System.Drawing.Point(570, 413);
            this.saveReport.Name = "saveReport";
            this.saveReport.Size = new System.Drawing.Size(218, 32);
            this.saveReport.TabIndex = 7;
            this.saveReport.Text = "Сохранить отчёт";
            this.saveReport.UseVisualStyleBackColor = true;
            this.saveReport.Click += new System.EventHandler(this.saveReport_Click);
            // 
            // algorythmTimeValue
            // 
            this.algorythmTimeValue.AutoSize = true;
            this.algorythmTimeValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.algorythmTimeValue.Location = new System.Drawing.Point(254, 416);
            this.algorythmTimeValue.Name = "algorythmTimeValue";
            this.algorythmTimeValue.Size = new System.Drawing.Size(0, 25);
            this.algorythmTimeValue.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.algorythmTimeValue);
            this.Controls.Add(this.saveReport);
            this.Controls.Add(this.algorythmTimeLable);
            this.Controls.Add(this.resultGrid);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.selectPathRecourse);
            this.Controls.Add(this.pathRecourse);
            this.Controls.Add(this.selectPathRkk);
            this.Controls.Add(this.pathRkk);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.resultGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox pathRkk;
        private Button selectPathRkk;
        private Button selectPathRecourse;
        private TextBox pathRecourse;
        private Button startButton;
        private DataGridView resultGrid;
        private Label algorythmTimeLable;
        private Button saveReport;
        private Label algorythmTimeValue;
        private DataGridViewTextBoxColumn OrderNum;
        private DataGridViewTextBoxColumn Executor;
        private DataGridViewTextBoxColumn AmountRkk;
        private DataGridViewTextBoxColumn AmountRecourse;
        private DataGridViewTextBoxColumn AmountDocument;
    }
}