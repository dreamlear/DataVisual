using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace TestParseTraco
{
    public partial class MainForm : Form
    {
        FileData fileData;
        
        Color[] colors = {Color.Black, Color.Blue, Color.Cyan, Color.DarkGray,
            Color.DarkGreen, Color.DarkOrange, Color.DarkRed, Color.DeepPink, Color.Yellow,
            Color.Purple, Color.OrangeRed, Color.LightGreen, Color.BurlyWood, Color.DarkMagenta,
            Color.IndianRed, Color.Olive, Color.GreenYellow };

        Data data = null;
        //一个 Timer 用于在用户定义的时间间隔引发事件
        Timer timer = new Timer();
        List<int> timeList = new List<int>();
        

        //记录参数对应颜色
        Dictionary<string, Color> colorDic = new Dictionary<string, Color>();

        //记录参数阈值
        Dictionary<string, Threshold> thresholdDic = new Dictionary<string, Threshold>();

        public MainForm()
        {
            InitializeComponent();
            fileData = new FileData();
            timer.Tick += new System.EventHandler(timer_Tick);
        }
        //int time = 0;
        private void buttonLoadFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFile = new OpenFileDialog();
                openFile.Filter = "TracoData(*.traco)|*.traco";
                DialogResult result = openFile.ShowDialog();
                if (result == System.Windows.Forms.DialogResult.OK)
                {
                    ParseFile(openFile.FileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ParseFile(string fileName)
        {
            try
            {
                fileData.Parse(System.IO.File.ReadAllText(fileName, System.Text.Encoding.UTF8));
                foreach (var item in fileData.history)
                {
                    ListViewItem lvi = new ListViewItem(item.name);
                    lvi.SubItems.Add(item.time);
                    lvi.SubItems.Add(item.description);
                    lvi.Tag = item;
                    listviewFileInfo.Items.Add(lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void listviewFileInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            data = null;
            timer.Stop();
            colorDic.Clear();
            timeList.Clear();
            warningTextBox.Clear();
            if (listviewFileInfo.SelectedItems.Count > 0)
            {
                timer.Dispose();
                timer.Start();
                timer.Interval = 1000;
                //timer.Enabled = true;
                data = (Data)listviewFileInfo.SelectedItems[0].Tag;
                textCondition.Text = data.condition;

                listviewVariable.Items.Clear();
                for (int i = 0; i < data.results.Count; i++)
                {
                    var item = data.results[i];
                    string headname = item.name;
                    ListViewItem lvi = new ListViewItem(headname);
                    lvi.SubItems.Add(item.type);
                    lvi.SubItems.Add(item.address);
                    lvi.Tag = item.name;
                    listviewVariable.Items.Add(lvi);
                    colorDic.Add(headname, colors[i]);
                }

            }
        }


        private void listviewVariable_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listviewVariable.SelectedItems.Count > 0)
            {
                listviewVariable.SelectedItems[0].Checked = !listviewVariable.SelectedItems[0].Checked;
                string varName = listviewVariable.SelectedItems[0].Tag.ToString();
                if (listviewVariable.SelectedItems[0].Checked == true)
                {
                    listviewVariable.SelectedItems[0].Focused = false;
                    listviewVariable.SelectedItems[0].BackColor = SystemColors.MenuHighlight;
                    listviewVariable.SelectedItems[0].ForeColor = SystemColors.Window;
                    comboBoxSelect.Items.Add(varName);
                    thresholdDic.Add(varName, new Threshold());
                    createChart(varName);
                    //comboBox1.Controls.Add()
                }
                else
                {
                    listviewVariable.SelectedItems[0].Focused = false;
                    listviewVariable.SelectedItems[0].BackColor = SystemColors.Window;
                    listviewVariable.SelectedItems[0].ForeColor = SystemColors.WindowText;
                    if (comboBoxSelect.Text.Equals(varName))
                        comboBoxSelect.Text = "";
                    comboBoxSelect.Items.Remove(varName);
                    thresholdDic.Remove(varName);
                    for(int i = 0; i < listThreshold.Items.Count; ++i)
                    {
                        if (varName.Equals(listThreshold.Items[i].SubItems[0].Text))
                        {
                            listThreshold.Items.RemoveAt(i);
                            break;
                        }
                    }
                    deleteChart(varName);
                }
                
            }
        }

        private void deleteChart(string varName)
        {
            for (int i = 0; i < flowLayoutPanel.Controls.Count; ++i)
            {
                Chart chart = (Chart)flowLayoutPanel.Controls[i];
                //若一个chart有且仅有该参数曲线，则删除该chart
                if (chart.Series.Count == 1 && chart.Series[0].Name.Equals(varName))
                {
                    flowLayoutPanel.Controls.Remove(chart);
                    timeList.RemoveAt(i);
                    break;
                }
                //否则只删除对应曲线
                else
                {
                    for(int s = 0; s < chart.Series.Count; ++s)
                    {
                        if (chart.Series[s].Name.Equals(varName))
                        {
                            chart.Series.RemoveAt(s);
                            if(s == 0)
                            {
                                chart.Name = chart.Series[s].Name;
                            }
                        }
                    }
                }
            }
        }

        private void createChart(string varName)
        {
            if (data != null && data.records.Count > 0)
            {
                int time = 0;
                timeList.Add(time);
                
                int index = flowLayoutPanel.Controls.Count;

                Chart chart = new Chart();
                chart.Name = varName;
                chart.Size = new System.Drawing.Size(1450, 350);
                chart.TabIndex = index;
                chart.Text = varName;
                flowLayoutPanel.Controls.Add(chart);

                //area.CursorX.AutoScroll = true;
                //area.CursorY.AutoScroll = true;
                //area.CursorX.IsUserEnabled = true;
                //area.CursorX.IsUserSelectionEnabled = true;

                //设置ChartArea的属性
                ChartArea area = new ChartArea();
                area.Name = "area" + varName;
                chart.ChartAreas.Add(area);
                chart.ChartAreas[0].AxisX.Title = "Time";
                chart.ChartAreas[0].AxisY.Title = "Value";
                //chart.ChartAreas[0].AxisX.LabelStyle.Format = "HH:mm:ss";
                chart.ChartAreas[0].AxisX.ScaleView.Size = 5; //横坐标显示5个坐标点
                chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
                chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
                chart.ChartAreas[0].AxisX.MajorGrid.Enabled = false; //横轴取消网格线
                chart.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;   //网格类型 短横线
                chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
                //chart.ChartAreas[0].AxisX.MajorTickMark.Enabled = false;                   //  x轴上突出的小点
                chart.ChartAreas[0].AxisY.MajorGrid.Enabled = false; //纵轴取消网格线
                //chart.ChartAreas[0].AxisY.MajorTickMark.Enabled = false;                  
                chart.ChartAreas[0].AxisY.IsInterlaced = true;  //显示交错带 
                chart.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;   //网格类型 短横线
                chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
                chart.ChartAreas[0].AxisY.MajorGrid.LineWidth = 1;

                //设置坐标轴的起始值，从当前time开始
                chart.ChartAreas[0].AxisX.Minimum = time;

                //创建曲线
                Series series = new Series(varName);
                chart.Series.Add(series);
                //chart.Series[0].Label = "#VAL";
                chart.Series[0].ToolTip = "#VALX, #VAL";
                chart.Series[0].ChartArea = "area" + varName;
                chart.Series[0].ChartType = SeriesChartType.Line;    //图类型(折线)
                //series.ChartType = SeriesChartType.Spline;
                //折线段配置
                chart.Series[0].Color = colorDic[varName];               //线条颜色
                chart.Series[0].MarkerBorderColor = colorDic[varName];   //标记点边框颜色
                chart.Series[0].MarkerColor = colorDic[varName];       //标记点中心颜色
                chart.Series[0].BorderWidth = 2;                 //线条粗细
                chart.Series[0].MarkerBorderWidth = 2;             //标记点边框大小
                chart.Series[0].MarkerSize = 4;                 //标记点大小
                chart.Series[0].MarkerStyle = MarkerStyle.Circle;  //标记点类型

                //设置标签
                Legend legend = new Legend();
                legend.Name = "legend";
                chart.Legends.Add(legend);
                chart.Series[0].Legend = "legend";
                chart.Series[0].IsVisibleInLegend = true;

                //双击放大
                chart.DoubleClick += chart_DoubleClick;

                chart.AllowDrop = true;
                //源chart拖动  
                chart.MouseDown += new MouseEventHandler(Chart_MouseDown);
                chart.MouseMove += new MouseEventHandler(Chart_MouseMove);

                //目标chart
                chart.DragEnter += new DragEventHandler(Chart_DragEnter);
                chart.DragDrop += new DragEventHandler(Chart_DragDrop);
            }
        }

        private bool cMouseDown = false;//表明是否拖入边界
        private Rectangle dragBoxFromMouseDown;

        //按下鼠标后即开始执行拖放操作
        private void Chart_MouseDown(object sender, MouseEventArgs e)
        {
            //记录鼠标按下位置，DragSize获取以鼠标按钮的按下点为中心的矩形的宽度和高度，在该矩形内不会开始拖动操作。
            Size dragSize = SystemInformation.DragSize;
            //创建一个矩形区域（正方形）。以鼠标按下电为中心，以DragSize为高和宽的矩形。
            dragBoxFromMouseDown = new Rectangle(new Point(e.X - (dragSize.Width / 2),
                                                           e.Y - (dragSize.Height / 2)), dragSize);

            
            //throw new NotImplementedException();
        }

        //拖动选中的chart
        private void Chart_MouseMove(object sender, MouseEventArgs e)
        {
            Chart chartSource = (Chart)sender;
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                //如果鼠标位置在拖动矩形之外（就可以开始拖动了）
                if (!dragBoxFromMouseDown.Contains(e.X, e.Y) && chartSource.Series.Count == 1)
                {
                    chartSource.DoDragDrop(chartSource, DragDropEffects.Move);
                }
            }
            //throw new NotImplementedException();
        }

        //拖动对象进入本chart的边界
        private void Chart_DragEnter(object sender, DragEventArgs e)
        {
            
            e.Effect = DragDropEffects.Move;
            cMouseDown = true;
            //throw new NotImplementedException();
        }

        //拖放操作完成
        private void Chart_DragDrop(object sender, DragEventArgs e)
        {
            //获取chartTarget
            Chart chartTarget = (Chart)sender;
            // 从事件参数 DragEventArgs 中获取被拖动的chartSource 
            Chart chartSource = (Chart)e.Data.GetData(typeof(Chart));
            if (cMouseDown && !chartTarget.Name.Equals(chartSource.Name))
            {

                //flowLayoutPanel1删除chartSource
                int indexSource = flowLayoutPanel.Controls.IndexOf(chartSource);
                flowLayoutPanel.Controls.Remove(chartSource);
                timeList.RemoveAt(indexSource);

                //目标chartTarget添加chartSource的曲线
                for(int i = 0; i < chartSource.Series.Count; ++i)
                {
                    int count = chartTarget.Series.Count;
                    Series serie = chartSource.Series[i];
                    chartTarget.Series.Add(serie);

                    serie.Legend = "legend";
                    serie.IsVisibleInLegend = true;
                    chartSource.ChartAreas[0].Name = chartTarget.ChartAreas[0].Name;
                    serie.ChartArea = chartTarget.ChartAreas[0].Name;
                    chartTarget.Update();
                }
                //RefreshControls(new Control[] { grp, (GroupBox)sender });
                cMouseDown = false;
            }
            //throw new NotImplementedException();
        }

        //每过一秒都会调用这个函数
        private void timer_Tick(object sender, EventArgs e)
        {
            //recordsWithTime.Add(data.records[time-1]);
            //遍历当前状态下flowLayoutPanel1下的所有chart
            for(int i = 0; i < flowLayoutPanel.Controls.Count; ++i)
            {
                timeList[i]++;
                Chart chart = (Chart)flowLayoutPanel.Controls[i];
                string xValue = FileData.ParseTime(data.records[timeList[i] - 1].instant).ToString("HH:mm:ss:fff");
                for (int j = 0; j < data.results.Count; j++) {
                    int s;
                    for(s = 0; s < chart.Series.Count; ++s)
                    {
                        if (chart.Series[s].Name.Equals(data.results[j].name))
                        {
                            var item = data.records[timeList[i] - 1];
                            chart.Series[s].Points.AddXY(xValue, item.values[j]);
                            double min;
                            double max;
                            if (thresholdDic[chart.Series[s].Name].min.Equals("无"))
                                min = double.MinValue;
                            else
                                min = double.Parse(thresholdDic[chart.Series[s].Name].min);
                            if (thresholdDic[chart.Series[s].Name].max.Equals("无"))
                                max = double.MaxValue;
                            else
                                max = double.Parse(thresholdDic[chart.Series[s].Name].max);
                            if (item.values[j]<min || item.values[j] > max)
                            {
                                warningTextBox.AppendText("参数" + chart.Series[s].Name + "在" + xValue + "时刻越出阈值范围！！！\n");
                            }
                        }
                    }
                    chart.ChartAreas[0].AxisX.ScaleView.Position = chart.Series[s-1].Points.Count < 5 ? 0 : chart.Series[s-1].Points.Count - 5;
                }
            }

        }

        //双击放大整个图表横轴，坐标轴显示点数为5个
        void chart_DoubleClick(object sender, EventArgs e)
        {
            Chart chart = (Chart)sender;
            chart.ChartAreas[0].AxisX.ScaleView.Size = 5;
            chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
            chart.ChartAreas[0].AxisX.ScrollBar.Enabled = true;
            //throw new NotImplementedException();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            if (textBoxMin.Text.Equals(""))
                textBoxMin.Text = "无";
            if (textBoxMax.Text.Equals(""))
                textBoxMax.Text = "无";
            double resultMin = double.MinValue;
            double resultMax = double.MaxValue;
            //输入的阈值不是double类型
            if (!textBoxMin.Text.Equals("无")&&(!double.TryParse(textBoxMin.Text, out resultMin)) || (!textBoxMax.Text.Equals("无")&& !double.TryParse(textBoxMax.Text, out resultMax)))
            {
                MessageBox.Show("请输入正确格式的阈值。", "警示框");
            }
            //输入的阈值最大值小于阈值最小值
            else if (resultMax < resultMin)
            {
                MessageBox.Show("阈值最大值应大于等于阈值最小值。", "警示框");
            }
            //参数或阈值未输入
            else if(comboBoxSelect.Text.Equals("") || (textBoxMin.Text.Equals("无") && textBoxMax.Text.Equals("无")))
            {
                MessageBox.Show("请输入参数或阈值。", "警示框");
            }
            else
            {
                string varName = comboBoxSelect.Text;
                //刷新阈值字典
                thresholdDic[varName].min = textBoxMin.Text;
                thresholdDic[varName].max = textBoxMax.Text;

                //刷新阈值框
                int i = 0;
                //若已在框内，则修改阈值即可
                for (i = 0; i < listThreshold.Items.Count; ++i)
                {
                    if (varName.Equals(listThreshold.Items[i].SubItems[0].Text))
                    {
                        listThreshold.Items[i].SubItems[1].Text = textBoxMin.Text;
                        listThreshold.Items[i].SubItems[2].Text = textBoxMax.Text;
                        break;
                    }
                }
                //若不存在，则添加至框中
                if (i == listThreshold.Items.Count)
                {
                    ListViewItem lvi = new ListViewItem(varName);
                    lvi.SubItems.Add(textBoxMin.Text);
                    lvi.SubItems.Add(textBoxMax.Text);
                    listThreshold.Items.Add(lvi);
                }
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            comboBoxSelect.Text = "";
            textBoxMin.Text = "";
            textBoxMax.Text = "";
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            if (warningTextBox.Text.Length == 0)
            {
                MessageBox.Show("还没有警示信息", "提示");
            }
            else
            {
                try
                {
                    SaveFileDialog saveFile = new SaveFileDialog();
                    saveFile.Filter = "文本文件(.txt)|*.txt";
                    string date = data.time;
                    string name = data.name;
                    saveFile.FileName += name + date + "WarningInfo";
                    DialogResult result = saveFile.ShowDialog();
                    if (result == System.Windows.Forms.DialogResult.OK && saveFile.FileName.Length > 0)
                    {
                        System.IO.StreamWriter sw = new System.IO.StreamWriter(saveFile.FileName, false);
                        try
                        {
                            sw.WriteLine(warningTextBox.Text);
                        }
                        catch
                        {
                            throw;
                        }
                        finally
                        {
                            sw.Close();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
        }

        
    }
}
