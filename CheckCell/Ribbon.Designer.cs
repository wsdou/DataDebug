﻿namespace CheckCell
{
    partial class Ribbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public Ribbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ribbon));
            this.tab1 = this.Factory.CreateRibbonTab();
            this.CheckCellTab = this.Factory.CreateRibbonTab();
            this.CheckCellGroup = this.Factory.CreateRibbonGroup();
            this.box1 = this.Factory.CreateRibbonBox();
            this.ToDOTButton = this.Factory.CreateRibbonButton();
            this.SensitivityTextBox = this.Factory.CreateRibbonEditBox();
            this.AboutCheckCell = this.Factory.CreateRibbonButton();
            this.AnalyzeButton = this.Factory.CreateRibbonButton();
            this.MarkAsOKButton = this.Factory.CreateRibbonButton();
            this.FixErrorButton = this.Factory.CreateRibbonButton();
            this.StartOverButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.CheckCellTab.SuspendLayout();
            this.CheckCellGroup.SuspendLayout();
            this.box1.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // CheckCellTab
            // 
            this.CheckCellTab.Groups.Add(this.CheckCellGroup);
            this.CheckCellTab.Label = "CheckCell";
            this.CheckCellTab.Name = "CheckCellTab";
            // 
            // CheckCellGroup
            // 
            this.CheckCellGroup.Items.Add(this.box1);
            this.CheckCellGroup.Items.Add(this.SensitivityTextBox);
            this.CheckCellGroup.Items.Add(this.AboutCheckCell);
            this.CheckCellGroup.Name = "CheckCellGroup";
            // 
            // box1
            // 
            this.box1.Items.Add(this.AnalyzeButton);
            this.box1.Items.Add(this.MarkAsOKButton);
            this.box1.Items.Add(this.FixErrorButton);
            this.box1.Items.Add(this.StartOverButton);
            this.box1.Items.Add(this.ToDOTButton);
            this.box1.Name = "box1";
            // 
            // ToDOTButton
            // 
            this.ToDOTButton.Label = "To DOT";
            this.ToDOTButton.Name = "ToDOTButton";
            this.ToDOTButton.Visible = false;
            this.ToDOTButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ToDOTButton_Click);
            // 
            // SensitivityTextBox
            // 
            this.SensitivityTextBox.Label = "% Most Unusual to Show";
            this.SensitivityTextBox.Name = "SensitivityTextBox";
            this.SensitivityTextBox.SizeString = "100.0";
            this.SensitivityTextBox.Text = "5.0";
            // 
            // AboutCheckCell
            // 
            this.AboutCheckCell.Image = ((System.Drawing.Image)(resources.GetObject("AboutCheckCell.Image")));
            this.AboutCheckCell.Label = "About";
            this.AboutCheckCell.Name = "AboutCheckCell";
            this.AboutCheckCell.ShowImage = true;
            this.AboutCheckCell.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AboutCheckCell_Click);
            // 
            // AnalyzeButton
            // 
            this.AnalyzeButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.AnalyzeButton.Image = global::CheckCell.Properties.Resources.analyze_small;
            this.AnalyzeButton.Label = "Analyze";
            this.AnalyzeButton.Name = "AnalyzeButton";
            this.AnalyzeButton.ShowImage = true;
            this.AnalyzeButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.AnalyzeButton_Click);
            // 
            // MarkAsOKButton
            // 
            this.MarkAsOKButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.MarkAsOKButton.Image = global::CheckCell.Properties.Resources.mark_as_ok_small;
            this.MarkAsOKButton.Label = "Mark as OK";
            this.MarkAsOKButton.Name = "MarkAsOKButton";
            this.MarkAsOKButton.ShowImage = true;
            this.MarkAsOKButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.MarkAsOKButton_Click);
            // 
            // FixErrorButton
            // 
            this.FixErrorButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.FixErrorButton.Image = global::CheckCell.Properties.Resources.correct_small;
            this.FixErrorButton.Label = "Fix Error";
            this.FixErrorButton.Name = "FixErrorButton";
            this.FixErrorButton.ShowImage = true;
            this.FixErrorButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.FixErrorButton_Click);
            // 
            // StartOverButton
            // 
            this.StartOverButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.StartOverButton.Image = global::CheckCell.Properties.Resources.clear_small;
            this.StartOverButton.Label = "Start Over";
            this.StartOverButton.Name = "StartOverButton";
            this.StartOverButton.ShowImage = true;
            this.StartOverButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.StartOverButton_Click);
            // 
            // Ribbon
            // 
            this.Name = "Ribbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Tabs.Add(this.CheckCellTab);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.Ribbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.CheckCellTab.ResumeLayout(false);
            this.CheckCellTab.PerformLayout();
            this.CheckCellGroup.ResumeLayout(false);
            this.CheckCellGroup.PerformLayout();
            this.box1.ResumeLayout(false);
            this.box1.PerformLayout();

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        private Microsoft.Office.Tools.Ribbon.RibbonTab CheckCellTab;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup CheckCellGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonBox box1;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AnalyzeButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton MarkAsOKButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton FixErrorButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton StartOverButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ToDOTButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox SensitivityTextBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton AboutCheckCell;
    }

    partial class ThisRibbonCollection
    {
        internal Ribbon Ribbon
        {
            get { return this.GetRibbon<Ribbon>(); }
        }
    }
}
