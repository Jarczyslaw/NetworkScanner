using JToolbox.Desktop.Dialogs;
using JToolbox.NetworkTools;
using JToolbox.NetworkTools.Inputs;
using JToolbox.NetworkTools.Results;
using JToolbox.WinForms.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace NetworkScanner
{
    public partial class PortScannerForm : Form
    {
        private readonly IPAddress address;
        private readonly PortScanner portScanner = new PortScanner();
        private readonly IDialogsService dialogsService = new DialogsService();
        private List<PortGridItem> ports = new List<PortGridItem>();
        private readonly Stopwatch stopwatch = new Stopwatch();
        private CancellationTokenSource cancellationTokenSource;

        public PortScannerForm(IPAddress address)
        {
            InitializeComponent();

            this.address = address;
            Initialize(address);
        }

        public int StartPort
        {
            get => (int)nudStartPort.Value;
            set => nudStartPort.Value = value;
        }

        public int EndPort
        {
            get => (int)nudEndPort.Value;
            set => nudEndPort.Value = value;
        }

        public ScanStatus Status
        {
            set
            {
                tsslStatus.Text = "Status: " + value.ToString();
                btnStart.Enabled = value != ScanStatus.Scanning;
                btnCancel.Enabled = value == ScanStatus.Scanning;
            }
        }

        public List<PortGridItem> Ports
        {
            get => grdPorts.Items;
            set => grdPorts.Items = value;
        }

        public int Timeout
        {
            get => (int)nudTimeout.Value;
            set => nudTimeout.Value = value;
        }

        public int Workers
        {
            get => (int)nudWorkers.Value;
            set => nudWorkers.Value = value;
        }

        public PortType PortType
        {
            get => (PortType)cbPortTypes.SelectedValue;
        }

        private void UpdateGrid()
        {
            Ports = ports;
        }

        private void Initialize(IPAddress address)
        {
            Text = "Port scanner: " + address.ToString();
            InitializeCombobox();

            portScanner.OnPortScanned += PortScanner_OnPortScanned;
            portScanner.OnPortsScanComplete += PortScanner_OnPortsScanComplete;

            Status = ScanStatus.Idle;
            Workers = Environment.ProcessorCount * 2;
        }

        private void InitializeCombobox()
        {
            cbPortTypes.DisplayMember = "Key";
            cbPortTypes.ValueMember = "Value";
            var types = new List<KeyValuePair<string, PortType>>
            {
                new KeyValuePair<string, PortType>(nameof(PortType.TCP), PortType.TCP),
                new KeyValuePair<string, PortType>(nameof(PortType.UDP), PortType.UDP)
            };
            cbPortTypes.DataSource = types;
            cbPortTypes.SelectedValue = PortType.TCP;
        }

        private void PortScanner_OnPortsScanComplete(List<PortResult> results)
        {
            this.SafeInvoke(() =>
            {
                Status = ScanStatus.Finished;
                dialogsService.ShowInfo($"Scan completed. Scanned {results.Count} ports in {stopwatch.Elapsed.TotalSeconds:0.00}s");
            });
        }

        private void PortScanner_OnPortScanned(PortResult result)
        {
            this.SafeInvoke(() =>
            {
                ports.Add(new PortGridItem
                {
                    Id = ports.Count + 1,
                    Number = result.Port,
                    Opened = result.IsOpen,
                    Type = result.Type
                });
                ports = ports.OrderBy(d => d.Opened ? 0 : 1)
                    .ThenBy(d => d.Number)
                    .ToList();
                UpdateGrid();
            });
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var errorOccured = false;
            try
            {
                ports.Clear();
                UpdateGrid();

                cancellationTokenSource = new CancellationTokenSource();
                stopwatch.Restart();
                Status = ScanStatus.Scanning;
                await portScanner.PortScan(new PortScanInput
                {
                    Address = address,
                    Workers = Workers,
                    Timeout = Timeout,
                    CancellationToken = cancellationTokenSource.Token,
                    StartPort = StartPort,
                    EndPort = EndPort
                }, PortType);
            }
            catch (Exception exc)
            {
                errorOccured = true;
                dialogsService.ShowException(exc);
            }
            finally
            {
                if (errorOccured)
                {
                    Status = ScanStatus.Idle;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            try
            {
                cancellationTokenSource?.Cancel();
            }
            catch (Exception exc)
            {
                dialogsService.ShowException(exc);
            }
        }

        private void nudEndPort_ValueChanged(object sender, EventArgs e)
        {
            if (nudEndPort.Value < nudStartPort.Value)
            {
                nudStartPort.ValueChanged -= nudStartPort_ValueChanged;
                nudStartPort.Value = nudEndPort.Value;
                nudStartPort.ValueChanged += nudStartPort_ValueChanged;
            }
        }

        private void nudStartPort_ValueChanged(object sender, EventArgs e)
        {
            if (nudStartPort.Value > nudEndPort.Value)
            {
                nudEndPort.ValueChanged -= nudEndPort_ValueChanged;
                nudEndPort.Value = nudStartPort.Value;
                nudEndPort.ValueChanged += nudEndPort_ValueChanged;
            }
        }
    }
}