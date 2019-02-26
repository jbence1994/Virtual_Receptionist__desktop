﻿using System.Data;

namespace virtual_receptionist.Presenter
{
    /// <summary>
    /// Vendég bejelentkező lap prezentere
    /// </summary>
    public class RegistrationCardPresenter : DefaultPresenter
    {
        #region Vendég bejelentkező lap nézetfrissítései

        /// <summary>
        /// Metódus, amely elmenti a vendég, cég és foglalás adatait adatbázisba
        /// </summary>
        public void SaveData(bool isCompany, params object[] dataParameters)
        {

        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetCompanyData() //Szétbontás elemi aattípusra az objektum mezőit
        {
            dataRepository.GetSpecifiedCompanyData();
            return new DataTable();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public DataTable GetGuestData() //Szétbontás elemi aattípusra az objektum mezőit
        {
            dataRepository.GetSpecifiedGuestData();
            return new DataTable();
        }

        #endregion
    }
}
