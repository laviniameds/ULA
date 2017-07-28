using System;
using System.Collections.Generic;
using System.IO;

namespace C_
{
    class Program
    {
        static string toBinary(string valor){
            return Convert.ToString(Convert.ToInt32(valor), 2).PadLeft(5, '0');
        }
        static string toBinaryConst(string valor){
            return Convert.ToString(Convert.ToInt32(valor), 2).PadLeft(12, '0');
        }
        static void Main(string[] args)
        {        
            string[] linesArq = File.ReadAllLines(@"fat.txt");
            List<string> listArqHex = new List<string>();
            foreach (string line in linesArq)
            {
                string[] comandos = line.Split(' ');
                string op = toBinary(comandos[0]);
                string regDEST = toBinary(comandos[1]);
                string RS = toBinary(comandos[2]);
                string RT = toBinary(comandos[3]);
                string constante = toBinaryConst(comandos[4]);
                string resultBin = op + regDEST + RS + RT + constante;
                int hex = Convert.ToInt32(resultBin,2);
                string linhaHex = hex.ToString("X");
                listArqHex.Add(linhaHex);
            }
            int cont = 0;
            int cT = 1;
            string[] texto = new string[listArqHex.Count];
            texto[0] = "v2.0 raw";
            
            if(listArqHex.Count > 7){
                for(int i=0;i<listArqHex.Count;i++){
                    if(cont<8){
                        texto[cT] += listArqHex[i] + " ";
                    }
                    else{
                        cT++;
                        cont = -1;
                        i--;
                    }
                    cont++;
                }
            }
            else{
                for(int i=0;i<listArqHex.Count;i++)
                    texto[cT] += listArqHex[i] + " ";
            }
            string[] textoF = new string[cT+1];
            for(int i=0; i<textoF.Length; i++){
                textoF[i] = texto[i];
            }
            File.WriteAllLines(@"fatLogisim.txt", textoF);
            Console.WriteLine("Arquivo gerado!");

            /*Console.WriteLine("Digite a operação: \n0 - AND \n1 - OR\n2 - XOR\n3 - NAND\n4 - SOMA INT
            \n5 - SOMA NAT\n6 - SUBTRAIR\n7 - DESL ESQ\n8 - DESL DIR
            \n9 - DESL DIR A\n10 - ROLL LEFT\n11 - COMPARADOR
            \n12 - SOMA CONSTANTE\n29 - BNE\n30 - BEQ\n31 - JMP");*/
            
            /*int n = int.Parse(Console.ReadLine());
            int fat = 1;
            int i = 1;
            while (i != n + 1){
                int x = 1;
                int aux = fat;
                while (x != i){
                    aux = aux + fat;
                    x = x + 1;
                }
                i = i + 1;
                fat = aux;
            }
            Console.WriteLine(fat);*/
        }
    }
}
