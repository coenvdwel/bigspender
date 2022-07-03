using System.ComponentModel;
using BigSpender.Objects;
using System.Windows.Forms;
using System.Data;

namespace BigSpender
{
  public partial class Form1 : Form
  {
    private readonly Manager _manager;

    public Form1()
    {
      InitializeComponent();
      _manager = new Manager();
    }

    private void Form1_Load(object sender, System.EventArgs e)
    {
      cbDisplay.SelectedIndex = 0;
    }

    private void Form1_DragEnter(object sender, DragEventArgs e)
    {
      if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
    }

    private void Form1_DragDrop(object sender, DragEventArgs e)
    {
      var files = (string[])e.Data.GetData(DataFormats.FileDrop);
      foreach (var f in files) _manager.AddFile(f);

      DoUpdate(null, null);
    }

    private void DoUpdate(object sender, System.EventArgs e)
    {
      MonthViewMode mode;
      switch (cbDisplay.SelectedItem.ToString())
      {
        case "Unknown":
          mode = MonthViewMode.Unknown;
          break;
        case "Predicted":
          mode = MonthViewMode.Predicted;
          break;
        case "Full":
          mode = MonthViewMode.Full;
          break;
        default:
          mode = MonthViewMode.Registered;
          break;
      }

      monthGrid.DataSource = null;

      mutationGrid.DataSource = new BindingSource { DataSource = _manager.GetMutationTable(tbMutationAccount.Text, tbMutationCategory.Text) };
      accountGrid.DataSource = new BindingSource { DataSource = _manager.GetAccountTable(tbAccountsAccount.Text, tbAccountsCategory.Text) };
      monthGrid.DataSource = new BindingSource { DataSource = _manager.GetMonthTable(mode, (int)tbHistory.Value) };
      cashFlowGrid.DataSource = new BindingSource { DataSource = _manager.GetCashFlow((int)tbCashflowForecast.Value) };
      plansGrid.DataSource = new BindingSource { DataSource = _manager.GetPlansTable() };

      mutationGrid.Sort(mutationGrid.Columns[0], ListSortDirection.Descending);
      accountGrid.Sort(accountGrid.Columns[2], ListSortDirection.Ascending);
      monthGrid.Sort(monthGrid.Columns[2], ListSortDirection.Ascending);
      plansGrid.Sort(plansGrid.Columns[0], ListSortDirection.Ascending);

      mutationGrid.Refresh();
      accountGrid.Refresh();
      monthGrid.Refresh();
      cashFlowGrid.Refresh();
      plansGrid.Refresh();
    }

    private void btnMaxPlan_Click(object sender, System.EventArgs e)
    {
      var row = plansGrid.Rows[plansGrid.SelectedCells[0].RowIndex].DataBoundItem as DataRowView;
      var data = row.Row.ItemArray;

      _manager.MaxPlan(data[4].ToString());
      DoUpdate(sender, e);
    }
  }
}