using KeyHouse.container;
using KeyHouse.Models.Entities;
using System.Diagnostics.Contracts;

namespace KeyHouse.Services
{
    public class ContractRepo : IContract
    {
        KeyHouseDB keyHouseContext;

        public ContractRepo(KeyHouseDB _keyHouseContext)
        {
            keyHouseContext = _keyHouseContext;
        }
        public int createContact(Contracts contracts)
        {
            Contracts new_Contract = new Contracts();
            new_Contract.Contract_Name = contracts.Contract_Name;
            new_Contract.Start_date = contracts.Start_date;
            new_Contract.End_date= contracts.End_date;
            new_Contract.Agencies = contracts.Agencies;
            
            keyHouseContext.Contracts.Add(new_Contract);
            return keyHouseContext.SaveChanges();

        }

        public int deleteContract(int Id)
        {
            var contract = keyHouseContext.Contracts.FirstOrDefault(x => x.Id == Id);
            if (contract != null)
            {
                keyHouseContext.Contracts.Remove(contract);
                return keyHouseContext.SaveChanges();

            }
            else
            {
                return 0; 
            }
        }

        public List<Contracts> getAllContacts()
        {

            return keyHouseContext.Contracts.ToList();

        }

        public Contracts getContractByID(int id)
        {
            return keyHouseContext.Contracts.SingleOrDefault(c => c.Id == id);

        }
        public Contracts getContractByAgencyID(string agencyID)
        {
            return keyHouseContext.Contracts.SingleOrDefault(a => a.Agencies.Id == agencyID && a.End_date > DateTime.Now);

        }

        public int updateContact(Contracts Updatedcontract)
        {
            var contract = keyHouseContext.Contracts.FirstOrDefault(x => x.Id == Updatedcontract.Id);
            if (contract != null)
            {
                contract.Contract_Name = Updatedcontract.Contract_Name;
                contract.Start_date = Updatedcontract.Start_date;
                contract.End_date = Updatedcontract.End_date;
                contract.Agencies = Updatedcontract.Agencies;
                return keyHouseContext.SaveChanges();

            }
            else
            {
                return 0;
            }
        }
    }
}
