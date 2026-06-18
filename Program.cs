char[] vocale = "AEIOUaeiou".ToCharArray();
bool EsteVocala(char c) => vocale.Contains(c);
bool EsteConsoana(char c) => !vocale.Contains(c);

bool FaraTreiConsoaneConsecutive(char[] s)
{
    int nrConsoane = 0;
    foreach (var c in s)
    {
        if (EsteConsoana(c)) nrConsoane++;
        else nrConsoane = 0;
        if (nrConsoane == 3) return false;
    }
    return true;
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

Console.WriteLine("Da-mi un cuvant: ");
string cuvant = Console.ReadLine();
MTAB_helper2(cuvant);