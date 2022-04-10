using System;
using System.Collections.Generic;
using System.IO;
using App.Models;
using OfficeOpenXml;
using App.Data;
using System.Linq;

namespace App.UI
{
    public static class MenuPrincipal
    {
        const int max = 99; // quantidade maxima de linhas  que o loop vai interar
        public static void ExibirMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== Menu Principal ===");
            Console.WriteLine();
            Console.WriteLine("1 - Importar .xlsx");
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("opc: ");

            int opc = Convert.ToInt32(Console.ReadLine());

            switch (opc)
            {
                case 0:
                    Environment.Exit(0); // fecha a aplicação
                    break;
                case 1:
                    ImportarArquivo();
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
            }
        }

        public static void ImportarArquivo()
        {
            // importa o arquivo
            FileInfo arquivo = new FileInfo(@"C:\Users\Selton\Documents\C#\Projetos\App\infosis.xlsx"); // caminho do arquivo

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(arquivo))
            {
                // especifica a planilha do arquivo a ser usado
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                using (var context = new AppDbContext()) // abre e fecha a conexão com banco de dados
                {
                    for (int linha = 2; linha <= max; linha++)
                    {
                        // verifica se o funcionario já existe no bando de dados
                        var funcionarioBusca = context.funcionarios.FirstOrDefault(x => x.Cpf == worksheet.Cells[linha, 3].Value.ToString());

                        // caso o funcionario não exista faz a inserção no banco de dados
                        if (funcionarioBusca == null)
                        {
                            var funcionario = new Funcionario
                            {
                                Nome = worksheet.Cells[linha, 1].Value.ToString(),
                                Sobrenome = worksheet.Cells[linha, 2].Value.ToString(),
                                Cpf = worksheet.Cells[linha, 3].Value.ToString(),
                            };

                            // salva os dados no banco
                            context.funcionarios.Add(funcionario);
                            context.SaveChanges();
                        }

                        // verifica se a modalidade de contrato já existe no bando de dados
                        var modalidadeContratoBusca = context.modalidadesDeContrato.FirstOrDefault(x => x.Nome == worksheet.Cells[linha, 5].Value.ToString());

                        if (modalidadeContratoBusca == null)
                        {
                            var modalidade = new ModalidadeContrato
                            {
                                Nome = worksheet.Cells[linha, 5].Value.ToString()
                            };

                            // salva os dados no banco
                            context.modalidadesDeContrato.Add(modalidade);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}