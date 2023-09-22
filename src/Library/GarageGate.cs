using System;

public class GarageGate
{
    private bool buttonA;
    private bool buttonB;
    private bool buttonC;

    public GarageGate()
    {
        buttonA = false;
        buttonB = false;
        buttonC = false;
    }

    public void PressButtonA()
    {
        buttonA = true;
    }

    public void ReleaseButtonA()
    {
        buttonA = false;
    }

    public void PressButtonB()
    {
        buttonB = true;
    }

    public void ReleaseButtonB()
    {
        buttonB = false;
    }

    public void PressButtonC()
    {
        buttonC = true;
    }

    public void ReleaseButtonC()
    {
        buttonC = false;
    }

    public bool OpenGate()
    {
        // Comprobar las condiciones de apertura según la tabla de verdad
        bool condition1 = !buttonC && !buttonB && !buttonA;
        bool condition2 = buttonC && buttonB && buttonA;

        // Aplicar las condiciones lógicas
        bool result = condition1 || condition2;

        return result;
    }
}