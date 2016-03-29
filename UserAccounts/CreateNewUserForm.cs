﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tenancy_Management_Information_Systems.Utilities;
using Echo.Data.Repository;
using Echo.Data.Repository.ViewModel;

namespace Tenancy_Management_Information_Systems.User_Accounts
{
    public partial class CreateNewUserForm : Form
    {
        UserUtilities userUtilities = new UserUtilities();

        FormUtilities formUtilities = new FormUtilities();

        public CreateNewUserForm()
        {
            InitializeComponent();
        }

        private void btnUserCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GenerateUsernameAndPassword()
        {
            if (txtBoxFirstName.Text != "" && txtBoxLastName.Text != "")
            {
                txtBoxUserName.Text = userUtilities.GenerateUsername
                    (txtBoxFirstName.Text, txtBoxLastName.Text, txtBoxMiddleName.Text);

                txtBoxPassword.Text = userUtilities.GeneratePassword(10);
            }
        }

        private UserProfile SetUserValues()
        {
            UserProfile user = new UserProfile();

            if (pictureBoxUser.Image != null)
            {
                using (var imgStr = new System.IO.MemoryStream())
                {
                    pictureBoxUser.Image.Save(imgStr, System.Drawing.Imaging.ImageFormat.Jpeg);
                    user.ImageContent = imgStr.ToArray();
                }
            }
           
            user.Username = txtBoxUserName.Text;
            user.FirstName = txtBoxFirstName.Text;
            user.MiddleName = txtBoxMiddleName.Text;
            user.LastName = txtBoxLastName.Text;
            user.DateOfBirth = datePickerDateOfBirth.Value;
            user.MaritalStatus = comboBoxMaritalStatus.Text.ToUpper();
            user.HomeAddress = txtBoxHomeAddress.Text;
            user.ProvincialAddress = txtBoxProvincialAddress.Text;
            user.Password = txtBoxPassword.Text;
            user.MobileNo = txtBoxMobileNo.Text;
            user.TelephoneNo = txtBoxTelNo.Text;
            user.Email = txtBoxEmail.Text;
            user.ContactPerson = txtBoxContactPerson.Text;
            user.ContactNo = txtBoxContactNo.Text;
            user.RelationshipToContact = txtBoxRelationToContactPerson.Text;
            user.Type = comboBoxAccountType.Text.ToUpper();
                  
            return user;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            string errorMessage = "";

            if (txtBoxFirstName.Text == "")
                errorMessage += "-First name\n";

            if (txtBoxLastName.Text == "")
                errorMessage += "-Last name\n";

            if (comboBoxMaritalStatus.Text == "")
                errorMessage += "-Marital status\n";

            if (comboBoxAccountType.Text == "")
                errorMessage += "-Account type\n";

            if (txtBoxContactNo.Text == "")
                errorMessage += "-Contact Number\n";

            if (txtBoxContactPerson.Text == "")
                errorMessage += "-Contact Person\n";

            if (txtBoxRelationToContactPerson.Text == "")
                errorMessage += "-Relation to contact person\n";

            if (datePickerDateOfBirth.Value.ToShortDateString() == DateTime.Now.ToShortDateString())
                errorMessage += "-Date of Birth\n";

            if (errorMessage != "")
            {
                errorMessage = "Please fill up missing fields \n\n" + errorMessage;

                MessageBox.Show(errorMessage, "Error on saving");
            }
            else
            {
                UserProfile newUser = SetUserValues();

                UserViewModel vm = new UserViewModel();

                if (vm.AddUser(newUser))
                    MessageBox.Show("Successfully saved");
                else
                    MessageBox.Show("Cannot save new user", "Error on saving");
            }
        }

        private void txtBoxLastName_Leave(object sender, EventArgs e)
        {
            GenerateUsernameAndPassword();
        }

        private void Error5_Click(object sender, EventArgs e)
        {

        }

        private void txtBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            lblFirstName.Visible = formUtilities.ShowRequiredLabel(txtBoxFirstName.Text);
        }

        private void txtBoxLastName_TextChanged(object sender, EventArgs e)
        {
            lblLastName.Visible = formUtilities.ShowRequiredLabel(txtBoxLastName.Text);
        }

        private void datePickerDateOfBirth_ValueChanged(object sender, EventArgs e)
        {
            lblDateOfBirth.Visible = formUtilities.ShowRequiredLabel
                (datePickerDateOfBirth.Value.ToShortDateString());
        }

        private void txtBoxHomeAddress_TextChanged(object sender, EventArgs e)
        {
            lblHomeAddress.Visible = formUtilities.ShowRequiredLabel(txtBoxHomeAddress.Text);
        }

        private void comboBoxAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblAccountType.Visible = formUtilities.ShowRequiredLabel(comboBoxAccountType.Text);
        }

        private void txtBoxContactPerson_TextChanged(object sender, EventArgs e)
        {
            lblContactPerson.Visible = formUtilities.ShowRequiredLabel(txtBoxContactPerson.Text);
        }

        private void txtBoxContactNo_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {
            lblContactNo.Visible = formUtilities.ShowRequiredLabel(txtBoxContactNo.Text);
        }

        private void txtBoxRelationToContactPerson_TextChanged(object sender, EventArgs e)
        {
            lblRelationToContactPerson.Visible = formUtilities.ShowRequiredLabel
                (txtBoxRelationToContactPerson.Text);
        }

        private void txtBoxMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            formUtilities.AllowsNumericOnly(sender, e);
        }

        private void txtBoxTelNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            formUtilities.AllowsNumericOnly(sender, e);
        }

        private void txtBoxContactNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            formUtilities.AllowsNumericOnly(sender, e);
        }

        private void txtBoxContactNo_TextChanged(object sender, EventArgs e)
        {
            lblContactNo.Visible = formUtilities.ShowRequiredLabel(txtBoxContactNo.Text);
        }

        private void btnAddPicture_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Filter = "Image files | *.jpg";

            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBoxUser.Image = Image.FromFile(openFileDialog.FileName);
            }
        }

        private void btnTakePicture_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Webcam photo not yet available", "Error");
        }
    }
}
