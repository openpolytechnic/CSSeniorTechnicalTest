using OpenPolytechnic.TechnicalTest.Enum;
using OpenPolytechnic.TechnicalTest.Model.Customer.Interface;

namespace OpenPolytechnic.TechnicalTest.Model.Customer
{
    public class Customer : ICustomer
    {
        public Customer(int userId, string mamberName, CustomerType customerType)
        {
            UserId = userId;
            MamberName = mamberName;
            CustomerType = customerType;
        }

        public int UserId { get; internal set; }

        public string MamberName { get; internal set; }

        public CustomerType CustomerType { get; internal set; }
    }
}
