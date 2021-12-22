using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using WpfApp2.Model;

namespace WpfApp2.View
{
    /// <summary>
    /// Логика взаимодействия для AddDriverDialogView.xaml
    /// </summary>
    public partial class AddDriverDialogView : Window
    {
        private Drivers driver = new Drivers();
        bool isNew = true;
        public AddDriverDialogView()
        {
            InitializeComponent();
            DataContext = driver;
        }
        
        public AddDriverDialogView(Drivers driver)
        {
            this.driver = driver;
            InitializeComponent();
            DataContext = driver;
            isNew = false;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if(isNew)
                    db.GetContext().Drivers.Add(driver);
                db.GetContext().SaveChanges();
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());   
            }
        }

        private void PhotoTextBox_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            
            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.Filter = "png files (*.png)|*.png|jpg files (*.jpg)|*.jpg";
            openFileDialog.FilterIndex = 1;
            openFileDialog.RestoreDirectory = true;

            if ((bool)openFileDialog.ShowDialog())
            {

                //Get the path of specified file
                var filePath = openFileDialog.FileName;
                try
                {
                    driver.photoBinary = File.ReadAllBytes(filePath);
                }
                catch
                {
                    MessageBox.Show("Ошибка чтения картинки");
                }
            }

                
            
            
        }
    }
}
