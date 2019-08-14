using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Threading;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Demo.SmartWindowsServices
{
    public partial class MainForm : Form
    {
        private Action<ServiceController, Control> refreshUIAfterStopped = delegate (ServiceController sc, Control ctr)
        {
            while (sc.Status != ServiceControllerStatus.Stopped)
            {
                Thread.Sleep(500);
                sc.Refresh();
            }
            ctr.Controls[2].Enabled = true;
            ctr.Controls[3].Enabled = false;
            (ctr.Controls[1] as ComboBox).SelectedItem = sc.Status.ToString();
        };

        private Action<ServiceController, Control> refreshUIAfterStarted = delegate (ServiceController sc, Control ctr)
        {
            try
            {
                while (sc.Status != ServiceControllerStatus.Running)
                {
                    Thread.Sleep(500);
                    sc.Refresh();
                }
                ctr.Controls[2].Enabled = false;
                ctr.Controls[3].Enabled = true;
                (ctr.Controls[1] as ComboBox).SelectedItem = sc.Status.ToString();
            }
            finally
            {
                sc.Dispose();
            }
        };

        public MainForm()
        {
            this.InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string uri = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Services.xml");
            XElement xElement = XElement.Load(uri);
            List<ServiceInfo> list = (from s in xElement.Elements()
                                      select new ServiceInfo
                                      {
                                          ServiceName = s.Element("ServiceName").Value,
                                          DisplayName = s.Element("DisplayName").Value
                                      }).ToList<ServiceInfo>();
            this.InitializeSelectAllControls("SelectAll", list.Count);
            int num = 0;
            foreach (ServiceInfo current in list)
            {
                this.InitializeControls(current, num++, true);
            }
            base.Size = new Size(640, base.Controls.Count * base.Controls[0].Height + 40);
            this.UpdateServiceStatus();
        }

        private void btnStopService_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ServiceInfo serviceInfo = button.Parent.Tag as ServiceInfo;
            using (ServiceController serviceController = new ServiceController(serviceInfo.ServiceName))
            {
                if (serviceController.CanStop)
                {
                    serviceController.Stop();
                    this.refreshUIAfterStopped(serviceController, button.Parent);
                }
            }
        }

        private void btnStartService_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            ServiceInfo serviceInfo = button.Parent.Tag as ServiceInfo;
            Control control = button.Parent.Controls[1];
            using (ServiceController serviceController = new ServiceController(serviceInfo.ServiceName))
            {
                if (serviceController.Status == ServiceControllerStatus.Stopped)
                {
                    serviceController.Start();
                    this.refreshUIAfterStarted(serviceController, button.Parent);
                }
            }
        }

        private void btnStopSelectedService_Click(object sender, EventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (control.Tag is ServiceInfo && (control.Controls[0] as CheckBox).Checked)
                {
                    this.btnStopService_Click(control.Controls[3], null);
                }
            }
        }

        private void btnStartSelectedService_Click(object sender, EventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (control.Tag is ServiceInfo && (control.Controls[0] as CheckBox).Checked)
                {
                    this.btnStartService_Click(control.Controls[3], null);
                }
            }
        }

        private void UpdateServiceStatus()
        {
            foreach (Control control in base.Controls)
            {
                if (control.Tag is ServiceInfo)
                {
                    ServiceControllerStatus serviceSatus = this.GetServiceSatus(control.Controls[0].Text);
                    (control.Controls[1] as ComboBox).SelectedItem = serviceSatus.ToString();
                    switch (serviceSatus)
                    {
                        case ServiceControllerStatus.Stopped:
                            control.Controls[2].Enabled = true;
                            control.Controls[3].Enabled = false;
                            break;
                        case ServiceControllerStatus.Running:
                            control.Controls[2].Enabled = false;
                            control.Controls[3].Enabled = true;
                            break;
                    }
                }
            }
        }

        private void InitializeSelectAllControls(string labelName, int index)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.Dock = DockStyle.Top;
            flowLayoutPanel.Height = 40;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.Name = "panel" + index;
            flowLayoutPanel.BackColor = Color.LightSlateGray;
            Button button = new Button();
            button.Text = "Start";
            button.Height = 30;
            button.ForeColor = Color.Red;
            button.Click += new EventHandler(this.btnStartSelectedService_Click);
            button.Name = "btnStartService" + index;
            Button button2 = new Button();
            button2.Text = "Stop";
            button2.Height = 30;
            button2.ForeColor = Color.Red;
            button2.Click += new EventHandler(this.btnStopSelectedService_Click);
            button2.Name = "btnStopService" + index;
            CheckBox checkBox = new CheckBox();
            checkBox.Text = labelName;
            checkBox.Width = 200;
            checkBox.Location = new Point
            {
                X = 20,
                Y = checkBox.Location.Y
            };
            checkBox.Margin = new Padding(3, 5, 3, 3);
            checkBox.Name = "chkName" + index;
            checkBox.AutoSize = false;
            checkBox.CheckedChanged += new EventHandler(this.chkName_CheckedChanged);
            flowLayoutPanel.Controls.Add(checkBox);
            Label label = new Label();
            label.Width = 200;
            flowLayoutPanel.Controls.Add(label);
            flowLayoutPanel.Controls.Add(button);
            flowLayoutPanel.Controls.Add(button2);
            base.Controls.Add(flowLayoutPanel);
        }

        private void chkName_CheckedChanged(object sender, EventArgs e)
        {
            foreach (Control control in base.Controls)
            {
                if (control.Tag is ServiceInfo)
                {
                    (control.Controls[0] as CheckBox).Checked = (sender as CheckBox).Checked;
                }
            }
        }

        private void InitializeControls(ServiceInfo service, int index, bool initialStatus = true)
        {
            FlowLayoutPanel flowLayoutPanel = new FlowLayoutPanel();
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanel.Dock = DockStyle.Top;
            flowLayoutPanel.Height = 40;
            flowLayoutPanel.Tag = service;
            flowLayoutPanel.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel.Name = "panel" + index;
            if (index % 2 == 0)
            {
                flowLayoutPanel.BackColor = Color.LightGray;
            }
            Button button = new Button();
            button.Text = "Start";
            button.Height = 30;
            button.ForeColor = Color.Red;
            button.Click += new EventHandler(this.btnStartService_Click);
            button.Name = "btnStartService" + index;
            Button button2 = new Button();
            button2.Text = "Stop";
            button2.Height = 30;
            button2.ForeColor = Color.Red;
            button2.Click += new EventHandler(this.btnStopService_Click);
            button2.Name = "btnStopService" + index;
            ComboBox comboBox = new ComboBox();
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox.DataSource = Enum.GetNames(typeof(ServiceControllerStatus));
            comboBox.Name = "cboStatus" + index;
            comboBox.Width = 200;
            CheckBox checkBox = new CheckBox();
            checkBox.Text = service.DisplayName;
            checkBox.Width = 200;
            checkBox.Location = new Point
            {
                X = 20,
                Y = checkBox.Location.Y
            };
            checkBox.Margin = new Padding(3, 5, 3, 3);
            checkBox.Name = "chkName" + index;
            checkBox.AutoSize = false;
            flowLayoutPanel.Controls.Add(checkBox);
            if (initialStatus)
            {
                flowLayoutPanel.Controls.Add(comboBox);
            }
            flowLayoutPanel.Controls.Add(button);
            flowLayoutPanel.Controls.Add(button2);
            base.Controls.Add(flowLayoutPanel);
        }

        private ServiceControllerStatus GetServiceSatus(string serviceName)
        {
            ServiceControllerStatus status;
            using (ServiceController serviceController = new ServiceController(serviceName))
            {
                status = serviceController.Status;
            }
            return status;
        }


    }
}
