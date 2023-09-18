using System;

public interface IGate
{
    string GetName();
    bool? Calculate();
}

class GateAND : IGate
{
    private string name;
    private object[] inputs;

    public GateAND(string nombre, int inputCount)
    {
        name = nombre;
        inputs = new object[inputCount];
    }

    public string GetName()
    {
        return name;
    }

    public void SetInput(int index, object value)
    {
        if (index >= 0 && index < inputs.Length)
        {
            inputs[index] = value;
        }
    }

    public bool? Calculate()
    {
        int product = 1;
        foreach (var input in inputs)
        {
            if (input is int intValue)
            {
                if (intValue == 0 || intValue == 1)
                {
                    product *= intValue;
                }
                else
                {
                    return null; // No se puede calcular si hay un valor no válido.
                }
            }
            else if (input is IGate gate)
            {
                var result = gate.Calculate();
                if (result.HasValue)
                {
                    product *= result.Value ? 1 : 0;
                }
                else
                {
                    return null; // No se puede calcular si una entrada es nula.
                }
            }
        }
        return product == 1;
    }
}

class GateOR : IGate
{
    private string name;
    private object[] inputs;

    public GateOR(string nombre, int inputCount)
    {
        name = nombre;
        inputs = new object[inputCount];
    }

    public string GetName()
    {
        return name;
    }

    public void SetInput(int index, object value)
    {
        if (index >= 0 && index < inputs.Length)
        {
            inputs[index] = value;
        }
    }

    public bool? Calculate()
    {
        int sum = 0;
        foreach (var input in inputs)
        {
            if (input is int intValue)
            {
                if (intValue == 0 || intValue == 1)
                {
                    sum += intValue;
                }
                else
                {
                    return null; // No se puede calcular si hay un valor no válido.
                }
            }
            else if (input is IGate gate)
            {
                var result = gate.Calculate();
                if (result.HasValue)
                {
                    sum += result.Value ? 1 : 0;
                }
                else
                {
                    return null; // No se puede calcular si una entrada es nula.
                }
            }
        }
        return sum > 0;
    }
}

class GateNOT : IGate
{
    private string name;
    private object input;

    public GateNOT(string nombre)
    {
        name = nombre;
        input = null;
    }

    public string GetName()
    {
        return name;
    }

    public void SetInput(object value)
    {
        input = value;
    }

    public bool? Calculate()
    {
        if (input != null)
        {
            if (input is int intValue)
            {
                if (intValue == 0)
                {
                    return true;
                }
                else if (intValue == 1)
                {
                    return false;
                }
                else
                {
                    return null; // Valor no válido.
                }
            }
            else if (input is IGate gate)
            {
                var result = gate.Calculate();
                if (result.HasValue)
                {
                    return !result.Value;
                }
                else
                {
                    return null; // No se puede calcular si una entrada es nula.
                }
            }
        }
        return null; // Entrada nula.
    }
}

class Program
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