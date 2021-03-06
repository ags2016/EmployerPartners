﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmployerPartners
{
    public partial class PracticeOrgCard : Form
    {
        #region Fields
        public string OrgName
        {
            get { return tbOrgName.Text.Trim(); }
            set { tbOrgName.Text = value; }
        }
        public string OrgAddress
        {
            get { return tbOrgAddress.Text.Trim(); }
            set { tbOrgAddress.Text = value; }
        }
        public string DateStart
        {
            get { return tbDateStart.Text.Trim(); }
            set { tbDateStart.Text = value; }
        }
        public string DateEnd
        {
            get { return tbDateEnd.Text.Trim(); }
            set { tbDateEnd.Text = value; }
        }
        private int? OrgDogId
        {
            get { return ComboServ.GetComboIdInt(cbOrgDogovor); }
            set { ComboServ.SetComboId(cbOrgDogovor, value); }
        }
        public string Comment
        {
            get { return tbComment.Text.Trim(); }
            set { tbComment.Text = value; }
        }
        #endregion

        private int? _Id
        {
            get;
            set;
        }
        public int POrgCardId
        {
            get;
            set;
        }
        private int _OrgId
        {
            get;
            set;
        }
        UpdateVoidHandler _hndl;

        public PracticeOrgCard(int? id, int orgid, UpdateVoidHandler _hdl)
        {
            InitializeComponent();
            _Id = id;
            POrgCardId = (int)id;
            _OrgId = orgid;
            _hndl = _hdl;
            FillCombo();
            FillCard();
            this.MdiParent = Util.mainform;
        }
        private void FillCombo()
        {
            ComboServ.FillCombo(cbOrgDogovor, HelpClass.GetComboListByQuery(@" select distinct  CONVERT(varchar(100), Id) AS Id, [Document] as Name
                from dbo.OrganizationDogovor where OrganizationId = " + _OrgId.ToString() + " and RubricId = 5 " + " and (DocumentTypeId = 2 or DocumentTypeId = 3) "), true, false);
        }
        private void FillCard()
        {
            if (_Id.HasValue)
                using (EmployerPartnersEntities context = new EmployerPartnersEntities())
                {
                    var org = (from x in context.PracticeLPOrganization
                                    where x.Id == _Id
                                    select x).First();
                    OrgName = org.OrganizationName;
                    OrgAddress = org.OrganizationAddress;
                    DateStart = (org.DateStart.HasValue) ? org.DateStart.Value.Date.ToString("dd.MM.yyyy") : "";
                    DateEnd = (org.DateEnd.HasValue) ? org.DateEnd.Value.Date.ToString("dd.MM.yyyy") : "";
                    OrgDogId = org.OrganizationDogovorId;
                    Comment = org.Comment;
                    try
                    {
                        if (!String.IsNullOrEmpty(OrgName))
                        {
                            this.Text = "Практика: " + OrgName;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
        }
        private bool CheckFields()
        {
            DateTime res;
            if (!String.IsNullOrEmpty(DateStart))
            {
                if (!DateTime.TryParse(DateStart, out res))
                {
                    MessageBox.Show("Неправильный формат даты в поле 'Начало практики' \r\n" + "Образец: 01.12.2016", "Инфо");
                    return false;
                }
            }
            if (!String.IsNullOrEmpty(DateEnd))
            {
                if (!DateTime.TryParse(DateEnd, out res))
                {
                    MessageBox.Show("Неправильный формат даты в поле 'Окончание практики'\r\n" + "Образец: 01.12.2016", "Инфо");
                    return false;
                }
            }
            return true;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_Id.HasValue)
                return;
            if (!CheckFields())
            {
                return;
            }
            try
            {
                using (EmployerPartnersEntities context = new EmployerPartnersEntities())
                {
                    var plp = context.PracticeLPOrganization.Where(x => x.Id == _Id).First();

                    plp.OrganizationName = OrgName;
                    plp.OrganizationAddress = OrgAddress;
                    plp.Comment = Comment;
                    plp.OrganizationDogovorId = OrgDogId;
                    if (!String.IsNullOrEmpty(DateStart))
                    {
                        plp.DateStart = DateTime.Parse(DateStart);
                    }
                    else
                    {
                        plp.DateStart = null;
                    }
                    if (!String.IsNullOrEmpty(DateEnd))
                    {
                        plp.DateEnd = DateTime.Parse(DateEnd);
                    }
                    else
                    {
                        plp.DateEnd = null;
                    }

                    context.SaveChanges();

                    //MessageBox.Show("Данные сохранены", "Сообщение");
                    if (_hndl != null)
                        _hndl(_Id);

                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Не удалось сохранить данные...\r\n" + ex.Message, "Сообщение");
            }
        }

        private void btnOrgCard_Click(object sender, EventArgs e)
        {
            if (Utilities.OrgCardIsOpened(_OrgId))
                return;
            new CardOrganization(_OrgId, null).Show();
        }

        private void btnOrgDogovorRefresh_Click(object sender, EventArgs e)
        {
            int? orgdogid = OrgDogId;
            FillCombo();
            OrgDogId = orgdogid;
        }
    }
}
