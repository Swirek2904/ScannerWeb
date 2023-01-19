using System;
using System.Collections.Generic;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ScannerWeb.Models;

public partial class Skaner
{
    public int IdSkanera { get; set; }
    [Required(ErrorMessage = "Podaj identyfikator budynku!")]
    public int IdBudynku { get; set; }
    [Required(ErrorMessage = "Podaj typ autoryzacji!")]
    public string? TypAutoryzacji { get; set; }
    [Required(ErrorMessage = "Podaj kod otwarcia!")]
    public int? KodOtwarcia { get; set; }
    [Required(ErrorMessage = "Podaj poziom dostępu!")]
    public string? PoziomDostepu { get; set; }

    public virtual ICollection<Historium> Historia { get; } = new List<Historium>();

    public virtual Budynek IdBudynkuNavigation { get; set; } = null!;
}
