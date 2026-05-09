using System;

class Program
{
    static void Main()
    {
        const int MAX = 20;

        string[] codigo = new string[MAX];
        string[] nombre = new string[MAX];
        double[] precio = new double[MAX];
        int[] stock = new int[MAX];
        string[] categoria = new string[MAX];

        int contador = 0;
        double totalVendido = 0;
        int opcion;

        do
        {
            Console.WriteLine("\n--- CAFETERIA ---");
            Console.WriteLine("1. Registrar producto");
            Console.WriteLine("2. Realizar venta");
            Console.WriteLine("3. Actualizar inventario");
            Console.WriteLine("4. Mostrar agotados");
            Console.WriteLine("5. Total vendido");
            Console.WriteLine("6. Salir");

            if (!int.TryParse(Console.ReadLine(), out opcion))
            {
                Console.WriteLine("Opción no válida");
                continue;
            }

            switch (opcion)
            {
                case 1: Registrar(ref contador, codigo, nombre, precio, stock, categoria, MAX); break;
                case 2: Vender(contador, codigo, nombre, precio, stock, ref totalVendido); break;
                case 3: Actualizar(contador, codigo, stock); break;
                case 4: Agotados(contador, nombre, codigo, stock); break;
                case 5: Console.WriteLine("Total vendido: $" + totalVendido); break;
            }

        } while (opcion != 6);
    }

    static void Registrar(ref int contador, string[] codigo, string[] nombre,
    double[] precio, int[] stock, string[] categoria, int max)
    {
        if (contador >= max)
        {
            Console.WriteLine("Inventario lleno");
            return;
        }

        Console.Write("Codigo: ");
        codigo[contador] = Console.ReadLine();

        Console.Write("Nombre: ");
        nombre[contador] = Console.ReadLine();

        Console.Write("Precio: ");
        if (!double.TryParse(Console.ReadLine(), out precio[contador]))
            precio[contador] = 0;

        Console.Write("Cantidad: ");
        if (!int.TryParse(Console.ReadLine(), out stock[contador]))
            stock[contador] = 0;

        Console.Write("Categoria (Bebidas/Panaderia/Snacks): ");
        categoria[contador] = Console.ReadLine();

        contador++;
    }

    static void Vender(int contador, string[] codigo, string[] nombre,
    double[] precio, int[] stock, ref double totalVendido)
    {
        Console.Write("Codigo producto: ");
        string cod = Console.ReadLine();

        for (int i = 0; i < contador; i++)
        {
            if (codigo[i] == cod)
            {
                Console.Write("Cantidad a vender: ");
                if (!int.TryParse(Console.ReadLine(), out int cant))
                {
                    Console.WriteLine("Cantidad no válida");
                    return;
                }

                if (cant > stock[i])
                {
                    Console.WriteLine("No hay stock suficiente");
                    return;
                }

                stock[i] -= cant;
                totalVendido += cant * precio[i];

                Console.WriteLine("Venta realizada");
                return;
            }
        }

        Console.WriteLine("Producto no encontrado");
    }

    static void Actualizar(int contador, string[] codigo, int[] stock)
    {
        Console.Write("Codigo producto: ");
        string cod = Console.ReadLine();

        for (int i = 0; i < contador; i++)
        {
            if (codigo[i] == cod)
            {
                Console.Write("Nueva cantidad: ");
                if (!int.TryParse(Console.ReadLine(), out stock[i]))
                    stock[i] = 0;
                return;
            }
        }

        Console.WriteLine("No existe");
    }

    static void Agotados(int contador, string[] nombre, string[] codigo, int[] stock)
    {
        Console.WriteLine("Productos agotados:");
        bool alguno = false;
        for (int i = 0; i < contador; i++)
        {
            if (stock[i] == 0)
            {
                alguno = true;
                string displayName = string.IsNullOrWhiteSpace(nombre[i]) ? "(sin nombre)" : nombre[i];
                string displayCode = string.IsNullOrWhiteSpace(codigo[i]) ? "" : $" - Código: {codigo[i]}";
                Console.WriteLine($"{displayName}{displayCode}");
            }
        }

        if (!alguno)
            Console.WriteLine("No hay productos agotados.");
    }
}