


public class ProgrammaEventi
{
    protected static int NumeroEventiPresenti = 0;
    public ProgrammaEventi(string titolo)
    {
        Titolo = titolo;
        Eventi = new List<Evento>();
    }
    protected string titolo;
    public List<Evento> Eventi { get; protected set; }
    public string Titolo
    {
        get
        {
            return titolo;
        }
        protected set
        {
            if (value == "")
            {
                throw new Exception();
            }
            else
            {
                titolo = value;
            }
        }
    }

    public void AggiungiEvento(Evento evento)
    {
        if(evento == null)
        {
            throw new Exception();
        }

        if(Eventi.Contains(evento))
        {
            throw new Exception();
        }

        Eventi.Add(evento);
        NumeroEventiPresenti++;
    }
    public List<Evento> GetListaEventiDaData(DateTime data)
    {
        List<Evento> listaEventiInData = new List<Evento>();
    
        foreach(Evento evento in Eventi)
        {
            if(evento.Data == data)
            {
                listaEventiInData.Add(evento);
            }
        }

        return listaEventiInData;
    }
    public static void StampaListaEventi(List<Evento> eventi)
    {
        if(eventi.Count() == 0)
        {
            throw new Exception();
        }

        for(int i = 0; i < eventi.Count(); i++)
        {
            Evento evento = eventi[i];

            if(i == 0 || i == eventi.Count() - 1)
            {
                if(eventi.Count() == 1 || i == eventi.Count() - 1)
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine($"EVENTO {i}");
                    Console.WriteLine(evento.ToString());
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine($"EVENTO {i}");
                    Console.WriteLine(evento.ToString());
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"EVENTO {i}");
                Console.WriteLine(evento.ToString());
                Console.WriteLine();
            }
        }
    }
    public static int GetNumeroEventiPresenti()
    {
        return NumeroEventiPresenti;
    }
    public void svuotaListaEventi()
    {
        NumeroEventiPresenti -= this.Eventi.Count();
        this.Eventi.Clear();
    }
    public void StampaProgrammaEventi()
    {
        if(Eventi.Count() == 0)
        {
            throw new Exception();
        }

        Console.WriteLine($"Titolo programa: {Titolo}");
        for (int i = 0; i < Eventi.Count(); i++)
        {
            Evento evento = Eventi[i];

            if(i == 0 || i == Eventi.Count() - 1)
            {
                if (Eventi.Count() == 1 || i == Eventi.Count() - 1)
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine($"Data: {evento.Data} - Titolo: {evento.Titolo}");
                    Console.WriteLine();
                    Console.WriteLine("---------------------------------------------------------------------");
                }
                else
                {
                    Console.WriteLine("---------------------------------------------------------------------");
                    Console.WriteLine();
                    Console.WriteLine($"Data: {evento.Data} - Titolo: {evento.Titolo}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("---------------------------------------------------------------------");
                Console.WriteLine();
                Console.WriteLine($"Data: {evento.Data} - Titolo: {evento.Titolo}");
                Console.WriteLine();
            }
        }
    }
}