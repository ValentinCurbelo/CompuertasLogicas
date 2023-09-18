﻿using System;

public interface IGate
{
    string GetName();
    bool? Calculate();
}
public class Program
{
    static void Main()
    {
        // Ejemplo de uso:
        GateAND andGate = new GateAND("AND1", 2);
        andGate.SetInput(0, 1);
        andGate.SetInput(1, 0);

        GateNOT notGate = new GateNOT("NOT1");
        notGate.SetInput(andGate);

        bool? result = notGate.Calculate();
        if (result.HasValue)
        {
            Console.WriteLine($"Resultado de {notGate.GetName()}: {result.Value}");
        }
        else
        {
            Console.WriteLine($"No se puede calcular el resultado de {notGate.GetName()}");
        }
    }
}