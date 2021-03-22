using BLL.DTO.Cliente;
using BLL.DTO.Fluxo;
using BLL.DTO.Usuario;
using BLL.Enums;
using BLL.Service.Cliente;
using BLL.Service.Fluxo;
using BLL.Service.Usuario;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("\n\nAutenticação");

            try
            {
                UsuarioAutenticarDTO usuarioAutenticarDTO = new UsuarioAutenticarDTO();

                Console.Write("\nLogin: ");
                usuarioAutenticarDTO.Login = Console.ReadLine();
                Console.Write("\nSenha: ");
                usuarioAutenticarDTO.Senha = Console.ReadLine();

                UsuarioService usuarioService = new UsuarioService(new UsuarioDAL());

                Console.Clear();

                var respostaAutenticarUsuario = usuarioService.Autenticar(ref usuarioAutenticarDTO);
                if(respostaAutenticarUsuario.Erros.Count() > 0) 
                    ExibirErros(respostaAutenticarUsuario.Erros);

                if (respostaAutenticarUsuario.RetornoAutenticacaoUsuario)
                {
                    var respostaPerfilUsuario = usuarioService.ListarPerfilsDeUsuario(usuarioAutenticarDTO);
                    if (respostaPerfilUsuario.Erros.Count() > 0)
                        ExibirErros(respostaPerfilUsuario.Erros);

                    ApresentarDadosUsuario(usuarioAutenticarDTO, respostaPerfilUsuario.PerfilsDeUsuario);

                    int opcao = ObterOpcao();

                    while (opcao != 0)
                    {
                        Console.Clear();

                        switch (opcao)
                        {
                            case 1:
                                if (respostaPerfilUsuario.PerfilsDeUsuario.Any(l => l.IdPerfil == (int)EPerfil.Operacao))
                                    CadastrarCliente(usuarioAutenticarDTO);
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nAcesso negado");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case 2:
                                if (respostaPerfilUsuario.PerfilsDeUsuario.Any(l => l.IdPerfil == (int)EPerfil.Operacao))
                                    EnviarAnaliseGerencia(usuarioAutenticarDTO);
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nAcesso negado");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case 3:
                                if (respostaPerfilUsuario.PerfilsDeUsuario.Any(l => l.IdPerfil == (int)EPerfil.Gerencia))
                                    EnviarAnaliseControleDeRisco(usuarioAutenticarDTO); // juntar com aprovar
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nAcesso negado");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case 4:
                                if (respostaPerfilUsuario.PerfilsDeUsuario.Any(l => l.IdPerfil == (int)EPerfil.Gerencia || l.IdPerfil == (int)EPerfil.Controle_de_risco))
                                    AprovarFluxo(usuarioAutenticarDTO);
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nAcesso negado");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case 5:
                                if (respostaPerfilUsuario.PerfilsDeUsuario.Any(l => l.IdPerfil == (int)EPerfil.Gerencia || l.IdPerfil == (int)EPerfil.Controle_de_risco))
                                    ReprovarFluxo(usuarioAutenticarDTO);
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nAcesso negado");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case 6:
                                if (respostaPerfilUsuario.PerfilsDeUsuario.Any(l => l.IdPerfil == (int)EPerfil.Gerencia || l.IdPerfil == (int)EPerfil.Controle_de_risco))
                                    CorrecaoDeCadastro(usuarioAutenticarDTO);
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nAcesso negado");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            case 7:
                                if (respostaPerfilUsuario.PerfilsDeUsuario.Any(l => l.IdPerfil == (int)EPerfil.Operacao))
                                    DevolverCadastro(usuarioAutenticarDTO);
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("\n\nAcesso negado");
                                    Console.ForegroundColor = ConsoleColor.White;
                                }
                                break;
                            default:
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\n\nOpção inválida!!!");
                                Console.ForegroundColor = ConsoleColor.White;
                                break;
                        }

                        ApresentarDadosUsuario(usuarioAutenticarDTO, respostaPerfilUsuario.PerfilsDeUsuario);

                        opcao = ObterOpcao();
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n\nAcesso negado");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine("\n\nAté a próxima!!!");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ApresentarDadosUsuario(UsuarioAutenticarDTO usuarioAutenticarDTO, List<PerfilDeUsuarioDTO> list)
        {
            Console.WriteLine("\n\n<=====DADOS DO USUÁRIO=====>\n");
            Console.WriteLine("Id: " + usuarioAutenticarDTO.IdUsuario);
            Console.WriteLine("Login: " + usuarioAutenticarDTO.Login);
            Console.WriteLine("Senha: " + usuarioAutenticarDTO.Senha);
            Console.WriteLine("Acesso:");
            foreach (var item in list)
            {
                Console.WriteLine("\t- " + item.NomePerfil);
            }
        }

        private static void DevolverCadastro(UsuarioAutenticarDTO usuario)
        {
            Console.WriteLine("\n\nDevolver cadastro ao Fluxo");

            try
            {
                FluxoDTO fluxoDTO = new FluxoDTO();
                fluxoDTO.IdCliente = InformarIdCliente();
                fluxoDTO.IdUsuario = usuario.IdUsuario;

                FluxoService fluxo = new FluxoService(new FluxoDAL());
                var respostaFluxo = fluxo.DevolverCadastro(fluxoDTO);
                if (respostaFluxo != null)
                    ExibirErros(respostaFluxo.Erros);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void CorrecaoDeCadastro(UsuarioAutenticarDTO usuario)
        {
            Console.WriteLine("\n\nCorreção de cadastro");

            try
            {
                FluxoDTO fluxoDTO = new FluxoDTO();
                fluxoDTO.IdCliente = InformarIdCliente();
                fluxoDTO.IdUsuario = usuario.IdUsuario;

                FluxoService fluxo = new FluxoService(new FluxoDAL());
                var respostaFluxo = fluxo.CorrecaoDeCadastro(fluxoDTO);
                if (respostaFluxo != null)
                    ExibirErros(respostaFluxo.Erros);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void ReprovarFluxo(UsuarioAutenticarDTO usuario)
        {
            Console.WriteLine("\n\nReprovar cliente");

            try
            {
                FluxoDTO fluxoDTO = new FluxoDTO();
                fluxoDTO.IdCliente = InformarIdCliente();
                fluxoDTO.IdUsuario = usuario.IdUsuario;

                FluxoService fluxo = new FluxoService(new FluxoDAL());
                var respostaFluxo = fluxo.ReprovarFluxo(fluxoDTO);
                if (respostaFluxo != null)
                    ExibirErros(respostaFluxo.Erros);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void EnviarAnaliseControleDeRisco(UsuarioAutenticarDTO usuario)
        {
            Console.WriteLine("\n\nEnviar cliente para análise do controle de risco");

            try
            {
                FluxoDTO fluxoDTO = new FluxoDTO();
                fluxoDTO.IdCliente = InformarIdCliente();
                fluxoDTO.IdUsuario = usuario.IdUsuario;

                FluxoService fluxo = new FluxoService(new FluxoDAL());
                var respostaFluxo = fluxo.EnviarAnaliseControleDeRisco(fluxoDTO);
                if (respostaFluxo != null)
                    ExibirErros(respostaFluxo.Erros);
            }
            catch (Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void CadastrarCliente(UsuarioAutenticarDTO usuario)
        {
            Console.WriteLine("\n\nCadastrar cliente");

            ClienteCadastroDTO clienteDTO = new ClienteCadastroDTO();

            try
            {
                Console.Write("Nome: ");
                clienteDTO.Nome = Console.ReadLine();
                Console.Write("CPF: ");
                clienteDTO.Cpf = Console.ReadLine();
                Console.Write("RG: ");
                clienteDTO.Rg = Console.ReadLine();
                Console.Write("Data de nascimento: ");
                clienteDTO.DataNascimento = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Email: ");
                clienteDTO.Email = Console.ReadLine();
                Console.Write("Número de telefone: ");
                clienteDTO.NumeroTelefone = Console.ReadLine();
                Console.Write("CEP: ");
                clienteDTO.Cep = Console.ReadLine();
                Console.Write("Rua: ");
                clienteDTO.Rua = Console.ReadLine();
                Console.Write("Número da casa: ");
                clienteDTO.Numero = Console.ReadLine();
                Console.Write("Complemento: ");
                clienteDTO.Complemento = Console.ReadLine();
                Console.Write("Bairro: ");
                clienteDTO.Bairro = Console.ReadLine();
                Console.Write("Id cidade: ");
                clienteDTO.IdCidade = int.Parse(Console.ReadLine());
                clienteDTO.IdUsuario = usuario.IdUsuario;

                ClienteService cliente = new ClienteService(new ClienteDAL());
                var respostaCadastro = cliente.CadastrarCliente(clienteDTO);
                if (respostaCadastro != null)
                    ExibirErros(respostaCadastro.Erros);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void AprovarFluxo(UsuarioAutenticarDTO usuario)
        {
            Console.WriteLine("\n\nAprovar cliente - Gerência");

            try
            {
                FluxoDTO fluxoDTO = new FluxoDTO();
                fluxoDTO.IdCliente = InformarIdCliente();
                fluxoDTO.IdUsuario = usuario.IdUsuario;

                FluxoService fluxo = new FluxoService(new FluxoDAL());
                var respostaFluxo = fluxo.AprovarFluxo(fluxoDTO);
                if (respostaFluxo != null)
                    ExibirErros(respostaFluxo.Erros);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static void EnviarAnaliseGerencia(UsuarioAutenticarDTO usuario)
        {
            Console.WriteLine("\n\nEnviar cliente para análise da gerência");

            try
            {
                FluxoDTO fluxoDTO = new FluxoDTO();
                fluxoDTO.IdCliente = InformarIdCliente();
                fluxoDTO.IdUsuario = usuario.IdUsuario;

                FluxoService fluxo = new FluxoService(new FluxoDAL());
                var respostaFluxo = fluxo.EnviarAnaliseGerencia(fluxoDTO);
                if (respostaFluxo != null)
                    ExibirErros(respostaFluxo.Erros);
            }
            catch(Exception e)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(e.Message);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        private static int InformarIdCliente()
        {
            Console.Write("\n\nDigite o ID do cliente: ");
            int idCliente = int.Parse(Console.ReadLine());
            return idCliente;
        }

        private static int ObterOpcao()
        {
            Console.WriteLine("\n\n<=====MENU DE AÇÕES=====>\n");
            Console.WriteLine("1 - Cadastrar cliente");
            Console.WriteLine("2 - Enviar cliente para análise da gerência");
            Console.WriteLine("3 - Enviar cliente para análise do controle de risco");
            Console.WriteLine("4 - Aprovar cliente");
            Console.WriteLine("5 - Reprovar cliente");
            Console.WriteLine("6 - Correção de cadastro");
            Console.WriteLine("7 - Devolver cadastro ao fluxo");
            Console.WriteLine("0 - Sair");

            Console.Write("\nSelecione a sua opção: ");
            int opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        public static void ExibirErros(IEnumerable<ValidationResult> erros)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n<=====ERROS=====>\n");
            foreach (var error in erros)
            {
                Console.WriteLine(error.ErrorMessage);
            }
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
