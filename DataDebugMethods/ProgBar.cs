﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataDebugMethods
{
    public partial class ProgBar : Form
    {
        int Maximum;
        int Minimum;

        public ProgBar(int low, int high)
        {
            Minimum = low;
            Maximum = high;
            InitializeComponent();
            this.Visible = true;
        }

        private void ProgBar_Load(object sender, EventArgs e)
        {

        }

        public void SetProgress(int progress)
        {
            progressBar1.Value = progress;
        }

        public int maxProgress()
        {
            return progressBar1.Maximum;
        }
    }
}
