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
    public partial class CardRubrics : Form
    {
        
         public int? _id;
        public int ObjectId;
        UpdateVoidHandler _hdl;

        public CardRubrics()
        {
            InitializeComponent();
        }
        public CardRubrics(int? Id, int objId, UpdateVoidHandler h)
        {
            InitializeComponent();
            _id = Id;
            ObjectId = objId;
            _hdl = h;
            this.MdiParent = Util.mainform;
            FillCard();
        }
        public void FillControls(string TableName, int? x)
        {
            btnAdd.Text = (_id.HasValue) ? "Обновить" : "Добавить";
            ComboServ.FillCombo(cbName, HelpClass.GetComboListByTable(TableName), false, false);
            if (x.HasValue)
                ComboServ.SetComboId(cbName, x);
        }

        virtual public void FillCard()
        {
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int? RubricId = ComboServ.GetComboIdInt(cbName);
            if (!RubricId.HasValue)
            { 
                MessageBox.Show("Рубрика не выбрана");
                return;
            }
            using (EmployerPartnersEntities context = new EmployerPartnersEntities())
            {
                if (!CheckExist(context, RubricId))
                    return;
                
                if (!_id.HasValue)
                {
                    InsertRec(context, RubricId.Value);
                }
                else if (_id.HasValue)
                {
                    UpdateRec(context, RubricId.Value);
                }
                if (_hdl != null && _id.HasValue)
                    _hdl(_id);
            }
            this.Close();
        }
        virtual public bool CheckExist(EmployerPartnersEntities context, int? AreaId)
        {
            return true;
        }
        virtual public void InsertRec(EmployerPartnersEntities context, int AreaId)
        {
        }
        virtual public void UpdateRec(EmployerPartnersEntities context, int AreaId)
        {
        }
    }
}
