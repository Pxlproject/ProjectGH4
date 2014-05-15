using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SamenSterker_WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface ISamenSterker_Service
    {
        // methoden van de klasse CompanyDB
        /// <summary>
        /// haalt een lijst op met de gegevens van bedrijven
        /// </summary>
        /// <returns> companyList (lijst van bedrijven) </returns>
        [OperationContract]
        List<Company> GetAllCompanies();

        /// <summary>
        /// voegt een nieuw bedrijf toe
        /// </summary>
        /// <param name="comp"></param>
        /// <returns> False of True (of het toevoegen al dan niet gelukt is) </returns>
        [OperationContract]
        Boolean AddCompany(Company comp);

        /// <summary>
        /// past de gegevens van een bedrijf aan
        /// </summary>
        /// <param name="old"></param>
        /// <param name="updated"></param>
        /// <returns> True of False (of de update al dan niet gelukt is) </returns>
        [OperationContract]
        Boolean UpdateCompany(Company old, Company updated);

        /// <summary>
        /// verwijdert een bedrijf met zijn gegevens
        /// </summary>
        /// <param name="comp"></param>
        /// <returns> True of False (naargelang het verwijderen geslaagd is) </returns>
        [OperationContract]
        Boolean DeleteCompany(Company comp);

        // methoden van de klasse ContractDB
        /// <summary>
        /// haalt een lijst op met de gegevens van contracten
        /// </summary>
        /// <returns> contractList (lijst van contracten) </returns>
        [OperationContract]
        List<Contract> GetAllContracts();

        // methoden van de klasse ContractFormulaDB
        /// <summary>
        /// haalt een lijst op met de gegevens van contractFormula
        /// </summary>
        /// <returns> contractFormulaList (lijst van contractFormula) </returns>
        [OperationContract]
        List<ContractFormula> GetAllContractFormula();

        // methoden van de klasse LocationDB
        /// <summary>
        /// haalt een lijst op met de locaties
        /// </summary>
        /// <returns></returns>
        [OperationContract]
        List<Location> GetAllLocations();

        // methoden van de klasse ReservationDB
        /// <summary>
        /// haalt een lijst op met de gegevens van reservaties
        /// </summary>
        /// <returns> reservationList (lijst van reservaties) </returns>
        [OperationContract]
        List<Reservation> GetAllReservations();

        /// <summary>
        /// voegt een nieuwe reservatie toe
        /// </summary>
        /// <param name="reserv"></param>
        /// <returns> True of False (of het toevoegen al dan niet gelukt is) </returns>
        [OperationContract]
        Boolean AddReservation(Reservation reserv);

        /// <summary>
        /// past een reservatie aan
        /// </summary>
        /// <param name="old"></param>
        /// <param name="updated"></param>
        /// <returns> True of False (of de update al dan niet gelukt is) </returns>
        [OperationContract]
        Boolean UpdateReservation(Reservation old, Reservation updated);

        /// <summary>
        /// verwijdert een reservatie
        /// </summary>
        /// <param name="reserv"></param>
        /// <returns> True of False (naargelang het verwijderen geslaagd is) </returns>
        [OperationContract]
        Boolean DeleteReservation(Reservation reserv);
    }
}
