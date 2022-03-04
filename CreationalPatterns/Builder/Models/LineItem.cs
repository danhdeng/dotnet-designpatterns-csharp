using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Builder.Models;

public class LineItem
{
    public LineItem(string name,int qty, decimal unitCost) => (Qty, Name, UnitCost) = (qty, name, unitCost);
    public int Qty { get; set; }
    public string Name { get; set; }

    public decimal UnitCost { get; set; }
}
