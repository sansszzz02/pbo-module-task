using System;
using System.Collections.Generic;


class Karyawan
{
    public string Nama { get; set; }
    public double Gaji { get; set; }

    public Karyawan(string nama, double gaji)
    {
        Nama = nama;
        Gaji = gaji;
    }

    public virtual void Kerja()
    {
        Console.WriteLine($"{Nama} sedang bekerja.");
    }

    public virtual void InfoKaryawan()
    {
        Console.WriteLine($"Nama : {Nama}");
        Console.WriteLine($"Gaji : Rp {Gaji}");
    }
}


class Tetap : Karyawan
{
    public double Tunjangan { get; set; }

    public Tetap(string nama, double gaji, double tunjangan)
        : base(nama, gaji)
    {
        Tunjangan = tunjangan;
    }

    public double HitungGajiTotal()
    {
        return Gaji + Tunjangan;
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai karyawan tetap.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Tunjangan  : Rp {Tunjangan}");
        Console.WriteLine($"Gaji Total : Rp {HitungGajiTotal()}");
    }
}


class Kontrak : Karyawan
{
    public int Durasi { get; set; } 

    public Kontrak(string nama, double gaji, int durasi)
        : base(nama, gaji)
    {
        Durasi = durasi;
    }

    public void CekKontrak()
    {
        Console.WriteLine($"{Nama} memiliki kontrak selama {Durasi} bulan.");
    }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja berdasarkan kontrak {Durasi} bulan.");
    }

    public override void InfoKaryawan()
    {
        base.InfoKaryawan();
        Console.WriteLine($"Durasi Kontrak : {Durasi} bulan");
    }
}


class Manager : Tetap
{
    public Manager(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Manager, mengawasi tim dan mengambil keputusan strategis.");
    }

    public void Memimpin()
    {
        Console.WriteLine($"Manager {Nama} sedang memimpin rapat tim.");
    }
}


class Staff : Tetap
{
    public Staff(string nama, double gaji, double tunjangan)
        : base(nama, gaji, tunjangan) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Staff.");
    }

    public void KerjakanTugas()
    {
        Console.WriteLine($"Staff {Nama} sedang mengerjakan tugas yang diberikan.");
    }
}


class Magang : Kontrak
{
    public Magang(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Magang.");
    }

    public void Belajar()
    {
        Console.WriteLine($"Magang {Nama} sedang belajar dan mengembangkan skill baru.");
    }
}


class Freelancer : Kontrak
{
    public Freelancer(string nama, double gaji, int durasi)
        : base(nama, gaji, durasi) { }

    public override void Kerja()
    {
        Console.WriteLine($"{Nama} bekerja sebagai Freelancer.");
    }

    public void AmbilProyek()
    {
        Console.WriteLine($"Freelancer {Nama} sedang mengambil proyek baru.");
    }
}


class Perusahaan
{
    private List<Karyawan> daftarKaryawan = new List<Karyawan>();

    public void TambahKaryawan(Karyawan karyawan)
    {
        daftarKaryawan.Add(karyawan);
        Console.WriteLine($"[+] {karyawan.Nama} berhasil ditambahkan ke perusahaan.");
    }

    public void DaftarKaryawan()
    {
        Console.WriteLine("\n========== DAFTAR KARYAWAN PERUSAHAAN ==========");
        foreach (var k in daftarKaryawan)
        {
            Console.WriteLine("\n--- " + k.GetType().Name + " ---");
            k.InfoKaryawan();
        }
        Console.WriteLine("=================================================");
    }
}


class Program
{
    static void Main(string[] args)
    {
        
        Perusahaan perusahaan = new Perusahaan();

        
        Manager mgr = new Manager("Faisal", 15000000, 5000000);
        Staff staff = new Staff("Ilham", 7000000, 1500000);
        Magang magang = new Magang("Joyo", 2000000, 3);
        Freelancer fl = new Freelancer("Dika", 5000000, 6);

        
        Console.WriteLine("===== PENDAFTARAN KARYAWAN =====");
        perusahaan.TambahKaryawan(mgr);
        perusahaan.TambahKaryawan(staff);
        perusahaan.TambahKaryawan(magang);
        perusahaan.TambahKaryawan(fl);

        
        perusahaan.DaftarKaryawan();

        //SOAL 1
        Console.WriteLine("\n===== SOAL 1: Kerja() - Manager & Freelancer =====");
        mgr.Kerja();
        fl.Kerja();

        //SOAL 2
        Console.WriteLine("\n===== SOAL 2: Memimpin() - Manager =====");
        mgr.Memimpin();

        //SOAL 3
        Console.WriteLine("\n===== SOAL 3: Info Lengkap Manager =====");
        Console.WriteLine($"Nama      : {mgr.Nama}");
        Console.WriteLine($"Gaji      : Rp {mgr.Gaji:N0}");
        Console.WriteLine($"Tunjangan : Rp {mgr.Tunjangan:N0}");
        Console.WriteLine($"Total     : Rp {mgr.HitungGajiTotal():N0}");

        //SOAL 4
        Console.WriteLine("\n===== SOAL 4: Belajar() - Magang =====");
        magang.Belajar();

        // e. Demonstrasikan polymorphism & f. Panggil method khusus
        //SOAL 5
        Console.WriteLine("\n===== SOAL 5: Polymorphism - Karyawan = Staff =====");
        Karyawan k = staff;
        k.Kerja();
    }
}