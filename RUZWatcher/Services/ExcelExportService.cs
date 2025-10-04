using ClosedXML.Excel;
using RUZWatcher.Models;

namespace RUZWatcher.Services
{
    /// <summary>
    /// Service na export účtovných jednotiek do Excelu.
    /// </summary>
    public class ExcelExportService
    {
        /// <summary>
        /// Exportuje zoznam účtovných jednotiek do Excel súboru.
        /// </summary>
        /// <param name="uctovneJednotky">Zoznam účtovných jednotiek na export</param>
        /// <returns>Byte array s Excel súborom</returns>
        public byte[] ExportUctovneJednotky(List<UctovnaJednotka> uctovneJednotky)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Účtovné jednotky");

            // Nastavenie hlavičiek
            worksheet.Cell(1, 1).Value = "ID";
            worksheet.Cell(1, 2).Value = "Názov subjektu";
            worksheet.Cell(1, 3).Value = "Právna forma";
            worksheet.Cell(1, 4).Value = "Mesto";
            worksheet.Cell(1, 5).Value = "Ulica";
            worksheet.Cell(1, 6).Value = "PSČ";
            worksheet.Cell(1, 7).Value = "Dátum vzniku";
            worksheet.Cell(1, 8).Value = "Poznámka";
            worksheet.Cell(1, 9).Value = "Hodnotenie";
            worksheet.Cell(1, 10).Value = "Počet účtovných závierok";

            // Formátovanie hlavičky
            var headerRange = worksheet.Range(1, 1, 1, 10);
            headerRange.Style.Font.Bold = true;
            headerRange.Style.Fill.BackgroundColor = XLColor.LightGray;
            headerRange.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

            // Naplnenie dát
            int row = 2;
            foreach (var jednotka in uctovneJednotky)
            {
                worksheet.Cell(row, 1).Value = jednotka.Id?.ToString() ?? "";
                worksheet.Cell(row, 2).Value = jednotka.NazovSubjektu ?? "";
                worksheet.Cell(row, 3).Value = jednotka.PravnaForma ?? "";
                worksheet.Cell(row, 4).Value = jednotka.AdresaMesto ?? "";
                worksheet.Cell(row, 5).Value = jednotka.AdresaUlica ?? "";
                worksheet.Cell(row, 6).Value = jednotka.AdresaPSC ?? "";

                if (jednotka.DatumVzniku.HasValue)
                {
                    worksheet.Cell(row, 7).Value = jednotka.DatumVzniku.Value;
                    worksheet.Cell(row, 7).Style.DateFormat.Format = "dd.MM.yyyy";
                }

                worksheet.Cell(row, 8).Value = jednotka.Poznámka ?? "";
                worksheet.Cell(row, 9).Value = jednotka.Hodnotenie;
                worksheet.Cell(row, 10).Value = jednotka.UctovneZavierky?.Count ?? 0;

                row++;
            }

            // Auto-fit stĺpcov
            worksheet.Columns().AdjustToContents();

            // Konverzia do byte array
            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            return stream.ToArray();
        }

        /// <summary>
        /// Vytvorí názov súboru s aktuálnym dátumom.
        /// </summary>
        public string GetFileName()
        {
            return $"UctovneJednotky_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";
        }
    }
}
