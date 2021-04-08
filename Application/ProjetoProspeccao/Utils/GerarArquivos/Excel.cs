using BLL.DTO.Fluxo;
using ClosedXML.Excel;
using System;
using System.IO;
using System.Linq;

namespace Utils.GerarArquivos
{
    public static class Excel
    {
        public static MemoryStream GerarArquivo(ListaFluxoDTO listaFluxo)
        {
            using(var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Fluxo clientes");

                worksheet.Cell("A1").Value = "Fluxo de clientes";
                var range = worksheet.Range("A1:E1");
                range.Merge().Style.Font.SetBold().Font.FontSize = 20;

                worksheet.Cell("A2").Value = "Cliente";
                worksheet.Cell("B2").Value = "CPF";
                worksheet.Cell("C2").Value = "Usuário";
                worksheet.Cell("D2").Value = "Status";
                worksheet.Cell("E2").Value = "Data e hora";

                var linha = 3;
                for(int i = 0; i < listaFluxo.ListaAnaliseModel.Count(); i++)
                {
                    worksheet.Cell($"A{linha}").Value = listaFluxo.ListaAnaliseModel[i].Cliente.Nome;
                    worksheet.Cell($"B{linha}").Value = Convert.ToInt64(listaFluxo.ListaAnaliseModel[i].Cliente.Cpf).ToString(@"000\.000\.000\-00");
                    worksheet.Cell($"C{linha}").Value = listaFluxo.ListaAnaliseModel[i].Usuario.Login_Usuario;
                    worksheet.Cell($"D{linha}").Value = listaFluxo.ListaAnaliseModel[i].StatusAnalise.Nome_Status;
                    worksheet.Cell($"E{linha}").Value = listaFluxo.ListaAnaliseModel[i].Data_Hora;

                    linha++;
                }

                linha--;

                range = worksheet.Range($"A2:E{linha}");
                range.CreateTable();

                worksheet.Columns("1-5").AdjustToContents();

                MemoryStream stream = new MemoryStream();
                workbook.SaveAs(stream);
                return stream;
            }
        }
    }
}
