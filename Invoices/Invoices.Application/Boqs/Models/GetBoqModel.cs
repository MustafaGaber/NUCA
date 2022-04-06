using NUCA.Invoices.Domain.Entities.Boqs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NUCA.Invoices.Application.Boqs.Models.GetBoq
{
    public class GetBoqModel
    {
        public double Addition { get; set; }
        public List<TableModel> Tables { get; set; } = new List<TableModel>();
        public GetBoqModel(Boq boq)
        {
            Addition = boq.Addition;
            Tables = boq.Tables.Select(t =>
            new TableModel
            {
                Id = t.Id,
                Name = t.Name,
                Count = t.Count,
                Addition = t.Addition,
                Sections = t.Sections.Select(s =>
                new SectionModel
                {
                    Id = s.Id,
                    Name = s.Name,
                    Items = s.Items.Select(i =>
                    new ItemModel
                    {
                        Id = i.Id,
                        Index = i.Index,
                        Content = i.Content,
                        Unit = i.Unit,
                        Quantity = i.Quantity,
                        UnitPrice = i.UnitPrice
                    }).ToList()
                }).ToList()
            }).ToList();
        }
    }

    public class TableModel
    {
        public List<SectionModel> Sections { get; set; } = new List<SectionModel>();
        public long Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public double Addition { get; set; }
    }

    public class SectionModel
    {
        public long Id { get; set; }
        public List<ItemModel> Items { get; set; } = new List<ItemModel>();
        public string Name { get; set; }
    }

    public class ItemModel
    {
        public long Id { get; set; }
        public string Index { get; set; }
        public string Content { get; set; }
        public string Unit { get; set; }
        public double Quantity { get; set; }
        public double UnitPrice { get; set; }
    }

}
