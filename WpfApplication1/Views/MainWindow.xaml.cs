using Microsoft.TeamFoundation.MVVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApplication1.ServiceReference1;
using System.Globalization;
using WpfApplication1.Views;
using WpfApplication1.ViewModel.Dates;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        SearchResultCollectionList searchResultCollectionList;

        public object DatesMV { get; private set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private async void dorun_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prog.Text = "working...";
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                /*
                using (new OperationContextScope(service.InnerChannel))
                {
                    OperationContext.Current.OutgoingMessageHeaders.Add(
                        new SecurityHeader("UsernameToken-49", "12345/userID", "password123"));
                    service.invokeIdentityService(new IdentityProofingRequest());
                }*/


                service.ClientCredentials.HttpDigest.ClientCredential.UserName = "test";
                service.ClientCredentials.HttpDigest.ClientCredential.Password = "test";


                ServiceReference1.Data data = new ServiceReference1.Data();
                data.DataLabel = adddata.Text;

                service.AddData(data);

                var ds = await service.GetCurrentDataAsync();
                text.Text = "";
                foreach (var d in ds)
                {
                    text.Text += d.DataLabel + "\n";
                }
                prog.Text = "";
            }
            catch (Exception exp)
            {
                text.Text = exp.Message; prog.Text = "";
            }

        }

        private async void dorun2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (searchResultCollectionList == null)
                    searchResultCollectionList = new SearchResultCollectionList();
                SearchResultCollectionList.ItemsSource = searchResultCollectionList.Items;

                prog.Text = "working...";
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                service.ClientCredentials.UserName.UserName = "aa";
                service.ClientCredentials.UserName.Password = "aa";

                ServiceReference1.AuthorResponse auth = await service.GetInfoAsync(adddata.Text);
                text.Text = auth.auhther.FirstName;
                prog.Text = "";
            }

            

            catch (Exception exp)
            {
                prog.Text = "";

                if (exp.InnerException != null)
                    text.Text = exp.InnerException.Message;
                else
                    if (exp != null)
                    text.Text = exp.Message;
                else
                    text.Text = "unknow error";
            }


        }

        private async void doSearch_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                prog.Text = "working...";
                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                service.ClientCredentials.UserName.UserName = "aa";
                service.ClientCredentials.UserName.Password = "aa";

                ServiceReference1.HotelSearchRequest hr= new HotelSearchRequest();
                hr.destination = destination.Text;
                hr.date = DateTime.Now.AddDays(2);

                ServiceReference1.hotelsummary[] hotels = await service.GetHotelsAsync(hr);
                text.Text = "";
                foreach (var h in hotels)
                {
                    text.Text += String.Format("{0},{1},{2}", h.name, h.address1, h.city)+"\n";
                }

                if (searchResultCollectionList == null)
                    searchResultCollectionList = new SearchResultCollectionList();

                SearchResultCollectionList.ItemsSource = hotels.ToList();


                prog.Text = "";
            }


            catch (Exception exp)
            {
                prog.Text = "";

                if (exp.InnerException != null)
                    text.Text = exp.InnerException.Message;
                else
                    if (exp != null)
                    text.Text = exp.Message;
                else
                    text.Text = "unknow error";
            }
        }

        private void ListView_TargetUpdated(object sender, DataTransferEventArgs e)
        {

        }





        private void dorun3_Click(object sender, RoutedEventArgs e)
        {
            Window1 win2 = new Window1();
            win2.Show();
            //this.Close()
        }

        private void dorun4_Click(object sender, RoutedEventArgs e)
        {
            // HotelList win = new HotelList();
            // win.Show();
             SearchHotelView win = new SearchHotelView();
             win.Show();

        }

        private void userctrl_Click(object sender, RoutedEventArgs e)
        {
            test win = new test();
            win.Show();
        }

        private void dorun11_Click(object sender, RoutedEventArgs e)
        {
            var v= DatesDataSource.months();
            foreach(string s in v)
            {
                Console.WriteLine(s);
            }

              v = DatesDataSource.days();
            foreach (string s in v)
            {
                Console.WriteLine(s);
            }
        }
    }

    public class SearchResultCollectionList : ViewModelBase
    {
        private List<SearchResultCollectionItem> items;        
        public List<SearchResultCollectionItem> Items { get { return items; } set { items = value; RaisePropertyChanged("Items"); } }
        public SearchResultCollectionList()
        {
            if (items == null) items = new List<SearchResultCollectionItem>();
            items.Clear();
            items.Add(new SearchResultCollectionItem { name = "test1" ,DueDate="soon"});
            items.Add(new SearchResultCollectionItem { name = "test2", DueDate = "latter" });
            items.Add(new SearchResultCollectionItem { name = "test3", DueDate = "after a while" });

        }



    }

    public class SearchResultCollectionItem
    {
        public string name { get; set; }
        public string DueDate { get; set; }



    

        private CommandHandler _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if(_clickCommand==null)
                    _clickCommand = new CommandHandler(MyAction, true);
                return _clickCommand;
                //return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute));
            }
        }
        private bool _canExecute;
        public void MyAction(String s)
        {
            MessageBox.Show("I'm clicked"+s);
        }

    }

    public class CommandHandler : ICommand
    {
        private Action<string> _action;
        private bool _canExecute;
        public CommandHandler(Action<string> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //if (parameter)
            {
                //MessageBox.Show("button");
            }
            if (parameter!=null)
            _action(parameter.ToString());
            else
                _action("no");
        }

    }


}
