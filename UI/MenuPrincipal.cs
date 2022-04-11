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
        public static void ExibirMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("=== Menu Principal ===");
            Console.WriteLine();
            Console.WriteLine("1 - Importar arquivo");
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

        // importa o arquivo
        public static void ImportarArquivo()
        {
            FileInfo arquivo = new FileInfo(@"C:\Users\Selton\Documents\C#\Projetos\App\infosis.xlsx"); // caminho do arquivo

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(arquivo))
            {
                // especifica a planilha do arquivo a ser usado
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];

                // quantidade maxima de linhas do arquivo
                int max = worksheet.Dimension.End.Row;

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

                        // verifica se o tipo de  modalidade de contratação já existe no banco de dados
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

                        // verifica se o tipo de expediente já existe no banco de dados
                        var expedienteBusca = context.expedientes.FirstOrDefault(x => x.CargaHoraria == int.Parse(worksheet.Cells[linha, 6].Value.ToString()));

                        if (expedienteBusca == null)
                        {
                            var expediente = new Expediente
                            {
                                CargaHoraria = int.Parse(worksheet.Cells[linha, 6].Value.ToString())
                            };

                            // salva os dados no banco
                            context.expedientes.Add(expediente);
                            context.SaveChanges();
                        }

                        // verifica se o tipo de cargo já existe no banco de dados
                        var cargoBusca = context.cargos.FirstOrDefault(x => x.NomeCargo == worksheet.Cells[linha, 7].Value.ToString());

                        if (cargoBusca == null)
                        {
                            var cargo = new Cargo
                            {
                                NomeCargo = worksheet.Cells[linha, 7].Value.ToString()
                            };

                            // salva os dados no banco
                            context.cargos.Add(cargo);
                            context.SaveChanges();
                        }

                        // verifica se o contrato já existe no banco de dados
                        var idFuncionario = context.funcionarios.FirstOrDefault(x => x.Cpf == worksheet.Cells[linha, 3].Value.ToString()).Id;
                        var idCargo = context.cargos.FirstOrDefault(x => x.NomeCargo == worksheet.Cells[linha, 7].Value.ToString()).Id;
                        var idExpediente = context.expedientes.FirstOrDefault(x => x.CargaHoraria == int.Parse(worksheet.Cells[linha, 6].Value.ToString())).Id;
                        var idModalidadeContrato = context.modalidadesDeContrato.FirstOrDefault(x => x.Nome == worksheet.Cells[linha, 5].Value.ToString()).Id;

                        var contratoBusca = context.contratos.FirstOrDefault(x => x.IdFuncionario == idFuncionario);

                        if (contratoBusca == null)
                        {
                            // verifica se o campo DataInicio e DataFim não estão em branco
                            if (worksheet.Cells[linha, 8].Text.Length > 0 && worksheet.Cells[linha, 9].Text.Length > 0)
                            {

                                var contrato = new Contrato
                                {
                                    IdFuncionario = idFuncionario,
                                    IdCargo = idCargo,
                                    IdExpediente = idExpediente,
                                    IdModalidadeContrato = idModalidadeContrato,
                                    DataInicio = Convert.ToDateTime(worksheet.Cells[linha, 8].Value.ToString()),
                                    DataFim = Convert.ToDateTime(worksheet.Cells[linha, 9].Value.ToString())
                                };

                                // salva os dados no banco
                                context.contratos.Add(contrato);
                                context.SaveChanges();
                            }

                            // verifica se o campo DataInicio não estão em branco
                            else if (worksheet.Cells[linha, 8].Text.Length > 0)
                            {

                                var contrato = new Contrato
                                {
                                    IdFuncionario = idFuncionario,
                                    IdCargo = idCargo,
                                    IdExpediente = idExpediente,
                                    IdModalidadeContrato = idModalidadeContrato,
                                    DataInicio = Convert.ToDateTime(worksheet.Cells[linha, 8].Value.ToString())
                                };

                                // salva os dados no banco
                                context.contratos.Add(contrato);
                                context.SaveChanges();
                            }
                            else // caso o campo DataInicio esteja em branco o banco de dados faz a inserção com base na data e hora atual
                            {
                                var contrato = new Contrato
                                {
                                    IdFuncionario = idFuncionario,
                                    IdCargo = idCargo,
                                    IdExpediente = idExpediente,
                                    IdModalidadeContrato = idModalidadeContrato,
                                };

                                // salva os dados no banco
                                context.contratos.Add(contrato);
                                context.SaveChanges();
                            }
                        }

                        // faz a inserção do registro de ponto no banco
                        var IdFuncionario = context.funcionarios.FirstOrDefault(x => x.Cpf == worksheet.Cells[linha, 3].Value.ToString()).Id;


                        // verifica se o campo tempo não esta em branco
                        if (worksheet.Cells[linha, 4].Text.Length > 0)
                        {
                            var registroPonto = new RegistroPonto
                            {
                                IdFuncionario = idFuncionario,
                                Tempo = Convert.ToDateTime(worksheet.Cells[linha, 4].Value.ToString())
                            };

                            // salva os dados no banco
                            context.registrosDePonto.Add(registroPonto);
                            context.SaveChanges();
                        }
                        else // caso o campo tempo esteja em branco o banco de dados faz a inserção com base na data e hora atual
                        {
                            var registroPonto = new RegistroPonto
                            {
                                IdFuncionario = idFuncionario
                            };

                            // salva os dados no banco
                            context.registrosDePonto.Add(registroPonto);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}