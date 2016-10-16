using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApplication1.Model;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            //DataContext = new MainWindowViewModel();
            DataContext = new TestViewModel();
        }



    }



    public class TestViewModel : IDataErrorInfo
    {

        private AppDB db;

        public string TextInput { get; set; }
        

        public string this[string columnName]
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        public string Error
        {
            get
            {
                throw new NotImplementedException();
            }
        }



        public ICommand TestInputCommand
        {
            get { return new RelayCommand(doWork); } 

        }

        public void doWork(string p)
        {

            

            if (!String.IsNullOrWhiteSpace(p))
            {
                if (db == null) db = new AppDB();

                var hotels = db.Hotels.Where(h => h.id !="").ToList();
                var users = DataSource.Hotels; //db.Users.Where(u => u.username == p).ToList();

                if (users.Count > 0)
                MessageBox.Show("found"+ hotels.Count+p);
                else
                    MessageBox.Show("not found"+ hotels.Count+p);
            }
            else
                MessageBox.Show("invalid value");
        }
    }




    public class MainWindowViewModel : IDataErrorInfo

    {

        public MainWindowViewModel()
        {

        }

        public string ValidateInputText
        {
            get;
            set;

        }

        //ICommand to bind to button

        public ICommand ValidateInputCommand
        {
            get { return new RelayCommand(doWork); }

        }

        public void doWork(string p)
        {
            
        }

        private int age = 20;

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        #region IDataErrorInfo

        //In this region we are implementing the properties defined in //the IDataErrorInfo interface in System.ComponentModel

        public string this[string columnName]
        {
            get
            {
                if ("ValidateInputText" == columnName)
                {
                    if (String.IsNullOrEmpty(ValidateInputText))
                    {

                        return "Please enter a Name";
                    }

                }

                else if ("Age" == columnName)

                {
                    if (Age < 0)

                    {

                        return "age should be greater than 0";

                    }

                }

                return "";

            }

        }

        public string Error

        {

            get { throw new NotImplementedException(); }

        }
    }

    class RelayCommand : ICommand
    {
        Action<string> _action;

        public event EventHandler CanExecuteChanged;

        public RelayCommand(Action<string> work)
        {
         
            _action = work;
        }

        public void Execute(object parameter)
        {
            _action((string)parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        

    }



    
}
#endregion