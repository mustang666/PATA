using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace PATA
{
    public class ExcelHandler
    {
        public static Dados readFromExcelFile(string path)
        {
            Sintoma p = null;
            Dados _dados = new Dados();


            Excel.Application excelApplication = new Excel.Application();
            excelApplication.Visible = false;
            Excel.Workbook excelWorkBook = excelApplication.Workbooks.Open(path);

            // WORKSHEET LISTA DE SINTOMAS
            Excel.Worksheet excelWorkSheetP = excelWorkBook.Worksheets.get_Item("Lista de Sintomas");
            // quantas linhas tem a worksheet?
            int linhaP = 1;

            while (linhaP <= excelWorkSheetP.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row)
            {
                // ler as colunas
                String name = excelWorkSheetP.Cells[linhaP, 1].Value;

                // teste
                p = new Sintoma(name);

                linhaP++;

                _dados._listSintomas.Add(p);
            }
            /* ######################################################################################################### */

            //WORKSHEET DIAGNOSTICO E TRATAMENTOS
            excelWorkSheetP = excelWorkBook.Worksheets.get_Item("Diagnósticos e Tratamentos");
            // quantas linhas tem a worksheet?
            linhaP = 2;
            int coluna = 1;
            Diagnostico diag = new Diagnostico();
            List<Sintoma> lista = new List<Sintoma>();

            while (linhaP <= excelWorkSheetP.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing).Row)
            {
               
                while ((string)(excelWorkSheetP.Cells[linhaP, coluna] as Excel.Range).Value != null)
                {
                    String name = excelWorkSheetP.Cells[linhaP, coluna].Value;


                    if (coluna == 1)
                    {
                        diag.Orgao = name;
                    }

                    if (coluna == 2)
                    {
                        diag.Nome = name;
                    }


                    if (coluna == 4)
                    {
                        diag.Tratamento = name;
                    }

                    if (coluna > 4)
                    {
                        if (!String.IsNullOrEmpty(name))
                        {
                            lista.Add(new Sintoma(name));
                        }
                    }
                    coluna++;
                }
                diag.ListSintomas = lista;
                _dados._listDiagnosticos.Add(diag);

                diag = new Diagnostico();
                lista = new List<Sintoma>();
                coluna = 1;
                linhaP++;
            }

            excelApplication.DisplayAlerts = false;
            excelApplication.Quit();

            

            return _dados;
        }



    }
}
