using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PacketMonitor.Filter
{
    public class Filter : Form
    {
        private Button AddFilter;
        private TextBox AddFilterName;
        private IContainer components;
        private ArrayList filter;
        private ListBox FilterList;
        private Button RemoveFilter;

        public Filter(ArrayList Filter)
        {
            this.InitializeComponent();
            this.filter = Filter;
        }

        private void AddFilter_Click(object sender, EventArgs e)
        {
            this.filter.Add(this.AddFilterName.Text);
            this.FilterList.Items.Add(this.AddFilterName.Text);            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            foreach (string filtername in this.filter)
            {
                this.FilterList.Items.Add(filtername);
            }
        }

        private void InitializeComponent()
        {
            this.FilterList = new ListBox();
            this.AddFilterName = new TextBox();
            this.AddFilter = new Button();
            this.RemoveFilter = new Button();
            base.SuspendLayout();
            this.FilterList.FormattingEnabled = true;
            this.FilterList.Location = new Point(13, 13);
            this.FilterList.Name = "FilterList";
            this.FilterList.Size = new Size(0x10b, 0xc7);
            this.FilterList.TabIndex = 0;
            this.AddFilterName.Location = new Point(13, 0xf7);
            this.AddFilterName.Name = "AddFilterName";
            this.AddFilterName.Size = new Size(0x85, 20);
            this.AddFilterName.TabIndex = 1;
            this.AddFilter.Location = new Point(0xcd, 0xf5);
            this.AddFilter.Name = "AddFilter";
            this.AddFilter.Size = new Size(0x4b, 0x17);
            this.AddFilter.TabIndex = 2;
            this.AddFilter.Text = "Add";
            this.AddFilter.UseVisualStyleBackColor = true;
            this.AddFilter.Click += new EventHandler(this.AddFilter_Click);
            this.RemoveFilter.Location = new Point(0xcd, 0xdb);
            this.RemoveFilter.Name = "RemoveFilter";
            this.RemoveFilter.Size = new Size(0x4b, 0x17);
            this.RemoveFilter.TabIndex = 3;
            this.RemoveFilter.Text = "Remove";
            this.RemoveFilter.UseVisualStyleBackColor = true;
            this.RemoveFilter.Click += new EventHandler(this.RemoveFilter_Click);
            base.AutoScaleDimensions = new SizeF(6f, 13f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x124, 0x117);
            base.Controls.Add(this.RemoveFilter);
            base.Controls.Add(this.AddFilter);
            base.Controls.Add(this.AddFilterName);
            base.Controls.Add(this.FilterList);
            base.Name = "Filter";
            this.Text = "Filter";
            base.Load += new EventHandler(this.Filter_Load);
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        private void RemoveFilter_Click(object sender, EventArgs e)
        {
            this.filter.Remove(this.FilterList.SelectedItem);
            this.FilterList.Items.Remove(this.FilterList.SelectedItem);
        }
    }
}
