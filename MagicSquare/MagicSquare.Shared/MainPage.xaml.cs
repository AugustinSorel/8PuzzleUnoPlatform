using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MagicSquare
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private MainPageViewModel mainPageViewModel;

        public MainPage()
        {
            this.InitializeComponent();
            
            foreach (var item in container.Children.Cast<Button>())
                item.Click += new RoutedEventHandler(Buttons_Click);

            mainPageViewModel = new MainPageViewModel(container);

            this.DataContext = mainPageViewModel;
        }

        private void Buttons_Click(object sender, RoutedEventArgs e)
        {
            mainPageViewModel.HandleClickEvent(buttonClicked: sender as Button);
        }
    }
}
//* ---TODO---
//* UNIT TEST
//
//
//
//*//