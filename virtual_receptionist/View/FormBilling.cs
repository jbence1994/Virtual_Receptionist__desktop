﻿using System;
using System.Windows.Forms;
using virtual_receptionist.Presenter;

namespace virtual_receptionist.View
{
    /// <summary>
    /// Számlázó modul ablak
    /// </summary>
    public partial class FormBilling : Form
    {
        #region Adattagok

        /// <summary>
        /// Számlázó modul prezenter egy példánya
        /// </summary>
        private BillingPresenter presenter;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Számlázó modul ablak konstruktora
        /// </summary>
        public FormBilling()
        {
            InitializeComponent();
            presenter = new BillingPresenter();
        }

        #endregion

        #region UI események

        private void buttonNewData_Click(object sender, EventArgs e)
        {

        }

        private void buttonAddItem_Click(object sender, EventArgs e)
        {
            presenter.AddNewRow();
        }

        private void buttonUpdateItem_Click(object sender, EventArgs e)
        {
            presenter.UpdateRow();

            if (dataGridViewItems.SelectedRows.Count != 0)
            {

            }
            else
            {
                MessageBox.Show("Nincs kijelölt elem!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonDeleteItem_Click(object sender, EventArgs e)
        {
            presenter.DeleteRow();


            if (dataGridViewItems.SelectedRows.Count != 0)
            {
                int rowToDelete = dataGridViewItems.SelectedRows[0].Index;
                dataGridViewItems.Rows.RemoveAt(rowToDelete);
            }
            else
            {
                MessageBox.Show("Nincs kijelölt elem!", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonPrintInvoice_Click(object sender, EventArgs e)
        {

        }

        private void dataGridViewItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            textBoxTotal.Text = presenter.GetTotalPrice().ToString();
        }

        private void dataGridViewItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            textBoxTotal.Text = presenter.GetTotalPrice().ToString();
        }

        #endregion
    }
}
