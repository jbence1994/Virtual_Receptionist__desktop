﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace virtual_receptionist
{
    /// <summary>
    /// Vendégadatbázis-kezelő ablak
    /// </summary>
    public partial class FormGuestDatabase : Form
    {
        #region Adattagok

        /// <summary>
        /// Főmenü ablak egy példánya
        /// </summary>
        private FormMainMenu formMainMenu;
        /// <summary>
        /// Vendégadatbázis-kezelő ablak új vendég felvételéhez vagy meglévő módosításához szükséges modális ablak egy példánya
        /// </summary>
        private FormModalGuestDatabase formModalGuestDatabase;

        #endregion

        #region Konstruktor

        /// <summary>
        /// Vendégadatbázis-kezelő ablak konstruktora, amely összeköti a főmenü ablakot a vendégadatbázis-kezelő ablakkal
        /// </summary>
        /// <param name="formMainMenu">Főmenü ablak egy példánya</param>
        public FormGuestDatabase(FormMainMenu formMainMenu)
        {
            InitializeComponent();
            this.formMainMenu = formMainMenu;
        }

        #endregion

        #region UI események

        private void buttonBackToMainMenu_Click(object sender, EventArgs e)
        {
            Close();
            formMainMenu.Show();
        }

        private void buttonAddGuest_Click(object sender, EventArgs e)
        {
            formModalGuestDatabase = new FormModalGuestDatabase();
            formModalGuestDatabase.ShowDialog();
        }

        private void buttonUpdateGuest_Click(object sender, EventArgs e)
        {
            formModalGuestDatabase = new FormModalGuestDatabase();
            formModalGuestDatabase.ShowDialog();
        }

        private void buttonDeleteGuest_Click(object sender, EventArgs e)
        {

        }

        private void FormGuestDatabase_Load(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
