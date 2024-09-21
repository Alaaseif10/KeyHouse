using KeyHouse.Models.Entities;

namespace KeyHouse.Services
{
    public interface IContract
    {
        public int createContact(Contracts contracts);

        public int updateContact(Contracts contracts);

        public List<Contracts> getAllContacts();

        public int deleteContract(int Id);

        public Contracts getContractByID(int id);
    }
}
