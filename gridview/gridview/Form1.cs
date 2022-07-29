using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;

namespace gridview
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            VisibleChanged += Form1_VisibleChanged;
            gridView1.CustomDrawCell += ComponentScheduleGridViewOnCustomDrawCell;
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (!Visible) return;

            gridControl1.DataSource = GridRow.Create(5);
        }

        void ComponentScheduleGridViewOnCustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            e.PaintNonSelectedComponentScheduleCellBackground();
            e.DrawAdditionalItemScheduleIndicator();
        }

        public class GridRow
        {
            public string Column1 { get; set; }

            public GridRow()
            {
                Column1 = Guid.NewGuid().ToString();
            }

            public static List<GridRow> Create(int number) 
                => Enumerable.Range(0, number)
                    .Select(_ => new GridRow())
                    .ToList();
        }
    }
}
