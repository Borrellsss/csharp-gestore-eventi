public class Conferenza : Evento
{
    public Conferenza(string relatore, double prezzo, string titolo, DateTime data, int capienzaMassima) : base(titolo, data, capienzaMassima)
    {
        Relatore = relatore;
        Prezzo = prezzo;
    }
    protected string relatore;
    public string Relatore
    {
        get
        {
            return relatore;
        }
        protected set
        {
            if (value == "")
            {
                throw new Exception();
            }
            else
            {
                relatore = value;
            }
        }
    }
    public double Prezzo { get; protected set; }
    public string GetPrezzoFormattato()
    {
        return Prezzo.ToString("0.00");
    }

    public override string ToString()
    {
        return $"Data: {GetDataFormattata()} \nTitolo: {Titolo} \nRelatore: {Relatore} \nPrezzo: {GetPrezzoFormattato()} euro";
    }
    public override string ToStringToExport()
    {
        return $"{Titolo.ToLower()}-{GetDataFormattata()}-{CapienzaMassima}-{PostiPrenotati}-{Relatore.ToLower()}-{GetPrezzoFormattato().Replace(",", ".")}";
    }
}