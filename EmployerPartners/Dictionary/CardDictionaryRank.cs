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
    public partial class CardDictionaryRank: CardDictionary
    {
        public CardDictionaryRank()
            :base()
        {
            InitializeComponent();
            this.Text = "Ученое звание";
        }

        public override void FillCard(DataGridView dgv, int? id)
        {
            using (EmployerPartnersEntities context = new EmployerPartnersEntities())
            {
                var lst = (from x in context.Rank
                           select new
                           {
                               x.Id,
                               x.Name
                           }).OrderBy(x=>x.Name).ToList();
                dgv.DataSource = lst;

                if (dgv.Columns.Contains("Id"))
                    dgv.Columns["Id"].Visible = false;

                if (dgv.Columns.Contains("Name"))
                {
                    dgv.Columns["Name"].HeaderText = "Название";
                }
                if (id.HasValue)
                    foreach (DataGridViewRow rw in dgv.Rows)
                        if (rw.Cells[0].Value.ToString() == id.Value.ToString())
                        {
                            dgv.CurrentCell = rw.Cells["Name"];
                            break;
                        }
            }
        }
        override public void DeleteRec(int Id)
        {
            using (EmployerPartnersEntities context = new EmployerPartnersEntities())
            {
                context.Rank.Remove(context.Rank.Where(x => x.Id == Id).First());
                context.SaveChanges();
            }
        }
        override public void UpdateRec(int? Id, string name)
        {
            if (Id.HasValue)
                using (EmployerPartnersEntities context = new EmployerPartnersEntities())
                {
                    Rank obj = context.Rank.Where(x => x.Id == Id).First();
                    obj.Name = name;
                    context.SaveChanges();
                    FillCard(Id);
                }
        }
        override public void AddRec(int? Id, string name)
        {
            using (EmployerPartnersEntities context = new EmployerPartnersEntities())
            {
                Rank obj = new Rank();
                obj.Name = name;
                context.Rank.Add(obj);
                context.SaveChanges();
                FillCard(obj.Id);
            }
        }
    }
}