using OpenPolytechnic.TechnicalTest.Enum;

namespace OpenPolytechnic.TechnicalTest.Model.Promotions
{
    public class Discount
    {
        public DiscountMonth Month { get; set; }
        public decimal DiscountAmout { get; set; }
        public bool ClubMembersOnly { get; set; }
    }
}
