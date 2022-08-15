using System.Diagnostics;

namespace SitekTestCase
{
    enum DocumentType
    {
        Rkk,
        Recourse
    }
    public partial class Form1 : Form
    {
        private Dictionary<string, int[]> performers;

        public Form1()
        {
            InitializeComponent();
            performers = new Dictionary<string, int[]>();
        }

        private string GetPath()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return ofd.FileName;
            }

            return string.Empty;
        }

        private void SelectedPathCheck()
        {
            if (!string.IsNullOrEmpty(pathRkk.Text) && !string.IsNullOrEmpty(pathRecourse.Text))
            {
                startButton.Enabled = true;
                return;
            }
            startButton.Enabled = false;
        }

        private void selectPathRkk_Click(object sender, EventArgs e)
        {
            var fileName = GetPath();
            pathRkk.Text = fileName;
            SelectedPathCheck();
        }

        private void selectPathRecourse_Click(object sender, EventArgs e)
        {
            var fileName = GetPath();
            pathRecourse.Text = fileName;
            SelectedPathCheck();
        }

        private void CountExecutorsDocuments(string[] lines, DocumentType type)
        {
            foreach (var line in lines)
            {
                var responsibleInfo = line.Split('\t');
                var executorName = "";
                if (responsibleInfo[0] == "������ ������ �������������")
                {
                    executorName = responsibleInfo[1].Split(';')[0].Replace(" (���.)", "");
                }
                else
                {
                    var directorName = responsibleInfo[0].Split();
                    executorName = $"{directorName[0]} {directorName[1][0]}.{directorName[2][0]}.";
                }

                if (!performers.ContainsKey(executorName))
                {
                    performers.Add(executorName, new int[2]);
                }

                performers[executorName][(int)type]++;
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            resultGrid.AutoResizeColumns();
            var watch = Stopwatch.StartNew();
            var textRkk = System.IO.File.ReadAllLines(pathRkk.Text);
            var textRecourse = System.IO.File.ReadAllLines(pathRecourse.Text);

            CountExecutorsDocuments(textRkk, DocumentType.Rkk);
            CountExecutorsDocuments(textRecourse, DocumentType.Recourse);
            watch.Stop();

            var time = watch.Elapsed;
            algorythmTimeValue.Text = $"{time.Seconds}s {time.Milliseconds}ms";

            foreach (var executorName in performers.Keys)
            {
                var amountRkk = performers[executorName][0];
                var amountRecourse = performers[executorName][1];
                var amountDocument = amountRkk + amountRecourse;

                var index = resultGrid.Rows.Add();
                resultGrid.Rows[index].Cells["Executor"].Value = executorName;
                resultGrid.Rows[index].Cells["AmountRkk"].Value = amountRkk;
                resultGrid.Rows[index].Cells["AmountRecourse"].Value = amountRecourse;
                resultGrid.Rows[index].Cells["AmountDocument"].Value = amountDocument;
            }
            var sortedColumn = resultGrid.SortedColumn;
            saveReport.Enabled = true;
        }

        private void saveReport_Click(object sender, EventArgs e)
        {
            var amountRkk = 0;
            var amountRecourse = 0;
            var amountDocument = 0;

            foreach (var item in performers.Values)
            {
                amountRkk += item[0];
                amountRecourse += item[1];
                amountDocument += item[0] + item[1];
            }

            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.FileName = "resultReport.txt";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                var reportPath = saveFileDialog.FileName;
                var streamWriter = new StreamWriter(reportPath);

                streamWriter.WriteLine("������� � ������������� ���������� � ���������� �������");
                streamWriter.WriteLine($"�� ��������� � ���� {amountDocument} ����������, �� ���:");
                streamWriter.WriteLine($"- ���������� ������������� �������� ����������: {amountRkk};");
                streamWriter.WriteLine($"- ���������� ������������� ���������� ��������� �������: {amountRecourse}.");
                var sortProperties = "���";
                if (resultGrid.SortedColumn != null)
                {
                    sortProperties = resultGrid.SortedColumn.HeaderText;
                }
                streamWriter.WriteLine($"����������: {sortProperties}");

                streamWriter.Write("������������ �����������\t���������� ���\t\t���������� ���������\t����� ����������");
                streamWriter.WriteLine();

                for (int i = 0; i < resultGrid.Rows.Count - 1; i++)
                {
                    for (int j = 0; j < resultGrid.Columns.Count; j++)
                    {
                        var value = resultGrid.Rows[i].Cells[j].Value.ToString();
                        string tabulation = "\t\t";
                        if (value != null && value.Length < 16)
                            tabulation = "\t\t\t";

                        streamWriter.Write(value + tabulation);
                    }
                    streamWriter.WriteLine();
                }
                streamWriter.WriteLine();
                streamWriter.WriteLine($"���� ����������� ������: {DateTime.Today.ToShortDateString()}");
                streamWriter.Close();
            }
        }

        private void ResultGrid_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            if (e.Column.Name == "Executor")
            {
                e.SortResult = string.CompareOrdinal(
                    e.CellValue1.ToString(), e.CellValue2.ToString());
            }

            var firstNum = (int) e.CellValue1;
            var secondNum = (int) e.CellValue2;

            if (firstNum == secondNum)
            {
                if (e.Column.Name == "AmountRkk")
                {
                    firstNum = CompareCells("AmountRecourse", e).Item1;
                    secondNum = CompareCells("AmountRecourse", e).Item2;
                }

                else
                {
                    firstNum = CompareCells("AmountRkk", e).Item1;
                    secondNum = CompareCells("AmountRkk", e).Item2;
                }
            }
            e.SortResult = firstNum.CompareTo(secondNum);
        }


        private Tuple<int, int> CompareCells(string type, DataGridViewSortCompareEventArgs e)
        {
            var first = (int)resultGrid.Rows[e.RowIndex1].Cells[$"{type}"].Value;
            var second = (int)resultGrid.Rows[e.RowIndex2].Cells[$"{type}"].Value;

            return new Tuple<int, int>((int)first, (int)second);
        }
    }
}