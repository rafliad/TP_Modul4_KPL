internal class Program
{
    private static void Main(string[] args)
    {
        KodePos.EnumNamaKelurahan Kelurahan = KodePos.EnumNamaKelurahan.Cijaura;
        int OutputKodePos = KodePos.GetKodePos(Kelurahan);
        Console.WriteLine("Kelurahan " + Kelurahan + "Memiliki kode pos: " + OutputKodePos);
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