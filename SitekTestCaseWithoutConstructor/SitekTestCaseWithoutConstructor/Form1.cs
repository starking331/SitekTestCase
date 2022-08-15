using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Drawing.Printing;

namespace SitekTestCaseWithoutConstructor
{
    public partial class Form1 : Form
    {
        private Dictionary<string, int[]> performers;

        public Form1()
        {
            InitializeComponent();
            performers = new Dictionary<string, int[]>();

            #region Init Components
            var pathRkk = new TextBox
            {
                Location = new Point(0, 0),
                Size = new Size(574, 23),
                PlaceholderText = "���� ���"
            };

            var selectPathRkk = new Button
            {
                Location = new Point(pathRkk.Right, 0),
                Size = new Size(196, 23),
                Text = "������� ���� ���",


            };

            var pathRecourse = new TextBox
            {
                Location = new Point(0, pathRkk.Bottom),
                Size = new Size(574, 23),
                PlaceholderText = "���� � �����������"
            };

            var selectPathRecourse = new Button
            {
                Location = new Point(pathRecourse.Right, selectPathRkk.Bottom),
                Size = new Size(196, 23),
                Text = "������� ���� � �����������",
            };

            var startButton = new Button
            {
                Location = new Point(0, pathRecourse.Bottom),
                Size = new Size(770, 41),
                Text = "��������� ��������"
            };
            startButton.BackColor = Color.LightGreen;

            var resultGrid = new DataGridView
            {
                Location = new Point(0, startButton.Bottom),
                Size = new Size(770, 280),
                Columns = 
                { 
                    {"Executor", "������������ �����������"}, 
                    {"AmountRkk", "���������� ������������� �������� ����������" },
                    {"AmountRecourse", "���������� ������������� ���������� ��������� �������"},
                    {"AmountDocument", "����� ���������� ���������� � ���������"}
                }
            };
            resultGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;

            var algorythmTimeLable = new Label
            {
                Location = new Point(0, resultGrid.Bottom),
                Size = new Size(236, 25),
                Text = "����� ������ ���������",
                Font = new Font("Segoe UI", 14),
            };

            var algorythmTimeValue = new Label
            {
                Location = new Point(algorythmTimeLable.Right, resultGrid.Bottom),
                //Size = new Size(25,25),
                Font = new Font("Segoe UI", 14),
            };

            var saveReport = new Button
            {
                Location = new Point(552, resultGrid.Bottom),
                Size = new Size(218, 32),
                Font = new Font("Segoe UI", 14),
                Text = "��������� �����",
            };


            Controls.Add(pathRkk);
            Controls.Add(selectPathRkk);
            Controls.Add(pathRecourse);
            Controls.Add(selectPathRecourse);
            Controls.Add(startButton);
            Controls.Add(resultGrid);
            Controls.Add(algorythmTimeLable);
            Controls.Add(algorythmTimeValue);
            Controls.Add(saveReport);
            #endregion

            selectPathRkk.Click += (sender, args) =>
            {
                var fileName = GetPath();
                pathRkk.Text = fileName;
                SelectedPathCheck();
            };

            selectPathRecourse.Click += (sender, args) =>
            {
                var fileName = GetPath();
                pathRecourse.Text = fileName;
                SelectedPathCheck();
            };

            startButton.Click += (sender, args) =>
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
            };

            saveReport.Click += (sender, args) =>
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

                    for (var i = 0; i < resultGrid.Rows.Count - 1; i++)
                    {
                        for (var j = 0; j < resultGrid.Columns.Count; j++)
                        {
                            var value = resultGrid.Rows[i].Cells[j].Value.ToString();
                            var tab = "\t\t";
                            if (value is { Length: < 16 })
                                tab = "\t\t\t";

                            streamWriter.Write(value + tab);
                        }
                        streamWriter.WriteLine();
                    }
                    streamWriter.WriteLine();
                    streamWriter.WriteLine($"���� ����������� ������: {DateTime.Today.ToShortDateString()}");
                    streamWriter.Close();
                }
            };


            resultGrid.SortCompare += (sender, e) =>
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
            };

            void SelectedPathCheck()
            {
                if (!string.IsNullOrEmpty(pathRkk.Text) && !string.IsNullOrEmpty(pathRecourse.Text))
                {
                    startButton.Enabled = true;
                    return;
                }
                startButton.Enabled = false;
            }

            Tuple<int, int> CompareCells(string type, DataGridViewSortCompareEventArgs e)
            {
                var first = (int)resultGrid.Rows[e.RowIndex1].Cells[$"{type}"].Value;
                var second = (int)resultGrid.Rows[e.RowIndex2].Cells[$"{type}"].Value;

                return new Tuple<int, int>((int)first, (int)second);
            }
        }

        private string GetPath()
        {
            var ofd = new OpenFileDialog();
            ofd.Filter = "txt files (*.txt)|*.txt";

            return ofd.ShowDialog() == DialogResult.OK ? ofd.FileName : string.Empty;
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



    }
}