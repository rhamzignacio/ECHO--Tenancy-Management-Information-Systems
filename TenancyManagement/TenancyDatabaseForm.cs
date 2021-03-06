﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Echo.Data.Repository.ViewModel;
using Tenancy_Management_Information_Systems.ReportForms;

namespace Tenancy_Management_Information_Systems.TenancyManagement
{
    public partial class TenancyDatabaseForm : Form
    {
        TenantViewModel vm = new TenantViewModel();

        public TenancyDatabaseForm()
        {
            InitializeComponent();

            GetTenants(); //Load all tenants upon opening form
        }

        private void GetSelected(Guid tenantID)
        {
            vm = new TenantViewModel();

            var tenant = vm.GetSelectedTenant(tenantID);

            //Tenant Information
            txtBoxFirstName.Text = tenant.FirstName;
            txtBoxMiddleName.Text = tenant.MiddleName;
            txtBoxLastName.Text = tenant.LastName;
            datePickerDateOfBirth.Value = DateTime.Parse(tenant.DateOfBirth.ToString());
            comboBoxMaritalStatus.Text = tenant.MaritalStatus;

            if (tenant.UnitNumber != null)
            {
                var unit = new UnitViewModel().GetSelected(tenant.UnitNumber);

                if (unit != null)
                {
                    var user = new UserViewModel().GetSelectedUser(unit.Owner);

                    txtBoxUnitNo.Text = unit.UnitNumber;

                    if (user != null)
                        txtBoxUnitOwner.Text = user.FullName;
                    else
                        txtBoxUnitOwner.Text = "N/A";
                }
                else
                {
                    txtBoxUnitNo.Text = "N/A";
                    txtBoxUnitOwner.Text = "N/A";
                }
                
            }
            else
            {
                txtBoxUnitNo.Text = "N/A";
                txtBoxUnitOwner.Text = "N/A";
            }

            txtBoxNatureOfOccupancy.Text = tenant.NatureOfOccupancy;
            txtBoxHomeAddress.Text = tenant.HomeAddress;
            txtBoxProvincialAddress.Text = tenant.ProvincialAddress;
            txtBoxMobileNo.Text = tenant.MobileNo;
            txtBoxTelNo.Text = tenant.TelephoneNo;
            txtBoxEmail.Text = tenant.Email;

            //Other Information
            txtBoxOtherName1.Text = tenant.OtherName1;
            txtBoxOtherName2.Text = tenant.OtherName2;
            txtBoxOtherName3.Text = tenant.OtherName3;
            txtBoxPetName.Text = tenant.PetName;
            txtBoxPetType.Text = tenant.PetType;

            //Duration of Stay
            if (tenant.StartOfOccupancy != null)
            {
                txtBoxStartDate.Text = tenant.StartOfOccupancy.ToString();
            }
            else
            {
                txtBoxStartDate.Text = "N/A";
            }

            if (tenant.EndOfOccupancy != null)
            {
                txtBoxEndDate.Text = tenant.EndOfOccupancy.ToString();
            }
            else
            {
                txtBoxEndDate.Text = "N/A";
            }

            if(tenant.ImageLocation != null) //Show image on picture box
            {

            }
        }

        private void GetTenants(string unitNo = "", int? start = null, int? end = null)
        {
            listViewTenants.Items.Clear(); //Clear data in list view

            vm = new TenantViewModel(); //Refresh database data

            var tenants = vm.GetAll("Y").AsQueryable();

            if (unitNo != "")
                tenants = tenants.Where(r => r.UnitNumber.Contains(unitNo));

            if (start != null)
                tenants = tenants.Where(r => r.StartOfOccupancy != null && DateTime.Parse(r.StartOfOccupancy.ToString()).Year == start);

            if (end != null)
                tenants = tenants.Where(r => r.EndOfOccupancy != null && DateTime.Parse(r.EndOfOccupancy.ToString()).Year == end);

            tenants.ToList().ForEach(item =>
            {
                ListViewItem lvi = new ListViewItem(item.ID.ToString());

                if (item.Status == "Y")
                    lvi.SubItems.Add("Active");
                else
                    lvi.SubItems.Add("Deactivated");

                if (item.UnitNumber != "" && item.UnitNumber != null)//if it has unit rented
                {
                    var unit = new UnitViewModel().GetSelected(item.UnitNumber);

                    lvi.SubItems.Add(unit.UnitNumber);//Unit No
                    lvi.SubItems.Add(unit.StartOfOccupancy.ToString()); //Start of occupancy
                    lvi.SubItems.Add(unit.ExpectedEndOfOccupancy.ToString());   //End of Occupancy

                    if (unit.Owner != null)
                    {
                        var owner = new TenantViewModel().GetSelectedTenant(unit.Owner);
                        lvi.SubItems.Add(owner.FirstName + " " + owner.LastName);   //Unit Owner
                    }
                    else
                        lvi.SubItems.Add("None");//If no owner

                    lvi.SubItems.Add(item.FirstName + " " + item.LastName); //Tenant
                    lvi.SubItems.Add(unit.NatureOfOccupancy);   //Nature of Occupancy
                }
                else //no unit rented
                {
                    lvi.SubItems.Add("N/A");    //Unit No
                    lvi.SubItems.Add("N/A");    //Start of Occupancy
                    lvi.SubItems.Add("N/A");    //End of Occupancy
                    lvi.SubItems.Add("N/A");    //Unit Owner
                    lvi.SubItems.Add(item.FirstName + " " + item.LastName);    //Tenant
                    lvi.SubItems.Add("N/A");    //Nature of Occupancy
                }
                listViewTenants.Items.Add(lvi);
            });
        }    

        private void button2_Click(object sender, EventArgs e) //Cancel
        {
            Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //Search Tenant
            if (txtBoxSearchUnitNo.Text != "" && cmbBoxSearchEnd.Text != "" && cmbBoxSearchStart.Text != "")
            {
                GetTenants(txtBoxSearchUnitNo.Text, int.Parse(cmbBoxSearchStart.Text), int.Parse(cmbBoxSearchEnd.Text));
            }
            else if (txtBoxSearchUnitNo.Text != "" && cmbBoxSearchEnd.Text != "")
            {
                GetTenants(txtBoxSearchUnitNo.Text, null, int.Parse(cmbBoxSearchEnd.Text));
            }
            else if (txtBoxSearchUnitNo.Text != "" && cmbBoxSearchStart.Text != "")
            {
                GetTenants(txtBoxSearchUnitNo.Text, int.Parse(cmbBoxSearchStart.Text), null);
            }
            else if (cmbBoxSearchEnd.Text != "" && cmbBoxSearchStart.Text != "")
            {
                GetTenants("", int.Parse(cmbBoxSearchStart.Text), int.Parse(cmbBoxSearchEnd.Text));
            }
            else if (txtBoxSearchUnitNo.Text != "")
            {
                GetTenants("", null, null);
            }
            else if (cmbBoxSearchStart.Text != "")
            {
                GetTenants("", int.Parse(cmbBoxSearchStart.Text), null);
            }
            else if (cmbBoxSearchEnd.Text != "")
            {
                GetTenants("", null, int.Parse(cmbBoxSearchEnd.Text));
            }
            else
                GetTenants("", null, null);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void listViewTenants_DoubleClick(object sender, EventArgs e)
        {
            //Transfer to 2nd tab
            TabPage openTab = tabControl1.TabPages[1];
            tabControl1.SelectedTab = openTab;

            var tenantID = Guid.Parse(listViewTenants.SelectedItems[0].SubItems[0].Text); //Get TenantID from List then converted to GUID

            GetSelected(tenantID);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            TenancyDatabaseParameter form = new TenancyDatabaseParameter();
            form.ShowDialog();
        }
    }
}
