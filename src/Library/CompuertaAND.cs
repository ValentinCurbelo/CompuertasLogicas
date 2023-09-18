using System;

public interface IGate
{
    string GetName();
    bool? Calculate();
}
public class GateAND : IGate
{
    public string name;
    public object[] inputs;

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