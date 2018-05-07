using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Mfrc522Lib;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ConsoleApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    /// 
    //public  delegate Task StartRfidWorker<in T>(IEnumerable<T> source) where T : class;

    public delegate Task StartRfid();

    //public Tools tool;
    

    public sealed partial class MainPage : Page
    {
        public static int Counter = 1;
        public Tools Tool;
        public MainPage()
        {
            Tool = new Tools();
            this.InitializeComponent();
        }

        private void BtnClick_Click(object sender, RoutedEventArgs e)
        {
            TxtBlockLabel.Text = Counter + ".  Time you have clicked me!";
            Counter++;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            CoreApplication.Exit();
        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            TxtBlockLabel.Text = "Counter has been stopped";
        }

        private void BtnSayHello_Click(object sender, RoutedEventArgs e)
        {
            TxtHello.Text = "Hello World!!";
        }


        private async void BtnRaspberry_Click(object sender, RoutedEventArgs e)
        {
            StartRfid startRfid = Tool.RfidReader;
            await startRfid();
        }
    }
}
