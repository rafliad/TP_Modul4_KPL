internal class Program
{
    private static void Main(string[] args)
    {
        KodePos.EnumNamaKelurahan Kelurahan = KodePos.EnumNamaKelurahan.Cijaura;
        int OutputKodePos = KodePos.GetKodePos(Kelurahan);
        Console.WriteLine("Kelurahan " + Kelurahan + " Memiliki kode pos: " + OutputKodePos);
        DoorMachine pintu = new DoorMachine();
        Console.WriteLine(pintu.currentState);
        pintu.ActivateTrigger(DoorMachine.Trigger.BukaPintu);
        pintu.ActivateTrigger(DoorMachine.Trigger.BukaPintu);
        pintu.ActivateTrigger(DoorMachine.Trigger.KunciPintu);
        pintu.ActivateTrigger(DoorMachine.Trigger.KunciPintu);
    }
}
public class KodePos
{
    public enum EnumNamaKelurahan
    {
        Batununggal,
        Kujangsari,
        Mengger,
        Wates,
        Cijaura,
        Jatisari,
        Margasari,
        Sekejati,
        Kebonwaru,
        Maleer,
        Samoja
    }
    public static int GetKodePos(EnumNamaKelurahan inputKelurahan)
    {
        int[] outputKodePos = { 40266, 40287, 40267, 40256, 40287, 40286, 40286, 40286, 40272, 40274, 40273 };
        return outputKodePos[(int)inputKelurahan];
    }
}

public class DoorMachine
{
    public enum statePintu
    {
        Terkunci,
        Terbuka
    }
    public enum Trigger
    {
        BukaPintu,
        KunciPintu
    }
    public class Transition
    {
        public statePintu stateAwal;
        public statePintu stateAkhir;
        public Trigger trigger;
        public Transition(statePintu stateAwal, statePintu stateAkhir, Trigger trigger)
        {
            this.stateAwal = stateAwal;
            this.stateAkhir = stateAkhir;
            this.trigger = trigger;
        }
    }
    Transition[] transisi =
    {
        new Transition(statePintu.Terkunci, statePintu.Terkunci, Trigger.KunciPintu),
        new Transition(statePintu.Terkunci, statePintu.Terbuka, Trigger.BukaPintu),
        new Transition(statePintu.Terbuka, statePintu.Terbuka, Trigger.BukaPintu),
        new Transition(statePintu.Terbuka, statePintu.Terkunci, Trigger.KunciPintu)
    };
    public statePintu GetNextState(statePintu stateAwal, Trigger trigger)
    {
        statePintu stateAkhir = stateAwal;
        for (int i = 0; i < transisi.Length; i++)
        {
            Transition perubahan = transisi[i];
            if (stateAwal == perubahan.stateAwal && trigger == perubahan.trigger)
            {
                stateAkhir = perubahan.stateAkhir;
            }
        }
        return stateAkhir;
    }
    public void ActivateTrigger(Trigger trigger)
    {
        currentState = GetNextState(currentState, trigger);
        Console.WriteLine("State anda sekarang adalah : " + currentState);

        if (currentState == statePintu.Terbuka)
        {
            Console.WriteLine("Pintu tidak terkunci");
        }
        else
        {
            Console.WriteLine("Pintu terkunci");
        }

    }
    public statePintu currentState = statePintu.Terkunci;
}