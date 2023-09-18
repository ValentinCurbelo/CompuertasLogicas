using System;

public class GateOR : IGate
{
    public string name;
    public object[] inputs;

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