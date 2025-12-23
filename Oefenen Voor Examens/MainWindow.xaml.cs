using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Oefenen_Voor_Examens
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //begin van MainWindow scope
        Random random = new Random(); //this variable can generate random numbers for you
        int toasts = 15;              //stores the number of toasts left on table
        int croissants = 5;           //stores the number of croissants left on table
        int eggs = 2;               //stores the number of eggs left on table

        int burntToasts = 0;
        int edibleToasts = 0;


        public MainWindow()
        {
            InitializeComponent();
        }

        //Executes when window is loaded for the first time
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //update labels
            lblToasts.Content = toasts;
            lblCroissants.Content = croissants;
            lblEggs.Content = eggs;
        }

        //Executes when clicking Button btnEatToast
        private void btnEatToast_Click(object sender, RoutedEventArgs e)
        {
            if (toasts <= 0)
                return;

            toasts--;
            lblToasts.Content = toasts;

            bool isBurnt = random.Next(2) == 1; // 50% kans

            if (isBurnt)
            {
                burntToasts++;
                MessageBox.Show("O nee! Je toast is aangebrand ", "Toaster defect");
            }
            else
            {
                edibleToasts++;
            }

            if (toasts == 0)
            {
                btnEatToast.IsEnabled = false;

                MessageBox.Show(
                    $"Al je toasts zijn op!\n\n" +
                    $" Aangebrande toasts: {burntToasts}\n" +
                    $" Eetbare toasts: {edibleToasts}",
                    "Toast-overzicht");
            }
        }

        //Executes when clicking Button btnEatCroissant
        private void BtnEatCroissant_Click(object sender, RoutedEventArgs e)
        {
            croissants = croissants - 1;        //remove one croissant from the table
            lblCroissants.Content = croissants; //update Label 

            if (croissants == 0)       //disable button if there are no croissants left
            {
                MessageBox.Show("oh nee , al je croissants zijn op");
                btnEatCroissant.IsEnabled = false;
            }
        }

        private void btnEatEgg_Click(object sender, RoutedEventArgs e)
        {
            eggs = eggs - 1;       //remove one egg from the table
            lblEggs.Content = eggs; //update Label

            if (eggs == 0)       //disable button if there are no eggs left
            {
                MessageBox.Show("oh nee , al je eitjes zijn op");
                btnEatEgg.IsEnabled = false;
            }
        }
    }
}