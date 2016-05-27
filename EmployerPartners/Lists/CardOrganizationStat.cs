﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;
using WordOut;
using FastMember;

namespace EmployerPartners
{
    public partial class CardOrganizationStat : Form
    {
        public int _Count;

        public CardOrganizationStat()
        {
            InitializeComponent();
            this.MdiParent = Util.mainform;
            FillCard();
        }
        #region Fill
        public void FillCard()
        {
            using (EmployerPartnersEntities context = new EmployerPartnersEntities())
            {
                _Count = (from x in context.Organization
                         select x.Id).Count();
                tbOrgCount.Text = _Count.ToString();

                FillActivityArea(context);
                FillOwnership(context);
                FillActivityGoal(context);
                FillRubrics(context);
                FillFaculty(context);
                FillNatAffil(context);
                FillCountry(context);
                FillLP(context);
            }
        }

        public void FillActivityArea(EmployerPartnersEntities context)
        {
            var lst = (from x in context.OrganizationActivityArea
                       join a in context.ActivityArea on x.ActivityAreaId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Name,
                           x.OrganizationId,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrganizationId).Distinct().Count();
            lblActivityArea.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Область_деятельности = l.First().Name,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
            
            
            dgvActivityArea.DataSource = gr;
            foreach (DataGridViewColumn col in dgvActivityArea.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }
        public void FillOwnership(EmployerPartnersEntities context)
        {
            var lst = (from x in context.Organization
                       join a in context.OwnershipType on x.OwnershipTypeId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Name,
                           OrgId = x.Id,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrgId).Distinct().Count();
            lblOwner.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Форма_собственности = l.First().Name,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
            
            
            dgvOwner.DataSource = gr;

            foreach (DataGridViewColumn col in dgvOwner.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }
        public void FillActivityGoal(EmployerPartnersEntities context)
        {
            var lst = (from x in context.Organization
                       join a in context.ActivityGoal on x.ActivityGoalId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Name,
                           OrgId = x.Id,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrgId).Distinct().Count();
            lblAcivityGoal.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Цель_деятельности = l.First().Name,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
            
            
            dgvActivityGoal.DataSource = gr;
            foreach (DataGridViewColumn col in dgvActivityGoal.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }
        public void FillRubrics(EmployerPartnersEntities context)
        {
            var lst = (from x in context.OrganizationRubric
                       join a in context.Rubric on x.RubricId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Name,
                           x.OrganizationId,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrganizationId).Distinct().Count();
            lblRubrics.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Рубрика = l.First().Name,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
            
            
            dgvRubrics.DataSource = gr;
            foreach (DataGridViewColumn col in dgvRubrics.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }
        public void FillFaculty(EmployerPartnersEntities context)
        {
            var lst = (from x in context.OrganizationFaculty
                       join a in context.Faculty on x.FacultyId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Name,
                           x.OrganizationId,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrganizationId).Distinct().Count();
            lblFaculty.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Направление = l.First().Name,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
            
            
            dgvFaculty.DataSource = gr;
            foreach (DataGridViewColumn col in dgvFaculty.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }
        public void FillNatAffil(EmployerPartnersEntities context)
        {
            var lst = (from x in context.Organization
                       join a in context.NationalAffiliation on x.NationalAffiliationId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Name,
                           OrgId = x.Id,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrgId).Distinct().Count();
            lblNatAffiliation.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Национальная_принадлежность = l.First().Name,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
           
            
            dgvNatAffil.DataSource =  gr;
            foreach (DataGridViewColumn col in dgvNatAffil.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }
        public void FillCountry(EmployerPartnersEntities context)
        {
            var lst = (from x in context.Organization
                       join a in context.Country on x.CountryId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Name,
                           OrgId = x.Id,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrgId).Distinct().Count();
            lblCountry.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Страна = l.First().Name,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
            dgvCountry.DataSource = gr;
            foreach (DataGridViewColumn col in dgvCountry.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }
        public void FillLP(EmployerPartnersEntities context)
        {
            var lst = (from x in context.OrganizationLP
                       join a in context.LicenseProgram on x.LicenseProgramId equals a.Id
                       select new
                       {
                           a.Id,
                           a.Code,
                           Level = a.StudyLevel.Name,
                           a.Name,
                           Ptype = a.ProgramType.Name,
                           Qual = a.Qualification.Name,
                           x.OrganizationId,
                       }).Distinct().ToList();
            int cnt = lst.Select(x => x.OrganizationId).Distinct().Count();
            lblLP.Text = cnt.ToString() + "/" + (_Count - cnt).ToString();
            
            var gr = (from l in lst
                      group l by l.Id into l
                      select new
                      {
                          Код = l.First().Code,
                          Уровень = l.First().Level,
                          Направление = l.First().Name,
                          Тип_программы = l.First().Ptype,
                          Квалификация = l.First().Qual,
                          Кол__во_организаций = l.Count(),
                      }).OrderByDescending(x => x.Кол__во_организаций).ToList();
            
            
            
            dgvLP.DataSource = gr;
            foreach (DataGridViewColumn col in dgvLP.Columns)
                col.HeaderText = col.HeaderText.Replace("__", "-").Replace("_", " ");
        }

        #endregion
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            FillCard();
        }

        private void btnXLS_Click(object sender, EventArgs e)
        {
            ToExcel();
        }
        private void ToExcel()
        {
            try
            {
                string filenameDate = "Выгрузка ";
                string filename = Util.TempFilesFolder + filenameDate + ".xlsx";

                int fileindex = 1;
                while (File.Exists(filename))
                {
                    filename = Util.TempFilesFolder + filenameDate + "(" + fileindex + ")" + ".xlsx";
                    fileindex++;
                }
                System.IO.FileInfo newFile = new System.IO.FileInfo(filename);
                if (newFile.Exists)
                {
                    newFile.Delete();  // ensures we create a new workbook
                    newFile = new System.IO.FileInfo(filename);
                }
                List<KeyValuePair<string, DataGridView>> dgvlst = new List<KeyValuePair<string,DataGridView>>();
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Рубрики", dgvRubrics));
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Направления образования", dgvFaculty));
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Формы собственности", dgvOwner));
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Цель деятельности", dgvActivityGoal));
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Национальная принадлежность", dgvNatAffil));
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Страны", dgvCountry));
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Направления подготовки", dgvLP));
                dgvlst.Add(new KeyValuePair<string, DataGridView>("Область деятельности", dgvActivityArea));

                using (ExcelPackage doc = new ExcelPackage(newFile))
                {
                    foreach (KeyValuePair<string, DataGridView> kvp in dgvlst)
                    {
                        ExcelWorksheet ws = doc.Workbook.Worksheets.Add(kvp.Key);
                        DataGridView dgv = kvp.Value;

                        int colind = 0;
                        foreach (DataGridViewColumn cl in dgv.Columns)
                        {
                            ws.Cells[1, ++colind].Value = cl.HeaderText.ToString();
                        }

                        for (int rwInd = 0; rwInd < dgv.Rows.Count; rwInd++)
                        {
                            DataGridViewRow rw = dgv.Rows[rwInd];
                            int colInd = 0;
                            foreach (DataGridViewCell cell in rw.Cells)
                            {
                                ws.Cells[rwInd + 2, colInd + 1].Value = cell.Value.ToString();
                                colInd++;
                            }
                        }
                    }
                    doc.Save();
                }
                
                System.Diagnostics.Process.Start(filename);
            }
            catch
            {
            }
        }

        private void btnDOC_Click(object sender, EventArgs e)
        {
            ToDOC();
        }
        public void ToDOC()
        {
            try
            {
                WordDoc wd = new WordDoc(string.Format(@"{0}\СтатистикаОрганизаций.dot", Util.TemplatesFolder));

                using (EmployerPartnersEntities context = new EmployerPartnersEntities())
                {
                    wd.SetFields("Count", _Count.ToString());

                    List<DataGridView> dgvlst = new List<DataGridView>() { dgvRubrics, dgvFaculty, dgvOwner, dgvActivityGoal, dgvNatAffil, dgvCountry, dgvLP, dgvActivityArea };
                    
                    int tbl_ind = 1;
                    foreach (DataGridView dgv in dgvlst)
                    {
                        TableDoc td = wd.Tables[tbl_ind];
                        tbl_ind++;

                        int curRow = 0;
                        foreach (DataGridViewColumn c in dgv.Columns)
                        {
                            td[c.Index, curRow] = c.HeaderText.ToString();
                        }
                        foreach (DataGridViewRow rw in dgv.Rows)
                        {
                            td.AddRow(1);
                            curRow++;
                            foreach (DataGridViewCell cell in rw.Cells)
                            {
                                td[cell.ColumnIndex, curRow] = cell.Value.ToString();
                            }
                        }
                        td.DeleteLastRow();
                        wd.AddParagraph(" ");
                        wd.AddParagraph(" ");
                    }
                }
            }
            catch (WordException we)
            {
                MessageBox.Show(we.Message);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message); ;
            }
        }

    }
}