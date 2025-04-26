using System.Linq;
using System.Windows;

namespace TheaterInventory
{
    public partial class AddEditCostumeWindow : Window
    {
        public UserCostumes Costume { get; private set; }
        private PRACTICE_LISAVEntities db;

        public AddEditCostumeWindow(UserCostumes costume)
        {
            InitializeComponent();
            db = new PRACTICE_LISAVEntities();
            Costume = costume;

            // Заполняем ComboBox пользователями
            OwnerComboBox.ItemsSource = db.UserInfo.ToList();
            OwnerComboBox.SelectedValue = Costume.UserID;

            CostumeNameTextBox.Text = Costume.CostumeName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            // Обновляем данные костюма
            Costume.CostumeName = CostumeNameTextBox.Text;
            Costume.UserID = (int)OwnerComboBox.SelectedValue;

            DialogResult = true;
        }
    }
}