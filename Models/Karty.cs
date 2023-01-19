using System;
using System.Collections.Generic;
using RequiredAttribute = System.ComponentModel.DataAnnotations.RequiredAttribute;

namespace ScannerWeb.Models;

public partial class Karty
{
    [Required(ErrorMessage = "Podaj identyfikator karty!")]
    public int Uid { get; set; }
    [Required(ErrorMessage = "Podaj identyfikator osoby!")]
    public int IdOsoby { get; set; }
    [Required(ErrorMessage = "Podaj kod otwarcia!")]
    public int? KodOtwarcia { get; set; }

    public virtual ICollection<Pracownik> Pracowniks { get; } = new List<Pracownik>();
}
