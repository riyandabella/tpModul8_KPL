using System;

class Program
{
    static void Main()
    {
        CovidConfig config = CovidConfig.Load();

        config.UbahSatuan();

        Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + config.satuan_suhu);
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuNormal = false;

        if (config.satuan_suhu == "celcius")
        {
            if (suhu >= 36.5 && suhu <= 37.5)
                suhuNormal = true;
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            if (suhu >= 97.7 && suhu <= 99.5)
                suhuNormal = true;
        }

        bool hariAman = hariDemam < config.batas_hari_deman;

        if (suhuNormal && hariAman)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}
