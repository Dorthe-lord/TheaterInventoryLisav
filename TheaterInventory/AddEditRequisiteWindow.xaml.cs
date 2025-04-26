using System.Linq;
using System.Windows;

namespace TheaterInventory
{
    public partial class AddEditRequisiteWindow : Window
    {
        public UserRequisites Requisite { get; private set; }
        private PRACTICE_LISAVEntities db;

        public AddEditRequisiteWindow(UserRequisites requisite)
        {
            InitializeComponent();
            db = new PRACTICE_LISAVEntities();
            Requisite = requisite;

            // Заполняем ComboBox пользователями
            OwnerComboBox.ItemsSource = db.UserInfo.ToList();
            OwnerComboBox.SelectedValue = Requisite.UserID;

            RequisiteNameTextBox.Text = Requisite.RequisitName;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Requisite.RequisitName = RequisiteNameTextBox.Text;
            Requisite.UserID = (int)OwnerComboBox.SelectedValue;
            DialogResult = true;
        }
    }
}