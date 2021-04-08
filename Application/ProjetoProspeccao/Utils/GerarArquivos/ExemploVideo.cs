using ClosedXML.Excel;
using System;
using System.Diagnostics;

namespace Utils.GerarArquivos
{
    static class ExemploVideo
    {
        public static void GerarArquivo()
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Planilha1");
                worksheet.Cell("A1").Value = "Olá mundo";
                worksheet.Cell("A2").Value = 1;
                worksheet.Cell("A3").Value = 2;
                worksheet.Cell("A4").Value = 3;

                // Formulas
                worksheet.Cell("A5").FormulaA1 = "=SUM(A2:A4)";

                // Imagens
                var caminhoImagem = @"C:\Users\FOEU\My Private Documents\Foto.jpg";
                worksheet.AddPicture(caminhoImagem).MoveTo(worksheet.Cell("A10")).Scale(0.05);

                // Bordas
                worksheet.Cell("A1").Style.Border.BottomBorder = XLBorderStyleValues.Thick;
                worksheet.Cell("A1").Style.Border.BottomBorderColor = XLColor.Red;
                worksheet.Cell("A1").Style.Border.LeftBorder = XLBorderStyleValues.Thick;
                worksheet.Cell("A1").Style.Border.LeftBorderColor = XLColor.Red;
                worksheet.Cell("A1").Style.Border.RightBorder = XLBorderStyleValues.Thick;
                worksheet.Cell("A1").Style.Border.RightBorderColor = XLColor.Red;
                worksheet.Cell("A1").Style.Border.TopBorder = XLBorderStyleValues.Thick;
                worksheet.Cell("A1").Style.Border.TopBorderColor = XLColor.Red;

                // Calculando com fórmula
                Console.WriteLine("Valor da soma: " + worksheet.Cell("A5").Value);

                workbook.SaveAs(@"C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\ArquivosExcel\testeExcel1.xlsx");
            }

            Process.Start(new ProcessStartInfo(@"C:\Users\FOEU\My Private Documents\Plano de Estudos UBS BB\projetos\ArquivosExcel\testeExcel1.xlsx") { UseShellExecute = true });
        }
    }
}
