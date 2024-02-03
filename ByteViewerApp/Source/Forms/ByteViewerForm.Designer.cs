using ByteViewerApp.Source;

namespace ByteViewerApp
{
    partial class ByteViewerForm
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ByteViewerForm));
            openFileDialog1 = new OpenFileDialog();
            byteViewDataGrid = new DataGridView();
            offset = new DataGridViewTextBoxColumn();
            bytes = new DataGridViewTextBoxColumn();
            symbols = new DataGridViewTextBoxColumn();
            tableLayoutPanel4 = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            encodingTypeComboBox = new ComboBox();
            label2 = new Label();
            offsetNumericUpDown = new NumericUpDown();
            offsetFileBtn = new Button();
            loadFileBtn = new Button();
            offsetLabel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            scrollBar = new DataGridScrollBar();
            ((System.ComponentModel.ISupportInitialize)byteViewDataGrid).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)offsetNumericUpDown).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            SuspendLayout();
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // byteViewDataGrid
            // 
            byteViewDataGrid.AllowUserToAddRows = false;
            byteViewDataGrid.AllowUserToDeleteRows = false;
            byteViewDataGrid.AllowUserToResizeColumns = false;
            byteViewDataGrid.AllowUserToResizeRows = false;
            byteViewDataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            byteViewDataGrid.BackgroundColor = Color.AliceBlue;
            byteViewDataGrid.CellBorderStyle = DataGridViewCellBorderStyle.RaisedVertical;
            byteViewDataGrid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.AliceBlue;
            dataGridViewCellStyle1.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = Color.AliceBlue;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            byteViewDataGrid.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            byteViewDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            byteViewDataGrid.Columns.AddRange(new DataGridViewColumn[] { offset, bytes, symbols });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = SystemColors.Window;
            dataGridViewCellStyle5.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle5.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = SystemColors.Window;
            dataGridViewCellStyle5.SelectionForeColor = SystemColors.ControlText;
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            byteViewDataGrid.DefaultCellStyle = dataGridViewCellStyle5;
            byteViewDataGrid.Dock = DockStyle.Fill;
            byteViewDataGrid.Enabled = false;
            byteViewDataGrid.EnableHeadersVisualStyles = false;
            byteViewDataGrid.GridColor = SystemColors.HighlightText;
            byteViewDataGrid.Location = new Point(3, 3);
            byteViewDataGrid.Name = "byteViewDataGrid";
            byteViewDataGrid.ReadOnly = true;
            byteViewDataGrid.RowHeadersVisible = false;
            byteViewDataGrid.RowHeadersWidth = 51;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            byteViewDataGrid.RowsDefaultCellStyle = dataGridViewCellStyle6;
            byteViewDataGrid.ScrollBars = ScrollBars.None;
            byteViewDataGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            byteViewDataGrid.Size = new Size(1200, 538);
            byteViewDataGrid.TabIndex = 3;
            // 
            // offset
            // 
            offset.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            offset.DefaultCellStyle = dataGridViewCellStyle2;
            offset.FillWeight = 15F;
            offset.HeaderText = "смещение";
            offset.MinimumWidth = 10;
            offset.Name = "offset";
            offset.ReadOnly = true;
            offset.Resizable = DataGridViewTriState.True;
            offset.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // bytes
            // 
            bytes.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Font = new Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.True;
            bytes.DefaultCellStyle = dataGridViewCellStyle3;
            bytes.FillWeight = 55F;
            bytes.HeaderText = "байтовое представление";
            bytes.MinimumWidth = 6;
            bytes.Name = "bytes";
            bytes.ReadOnly = true;
            bytes.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // symbols
            // 
            symbols.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new Font("Courier New", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            symbols.DefaultCellStyle = dataGridViewCellStyle4;
            symbols.FillWeight = 30F;
            symbols.HeaderText = "символьное представление";
            symbols.MinimumWidth = 6;
            symbols.Name = "symbols";
            symbols.ReadOnly = true;
            symbols.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.BackColor = Color.Lavender;
            tableLayoutPanel4.ColumnCount = 1;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel4.Controls.Add(tableLayoutPanel1, 0, 0);
            tableLayoutPanel4.Controls.Add(tableLayoutPanel2, 0, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(0, 0);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 60F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Absolute, 550F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 40F));
            tableLayoutPanel4.Size = new Size(1232, 653);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(encodingTypeComboBox, 0, 1);
            tableLayoutPanel1.Controls.Add(label2, 0, 0);
            tableLayoutPanel1.Controls.Add(offsetNumericUpDown, 1, 1);
            tableLayoutPanel1.Controls.Add(offsetFileBtn, 2, 1);
            tableLayoutPanel1.Controls.Add(loadFileBtn, 3, 1);
            tableLayoutPanel1.Controls.Add(offsetLabel, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 3);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 34.848484F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 65.15151F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1226, 55);
            tableLayoutPanel1.TabIndex = 8;
            // 
            // encodingTypeComboBox
            // 
            encodingTypeComboBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            encodingTypeComboBox.BackColor = Color.AliceBlue;
            encodingTypeComboBox.FormattingEnabled = true;
            encodingTypeComboBox.Items.AddRange(new object[] { BufferedFileReader.EncodingType.UTF8, BufferedFileReader.EncodingType.UTF32, BufferedFileReader.EncodingType.UTF16BE, BufferedFileReader.EncodingType.UTF16LE, BufferedFileReader.EncodingType.ASCII });
            encodingTypeComboBox.Location = new Point(3, 22);
            encodingTypeComboBox.Name = "encodingTypeComboBox";
            encodingTypeComboBox.Size = new Size(300, 25);
            encodingTypeComboBox.TabIndex = 8;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.Location = new Point(3, 2);
            label2.Name = "label2";
            label2.Size = new Size(98, 17);
            label2.TabIndex = 8;
            label2.Text = "кодировка:";
            // 
            // offsetNumericUpDown
            // 
            offsetNumericUpDown.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            offsetNumericUpDown.BackColor = Color.AliceBlue;
            offsetNumericUpDown.Hexadecimal = true;
            offsetNumericUpDown.Increment = new decimal(new int[] { 16, 0, 0, 0 });
            offsetNumericUpDown.Location = new Point(309, 22);
            offsetNumericUpDown.Maximum = new decimal(new int[] { -1, int.MaxValue, 0, 0 });
            offsetNumericUpDown.Name = "offsetNumericUpDown";
            offsetNumericUpDown.Size = new Size(300, 24);
            offsetNumericUpDown.TabIndex = 2;
            // 
            // offsetFileBtn
            // 
            offsetFileBtn.BackColor = Color.AliceBlue;
            offsetFileBtn.Location = new Point(615, 22);
            offsetFileBtn.Name = "offsetFileBtn";
            offsetFileBtn.Size = new Size(169, 24);
            offsetFileBtn.TabIndex = 5;
            offsetFileBtn.Text = "сместить файл";
            offsetFileBtn.UseVisualStyleBackColor = false;
            offsetFileBtn.Click += OffsetFile_Click;
            // 
            // loadFileBtn
            // 
            loadFileBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            loadFileBtn.BackColor = Color.Thistle;
            loadFileBtn.Location = new Point(1054, 22);
            loadFileBtn.Name = "loadFileBtn";
            loadFileBtn.Size = new Size(169, 24);
            loadFileBtn.TabIndex = 7;
            loadFileBtn.Text = "загрузить файл";
            loadFileBtn.UseVisualStyleBackColor = false;
            loadFileBtn.Click += LoadFile_Click;
            // 
            // offsetLabel
            // 
            offsetLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            offsetLabel.AutoSize = true;
            offsetLabel.Location = new Point(309, 2);
            offsetLabel.Name = "offsetLabel";
            offsetLabel.Size = new Size(0, 17);
            offsetLabel.TabIndex = 8;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Controls.Add(byteViewDataGrid, 0, 0);
            tableLayoutPanel2.Controls.Add(scrollBar, 1, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(3, 64);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(1226, 544);
            tableLayoutPanel2.TabIndex = 9;
            // 
            // scrollBar
            // 
            scrollBar.Dock = DockStyle.Fill;
            scrollBar.Enabled = false;
            scrollBar.LargeChange = 1;
            scrollBar.Location = new Point(1206, 0);
            scrollBar.Name = "scrollBar";
            scrollBar.Size = new Size(20, 544);
            scrollBar.TabIndex = 4;
            scrollBar.ScrollUp += LoadRows_ScrollUp;
            scrollBar.ScrollDown += LoadRows_ScrollDown;
            scrollBar.ValueChanged += ScrollBar_ValueChanged;
            // 
            // ByteViewerForm
            // 
            AutoScaleDimensions = new SizeF(9F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 653);
            Controls.Add(tableLayoutPanel4);
            Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimumSize = new Size(1250, 700);
            Name = "ByteViewerForm";
            Text = "ByteViewer";
            ((System.ComponentModel.ISupportInitialize)byteViewDataGrid).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)offsetNumericUpDown).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private OpenFileDialog openFileDialog1;
        private DataGridView byteViewDataGrid;
        private TableLayoutPanel tableLayoutPanel4;
        private TableLayoutPanel tableLayoutPanel1;
        private NumericUpDown offsetNumericUpDown;
        private Button offsetFileBtn;
        private Button loadFileBtn;
        private Label offsetLabel;
        private Label label2;
        private ComboBox encodingTypeComboBox;
        private DataGridViewTextBoxColumn offset;
        private DataGridViewTextBoxColumn bytes;
        private DataGridViewTextBoxColumn symbols;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridScrollBar scrollBar;
    }
}
