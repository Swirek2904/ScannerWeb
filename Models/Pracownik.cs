using Microsoft.Build.Framework;
using System;
using System.Collections.Generic;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ScannerWeb.Models;

public class Pracownik
{
    public int IdPracownik { get; set; }
    [Required(ErrorMessage = "Podaj imie!")]
    public string Imie { get; set; } = null!;
    [Required(ErrorMessage = "Podaj nazwisko!")]
    public string Nazwisko { get; set; } = null!;
    [Required(ErrorMessage = "Podaj pesel!")]
    public string Pesel { get; set; } = null!;
    [Required(ErrorMessage = "Podaj numer telefonu! ")]
    public string NumerTelefonu { get; set; } = null!;

    public int IdKarty { get; set; }
    [Required(ErrorMessage = "Podaj poziom dostępu! ")]
    public string PoziomDostepu { get; set; } = null!;

    public virtual ICollection<Historium> Historia { get; } = new List<Historium>();

    public virtual Karty IdKartyNavigation { get; set; } = null!;
}
