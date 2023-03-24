//HABILITALO PARA QUE ACEPTE DE 200
//DESGLOZAR CENTAVOS,50,25,10,5,1
///poner un menú de op, op 1 dolares,2 euros,3quetsales,4salir
//cambiar la clave de numerica a alfanumerica , numeros y letras.
//validaciones convenientes en todo lo que nostros pensemos que es la correcta 
using System;

static string HideCharacter()
{
    ConsoleKeyInfo key;
    string code = "";
    do
    {
        key = Console.ReadKey(true);
        if (char.IsLetterOrDigit(key.KeyChar))
        {
            Console.Write("*"); 
        }
        code += key.KeyChar;
    } while (key.Key != ConsoleKey.Enter);
    return code;
}

static void contrasena()
{
    byte OPORTUNIDADES, TienePermiso;
    string CLAVE;
    TienePermiso = 0;
    OPORTUNIDADES = 0;
    do
    {
        Console.WriteLine("DIGITE UN NUMERO");
        CLAVE = HideCharacter().Replace("\r", "");//sirve para remplazar una cadena por otra, en este caso vacia 
        Console.WriteLine(0);
        if ((CLAVE.ToUpper() == "G1234"))
        {
            TienePermiso = 1;
        }
        else
        {
            OPORTUNIDADES++;
        }
    } while (((OPORTUNIDADES < 3) & (TienePermiso == 0)));
    if (TienePermiso == 1)
    {
        
        Console.WriteLine("Hola, sea bienvenido, seleccione la operacion a ralizar");
        menu();

    }
    else
    {
        Console.WriteLine("Oportunidades terminadas ");
    }
}


static void menu()
{
    int opcion;
    do
    {

        Console.WriteLine("Seleccione la moneda a desglosar:");
        Console.WriteLine("1. Dólares");
        Console.WriteLine("2. Euros");
        Console.WriteLine("3. Quetzales");
        Console.WriteLine("4. Salir");
        Console.Write("Opción: ");
        opcion = Convert.ToInt32(Console.ReadLine());


        switch (opcion)
        {
            case 1:
                Console.WriteLine("Ingrese una cantidad en dólares");
                Decimal cantidad = Convert.ToDecimal(Console.ReadLine());
                cantidad *= 7.80M; // Tipo de cambio actual de USD a GTQ
                Console.WriteLine($"Cantidad en quetzales: {cantidad}");
                desglose(cantidad);
                borrador();

                break;
            case 2:
                Console.WriteLine("Ingrese una cantidad en euros");
                cantidad = Convert.ToDecimal(Console.ReadLine());
                cantidad *= 8.50M; // Tipo de cambio actual de EU a GTQ
                Console.WriteLine($"Cantidad en quetzales: {cantidad}");
                desglose(cantidad);
                borrador();
                break;
            case 3:
                Console.WriteLine("Ingrese una cantidad en quetzales");
                cantidad = Convert.ToDecimal(Console.ReadLine());
                Console.WriteLine($"Cantidad en quetzales: {cantidad}");
                desglose(cantidad);
                borrador();
                break;
            case 4:
                Console.WriteLine("Saliendo...");
                borrador();
                break;
            default:
                Console.WriteLine("Opción no válida");
                borrador();
                break;
        }
       

    } while (opcion != 4);
}

static void desglose( decimal cantidad)
{

    int CAN, C200, C100, C50, C20, C10, C5;
    CAN = C200 = C100 = C50 = C20 = C10 = C5 = 0;
    int DCAN, DC50, DC25, DC10, DC5;
    DCAN = DC50 = DC25 = DC10 = DC5 = 0;
   
    decimal parte_entera = Math.Truncate(cantidad);

    CAN = Convert.ToInt32(parte_entera);
    if ((CAN >= 200))
    {
        C200 = (CAN / 200);
        CAN = CAN - (C200 * 200);
    }
    if ((CAN >= 100))
    {
        C100 = (CAN / 100);
        CAN = CAN - (C100 * 100);
    }
    if ((CAN >= 50))
    {
        C50 = (CAN / 50);
        CAN = CAN - (C50 * 50);
    }
    if ((CAN >= 20))
    {
        C20 = (CAN / 20);
        CAN = CAN - (C20 * 20);
    }
    if ((CAN >= 10))
    {
        C10 = (CAN / 10);
        CAN = CAN - (C10 * 10);
    }
    if ((CAN >= 5))
    {
        C5 = (CAN / 5);
        CAN = CAN - (C5 * 5);
    }
    //Parte decimal
    decimal parte_decimal = cantidad - parte_entera;
    DCAN = Convert.ToInt32(parte_decimal * 100);

    if ((DCAN >= 50))
    {
        DC50 = (DCAN / 50);
        DCAN = DCAN - (DC50 * 50);
    }
    if ((DCAN >= 25))
    {
        DC25 = (DCAN / 25);
        DCAN = DCAN - (DC25 * 25);
    }
    if ((DCAN >= 10))
    {
        DC10 = (DCAN / 10);
        DCAN = DCAN - (DC10 * 10);
    }
    if ((DCAN >= 5))
    {
        DC5 = (DCAN / 5);
        DCAN = DCAN - (DC5 * 5);
    }
    Console.WriteLine($"-- Estos son los billetes --");
    Console.WriteLine($"Billetes de 200: {C200}");
    Console.WriteLine($"Billetes de 100: {C100}");
    Console.WriteLine($"Billetes de 50: {C50}");
    Console.WriteLine($"Billetes de 20: {C20}");
    Console.WriteLine($"Billetes de 10: {C10}");
    Console.WriteLine($"Billetes de 5: {C5}");
    Console.WriteLine($"Billetes de 1: {CAN}");
    Console.WriteLine($"-- Estos son los centavos --");
    Console.WriteLine($"Centavos de 50: {DC50}");
    Console.WriteLine($"Centavos de 25: {DC25}");
    Console.WriteLine($"Centavos de 10: {DC10}");
    Console.WriteLine($"Centavos de 5: {DC5}");
    Console.WriteLine($"Centavos de 1: {DCAN}");
}

static void borrador()
{

    Console.ReadLine();
    Console.Clear();
}

contrasena();

