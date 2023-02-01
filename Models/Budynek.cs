using System;
using System.Collections.Generic;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ScannerWeb.Models;

public partial class Budynek
{
    public int IdBudynku { get; set; }
    [Required(ErrorMessage = "Podaj nazwę budynku!")]
    public string Nazwa { get; set; } = null!;
    [Required(ErrorMessage = "Podaj identyfikator skanera!")]
    public int IdSkanera { get; set; }

    public virtual ICollection<Skaner> Skaners { get; } = new List<Skaner>();
}
