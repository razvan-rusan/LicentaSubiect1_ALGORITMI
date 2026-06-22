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

void MTAB2(int k, char[] s, string cuvant, bool[] b, HashSet<string> hs)
{
    if (k >= s.Length)
    {
        if (!FaraTreiConsoaneConsecutive(s)) return;
        string word = "";
        foreach (var ch in s) word += ch;
        if (hs.Contains(word)) return;
        else hs.Add(word);
        Console.WriteLine(word);
    }
    else
    {
        for (int i = 0; i < s.Length; i++)
        {
            if (!b[i])
            {
                s[k] = cuvant[i]; 
                b[i] = true;
                MTAB2(k + 1, s, cuvant, b, hs);
                b[i] = false;
            }
        }
    }
}

void MTAB_helper2(string s)
{
    MTAB2(0, new char[s.Length], s, new bool[s.Length], new());
}

Console.WriteLine("Da-mi un cuvant: ");
string cuvant = Console.ReadLine();
MTAB_helper2(cuvant);