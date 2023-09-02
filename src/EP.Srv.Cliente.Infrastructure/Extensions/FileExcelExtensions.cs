using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
//using Aspose.Cells;

namespace EP.Srv.Cliente.Infrastructure.Extensions
{
    public class FileExcelExtensions
    {
        public MemoryStream CreateFileStream<TEntity>(IEnumerable<TEntity> entities, IEnumerable<string> columns, Action<TEntity, string, Cell> valorCelula, string sheetName = "Sheet1", int sheetId = 1) where TEntity : class
        {
            var memoryStream = new MemoryStream();
            using var document = SpreadsheetDocument.Create(memoryStream, SpreadsheetDocumentType.Workbook, true);
            var workbookPart = document.AddWorkbookPart();
            workbookPart.Workbook = new Workbook();
            var sheetData = new SheetData();
            var worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
            worksheetPart.Worksheet = new Worksheet(sheetData);
            var sheets = workbookPart.Workbook.AppendChild(new Sheets());
            var sheet = new Sheet { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = Convert.ToUInt32(sheetId), Name = sheetName };
            sheets.Append(sheet); uint rowIndex = 1;
            var headerRow = new Row { RowIndex = rowIndex };
            var cellReference = 0;

            foreach (var columnName in columns)
            {
                var cell = new Cell
                {
                    CellReference = $"{(char)('A' + cellReference)}{rowIndex}",
                    DataType = CellValues.String,
                    CellValue = new CellValue(columnName)
                };
                headerRow.AppendChild(cell);
                cellReference++;
            }
            sheetData.AppendChild(headerRow);
            rowIndex++;

            foreach (var entity in entities)
            {
                var newRow = new Row { RowIndex = rowIndex };
                cellReference = 0;
                foreach (var columnName in columns)
                {
                    var cell = new Cell
                    {
                        CellReference = $"{(char)('A' + cellReference)}{rowIndex}",
                        DataType = CellValues.String
                    };
                    valorCelula?.Invoke(entity, columnName, cell);
                    newRow.AppendChild(cell);
                    cellReference++;
                }
                sheetData.AppendChild(newRow);
                rowIndex++;
            }
            document.WorkbookPart!.Workbook.Save();
            memoryStream.Position = 0;
            return memoryStream;
        }

        public MemoryStream CombinedFiles(List<MemoryStream> listStream)
        {
            var newStream = new MemoryStream();

            // Criar pasta de trabalho de destino.
            // A primeira planilha é adicionada por padrão. Adicione a segunda planilha.
            Aspose.Cells.Workbook destWorkbook = new Aspose.Cells.Workbook();


            for (int i = 0; i < listStream.Count; i++)
            {
                Aspose.Cells.Workbook excelA = new Aspose.Cells.Workbook(listStream[i]);
                destWorkbook.Worksheets.Add();
                destWorkbook.Worksheets[i].Copy(excelA.Worksheets[0]);
                destWorkbook.Worksheets[i].Name = excelA.Worksheets[0].Name;
            }

            //removendo a ultima planilha adicionada pela biblioteca
            destWorkbook.Worksheets.RemoveAt(5);
            newStream = destWorkbook.SaveToStream();

            return newStream;
        }
    }
}
