using System;
using System.Collections.Generic;
using System.IO;
using App.Models;
using OfficeOpenXml;
using App.Data;

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

        // importa o xlsx
        public static void ImportarArquivo()
        {
            LerExel();
        }


        public static void LerExel()
        {
            // inicializa uma lista vazia
            var listaFuncionario = new List<Funcionario>();
            var listaRegistroPonto = new List<RegistroPonto>();
            var listaCargo = new List<Cargo>();
            var listaContrato = new List<Contrato>();
            var listaExpediente = new List<Expediente>();
            var listaHoraExtra = new List<HoraExtra>();
            var listaModalidadeContrato = new List<ModalidadeContrato>();
            var listaModalidadeHoraExtra = new List<ModalidadeHoraExtra>();
            var listaOcorrencia = new List<Ocorrencia>();
            var listaStatusOcorrencia = new List<StatusOcorrencia>();
            var listaTipo = new List<Tipo>();
            var listaTipoOcorrencia = new List<TipoOcorrencia>();

            // importa o arquivo
            FileInfo arquivo = new FileInfo(@"C:\Users\Selton\Documents\C#\Projetos\App\infosis.xlsx"); // caminho do arquivo

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage package = new ExcelPackage(arquivo))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];


                using (var context = new AppDbContext()) // abre e fecha a conexão com sql server
                {
                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaFuncionario
                        if (worksheet.Cells[linha, 1].Text.Length > 0)
                        {
                            var funcionario = new Funcionario
                            {
                                Id = int.Parse(worksheet.Cells[linha, 1].Value.ToString()),
                                Nome = worksheet.Cells[linha, 2].Value.ToString(),
                                Sobrenome = worksheet.Cells[linha, 3].Value.ToString(),
                                Cpf = worksheet.Cells[linha, 4].Value.ToString(),
                            };

                            listaFuncionario.Add(funcionario);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaRegistroPonto
                        if (worksheet.Cells[linha, 5].Text.Length > 0)
                        {
                            var registroPonto = new RegistroPonto
                            {
                                Id = int.Parse(worksheet.Cells[linha, 5].Value.ToString()),
                                IdFuncionario = int.Parse(worksheet.Cells[linha, 6].Value.ToString()),
                                Tempo = Convert.ToDateTime(worksheet.Cells[linha, 7].Value.ToString())
                            };

                            listaRegistroPonto.Add(registroPonto);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaModalidadeContrato
                        if (worksheet.Cells[linha, 8].Text.Length > 0)
                        {
                            var modalidadeContrato = new ModalidadeContrato
                            {
                                Id = int.Parse(worksheet.Cells[linha, 8].Value.ToString()),
                                Nome = worksheet.Cells[linha, 9].Value.ToString()
                            };

                            listaModalidadeContrato.Add(modalidadeContrato);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaExpediente
                        if (worksheet.Cells[linha, 10].Text.Length > 0)
                        {
                            var expediente = new Expediente
                            {
                                Id = int.Parse(worksheet.Cells[linha, 10].Value.ToString()),
                                CargaHoraria = int.Parse(worksheet.Cells[linha, 11].Value.ToString())
                            };

                            listaExpediente.Add(expediente);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaCargo
                        if (worksheet.Cells[linha, 12].Text.Length > 0)
                        {
                            var cargo = new Cargo
                            {
                                Id = int.Parse(worksheet.Cells[linha, 12].Value.ToString()),
                                NomeCargo = worksheet.Cells[linha, 13].Value.ToString()
                            };

                            listaCargo.Add(cargo);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaContrato
                        if (worksheet.Cells[linha, 14].Text.Length > 0)
                        {
                            // verifica se o campo campoDataInicio e DataFim estão preenchidos 
                            if (worksheet.Cells[linha, 19].Text.Length > 0 && worksheet.Cells[linha, 20].Text.Length > 0)
                            {
                                var contrato = new Contrato
                                {
                                    Id = int.Parse(worksheet.Cells[linha, 14].Value.ToString()),
                                    IdFuncionario = int.Parse(worksheet.Cells[linha, 15].Value.ToString()),
                                    IdModalidadeContrato = int.Parse(worksheet.Cells[linha, 16].Value.ToString()),
                                    IdExpediente = int.Parse(worksheet.Cells[linha, 17].Value.ToString()),
                                    IdCargo = int.Parse(worksheet.Cells[linha, 18].Value.ToString()),
                                    DataInicio = Convert.ToDateTime(worksheet.Cells[linha, 19].Value.ToString()),
                                    DataFim = Convert.ToDateTime(worksheet.Cells[linha, 20].Value.ToString())
                                };

                                listaContrato.Add(contrato);
                            }
                            // verifica se o campo campoDataInicio esta preenchidos 
                            else if (worksheet.Cells[linha, 19].Text.Length > 0)
                            {
                                var contrato = new Contrato
                                {
                                    Id = int.Parse(worksheet.Cells[linha, 14].Value.ToString()),
                                    IdFuncionario = int.Parse(worksheet.Cells[linha, 15].Value.ToString()),
                                    IdModalidadeContrato = int.Parse(worksheet.Cells[linha, 16].Value.ToString()),
                                    IdExpediente = int.Parse(worksheet.Cells[linha, 17].Value.ToString()),
                                    IdCargo = int.Parse(worksheet.Cells[linha, 18].Value.ToString()),
                                    DataInicio = Convert.ToDateTime(worksheet.Cells[linha, 19].Value.ToString()),

                                };

                                listaContrato.Add(contrato);
                            }
                            // caso o campo DataInicio e DataFim forem nulos o campo dataInicio sera preenchido com a data e hora atual 
                            else
                            {
                                var contrato = new Contrato
                                {
                                    Id = int.Parse(worksheet.Cells[linha, 14].Value.ToString()),
                                    IdFuncionario = int.Parse(worksheet.Cells[linha, 15].Value.ToString()),
                                    IdModalidadeContrato = int.Parse(worksheet.Cells[linha, 16].Value.ToString()),
                                    IdExpediente = int.Parse(worksheet.Cells[linha, 17].Value.ToString()),
                                    IdCargo = int.Parse(worksheet.Cells[linha, 18].Value.ToString())

                                };

                                listaContrato.Add(contrato);
                            }
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaTipo
                        if (worksheet.Cells[linha, 21].Text.Length > 0)
                        {
                            var tipo = new Tipo
                            {
                                Id = int.Parse(worksheet.Cells[linha, 21].Value.ToString()),
                                Descricao = worksheet.Cells[linha, 22].Value.ToString()
                            };

                            listaTipo.Add(tipo);
                        }
                    }


                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaModalidadeHoraExtra
                        if (worksheet.Cells[linha, 23].Text.Length > 0)
                        {
                            var modalidadeHoraExtra = new ModalidadeHoraExtra
                            {
                                Id = int.Parse(worksheet.Cells[linha, 23].Value.ToString()),
                                Descricao = worksheet.Cells[linha, 24].Value.ToString(),
                                Valor = float.Parse(worksheet.Cells[linha, 25].Value.ToString())
                            };

                            listaModalidadeHoraExtra.Add(modalidadeHoraExtra);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaHoraExtra
                        if (worksheet.Cells[linha, 26].Text.Length > 0)
                        {

                            if (worksheet.Cells[linha, 31].Text.Length > 0)
                            {
                                var horaExtra = new HoraExtra
                                {
                                    Id = int.Parse(worksheet.Cells[linha, 26].Value.ToString()),
                                    IdFuncionario = int.Parse(worksheet.Cells[linha, 27].Value.ToString()),
                                    IdTipo = int.Parse(worksheet.Cells[linha, 28].Value.ToString()),
                                    IdModalidadeHoraExtra = int.Parse(worksheet.Cells[linha, 29].Value.ToString()),
                                    QtdUsada = int.Parse(worksheet.Cells[linha, 30].Value.ToString()),
                                    DataUso = Convert.ToDateTime(worksheet.Cells[linha, 31].Value.ToString())
                                };

                                listaHoraExtra.Add(horaExtra);
                            }
                            else // caso o campo DataUso for nulo sera preenchido com a data e hora atual
                            {
                                var horaExtra = new HoraExtra
                                {
                                    Id = int.Parse(worksheet.Cells[linha, 26].Value.ToString()),
                                    IdFuncionario = int.Parse(worksheet.Cells[linha, 27].Value.ToString()),
                                    IdTipo = int.Parse(worksheet.Cells[linha, 28].Value.ToString()),
                                    IdModalidadeHoraExtra = int.Parse(worksheet.Cells[linha, 29].Value.ToString()),
                                    QtdUsada = int.Parse(worksheet.Cells[linha, 30].Value.ToString()),
                                };

                                listaHoraExtra.Add(horaExtra);
                            }
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaTipoOcorrencia
                        if (worksheet.Cells[linha, 32].Text.Length > 0)
                        {
                            var tipoOcorrencia = new TipoOcorrencia
                            {
                                Id = int.Parse(worksheet.Cells[linha, 32].Value.ToString()),
                                Descricao = worksheet.Cells[linha, 33].Value.ToString(),
                            };

                            listaTipoOcorrencia.Add(tipoOcorrencia);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaStatusOcorrencia
                        if (worksheet.Cells[linha, 34].Text.Length > 0)
                        {
                            var statusOcorrencia = new StatusOcorrencia
                            {
                                Id = int.Parse(worksheet.Cells[linha, 34].Value.ToString()),
                                Nome = worksheet.Cells[linha, 35].Value.ToString(),
                                Descricao = worksheet.Cells[linha, 36].Value.ToString(),
                            };

                            listaStatusOcorrencia.Add(statusOcorrencia);
                        }
                    }

                    for (int linha = 2; linha <= max; linha++)
                    {
                        // faz a leitura da linha e adiciona na listaOcorrencia
                        if (worksheet.Cells[linha, 37].Text.Length > 0)
                        {
                            if (worksheet.Cells[linha, 42].Text.Length > 0)
                            {
                                var ocorrencia = new Ocorrencia
                                {
                                    Id = int.Parse(worksheet.Cells[linha, 37].Value.ToString()),
                                    IdFuncionario = int.Parse(worksheet.Cells[linha, 38].Value.ToString()),
                                    IdStatusOcorrencia = int.Parse(worksheet.Cells[linha, 39].Value.ToString()),
                                    IdTipoOcorrencia = int.Parse(worksheet.Cells[linha, 40].Value.ToString()),
                                    Descricao = worksheet.Cells[linha, 41].Value.ToString(),
                                    Data = Convert.ToDateTime(worksheet.Cells[linha, 42].Value.ToString())
                                };

                                listaOcorrencia.Add(ocorrencia);
                            }
                            else // caso o campo Data for nulo sera preenchido com a data e hora atual
                            {
                                var ocorrencia = new Ocorrencia
                                {
                                    Id = int.Parse(worksheet.Cells[linha, 37].Value.ToString()),
                                    IdFuncionario = int.Parse(worksheet.Cells[linha, 38].Value.ToString()),
                                    IdStatusOcorrencia = int.Parse(worksheet.Cells[linha, 39].Value.ToString()),
                                    IdTipoOcorrencia = int.Parse(worksheet.Cells[linha, 40].Value.ToString()),
                                    Descricao = worksheet.Cells[linha, 41].Value.ToString(),
                                };

                                listaOcorrencia.Add(ocorrencia);
                            }
                        }
                    }

                    context.funcionarios.AddRange(listaFuncionario);
                    context.registroPontos.AddRange(listaRegistroPonto);
                    context.modalidadeContratos.AddRange(listaModalidadeContrato);
                    context.expedientes.AddRange(listaExpediente);
                    context.cargos.AddRange(listaCargo);
                    context.contratos.AddRange(listaContrato);
                    context.tipos.AddRange(listaTipo);
                    context.modalidadeHoraExtras.AddRange(listaModalidadeHoraExtra);
                    context.horaExtras.AddRange(listaHoraExtra);
                    context.tipoOcorrencias.AddRange(listaTipoOcorrencia);
                    context.statusOcorrencias.AddRange(listaStatusOcorrencia);
                    context.ocorrencias.AddRange(listaOcorrencia);

                    context.SaveChanges(); // salva as mudanças no banco
                }

            }


        }


    }
}