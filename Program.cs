using System.Data;

bool FaraTreiConsoaneConsecutive(char[] s)
{
    int nrConsoane = 0;
    foreach (var c in s)
    {
        if (TreiConsoaneBuf.EsteConsoana(c)) nrConsoane++;
        else nrConsoane = 0;
        if (nrConsoane == 3) return false;
    }
    return true;
}

void MTAB(int k, char[] s, string cuvant, bool[] b, TreiConsoaneBuf buf)
{
    if (k >= s.Length)
    {
        string s2 = "";
        foreach (char c in s) {
            s2 += c;
        }
        Console.WriteLine(s2);
        buf.Clear();
    } else
    {
        for (int i=0; i<s.Length; i++)
        {
            if (
                buf.MaiIntraOConsoana() && 
                !b[i])
            {
                s[k] = cuvant[i];
                b[i] = true;
                buf.Add(cuvant[i]);
                MTAB(k + 1, s, cuvant, b, buf);
                buf.Remove(cuvant[i]);
                b[i] = false;
            }
        }
    }
}

void MTAB_helper(string s)
{
    MTAB(0, new char[s.Length], s, new bool[s.Length], new TreiConsoaneBuf());
}

void MTAB2(int k, char[] s, string cuvant, bool[] b)
{
    if (k >= s.Length)
    {
        if (!FaraTreiConsoaneConsecutive(s)) return;
        string s2 = "";
        foreach (char c in s)
        {
            s2 += c;
        }
        Console.WriteLine(s2);
    }
    else
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (!b[i])
            {
                s[k] = cuvant[i];
                b[i] = true;
                MTAB2(k + 1, s, cuvant, b);
                b[i] = false;
            }
        }
    }
}

void MTAB_helper2(string s)
{
    MTAB2(0, new char[s.Length], s, new bool[s.Length]);
}

//MTAB_helper("abc");

//for (char i='a'; i<='z'; i++)
//{
//    Console.WriteLine($"{i} {(TreiConsoaneBuf.EsteConsoana(i) ? "este consoana" : "este vocala")}");
//}

//MTAB_helper("zgripsor");
//MTAB_helper2("zgripsor");

Console.WriteLine("Da-mi un cuvant: ");
string cuvant = Console.ReadLine() ?? "zgripsor";
MTAB_helper2(cuvant);

class TreiConsoaneBuf()
{
    static public char[] vocale = "AEIOUaeiou".ToCharArray();
    static public bool EsteVocala(char c) => vocale.Contains(c);
    static public bool EsteConsoana(char c) => !vocale.Contains(c);

    Dictionary<char, int> buf = new();

    public int NrConsoane() => buf.Aggregate(0, (accumulator, elem) => accumulator + elem.Value);

    public bool MaiIntraOConsoana() => NrConsoane() + 1 <= 3;

    public void Add(char c)
    {
        if (EsteVocala(c)) return;
        if (buf.ContainsKey(c)) buf[c]++;
        else buf[c] = 1;
    }

    public void Remove(char c)
    {
        if (EsteVocala(c)) return;
        if (buf.TryGetValue(c, out int count))
        {
            if (count > 1) buf[c] = count = 1;
            else buf.Remove(c);
        }
    }

    public void Clear() => buf.Clear(); 
}