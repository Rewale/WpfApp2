using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApp2.Base;
using WpfApp2.View;

namespace WpfApp2.ViewModel
{
    class AuthViewModel
    {
        public RelayCommand clickAuth { get; set; }
        public string Login { get; set; }
        public string Pass { get; set; }

        public Action CloseView { get; set; }
        public AuthViewModel(Action close)
        {
            CloseView = close;
            clickAuth = new RelayCommand(p =>
            {
                if (Pass == "1" && Login == "1")
                {
                    MainView c = new MainView();
                    c.Show();
                    CloseView();
                }
            });
        }
        public AuthViewModel()
        { }
    }
}
