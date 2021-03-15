using System;
using System.Collections.Generic;
using System.Linq;
using BLL;
using DAL;

namespace UI
{
    class Program
    {
        static void Main(string[] args)
        {
            string login, senha;
            FluxoDAL fluxoDAL = new FluxoDAL();

            Console.WriteLine("\n\nAutenticação");

            try
            {
                Console.Write("\nLogin: ");
                login = Console.ReadLine();
                Console.Write("\nSenha: ");
                senha = Console.ReadLine();

                Usuario usuario = new Usuario(login, senha);
                UsuarioDAL usuarioDAL = new UsuarioDAL();

                Console.Clear();

                if (usuarioDAL.Autenticar(ref usuario))
                {
                    List<Perfil> list = usuarioDAL.VerificarPerfil(usuario);

                    Console.WriteLine("\n\nId: " + usuario.Id);
                    Console.WriteLine("Login: " + usuario.Login);
                    Console.WriteLine("Senha: " + usuario.Senha);
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
                                if (list.Any(l => l.Id == 2)) //usar enum
                                        CadastrarUsuario(usuario);
                                else
                                    Console.WriteLine("Acesso negado");
                                break;
                            case 2:
                                EnviarAnaliseGerencia(fluxoDAL, usuario);
                                break;
                            case 3:
                                EnviarAnaliseControleDeRisco(fluxoDAL, usuario); //colocar depois do aprovar
                                break;
                            case 4:
                                AprovarFluxo(fluxoDAL, usuario);
                                break;
                            case 5:
                                ReprovarFluxo(fluxoDAL, usuario);
                                break;
                            case 6:
                                CorrecaoDeCadastro(fluxoDAL, usuario);
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

        private static void CorrecaoDeCadastro(FluxoDAL fluxoDAL, Usuario usuario)
        {
            Console.WriteLine("\n\nCorreção de cadastro");

            try
            {
                Fluxo fluxo = new Fluxo(InformarIdCliente(), usuario.Id);
                fluxoDAL.CorrecaoDeCadastro(fluxo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ReprovarFluxo(FluxoDAL fluxoDAL, Usuario usuario)
        {
            Console.WriteLine("\n\nReprovar cliente");

            try
            {
                Fluxo fluxo = new Fluxo(InformarIdCliente(), usuario.Id);
                fluxoDAL.ReprovarFluxo(fluxo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void EnviarAnaliseControleDeRisco(FluxoDAL fluxoDAL, Usuario usuario)
        {
            Console.WriteLine("\n\nEnviar cliente para análise do controle de risco");

            try
            {
                Fluxo fluxo = new Fluxo(InformarIdCliente(), usuario.Id);
                fluxoDAL.EnviarAnaliseControleDeRisco(fluxo);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void CadastrarUsuario(Usuario usuario)
        {
            Console.WriteLine("\n\nCadastrar cliente");

            string nome, cpf, rg, email, nTelefone, cep = null, rua, nCasa, complemento = null, bairro;
            int idCidade;
            DateTime dataNascimento;

            try
            {
                Console.Write("Nome: ");
                nome = Console.ReadLine();
                Console.Write("CPF: ");
                cpf = Console.ReadLine();
                Console.Write("RG: ");
                rg = Console.ReadLine();
                Console.Write("Data de nascimento: ");
                dataNascimento = Convert.ToDateTime(Console.ReadLine());
                Console.Write("Email: ");
                email = Console.ReadLine();
                Console.Write("Número de telefone: ");
                nTelefone = Console.ReadLine();
                Console.Write("CEP: ");
                cep = Console.ReadLine();
                Console.Write("Rua: ");
                rua = Console.ReadLine();
                Console.Write("Número da casa: ");
                nCasa = Console.ReadLine();
                Console.Write("Complemento: ");
                complemento = Console.ReadLine();
                Console.Write("Bairro: ");
                bairro = Console.ReadLine();
                Console.Write("Id cidade: ");
                idCidade = int.Parse(Console.ReadLine());

                Cliente cliente = new Cliente(nome, cpf, rg, dataNascimento, email);
                Telefone telefone = new Telefone(nTelefone);
                Endereco endereco = new Endereco(cep, rua, nCasa, complemento, bairro, idCidade);

                ClienteDAL clienteDAL = new ClienteDAL();
                clienteDAL.CadastrarUsuario(cliente, telefone, endereco, usuario);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void AprovarFluxo(FluxoDAL fluxoDAL, Usuario usuario)
        {
            Console.WriteLine("\n\nAprovar cliente - Gerência");

            try
            {
                Fluxo fluxo = new Fluxo(InformarIdCliente(), usuario.Id);
                fluxoDAL.AprovarFluxo(fluxo);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void EnviarAnaliseGerencia(FluxoDAL fluxoDAL, Usuario usuario)
        {
            Console.WriteLine("\n\nEnviar cliente para análise da gerência");

            try
            {
                Fluxo fluxo = new Fluxo(InformarIdCliente(), usuario.Id);
                fluxoDAL.EnviarAnaliseGerencia(fluxo);
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
