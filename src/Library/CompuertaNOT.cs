using System;

public class GateNOT : IGate
{
    public string name;
    public object input;

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