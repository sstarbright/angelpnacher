namespace pnachbuilder
{
    partial class angelpnacher
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(angelpnacher));
            this.pnachOutput = new System.Windows.Forms.RichTextBox();
            this.appendCode = new System.Windows.Forms.Button();
            this.copySelected = new System.Windows.Forms.Button();
            this.pasteSelected = new System.Windows.Forms.Button();
            this.insertInto = new System.Windows.Forms.Button();
            this.blockView = new System.Windows.Forms.FlowLayoutPanel();
            this.addressPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.addressPanelTitle = new System.Windows.Forms.Label();
            this.addAddress = new System.Windows.Forms.Button();
            this.newAddressBox = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.codeSelector = new System.Windows.Forms.ComboBox();
            this.hiddenLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // pnachOutput
            // 
            this.pnachOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnachOutput.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pnachOutput.Location = new System.Drawing.Point(5, 480);
            this.pnachOutput.Name = "pnachOutput";
            this.pnachOutput.ReadOnly = true;
            this.pnachOutput.Size = new System.Drawing.Size(848, 379);
            this.pnachOutput.TabIndex = 0;
            this.pnachOutput.TabStop = false;
            this.pnachOutput.Text = "";
            // 
            // appendCode
            // 
            this.appendCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.appendCode.Location = new System.Drawing.Point(640, 445);
            this.appendCode.Name = "appendCode";
            this.appendCode.Size = new System.Drawing.Size(94, 29);
            this.appendCode.TabIndex = 4;
            this.appendCode.TabStop = false;
            this.appendCode.Text = "Append";
            this.appendCode.UseVisualStyleBackColor = true;
            this.appendCode.Click += new System.EventHandler(this.appendCode_Click);
            // 
            // copySelected
            // 
            this.copySelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.copySelected.Location = new System.Drawing.Point(11, 410);
            this.copySelected.Name = "copySelected";
            this.copySelected.Size = new System.Drawing.Size(94, 29);
            this.copySelected.TabIndex = 5;
            this.copySelected.TabStop = false;
            this.copySelected.Text = "Copy";
            this.copySelected.UseVisualStyleBackColor = true;
            // 
            // pasteSelected
            // 
            this.pasteSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.pasteSelected.Location = new System.Drawing.Point(122, 410);
            this.pasteSelected.Name = "pasteSelected";
            this.pasteSelected.Size = new System.Drawing.Size(94, 29);
            this.pasteSelected.TabIndex = 6;
            this.pasteSelected.TabStop = false;
            this.pasteSelected.Text = "Paste";
            this.pasteSelected.UseVisualStyleBackColor = true;
            // 
            // insertInto
            // 
            this.insertInto.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.insertInto.Enabled = false;
            this.insertInto.Location = new System.Drawing.Point(751, 445);
            this.insertInto.Name = "insertInto";
            this.insertInto.Size = new System.Drawing.Size(94, 29);
            this.insertInto.TabIndex = 7;
            this.insertInto.TabStop = false;
            this.insertInto.Text = "Insert";
            this.insertInto.UseVisualStyleBackColor = true;
            // 
            // blockView
            // 
            this.blockView.AllowDrop = true;
            this.blockView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.blockView.AutoScroll = true;
            this.blockView.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.blockView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.blockView.Location = new System.Drawing.Point(5, 4);
            this.blockView.Name = "blockView";
            this.blockView.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.blockView.Size = new System.Drawing.Size(569, 400);
            this.blockView.TabIndex = 8;
            // 
            // addressPanel
            // 
            this.addressPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.addressPanel.AutoScroll = true;
            this.addressPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.addressPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.addressPanel.Location = new System.Drawing.Point(580, 67);
            this.addressPanel.Name = "addressPanel";
            this.addressPanel.Padding = new System.Windows.Forms.Padding(0, 0, 10, 0);
            this.addressPanel.Size = new System.Drawing.Size(273, 337);
            this.addressPanel.TabIndex = 9;
            this.addressPanel.WrapContents = false;
            this.addressPanel.Click += new System.EventHandler(this.addressPanel_Click);
            // 
            // addressPanelTitle
            // 
            this.addressPanelTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addressPanelTitle.AutoSize = true;
            this.addressPanelTitle.Location = new System.Drawing.Point(589, 9);
            this.addressPanelTitle.Name = "addressPanelTitle";
            this.addressPanelTitle.Size = new System.Drawing.Size(76, 20);
            this.addressPanelTitle.TabIndex = 10;
            this.addressPanelTitle.Text = "Addresses";
            // 
            // addAddress
            // 
            this.addAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addAddress.Location = new System.Drawing.Point(788, 4);
            this.addAddress.Name = "addAddress";
            this.addAddress.Size = new System.Drawing.Size(57, 31);
            this.addAddress.TabIndex = 11;
            this.addAddress.TabStop = false;
            this.addAddress.Text = "Add";
            this.addAddress.UseVisualStyleBackColor = true;
            this.addAddress.Click += new System.EventHandler(this.addAddress_Click);
            // 
            // newAddressBox
            // 
            this.newAddressBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newAddressBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.newAddressBox.Location = new System.Drawing.Point(580, 36);
            this.newAddressBox.MaxLength = 7;
            this.newAddressBox.Multiline = true;
            this.newAddressBox.Name = "newAddressBox";
            this.newAddressBox.Size = new System.Drawing.Size(273, 27);
            this.newAddressBox.TabIndex = 12;
            this.newAddressBox.TabStop = false;
            this.newAddressBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.newAddressBox.TextChanged += new System.EventHandler(this.newAddressBox_TextChanged);
            this.newAddressBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.newAddressBox_KeyDown);
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 0;
            this.toolTip1.IsBalloon = true;
            this.toolTip1.UseAnimation = false;
            this.toolTip1.UseFading = false;
            // 
            // codeSelector
            // 
            this.codeSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.codeSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.codeSelector.FormattingEnabled = true;
            this.codeSelector.Location = new System.Drawing.Point(12, 446);
            this.codeSelector.Name = "codeSelector";
            this.codeSelector.Size = new System.Drawing.Size(204, 28);
            this.codeSelector.TabIndex = 13;
            this.codeSelector.TabStop = false;
            // 
            // hiddenLink
            // 
            this.hiddenLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.hiddenLink.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point);
            this.hiddenLink.Location = new System.Drawing.Point(580, 407);
            this.hiddenLink.Name = "hiddenLink";
            this.hiddenLink.Size = new System.Drawing.Size(273, 18);
            this.hiddenLink.TabIndex = 15;
            this.hiddenLink.TabStop = true;
            this.hiddenLink.Text = "View";
            this.hiddenLink.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.hiddenLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.hiddenLink_LinkClicked);
            // 
            // angelpnacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 863);
            this.Controls.Add(this.hiddenLink);
            this.Controls.Add(this.codeSelector);
            this.Controls.Add(this.newAddressBox);
            this.Controls.Add(this.addAddress);
            this.Controls.Add(this.addressPanelTitle);
            this.Controls.Add(this.addressPanel);
            this.Controls.Add(this.blockView);
            this.Controls.Add(this.insertInto);
            this.Controls.Add(this.pasteSelected);
            this.Controls.Add(this.copySelected);
            this.Controls.Add(this.appendCode);
            this.Controls.Add(this.pnachOutput);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(733, 910);
            this.Name = "angelpnacher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AngelPnacher";
            this.Load += new System.EventHandler(this.pnachbuilder_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox pnachOutput;
        private Button appendCode;
        private Button copySelected;
        private Button pasteSelected;
        private Button insertInto;
        private FlowLayoutPanel blockView;
        private FlowLayoutPanel addressPanel;
        private Label addressPanelTitle;
        private Button addAddress;
        private TextBox newAddressBox;
        private ToolTip toolTip1;
        private ComboBox codeSelector;
        private LinkLabel hiddenLink;
    }
}