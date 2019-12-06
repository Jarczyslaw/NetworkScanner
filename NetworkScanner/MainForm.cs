﻿using JToolbox.Core.Utilities;
using JToolbox.Desktop.Dialogs;
using JToolbox.NetworkTools;
using JToolbox.WinForms.Core.Extensions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace NetworkScanner
{
    public partial class MainForm : Form
    {
        private readonly PingScanner pingScanner = new PingScanner();
        private readonly IDialogsService dialogsService = new DialogsService();
        private List<GridItem> devices = new List<GridItem>();
        private readonly Stopwatch stopwatch = new Stopwatch();
        private CancellationTokenSource cancellationTokenSource;

        public MainForm()
        {
            InitializeComponent();
            Initialize();
        }

        public IPAddress StartAddress
        {
            get => IPAddress.Parse(tbStartAddress.Text);
            set => tbStartAddress.Text = value.ToString();
        }

        public IPAddress EndAddress
        {
            get => IPAddress.Parse(tbEndAddress.Text);
            set => tbEndAddress.Text = value.ToString();
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

        public List<GridItem> Scanned
        {
            get => grid.DataSource as List<GridItem>;
            set
            {
                grid.DataSource = null;
                grid.DataSource = value;
            }
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

        private void UpdateGrid()
        {
            Scanned = devices;
        }

        private void Initialize()
        {
            pingScanner.OnDeviceScanned += PingScanner_OnDeviceScanned;
            pingScanner.OnScanComplete += PingScanner_OnScanComplete;

            Status = ScanStatus.Idle;
            Workers = Environment.ProcessorCount * 2;

            var mask = new IPAddress(new byte[] { 255, 255, 255, 0 });
            var address = NetworkUtils.GetLocalIPAddress();
            tbStartAddress.Text = NetworkUtils.FirstAddressInSubnet(address, mask).ToString();
            tbEndAddress.Text = NetworkUtils.LastAddressInSubnet(address, mask).ToString();
        }

        private void PingScanner_OnScanComplete(List<PingResult> results)
        {
            this.SafeInvoke(() =>
            {
                Status = ScanStatus.Finished;
                dialogsService.ShowInfo($"Scan completed. Found {results.Count} devices in {stopwatch.Elapsed.TotalSeconds:0.00}s");
            });
        }

        private void PingScanner_OnDeviceScanned(PingResult result)
        {
            this.SafeInvoke(() =>
            {
                devices.Add(new GridItem
                {
                    Address = result.Address.ToString(),
                    Id = devices.Count + 1,
                    Status = result.Reply.Status
                });
                devices = devices.OrderBy(d => d.Status == IPStatus.Success ? 0 : 1)
                    .ThenBy(d => Version.Parse(d.Address))
                    .ToList();
                UpdateGrid();
            });
        }

        private async void btnStart_Click(object sender, EventArgs e)
        {
            var errorOccured = false;
            try
            {
                devices.Clear();
                UpdateGrid();

                cancellationTokenSource = new CancellationTokenSource();
                stopwatch.Restart();
                Status = ScanStatus.Scanning;
                await pingScanner.PingScan(new PingScanInput
                {
                    StartAddress = StartAddress,
                    EndAddress = EndAddress,
                    Workers = Workers,
                    Timeout = Timeout,
                    CancellationToken = cancellationTokenSource.Token
                });
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
    }
}