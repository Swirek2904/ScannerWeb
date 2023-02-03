using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ScannerWeb.Models;

public partial class Pracownik
{
    public int IdPracownik { get; set; }
    [Required(ErrorMessage = "Podaj imie!")]
    [RegularExpression(@"^[A-ZŁŻ]{1}[a-ząćęłńóśżź]{1,14}$", ErrorMessage = "Imię jest niepoprawne")]
    public string Imie { get; set; } = null!;

    [Required(ErrorMessage = "Podaj nazwisko!")]
    [RegularExpression(@"^[A-ZĆŁŃŚŻŹ]{1}[a-ząćęłńóśżź]{1,24}$", ErrorMessage = "Nazwisko jest niepoprawne")]
    public string Nazwisko { get; set; } = null!;

    [StringLength(11,ErrorMessage = "Pesel musi zawierać 11 cyfr!")]
    [MinLength(11, ErrorMessage = "Pesel musi zawierać 11 cyfr!")]
    [Required(ErrorMessage = "Podaj pesel!")]
    public string Pesel { get; set; } = null!;

    [Required(ErrorMessage = "Podaj numer telefonu! ")]
    [RegularExpression(@"^(\d{3}[-]\d{3}[-]\d{3}|\d{9})$", ErrorMessage = " Numer musi składać się z 9 cyfr, akceptowalny format to XXX-YYY-ZZZ lub XXXYYYZZZ.")]
    public string NumerTelefonu { get; set; } = null!;

    public int IdKarty { get; set; }

    public string PoziomDostepu { get; set; } = null!;

    public virtual ICollection<Historium> Historia { get; } = new List<Historium>();

    public virtual Karty IdKartyNavigation { get; set; } = null!;
}
