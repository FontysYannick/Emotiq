﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EmotiqApp
{
    public partial class Form1 : Form
    {
        frmHome frmHomeWindow = new frmHome() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmGraph frmGraphWindow = new frmGraph() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmContacts frmContactsWindow = new frmContacts() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };
        frmSettings frmSettingsWindow = new frmSettings() { Dock = DockStyle.Fill, TopLevel = false, TopMost = true };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pnlNav.Width = btnHome.Width;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;

            btnColorReset();
            btnHome.BackColor = Color.FromArgb(46, 52, 73);

            loadPanel(frmHomeWindow);
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            pnlNav.Width = btnHome.Width;
            pnlNav.Top = btnHome.Top;
            pnlNav.Left = btnHome.Left;

            btnColorReset();
            btnHome.BackColor = Color.FromArgb(46, 52, 73);

            loadPanel(frmHomeWindow);
        }

        private void btnGraph_Click(object sender, EventArgs e)
        {
            pnlNav.Width = btnGraph.Width;
            pnlNav.Top = btnGraph.Top;
            pnlNav.Left = btnGraph.Left;

            btnColorReset();
            btnGraph.BackColor = Color.FromArgb(46, 52, 73);

            loadPanel(frmGraphWindow);
        }

        private void btnContacts_Click(object sender, EventArgs e)
        {
            pnlNav.Width = btnContacts.Width;
            pnlNav.Top = btnContacts.Top;
            pnlNav.Left = btnContacts.Left;

            btnColorReset();
            btnContacts.BackColor = Color.FromArgb(46, 52, 73);

            loadPanel(frmContactsWindow);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlNav.Width = btnSettings.Width;
            pnlNav.Top = btnSettings.Top;
            pnlNav.Left = btnSettings.Left;

            btnColorReset();
            btnSettings.BackColor = Color.FromArgb(46, 52, 73);

            loadPanel(frmSettingsWindow);
        }

        private void loadPanel(System.Windows.Forms.Form iForm)
        {
        this.pnlFormLoader.Controls.Clear();
        this.pnlFormLoader.Controls.Add(iForm);
        iForm.Show();
        }

        private void btnColorReset()
        {
            btnHome.BackColor = Color.FromArgb(24, 30, 54);
            btnGraph.BackColor = Color.FromArgb(24, 30, 54);
            btnContacts.BackColor = Color.FromArgb(24, 30, 54);
            btnSettings.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
