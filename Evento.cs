
public class Evento
{
    protected string titolo;
    protected DateTime data;
    protected int capienzaMassima;

    public Evento(string titolo, DateTime data, int capienzaMassima)
    {
        Titolo = titolo;
        Data = data;
        CapienzaMassima = capienzaMassima;
        PostiPrenotati = 0;
    }
    public string Titolo
    { 
        get 
        {
            return titolo;
        }
        protected set
        {
            if(value == "")
            {
                throw new Exception();
            }
            else
            {
                titolo = value;
            }
        }
    }
    public DateTime Data
    {
        get
        {
            return data;
        }
        protected set
        {
            if (!Evento.IsValidDate(value))
            {
                throw new Exception();
            }

            data = value;
        }
    }
    public int CapienzaMassima
    {
        get
        {
            return capienzaMassima;
        }
        protected set
        {
            if(value < 0)
            {
                throw new Exception();
            }

            capienzaMassima = value;
        }
    }
    public int PostiPrenotati { get; protected set; }
    public int PostiDisponibili
    {
        get
        {
            return CapienzaMassima - PostiPrenotati;
        }
    }
    public void PrenotaPosti(int numeroPosti)
    {
        if (numeroPosti > PostiDisponibili)
        {
            throw new Exception();
        }

        if (!Evento.IsValidDate(Data))
        {
            throw new Exception();
        }

        PostiPrenotati += numeroPosti;
    }
    public void DisdiciPostiPrenotati(int numeroPosti)
    {
        int totalePosti = numeroPosti + PostiDisponibili;

        if (totalePosti > CapienzaMassima)
        {
            throw new Exception();
        }

        if (!Evento.IsValidDate(Data))
        {
            throw new Exception();
        }

        PostiPrenotati -= numeroPosti;
    }
    public override string ToString()
    {
        return $"Data: {GetDataFormattata()} \nTitolo: {Titolo}";
    }

    public string GetDataFormattata()
    {
        return Data.ToString("dd/MM/yyyy");
    }
    public static bool IsValidDate(DateTime data)
    {
        DateTime dataOdierna = DateTime.Today;

        if (dataOdierna == data || dataOdierna > data)
        {
            return false;
        }
        
        return true;
    }
    public virtual string ToStringToExport()
    {
        return $"{Titolo.ToLower()}-{GetDataFormattata()}-{CapienzaMassima}-{PostiPrenotati}";
    }
}