using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace tp_clase_virtual_31_08
{
    internal class Program
    {

        static int k, i, auxN;
        static  char auxC;
        static string auxS;
        
        static void Main(string[] args)
        {
            try
            {
            int CantPersonas = 0;
                WriteLine("\n############################################################################");
                WriteLine("########>PROGRAMA DE CONTROL DE VACUNACION DE LA CIUDAD LIBERTAD <##########");
                WriteLine("############################################################################\n");

                Write("Ingrese la cantidad de personas: ");
                CantPersonas = int.Parse(ReadLine());

                string[] Apellido = new string[CantPersonas]; //{ "Gonzalez", "Lugo", "Sanchez", "Gomes" };
                string[] Nombre = new string[CantPersonas]; //{ "Lucas", "Cristian", "Mariano", "Micaela" };
                char[] Sexo = new char[CantPersonas];// { 'M', 'M', 'M', 'F' };
                int[] DNI = new int[CantPersonas]; // { 2124414, 124124412, 42344234, 231424234 };
                int[] Dosis = new int[CantPersonas]; // { 2, 4, 3, 4 };
                         
                Carga(Apellido, Nombre, Sexo, DNI, Dosis);
                Menu(Apellido, Nombre, Sexo, DNI, Dosis);

            }catch(Exception)
            {
                WriteLine("ERROR AL INGRESAR DATOS");
            }
            ReadKey();
        }

        private static void Carga(string[] Apellido, string[] Nombre, char[] Sexo, int[] DNI, int[] Dosis)
        {
            Clear();
            //Craga
             WriteLine("CARGAR DATOS\n");
             for (i = 0; i < Apellido.Length; i++)
             {
                 Write($"Ingrese Apellido de la {i} persona: ");
                 Apellido[i] = ReadLine();
                 Apellido[i] = Apellido[i].ToUpper();
                 Write($"Ingrese Nombre de la {i} persona: ");
                 Nombre[i] = ReadLine();
                 ValidandoSexo(Sexo);
                 Write($"Ingrese DNI de la {i} persona: ");
                 DNI[i] = int.Parse(ReadLine());
                 Write($"Ingrese Dosis de la {i} persona: ");
                 Dosis[i] = int.Parse(ReadLine());
                 WriteLine();
             }
        }

       static void ValidandoSexo(char[] Sexo)
        {
            do
            {
                try 
                {
                    Write($"Ingrese Sexo de la {i} persona: ");
                    Sexo[i] = char.Parse(ReadLine());
                    Sexo[i] = char.ToUpper(Sexo[i]);
                }
                catch (Exception e)
                {
                    Console.WriteLine($"\n{e.Message}: M (Masculino) o F (Femenino)\n");
                }          

            } while (Sexo[i] != 'F' && Sexo[i] != 'M');
            
        }

        public static void Menu(string[] Apellido, string[] Nombre, char[] Sexo, int[] DNI, int[] Dosis)
        {
            float suma = 0;
            char opcion;
            while (true)
            {
                Clear();
                WriteLine("####### MENU ######\n");
                WriteLine("A---> Lista completa ordenado por apellido (Todos los datos)");
                WriteLine("B---> Lista Femenino con 4 dosis");
                WriteLine("C---> Lista Masculino con 4 dosis");
                WriteLine("D---> Porcentaje de personas que tienen 3 y 4 Dosis");
                WriteLine("C---> Listado de persona que no han sido vacunadas (ordenada por dni)\n");
                Write("Ingrese una opcion: ");
                opcion = char.Parse(ReadLine());
                opcion = char.ToUpper(opcion);


                switch (opcion)
                {
                    case 'A':
                        {
                            Clear();
                            OrdenarApe(Apellido, Nombre, Sexo, DNI, Dosis);
                            Write($"\nLista ordena\n\n");
                            Write($"Apellido\tNombre\tSexo\tDNI\tDosis\n\n");
                            Salida(Apellido, Nombre, Sexo, DNI, Dosis);
                            break;
                        }
                    case 'B':
                        {
                            Clear();
                            Write($"\nLista DE SEXO FEMENINO CON 4 DOSIS\n\n");
                            Write($"Apellido\tNombre\tSexo\tDNI\tDosis\n\n");
                            for (i = 0; i < Apellido.Length; i++)
                            {
                                if ((Dosis[i] == 4) && (Sexo[i] == 'F'))
                                {
                                    WriteLine($"{Apellido[i]}   {Nombre[i]}   {Sexo[i]}   {DNI[i]}    {Dosis[i]}\n");
                                }
                            }
                            break;
                        }
                    case 'C':
                        {
                            Clear();
                            Write($"\nLista DE SEXO MASCULINA CON 4 DOSIS\n\n");
                            Write($"Apellido\tNombre\tSexo\tDNI\tDosis\n\n");
                            for (i = 0; i < Apellido.Length; i++)
                            {
                                if ((Dosis[i] == 4) && (Sexo[i] == 'M'))
                                {
                                    WriteLine($"{Apellido[i]}   {Nombre[i]}   {Sexo[i]}   {DNI[i]}    {Dosis[i]}\n");
                                }
                            }
                            break;
                        }
                    case 'D':
                        {
                            Clear();
                            Write($"\nPorsentaje de personas con 3 y 4 dosis\n");
                            for (i = 0; i < Apellido.Length; i++)
                            {
                                if (Dosis[i] == 4 || Dosis[i] == 3)
                                {
                                    suma++;
                                }
                            }
                            suma = (suma * 100) / Dosis.Length;
                            WriteLine($"El porcentaje de personas que tiene 3 y 4 dosis es de {suma}%");
                            break;
                        }
                    case 'E':
                        {

                            OrdenarDni(Apellido, Nombre, Sexo, DNI, Dosis);

                            Clear();
                            Write($"\nLista ordena por DNI de personas que no tomaron vacunas\n");
                            Write($"DNI\tApellido\tNombre\tSexo\tDosis\n\n");

                            Salida(Apellido, Nombre, Sexo, DNI, Dosis);

                            break;
                        }
                }
            }
        }
       static void Salida( string[] Apellido, string[] Nombre, char[] Sexo, int[] DNI, int[] Dosis)
        {
            for (i = 0; i < Apellido.Length; i++)
            {
                WriteLine($"{Apellido[i]}   {Nombre[i]}   {Sexo[i]}  {DNI[i]}   {Dosis[i]}\n");
            }
        }

        static void OrdenarApe(string[] Apellido, string[] Nombre, char[]Sexo, int[] DNI , int[] Dosis)
        {
           
            for (k = Apellido.Length - 1; k >= 0; k--)
            {
                for (i = 0; i < k; i++)
                {
                    if (Apellido[i].CompareTo(Apellido[i + 1]) > 0)
                    {
                        //Apellido
                        auxS = Apellido[i];
                        Apellido[i] = Apellido[i + 1];
                        Apellido[i + 1] = auxS;
                        //Nombre
                        auxS = Nombre[i];
                        Nombre[i] = Nombre[i + 1];
                        Nombre[i + 1] = auxS;
                        //Sexo
                        auxC = Sexo[i];
                        Sexo[i] = Sexo[i + 1];
                        Sexo[i + 1] = auxC;
                        //DNI
                        auxN = DNI[i];
                        DNI[i] = DNI[i + 1];
                        DNI[i + 1] = auxN;
                        //Dosis
                        auxN = Dosis[i];
                        Dosis[i] = Dosis[i + 1];
                        Dosis[i + 1] = auxN;
                    }
                }
            }
        }

        static void OrdenarDni(string[] Apellido, string[] Nombre, char[] Sexo, int[] DNI, int[] Dosis)
        {
            for (k = Apellido.Length - 1; k >= 0; k--)
            {
                for (i = 0; i < k; i++)
                {
                    if (Dosis[i] == 0)
                    {
                        if (DNI[i] > DNI[i + 1])
                        {
                            //DNI
                            auxN = DNI[i];
                            DNI[i] = DNI[i + 1];
                            DNI[i + 1] = auxN;
                            //Apellido
                            auxS = Apellido[i];
                            Apellido[i] = Apellido[i + 1];
                            Apellido[i + 1] = auxS;
                            //Nombre
                            auxS = Nombre[i];
                            Nombre[i] = Nombre[i + 1];
                            Nombre[i + 1] = auxS;
                            //Sexo
                            auxC = Sexo[i];
                            Sexo[i] = Sexo[i + 1];
                            Sexo[i + 1] = auxC;
                            //Dosis
                            auxN = Dosis[i];
                            Dosis[i] = Dosis[i + 1];
                            Dosis[i + 1] = auxN;
                        }
                    }
                }
            }
        }
    }
}
