using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Caixa
{
    class Caixa
    {
        protected double saldo;
        protected Boolean entradadedinheiro;
        protected double saque;
        protected double deposito;
        public void caixa(double saldo, Boolean entradadedinheiro, double saque, double deposito)
        {
            this.saldo = saldo;
            this.entradadedinheiro = entradadedinheiro;
            this.saque = saque;
            this.deposito = deposito;
        }
        public void definirsaldo(double valorsaldo)
        {
            saldo = valorsaldo;
        }
        public void definirentradadedinheiro(Boolean valorentradadedinheiro)
        {
            entradadedinheiro = valorentradadedinheiro;
            if (valorentradadedinheiro)
            {
                if (saldo > deposito)
                {
                    if (saque < saldo)
                    {
                        entradadedinheiro = true;
                    }
                }
            }

        }
        public void saquenocaixa()
        {
            saque--;
            if(saque < saldo)
            {
                saldo = saque;
            }
        }
        public void depositonocaixa()
        {
            deposito++;
            if(deposito > saldo)
            {
                saldo = deposito;

            }
        }

    }

    class banco : Caixa
    {
        protected int agencia;
        protected Boolean conta;
        protected double financia;
        protected double investe;
        public void caixabanco(int agencia, Boolean conta, double financia, double investe)
        {
            this.agencia = agencia;
            this.financia = financia;
            this.investe = investe;
            this.conta = conta;

        }
        public void agenciacod()
        {
            agencia++;
        }
        public void contabanco(Boolean valorcontabanco)
        {
            if (valorcontabanco)
            {
                if (conta)
                {
                    saldo = financia;
                    financia++;
                    entradadedinheiro = true;

                }
            }
            if (valorcontabanco)
            {
                if (conta)
                {
                    saldo = investe;
                    investe++;
                    entradadedinheiro = true;

                }
            }

        }



    }
    class conta : banco
    { 
        public int senha;
        public double numerodaconta;
        public double Calcsaldo(double saldo, int senha, double numerodaconta, double saque, double deposito)
        {
            this.saldo = saldo;
            this.senha = senha;
            this.numerodaconta = numerodaconta;
            saldo = numerodaconta;
            saldo = saldo - saque;
            saldo = saldo + deposito;
            saldo = saque - deposito;
            return saldo;


        }
        public void numerodacontadobanco(double valornumerodacontabanco)
        {
            numerodaconta = valornumerodacontabanco;
        
        }

        internal double Calcsaldo(double saque, double deposito)
        {
            saldo = saque - deposito;
            return saldo;
            throw new NotImplementedException("Cláusula Implementada");
        }
    }
    class cliente : conta
    {
        public string nome;
        public void Calccliente(string nome, double saldo, int senha)
        {
            this.nome = nome;
            this.saldo = saldo;
            this.senha = senha;
        }
    }

    class Program
    {

        static void Main(string[] args)
        {
            conta cont = new conta();
            Console.WriteLine();
            double saque, deposito,saldo, senha, numeroconta ;string nome;
            Console.Write("Entre com seu nome:  ");
            nome = Console.ReadLine();
            Console.WriteLine("Olá, " + nome);
            Console.Write("Entre com o número da conta: ");
            numeroconta = double.Parse(Console.ReadLine());
            Console.WriteLine("Número da conta.............:  " + numeroconta);
            Console.Write("Entre com a senha: ");
            senha = double.Parse(Console.ReadLine());
            Console.WriteLine("Senha................:  " + senha);
            Console.Write("Entre com seu saque: ");
            saque = double.Parse(Console.ReadLine());
            Console.WriteLine("Saque................:  " + saque);
            Console.Write("Entre com seu depósito: ");
            deposito = double.Parse(Console.ReadLine());
            Console.WriteLine("Depósito..............:  " + deposito);
            saldo = cont.Calcsaldo(saque, deposito);
            Console.WriteLine("saldo..............:  " + saldo);
            



            Console.ReadKey();
        }
    }

}
