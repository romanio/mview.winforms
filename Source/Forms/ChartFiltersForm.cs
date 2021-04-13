using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mview
{
    public partial class ChartFiltersForm : Form
    {
        public event EventHandler UpdateData;

        public ChartFiltersForm()
        {
            InitializeComponent();
        }

        public void SetFitersSettings(ChartFilterSettings data)
        {

        }

        public ChartFilterSettings GetFilterSettings()
        {
            return new ChartFilterSettings { };
        }

        private void ChartFiltersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }
    }

    public class ChartFilterSettings
    {
        bool ShowOnlyProducers = true;
    }
}
