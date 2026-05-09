using System;

class Program
{
    static void Main()
    {
        const int MAX = 40;

        string[] placa = new string[MAX];
        string[] torre = new string[MAX];
        string[] apto = new string[MAX];
        int[] horaIng = new int[MAX];
        int[] horaSal = new int[MAX];
        string[] tipo = new string[MAX];
        bool[] dentro = new bool[MAX];

        int contador = 0;
        int opcion;

        do
        {
            Console.WriteLine("\n--- PARQUEADERO ---");
            Console.WriteLine("1. Registrar ingreso");
            Console.WriteLine("2. Registrar salida");
            Console.WriteLine("3. Calcular permanencia");
            Console.WriteLine("4. Conteo por tipo");
            Console.WriteLine("5. Mayor permanencia");
            Console.WriteLine("6. Salir");
            opcion = int.Parse(Console.ReadLine());

            switch (opcion)
            {
                case 1: Ingreso(ref contador, placa, torre, apto, horaIng, tipo, dentro); break;
                case 2: Salida(contador, placa, horaSal, dentro); break;
                case 3: Permanencia(contador, placa, horaIng, horaSal, dentro); break;
                case 4: ConteoTipo(contador, tipo); break;
                case 5: MayorTiempo(contador, placa, horaIng, horaSal); break;
            }

        } while (opcion != 6);
    }

    static void Ingreso(ref int contador, string[] placa, string[] torre, string[] apto,
    int[] horaIng, string[] tipo, bool[] dentro)
    {
        Console.Write("Placa: ");
        string p = Console.ReadLine();

        for (int i = 0; i < contador; i++)
            if (placa[i] == p && dentro[i])
            {
                Console.WriteLine("Ese vehiculo ya esta dentro");
                return;
            }

        placa[contador] = p;
        Console.Write("Torre: ");
        torre[contador] = Console.ReadLine();
        Console.Write("Apartamento: ");
        apto[contador] = Console.ReadLine();
        Console.Write("Hora ingreso (0-23): ");
        horaIng[contador] = int.Parse(Console.ReadLine());
        Console.Write("Tipo (Carro/Moto/Bicicleta): ");
        tipo[contador] = Console.ReadLine();

        dentro[contador] = true;
        contador++;
    }

    static void Salida(int contador, string[] placa, int[] horaSal, bool[] dentro)
    {
        Console.Write("Placa: ");
        string p = Console.ReadLine();

        for (int i = 0; i < contador; i++)
            if (placa[i] == p && dentro[i])
            {
                Console.Write("Hora salida: ");
                horaSal[i] = int.Parse(Console.ReadLine());
                dentro[i] = false;
                return;
            }

        Console.WriteLine("Vehiculo no encontrado");
    }

    static void Permanencia(int contador, string[] placa, int[] horaIng, int[] horaSal, bool[] dentro)
    {
        Console.Write("Placa: ");
        string p = Console.ReadLine();

        for (int i = 0; i < contador; i++)
            if (placa[i] == p && !dentro[i])
            {
                int tiempo = horaSal[i] - horaIng[i];
                Console.WriteLine("Tiempo: " + tiempo + " horas");
                return;
            }

        Console.WriteLine("Aun no ha salido");
    }

    static void ConteoTipo(int contador, string[] tipo)
    {
        int carro = 0, moto = 0, bici = 0;

        for (int i = 0; i < contador; i++)
        {
            if (tipo[i] == "Carro") carro++;
            else if (tipo[i] == "Moto") moto++;
            else if (tipo[i] == "Bicicleta") bici++;
        }

        Console.WriteLine($"Carros: {carro} Motos: {moto} Bicis: {bici}");
    }

    static void MayorTiempo(int contador, string[] placa, int[] horaIng, int[] horaSal)
    {
        int max = -1;
        int pos = -1;

        for (int i = 0; i < contador; i++)
        {
            int tiempo = horaSal[i] - horaIng[i];
            if (tiempo > max)
            {
                max = tiempo;
                pos = i;
            }
        }

        if (pos != -1)
            Console.WriteLine("Mayor permanencia: " + placa[pos] + " " + max + " horas");
    }
}