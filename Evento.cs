
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
            DateTime dataOdierna = DateTime.Now;
            TimeSpan timeSpan = value - dataOdierna;
            int differenzaInGiorni = Convert.ToInt32(timeSpan.Days / 30);

            if(differenzaInGiorni < 0)
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

        DateTime dataOdierna = DateTime.Now;
        TimeSpan timeSpan = Data - dataOdierna;
        int differenzaInGiorni = Convert.ToInt32(timeSpan.Days / 30);

        if (differenzaInGiorni < 0)
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

        DateTime dataOdierna = DateTime.Now;
        TimeSpan timeSpan = Data - dataOdierna;
        int differenzaInGiorni = Convert.ToInt32(timeSpan.Days / 30);

        if (differenzaInGiorni < 0)
        {
            throw new Exception();
        }

        PostiPrenotati -= numeroPosti;
    }
    public override string ToString()
    {
        return $"Data Evento: {Data.ToString("dd/MM/yyyy")} \nTitolo: {Titolo} \nPosti prenotati: {PostiPrenotati} \nPosti ancora disponibili: {PostiDisponibili}";
    }
}  