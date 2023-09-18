namespace compuertas;

public class Program
{

    //Clase Compuerta
    public class Compuerta
    {
        //Atributos
        public bool entrada1;
        public bool entrada2;
        public bool salida;

        //Constructor
        public Compuerta(bool entrada1, bool entrada2)
        {
            this.entrada1 = entrada1;
            this.entrada2 = entrada2;
        }

        //Metodos
        public virtual void Calcular()
        {
            Console.WriteLine("Compuerta");
        }
    }
}
    //Clase Compuerta AND
    public class CompuertaAND : Compuerta
    {
        //Constructor
        public CompuertaAND(bool entrada1, bool entrada2) : base(entrada1, entrada2)
        {
        }

        //Metodos
        public override void Calcular()
        {
            if (entrada1 == true && entrada2 == true)
            {
                salida = true;
            }
            else
            {
                salida = false;
            }
        }
    }

    //Clase Compuerta OR
    public class CompuertaOR : Compuerta
    {
        //Constructor
        public CompuertaOR(bool entrada1, bool entrada2) : base(entrada1, entrada2)
        {
        }

        //Metodos
        public override void Calcular()
        {
            if (entrada1 == true || entrada2 == true)
            {
                salida = true;
            }
            else
            {
                salida = false;
            }
        }
    }

    //Clase Compuerta NOT
    public class CompuertaNOT : Compuerta
    {
        //Constructor
        public CompuertaNOT(bool entrada1) : base(entrada1, false)
        {
        }

        //Metodos
        public override void Calcular()
        {
            if (entrada1 == true)
            {
                salida = false;
            }
            else
            {
                salida = true;
            }
        }
    }

    //Clase Compuerta XOR
    public class CompuertaXOR : Compuerta
    {
        //Constructor
        public CompuertaXOR(bool entrada1, bool entrada2) : base(entrada1, entrada2)
        {
        }

        //Metodos
        public override void Calcular()
        {
            if (entrada1 == true && entrada2 == false || entrada1 == false && entrada2 == true)
            {
                salida = true;
            }
            else
            {
                salida = false;
            }
        }
    }