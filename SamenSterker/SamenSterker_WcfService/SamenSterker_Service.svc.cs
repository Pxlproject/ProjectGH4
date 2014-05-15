using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SamenSterker_WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class SamenSterker_Service : ISamenSterker_Service
    {
        // methoden van de klasse CompanyDB
        /// <summary>
        /// haalt een lijst op met de gegevens van bedrijven
        /// </summary>
        /// <returns> GetCompanyList() </returns>
        public List<Company> GetAllCompanies()
        {
            return CompanyDB.GetCompanyList();
        }

        /// <summary>
        /// voegt een nieuw bedrijf toe
        /// </summary>
        /// <param name="comp"></param>
        /// <returns> AddCompany(comp) </returns>
        public Boolean AddCompany(Company comp)
        {
            return CompanyDB.AddCompany(comp);
        }

        /// <summary>
        /// past de gegevens van een bedrijf aan
        /// </summary>
        /// <param name="old"></param>
        /// <param name="updated"></param>
        /// <returns> UpdateCompany(old, updated) </returns>
        public Boolean UpdateCompany(Company old, Company updated)
        {
            return CompanyDB.UpdateCompany(old, updated);
        }

        /// <summary>
        /// verwijdert een bedrijf met zijn gegevens
        /// </summary>
        /// <param name="comp"></param>
        /// <returns> DeleteCompany(comp) </returns>
        public Boolean DeleteCompany(Company comp)
        {
            return CompanyDB.DeleteCompany(comp);
        }

        // methoden van de klasse ContractDB
        /// <summary>
        /// haalt een lijst op met de gegevens van contracten
        /// </summary>
        /// <returns> GetContractList() </returns>
        public List<Contract> GetAllContracts()
        {
            return ContractDB.GetContractList();
        }

        // methoden van de klasse ContractFormulaDB
        /// <summary>
        /// haalt een lijst op met de gegevens van contractFormula
        /// </summary>
        /// <returns> GetContractFormulaList() </returns>
        public List<ContractFormula> GetAllContractFormula()
        {
            return ContractFormulaDB.GetContractFormulaList();
        }

        // methoden van de klasse LocationDB
        /// <summary>
        /// haalt een lijst op met de locaties
        /// </summary>
        /// <returns> GetLocationList() </returns>
        public List<Location> GetAllLocations()
        {
            return LocationDB.GetLocationList();
        }

        // methoden van de klasse ReservationDB
        /// <summary>
        /// haalt een lijst op met de gegevens van reservaties
        /// </summary>
        /// <returns> GetReservationList() </returns>
        public List<Reservation> GetAllReservations()
        {
            return ReservationDB.GetReservationList();
        }

        /// <summary>
        /// voegt een nieuwe reservatie toe
        /// </summary>
        /// <param name="reserv"></param>
        /// <returns> AddReservation(reserv) </returns>
        public Boolean AddReservation(Reservation reserv)
        {
            return ReservationDB.AddReservation(reserv);
        }

        /// <summary>
        /// past een reservatie aan
        /// </summary>
        /// <param name="old"></param>
        /// <param name="updated"></param>
        /// <returns> UpdateReservation(old, updated) </returns>
        public Boolean UpdateReservation(Reservation old, Reservation updated)
        {
            return ReservationDB.UpdateReservation(old, updated);
        }

        /// <summary>
        /// verwijdert een reservatie
        /// </summary>
        /// <param name="reserv"></param>
        /// <returns> DeleteReservation(reserv)  </returns>
        public Boolean DeleteReservation(Reservation reserv)
        {
            return ReservationDB.DeleteReservation(reserv);
        }
    }
}
