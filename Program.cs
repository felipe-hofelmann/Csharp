using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloC
{
    class Program
    {
        static void Main(string[] args) 
        {   int escolha;
            int[] password = new int[10];
            double[] saldo = new double[10];
            string[] name = new string[10];
            escolha = 0;
            do
            {
                Console.WriteLine("Aperte 1. Se você for usuario de uma conta e 2. Se for Pessoal autorizado.\n\n\t1.Usuario\n\t2.Pessoal autorizado");

                escolha = Convert.ToInt32(Console.ReadLine());
                switch (escolha)
                {
                    case 1:
                        Usuario(password, saldo, name);
                        break;
                    case 2:
                        Admin(password, saldo, name);
                        break;
                    default:
                        Console.WriteLine("Opção invalida");
                        break;

                }
            } while (0 < 1);

            
        }
        static public void Usuario(int[] password,double[] saldo,string[] name)
        {
            int escolha,i,verification,senha,nomei;
            double saque,deposito;
            String nome;
            escolha = 0;
            saque = 0;
            deposito = 0;
            verification = 0;
            nomei = 0;
            
            do
            {
                Console.Write("Insira seu nome de ususario: ");
                nome = Console.ReadLine();

                Console.Write("Insira sua senha: ");
                senha = Convert.ToInt32(Console.ReadLine());

                for (i = 0; i < name.Length; i++)
                {
                    verification = 0;
                    if (nome == name[i])
                    {
                        verification +=  1;
                        nomei = i;
                    }

                    if (senha == password[i])
                    {
                        verification += 2;
                    }
                    if (verification == 3) 
                    {
                        i = name.Length + 1;
                    }
                }
               

                if (verification == 3)
                {
                    do
                    {

                        Console.WriteLine("Ola, " + name[nomei] + " Como posso ajudar? \n\n\t\tMENU\n\t1.Sacar\n\t2.Depositar\n\t3.Ver saldo\n\t4.Sair");

                        escolha = Convert.ToInt32(Console.ReadLine());

                        switch (escolha)
                        {
                            case 1:
                                Console.Write("Insira o valor do saque desejado: ");
                                saque = Convert.ToDouble(Console.ReadLine());
                                Sacar(nomei, saldo, saque);
                                break;
                            case 2:
                                Console.Write("Insira o valor do deposito desejado: ");
                                deposito = Convert.ToDouble(Console.ReadLine());
                                Depositar(nomei,saldo, deposito);
                                break;
                            case 3:
                                Console.WriteLine("Seu saldo atual é de : " + saldo[nomei]);

                                break;
                            case 4:
                                escolha = 9;
                                break;
                            default:
                                Console.WriteLine("Opção invalida!");
                                break;
                        };
                    } while (escolha != 9);

                }
                else 
                {
                    if (verification == 2) 
                    {
                        Console.WriteLine("Senha incorreta");
                    }
                    if (verification == 1) 
                    {
                        Console.WriteLine("Nome de usuario incorreto");
                    }
                }
            } while (escolha != 9 );
        }

        static public void Sacar(int nomei, double[] saldo, double saque)
        { 

            if (saque <= saldo[nomei]) 
            {
                saldo[nomei] -= saque;
                Console.WriteLine("Saque realizada com sucesso!");
            }
            else 
            {
                Console.WriteLine("Saldo indísponvel para o valor de saque requisitado");
            }
            
        }

        static public void Depositar(int nomei, double[] saldo, double deposito) 
        {
            saldo[nomei] += deposito;
            Console.WriteLine("Deposito realizado com sucesso!");
            
        }

        static public void Admin(int[] password, double[] saldo, string[] name) 
        {
            int senha, verification,escolha,opcao;
            string nome;
            senha = 1234;
            nome = "Admin";
            verification = 0;
            escolha = 0;

            Console.Write("Insira seu nome: ");
            nome = Console.ReadLine();
            if (nome == "Admin") 
            {
                verification += 1;
            }
            
            Console.Write("Insira sa senha: ");
            senha = Convert.ToInt32(Console.ReadLine());
            if (senha == 1234)
            {
                verification += 1;
            }

            if (verification == 2) 
            {

                do
                {
                    Console.WriteLine("\n\n\t\tMENU\n\t1.Adicionar\n\t2.Excluir\n\t3.Editar\n\t4.Mostrar dados dos Usuarios\n\t5.Sair");

                    escolha = Convert.ToInt32(Console.ReadLine());

                    
                    switch (escolha) 
                    {
                        case 1:
                            Adicionar(password, saldo, name);
                            break;
                        case 2:
                            Excluir(password, saldo, name);
                            break;
                        case 3:
                            Editar(password, saldo, name);
                            break;
                        case 4:
                            Mostrar(password, saldo, name);
                            break;
                        case 5:
                            escolha = 5;
                            break;
                        default:
                            Console.WriteLine("Opção invalida!");
                            break;
                    }
                    opcao = escolha;
                } while (opcao != 5);
                
            }

        }

        static public void Adicionar(int[] password, double[] saldo, string[] name) 
        {
            int i,j,verification,adicionar;
            String nome;
            verification = 0;
            adicionar = 0;
            nome = "";
            

            for (i = 0; i < name.Length;i++) 
            {
                if (name[i] == null)
                {
                    while (adicionar == 0) 
                    {
                        Console.Write("Insira o nome do usuario: ");
                        nome = Console.ReadLine();
                        for (j = 0; j < name.Length; j++)
                        {
                            if (nome == name[j])
                            {
                                Console.WriteLine("Ja possue usuario com esse nome!");
                                verification = 0;
                                j = name.Length + 1;
                            }
                            else
                            {
                                verification = 1;
                            }
                        }

                        if (verification == 1)
                        {
                            name[i] = nome;

                            Console.Write("Insira a senha do usuario: ");
                            password[i] = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Insira o saldo do usuario: ");
                            saldo[i] = Convert.ToDouble(Console.ReadLine());

                            adicionar = 1;
                            Console.Write("Usuario "+nome+", adicionado com sucesso!");
                        }
                    }
                }
            }
        }

        static public void Excluir(int[] password, double[] saldo, string[] name)
        {
            int i,j;
            String nome;
            nome = "";
            


            Console.Write("Insira o nome do usuario que deseja Excluir: ");
            nome = Console.ReadLine();

            for (i = 0; i < name.Length; i++) 
            {
                if (nome == name[i]) 
                {
                    name[i] = null;

                    saldo[i] = 00.0;

                    password[i] = 0;
                    Console.Write("O usuario "+nome+", foi excluido com sucesso!");
                    for (j = i+1;j < name.Length - 1;j++) 
                    {
                        name[j-1] = name[j];
                        password[j-1] = password[j];
                        saldo[j-1] = saldo[j];
                        
                    }
                }
            }
        }

        static public void Editar(int[] password, double[] saldo, string[] name)
        {
            int i,j,verification,editar;
            String nome;
            nome = "";
            verification = 0;
            editar = 0;

            Console.Write("Insira o nome do usuario que deseja Editar: ");
            nome = Console.ReadLine();

            for (i = 0; i < name.Length; i++)
            {
                if (nome == name[i])
                {
                    while (editar == 0) 
                    {
                        Console.Write("Insira o novo nome do usuario: ");
                        nome = Console.ReadLine();
                        for (j = 0; j < name.Length; j++)
                        {
                            if (j != i) 
                            {
                                if (nome == name[j])
                                {
                                    Console.WriteLine("Ja possue usuario com esse nome!");
                                    verification = 0;
                                    j = name.Length;
                                }
                                else
                                {
                                    verification = 1;
                                }
                            }

                        }

                        if (verification == 1)
                        {
                            name[i] = nome;

                            Console.Write("Insira a nova senha do usuario: ");
                            password[i] = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Insira o novo saldo do usuario: ");
                            saldo[i] = Convert.ToDouble(Console.ReadLine());
                            editar = 1;

                            Console.Write("O usuario "+nome+", foi editado com sucesso!");
                        }
                    }
                }
            }
        }

        static public void Mostrar(int[] password, double[] saldo, string[] name) 
        {
            int i;

            for (i = 0; i < name.Length; i++) 
            {
                if (name[i] != null) 
                {
                    Console.WriteLine(i+1 + ". " +name[i]+ " " +password[i]+ " " +saldo[i]);
                }
            }
        }
    }
}
