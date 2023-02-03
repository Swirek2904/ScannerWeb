using System;
using System.Collections.Generic;

namespace ScannerWeb.Models;

public partial class Historium
{
    public int Id { get; set; }

    public int IdSkanera { get; set; }

    public int IdOsoby { get; set; }

	public DateTime Data { get; set; } = DateTime.Now.Date;
	public string DataDisplay
	{
		get { return Data.ToString("dd.MM.yyyy"); }
	}

	public TimeSpan Czas { get; set; }
    public string CzasDisplay
    {
        get { return Czas.ToString("hh\\:mm\\:ss"); }
    }

    public string TypAutoryzacji { get; set; } = null!;

    public virtual Pracownik IdOsobyNavigation { get; set; } = null!;

    public virtual Skaner IdSkaneraNavigation { get; set; } = null!;
}
