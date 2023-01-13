using System;
using System.Collections.Generic;

namespace ScannerWeb.Models;

public partial class Budynek
{
    public int IdBudynku { get; set; }

    public string Nazwa { get; set; } = null!;

    public int IdSkanera { get; set; }

    public virtual ICollection<Skaner> Skaners { get; } = new List<Skaner>();
}
