using System.Collections.Generic;

namespace NUCA.Projects.Application.Invoices.Commands.UpdateItems
{
    public class UpdateItemModel
    {
        public long TableId { get; set; }
        public long SectionId { get; set; }
        public long ItemId { get; set; }
        public bool IsSupplies { get; set; }
        public double CurrentQuantity { get; set; }
        public List<ItemPercentageModel> Percentages = new List<ItemPercentageModel>();
        public string Notes { get; set; }
    }

    public class ItemPercentageModel
    {
        public double Quantity { get; set; }
        public double Percentage { get; set; }
        public string Notes { get; set; }
    }
}
