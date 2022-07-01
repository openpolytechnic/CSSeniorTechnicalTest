using OpenPolytechnic.TechnicalTest.Enum;

namespace OpenPolytechnic.TechnicalTest.Model.Customer.Interface
{
    public interface ICustomer
    {
        public int UserId { get; }
        public string MamberName { get; }
        public CustomerType CustomerType { get; }
    }
}
