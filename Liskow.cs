using System.Reflection.PortableExecutable;

namespace ListKow{
    public abstract class Ave{
        public int Peso { get; init; }
        public Ave(int peso){
            Peso = peso;
        }
    }

    public abstract class AveVoladora:Ave{
        public int Velocidad { get; init; }
        public AveVoladora(int peso , int velocidad):base(peso){
            Velocidad = velocidad;
        }
    }

    public class Pinguino:Ave{
        public Pinguino(int peso):base(peso){

        }
    }
    public class Aguila:AveVoladora{
        public Aguila(int peso,int velocidad):base(peso,velocidad){

        }
    }

    public class Paloma:AveVoladora{
        public Paloma(int peso,int velocidad):base(peso,velocidad){
            
        }
    }
    public class Printer{        

        public static Action<Ave,Action<Object>> PrintAve =(ave,printer)=>printer(ave);
        public static Action<AveVoladora,Action<Object>> PrintAveVoladora =(ave,printer)=>printer(ave);
    }
    
}