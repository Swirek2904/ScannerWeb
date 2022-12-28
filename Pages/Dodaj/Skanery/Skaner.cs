using System.ComponentModel.DataAnnotations;

namespace ScannerWeb.Pages.Skanery
{
    public class Skaner
    {
        // to jak chcesz to wyrzuć bo jednak mi nie poszło tym sposobem i nie potrzebuje
        public int idSkanera { get; set; }
        public int idBudynku { get; set; }
        public string? typAutoryzacji { get; set; }
        public int kodOtwarcia { get; set; }
        public string? poziomDostepu { get; set; }
    }
}
