using System;

namespace Poryecto_FInal
{
    class Program
    {
        const int MAX_HABITACIONES = 20;
        const int MAX_HUESPEDES = 20;
        const int MAX_RESERVAS = 5;

        static int[] numeroHabitacion = new int[MAX_HABITACIONES];
        static string[] tipoHabitacion = new string[MAX_HABITACIONES];
        static double[] precioPorNoche = new double[MAX_HABITACIONES];
        static bool[] habitacionDisponible = new bool[MAX_HABITACIONES];
        static int cantidadHabitaciones = 0;

        static string[] nombreHuesped = new string[MAX_HUESPEDES];
        static string[] documentoHuesped = new string[MAX_HUESPEDES];
        static string[] telefonoHuesped = new string[MAX_HUESPEDES];
        static int cantidadHuespedes = 0;

        static string[,] reservasHuesped = new string[MAX_HABITACIONES, MAX_RESERVAS];
        static string[,] fechaEntrada = new string[MAX_HABITACIONES, MAX_RESERVAS];
        static int[,] nochesReserva = new int[MAX_HABITACIONES, MAX_RESERVAS];

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            int opcion = 0;

            while (opcion != 4)
            {
                Console.WriteLine("\nMENÚ PRINCIPAL");
                Console.WriteLine("1. Gestión de habitaciones");
                Console.WriteLine("2. Gestión de huéspedes");
                Console.WriteLine("3. Gestión de reservas");
                Console.WriteLine("4. Salir");
                Console.Write("Seleccione una opción: ");

                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    GestionHabitaciones();
                }
                else if (opcion == 2)
                {
                    GestionHuespedes();
                }
                else if (opcion == 3)
                {
                    GestionReservas();
                }
                else if (opcion == 4)
                {
                    Console.WriteLine("Saliendo");
                }
                else
                {
                    Console.WriteLine("Opción inválida");
                }
            }
        }

        // GESTIÓN HABITACIONES 
        static void GestionHabitaciones()
        {
            int opcion = 0;

            while (opcion != 5)
            {
                Console.WriteLine("\nGESTIÓN DE HABITACIONES");
                Console.WriteLine("1. Registrar nueva habitación");
                Console.WriteLine("2. Ver lista");
                Console.WriteLine("3. Editar habitación");
                Console.WriteLine("4. Ver disponibilidad");
                Console.WriteLine("5. Regresar");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    RegistrarHabitacion();
                }
                else if (opcion == 2)
                {
                    VerHabitaciones();
                }
                else if (opcion == 3)
                {
                    EditarHabitacion();
                }
                else if (opcion == 4)
                {
                    VerDisponibilidad();
                }
            }
        }

        static void RegistrarHabitacion()
        {
            if (cantidadHabitaciones >= MAX_HABITACIONES)
            {
                Console.WriteLine("Límite alcanzado");
                return;
            }

            Console.Write("Número habitación: ");
            numeroHabitacion[cantidadHabitaciones] = int.Parse(Console.ReadLine());

            Console.Write("Tipo (Sencilla/Doble/Suite): ");
            tipoHabitacion[cantidadHabitaciones] = Console.ReadLine();

            Console.Write("Precio x noche: ");
            precioPorNoche[cantidadHabitaciones] = double.Parse(Console.ReadLine());

            habitacionDisponible[cantidadHabitaciones] = true;
            cantidadHabitaciones++;

            Console.WriteLine("Registrada");
        }

        static void VerHabitaciones()
        {
            if (cantidadHabitaciones == 0)
            {
                Console.WriteLine("No hay habitaciones");
                return;
            }

            Console.WriteLine("\nHABITACIONES");
            for (int i = 0; i < cantidadHabitaciones; i++)
            {
                Console.WriteLine($"#{numeroHabitacion[i]} | {tipoHabitacion[i]} | ${precioPorNoche[i]} | {(habitacionDisponible[i] ? "Disponible" : "Ocupada")}");
            }
        }

        static void EditarHabitacion()
        {
            Console.Write("Número habitación a editar: ");
            int buscar = int.Parse(Console.ReadLine());

            int indice = -1;
            for (int i = 0; i < cantidadHabitaciones; i++)
                if (numeroHabitacion[i] == buscar) indice = i;

            if (indice == -1)
            {
                Console.WriteLine("No encontrada");
                return;
            }

            Console.Write("Nuevo tipo: ");
            tipoHabitacion[indice] = Console.ReadLine();

            Console.Write("Nuevo precio: ");
            precioPorNoche[indice] = double.Parse(Console.ReadLine());

            Console.WriteLine("Actualizada");
        }

        static void VerDisponibilidad()
        {
            Console.WriteLine("\nDISPONIBILIDAD");
            for (int i = 0; i < cantidadHabitaciones; i++)
            {
                Console.WriteLine($"Hab {numeroHabitacion[i]}: {(habitacionDisponible[i] ? "Disponible" : "Ocupada")}");
            }
        }

        // ====== GESTIÓN HUÉSPEDES ======
        static void GestionHuespedes()
        {
            int opcion = 0;

            while (opcion != 4)
            {
                Console.WriteLine("\nGESTIÓN HUÉSPEDES");
                Console.WriteLine("1. Registrar huésped");
                Console.WriteLine("2. Ver lista");
                Console.WriteLine("3. Editar huésped");
                Console.WriteLine("4. Regresar");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    RegistrarHuesped();
                }
                else if (opcion == 2)
                {
                    VerHuespedes();
                }
                else if (opcion == 3)
                {
                    EditarHuesped();
                }
            }
        }

        static void RegistrarHuesped()
        {
            if (cantidadHuespedes >= MAX_HUESPEDES)
            {
                Console.WriteLine("Límite alcanzado");
                return;
            }

            Console.Write("Nombre: ");
            nombreHuesped[cantidadHuespedes] = Console.ReadLine();

            Console.Write("Documento: ");
            documentoHuesped[cantidadHuespedes] = Console.ReadLine();

            Console.Write("Teléfono: ");
            telefonoHuesped[cantidadHuespedes] = Console.ReadLine();

            cantidadHuespedes++;
            Console.WriteLine("Registrado");
        }

        static void VerHuespedes()
        {
            for (int i = 0; i < cantidadHuespedes; i++)
            {
                Console.WriteLine($"{nombreHuesped[i]} | {documentoHuesped[i]} | {telefonoHuesped[i]}");
            }
        }

        static void EditarHuesped()
        {
            Console.Write("Documento a buscar: ");
            string doc = Console.ReadLine();

            int indice = -1;
            for (int i = 0; i < cantidadHuespedes; i++)
                if (documentoHuesped[i] == doc) indice = i;

            if (indice == -1)
            {
                Console.WriteLine("No encontrado");
                return;
            }

            Console.Write("Nuevo nombre: ");
            nombreHuesped[indice] = Console.ReadLine();

            Console.Write("Nuevo teléfono: ");
            telefonoHuesped[indice] = Console.ReadLine();

            Console.WriteLine("Huesped actualizado");
        }

        //GESTIÓN RESERVAS 
        static void GestionReservas()
        {
            int opcion = 0;

            while (opcion != 5)
            {
                Console.WriteLine("\nGESTIÓN RESERVAS ");
                Console.WriteLine("1. Crear reserva");
                Console.WriteLine("2. Ver reservas por habitación");
                Console.WriteLine("3. Ver historial por huésped");
                Console.WriteLine("4. Cancelar reserva");
                Console.WriteLine("5. Regresar");
                Console.Write("Opción: ");
                opcion = int.Parse(Console.ReadLine());

                if (opcion == 1)
                {
                    CrearReserva();
                }
                else if (opcion == 2)
                {
                    VerReservasPorHabitacion();
                }
                else if (opcion == 3)
                {
                    VerHistorialHuesped();
                }
                else if (opcion == 4)
                {
                    CancelarReserva();
                }
            }
        }

        static void CrearReserva()
        {
            Console.Write("Número habitación: ");
            int numero = int.Parse(Console.ReadLine());

            int indiceHab = -1;
            for (int i = 0; i < cantidadHabitaciones; i++)
                if (numeroHabitacion[i] == numero) indiceHab = i;

            if (indiceHab == -1)
            {
                Console.WriteLine("No existe");
                return;
            }

            if (!habitacionDisponible[indiceHab])
            {
                Console.WriteLine("Ocupada");
                return;
            }

            Console.Write("Documento huésped: ");
            string doc = Console.ReadLine();

            int indiceH = -1;
            for (int i = 0; i < cantidadHuespedes; i++)
                if (documentoHuesped[i] == doc) indiceH = i;

            if (indiceH == -1)
            {
                Console.WriteLine("No existe huésped");
                return;
            }

            int pos = -1;
            for (int r = 0; r < MAX_RESERVAS; r++)
                if (reservasHuesped[indiceHab, r] == null) pos = r;

            if (pos == -1)
            {
                Console.WriteLine("Máximo reservas");
                return;
            }

            Console.Write("Fecha entrada: ");
            fechaEntrada[indiceHab, pos] = Console.ReadLine();

            Console.Write("Noches: ");
            nochesReserva[indiceHab, pos] = int.Parse(Console.ReadLine());

            reservasHuesped[indiceHab, pos] = doc;
            habitacionDisponible[indiceHab] = false;

            Console.WriteLine("Reserva creada");
        }

        static void VerReservasPorHabitacion()
        {
            Console.Write("Número habitación: ");
            int numero = int.Parse(Console.ReadLine());

            int h = -1;
            for (int i = 0; i < cantidadHabitaciones; i++)
                if (numeroHabitacion[i] == numero) h = i;

            if (h == -1)
            {
                Console.WriteLine("No existe");
                return;
            }

            for (int r = 0; r < MAX_RESERVAS; r++)
            {
                if (reservasHuesped[h, r] != null)
                    Console.WriteLine($"{reservasHuesped[h, r]} | {fechaEntrada[h, r]} | {nochesReserva[h, r]} noches");
            }
        }

        static void VerHistorialHuesped()
        {
            Console.Write("Documento huésped: ");
            string doc = Console.ReadLine();

            for (int h = 0; h < cantidadHabitaciones; h++)
            {
                for (int r = 0; r < MAX_RESERVAS; r++)
                {
                    if (reservasHuesped[h, r] == doc)
                    {
                        Console.WriteLine($"Hab {numeroHabitacion[h]} | {fechaEntrada[h, r]} | {nochesReserva[h, r]} noches");
                    }
                }
            }
        }

        static void CancelarReserva()
        {
            Console.Write("Número habitación: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Documento huésped: ");
            string doc = Console.ReadLine();

            int h = -1;
            for (int i = 0; i < cantidadHabitaciones; i++)
                if (numeroHabitacion[i] == numero) h = i;

            if (h == -1)
            {
                Console.WriteLine("No existe");
                return;
            }

            for (int r = 0; r < MAX_RESERVAS; r++)
            {
                if (reservasHuesped[h, r] == doc)
                {
                    reservasHuesped[h, r] = null;
                    fechaEntrada[h, r] = null;
                    nochesReserva[h, r] = 0;
                    habitacionDisponible[h] = true;

                    Console.WriteLine("Reserva cancelada");
                    return;
                }
            }

            Console.WriteLine("No encontrada");
        }
    }
}
