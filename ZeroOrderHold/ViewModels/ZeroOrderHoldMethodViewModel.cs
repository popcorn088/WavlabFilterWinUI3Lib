using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.UI.Xaml.Controls;
using WavlabFilterWinUI3Lib;

namespace ZeroOrderHold.ViewModels
{
    internal class ZeroOrderHoldMethodViewModel : ObservableObject
    {
        public RelayCommand UpCommand { get; private set; }
        public RelayCommand DownCommand { get; private set; }
        public RelayCommand SendCommand { get; private set; }
        public RelayCommand CloseCommand { get; private set; }
        private int order = 1;
        public int Order
        {
            get => this.order;
            set => SetProperty(ref this.order, value);
        }
        public ZeroOrderHoldMethodViewModel()
        {
            UpCommand = new RelayCommand(UpCommandExecute);
            DownCommand = new RelayCommand(DownCommandExecute);
            SendCommand = new RelayCommand(SendCommandExecute);
            CloseCommand = new RelayCommand(CloseCommandExecute);
        }

        private void CloseCommandExecute()
        {
            MainWindow.Handle.Close();
        }

        private async void SendCommandExecute()
        {
            try
            {
                WavlabFilterClient client = new WavlabFilterClient();
                await client.SendCoefs(Design(Order), new double[0]);
            }
            catch (Exception ex)
            {
                var cd = new ContentDialog();
                cd.Title = "Error";
                cd.Content = ex.Message;
                cd.CloseButtonText = "OK";
                cd.XamlRoot = MainWindow.Handle.Content.XamlRoot;
                await cd.ShowAsync();
            }
        }

        private void UpCommandExecute() => Order++;
        private void DownCommandExecute()
        {
            if (Order <= 1)
            {
                return;
            }
            Order--;
        }

        private static double[] Design(int order)
        {
            double[] ret = new double[order];
            for (int i = 0; i < order; i++)
            {
                ret[i] = 1.0 / order;
            }

            return ret;
        }
    }
}
