using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextFileChallenge
{
    public partial class ChallengeForm : Form
    {
        BindingList<UserModel> users = new BindingList<UserModel>();
        TextFileParser parser;

        public ChallengeForm()
        {
            InitializeComponent();

            WireUpDropDown();

            parser = new TextFileParser("AdvancedDataSet.csv");

            foreach (var user in parser.ParseFile())
                users.Add(user);
        }

        private void WireUpDropDown()
        {
            usersListBox.DataSource = users;
            usersListBox.DisplayMember = nameof(UserModel.DisplayText);
        }

        private void addUserButton_Click(object sender, EventArgs e)
        {
            var userModel = new UserModel();
            userModel.FirstName = firstNameText.Text;
            userModel.LastName = lastNameText.Text;
            userModel.Age = Convert.ToInt32(agePicker.Value);
            userModel.IsAlive = isAliveCheckbox.Checked;

            users.Add(userModel);
        }

        private void saveListButton_Click(object sender, EventArgs e)
        {
            parser.SaveFile(users.ToList());
        }
    }
}
