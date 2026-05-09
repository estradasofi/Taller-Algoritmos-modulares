using System;

    class Program
{
    static void Main()
    {
        const int MAX = 25;

        string?[] codigo = new string?[MAX];
        string?[] nombre = new string?[MAX];
        double[,] notas = new double[MAX, 3];
        double[] asistencia = new double[MAX];
        double[] definitiva = new double[MAX];

        int contador = 0;
        int opcion;

        do
        {
            Console.WriteLine();
            Console.WriteLine("1. Registrar estudiante");
            Console.WriteLine("2. Mostrar listado");
            Console.WriteLine("3. Calcular definitivas y estados");
            Console.WriteLine("4. Mostrar promedio general del grupo");
            Console.WriteLine("5. Mejor y peor promedio");
            Console.WriteLine("6. Salir");
            Console.Write("Seleccione una opción: ");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out opcion))
            {
                Console.WriteLine("Opción inválida. Intente de nuevo.");
                continue;
            }

            switch (opcion)
            {
                case 1:
                    Registrar(ref contador, codigo, nombre, notas, asistencia);
                    break;
                case 2:
                    Mostrar(contador, codigo, nombre, notas, asistencia, definitiva);
                    break;
                case 3:
                    CalcularDefinitivas(contador, notas, asistencia, definitiva);
                    MostrarEstados(contador, codigo, nombre, definitiva, asistencia);
                    break;
                case 4:
                    MostrarPromedioGeneral(contador, definitiva);
                    break;
                case 5:
                    MostrarMejorPeor(contador, codigo, nombre, definitiva);
                    break;
            }

        } while (opcion != 6);
    }

    static void Registrar(ref int contador, string?[] codigo, string?[] nombre, double[,] notas, double[] asistencia)
    {
        const int MAX = 25;
        if (contador >= MAX)
        {
            Console.WriteLine("No hay cupos disponibles.");
            return;
        }

        // Código: único y no vacío
        while (true)
        {
            Console.Write("Código: ");
            string? c = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(c))
            {
                Console.WriteLine("Código inválido. Intente de nuevo.");
                continue;
            }

            bool existe = false;
            for (int i = 0; i < contador; i++)
            {
                if (codigo[i] == c) { existe = true; break; }
            }
            if (existe)
            {
                Console.WriteLine("Código ya registrado. Ingrese otro.");
                continue;
            }

            codigo[contador] = c;
            break;
        }

        // Nombre
        while (true)
        {
            Console.Write("Nombre completo: ");
            string? n = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(n))
            {
                Console.WriteLine("Nombre inválido. Intente de nuevo.");
                continue;
            }
            nombre[contador] = n;
            break;
        }

        // Tres notas parciales (escala 0.0 - 5.0)
        for (int j = 0; j < 3; j++)
        {
            while (true)
            {
                Console.Write($"Nota parcial {j + 1} (0.0 - 5.0): ");
                string? notaIn = Console.ReadLine();
                if (!double.TryParse(notaIn, out double nota) || nota < 0.0 || nota > 5.0)
                {
                    Console.WriteLine("Nota inválida. Debe ser número entre 0.0 y 5.0.");
                    continue;
                }
                notas[contador, j] = nota;
                break;
            }
            edad[contador] = e;
            break;
        }

        // Porcentaje de asistencia (0 - 100)
        while (true)
        {
            Console.Write("Porcentaje de asistencia (0 - 100): ");
            string? asisIn = Console.ReadLine();
            if (!double.TryParse(asisIn, out double asis) || asis < 0.0 || asis > 100.0)
            {
                Console.WriteLine("Asistencia inválida. Ingrese un porcentaje entre 0 y 100.");
                continue;
            }
            asistencia[contador] = asis;
            break;
        }

        contador++;
        Console.WriteLine("Estudiante registrado.");
    }

    static void CalcularDefinitivas(int contador, double[,] notas, double[] asistencia, double[] definitiva)
    {
        for (int i = 0; i < contador; i++)
        {
            double sum = 0.0;
            for (int j = 0; j < 3; j++) sum += notas[i, j];
            definitiva[i] = Math.Round(sum / 3.0, 2);
        }

        Console.WriteLine("Definitivas calculadas.");
    }

    static string DeterminarEstado(double def, double asis)
    {
        // Reglas:
        // - Si asistencia < 75% → Reprueba (por inasistencia)
        // - Si asistencia >= 75% y definitiva >= 3.0 → Aprobado
        // - Si asistencia >= 75% y definitiva >= 2.0 y < 3.0 → Habilita
        // - Si asistencia >= 75% y definitiva < 2.0 → Reprueba
        if (asis < 75.0) return "Reprueba (inasistencia)";
        if (def >= 3.0) return "Aprobado";
        if (def >= 2.0) return "Habilita";
        return "Reprueba";
    }

    static void MostrarEstados(int contador, string?[] codigo, string?[] nombre, double[] definitiva, double[] asistencia)
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        Console.WriteLine();
        Console.WriteLine("Listado de estudiantes con definitivas y estado:");
        for (int i = 0; i < contador; i++)
        {
            double def = definitiva[i];
            double asis = asistencia[i];
            string estado = DeterminarEstado(def, asis);
            Console.WriteLine($"{i + 1}. {codigo[i] ?? ""} - {nombre[i] ?? ""} - Definitiva: {def:F2} - Asistencia: {asis:F1}% - Estado: {estado}");
        }
    }

    static void MostrarPromedioGeneral(int contador, double[] definitiva)
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        double sum = 0.0;
        for (int i = 0; i < contador; i++) sum += definitiva[i];
        double prom = sum / contador;
        Console.WriteLine($"Promedio general del grupo: {prom:F2}");
    }

    static void MostrarMejorPeor(int contador, string?[] codigo, string?[] nombre, double[] definitiva)
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay estudiantes registrados.");
            return;
        }

        for (int i = 0; i < contador; i++)
        {
            string t = tipo[i] ?? "";
            if (t.Equals("Urgencias", StringComparison.OrdinalIgnoreCase)) u++;
            else if (t.Equals("Consulta General", StringComparison.OrdinalIgnoreCase)) c++;
            else if (t.Equals("Prioritaria", StringComparison.OrdinalIgnoreCase)) p++;
        }

        Console.WriteLine($"Urgencias: {u}");
        Console.WriteLine($"Consulta General: {c}");
        Console.WriteLine($"Prioritaria: {p}");
    }

    static void MayorPrioridad(int contador, string?[] nombre, int[] prioridad)
    {
        if (contador == 0)
        {
            Console.WriteLine("No hay pacientes registrados.");
            return;
        }

        int max = prioridad[0];
        int pos = 0;
        for (int i = 1; i < contador; i++)
        {
            if (prioridad[i] > max)
            {
                max = prioridad[i];
                pos = i;
            }
        }

                        Console.WriteLine("Mayor prioridad: " + (nombre[pos] ?? "") + " Nivel " + max);
    }
}