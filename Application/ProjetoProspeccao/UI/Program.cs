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

                if (usuarioService.Autenticar(ref usuarioAutenticarDTO))
                {
                    List<UsuarioVerificarResultadoDTO> list = usuarioService.Verificar(usuarioAutenticarDTO);

                    Console.WriteLine("\n\nId: " + usuarioAutenticarDTO.IdUsuario);
                    Console.WriteLine("Login: " + usuarioAutenticarDTO.Login);
                    Console.WriteLine("Senha: " + usuarioAutenticarDTO.Senha);
                    Console.WriteLine("Acesso:");
                    foreach(var item in list)
                    {
                        Console.WriteLine("\t- " + item.NomePerfil);
                    }

                    int opcao = ObterOpcao();

                    while (opcao != 0)
                    {
                        Console.Clear();

                        switch (opcao)
                        {
                            case 1:
                                if (list.Any(l => l.IdPerfil == (int)EPerfil.Operacao))
                                        CadastrarCliente(usuarioAutenticarDTO);
                                else
                                    Console.WriteLine("Acesso negado");
                                break;
                            case 2:
                                if(list.Any(l => l.IdPerfil == (int)EPerfil.Operacao || l.IdPerfil == (int)EPerfil.Controle_de_risco))
                                    EnviarAnaliseGerencia(usuarioAutenticarDTO);
                                else
                                    Console.WriteLine("Acesso negado");
                                break;
                            case 3:
                                EnviarAnaliseControleDeRisco(usuarioAutenticarDTO); //colocar depois do aprovar
                                break;
                            case 4:
                                AprovarFluxo(usuarioAutenticarDTO);
                                break;
                            case 5:
                                ReprovarFluxo(usuarioAutenticarDTO);
                                break;
                            case 6:
                                CorrecaoDeCadastro(usuarioAutenticarDTO);
                                break;
                            default:
                                Console.Clear();
                                Console.WriteLine("\n\nOpção inválida!!!");
                                break;
                        }

                        opcao = ObterOpcao();
                    }
                }
                else
                {
                    Console.WriteLine("Acesso negado");
                }

                Console.WriteLine("\n\nAté a próxima!!!");
                Console.ReadKey();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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
                fluxo.CorrecaoDeCadastro(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                fluxo.ReprovarFluxo(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                fluxo.EnviarAnaliseControleDeRisco(fluxoDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
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
                cliente.CadastrarCliente(clienteDTO);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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
                fluxo.AprovarFluxo(fluxoDTO);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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
                fluxo.EnviarAnaliseGerencia(fluxoDTO);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
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
            Console.WriteLine("0 - Sair");

            Console.Write("\nSelecione a sua opção: ");
            int opcao = int.Parse(Console.ReadLine());
            return opcao;
        }
    }
}
