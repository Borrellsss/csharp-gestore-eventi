using System.Linq.Expressions;

bool runProgram = true;
ProgrammaEventi nuovoProgrammaEvento = null;

while (runProgram)
{
    Console.WriteLine("Cosa vuoi fare?");
    Console.WriteLine("[1]: Crea Programma Evento.");
    Console.WriteLine("[2]: Crea un singolo Evento.");
    Console.WriteLine("[3]: Esporta programma eventi.");
    Console.WriteLine("[4]: Importa programma eventi.");
    Console.WriteLine("[5]: Termina programma.");

    string sceltaMenu = Console.ReadLine();
    Console.Clear();

    switch(sceltaMenu)
    {
        case "1":
            CreaProgrammaEvento();
            TerminaProgramma();
            break;

        case "2":
            CreaEvento();
            TerminaProgramma();
            break;

        case "3":
            EsportaProgrammaEventi();
            TerminaProgramma();
            break;

        case "4":
            ImportaProgrammaEventi();
            TerminaProgramma();
            break;

        case "5":
            Console.WriteLine("Grazie e arrivederci!");
            runProgram = false;
            break;

        default:
            Console.WriteLine("Scelta errata!");
            TerminaProgramma();
            break;
    }
}

void CreaProgrammaEvento()
{
    Console.WriteLine("Quale Programma Evento vuoi creare?");

    bool createEventProgramRequest = true;
    while(createEventProgramRequest)
    {
        Console.Write("Inserisci titolo: ");
        string titoloProgrammaEvento = Console.ReadLine();
        Console.Clear();

        try
        {
            nuovoProgrammaEvento = new ProgrammaEventi(titoloProgrammaEvento);
            Console.WriteLine("Programma Evento creato correttamente!");
            createEventProgramRequest = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Qualcosa è andato storto!");
        }
    }

    int numeroEventiDaAggiungere = 0;

    bool numberOfEventsRequest = true;
    while (numberOfEventsRequest)
    {
        Console.WriteLine("Quanti Eventi e/o Conferenze vuoi creare e aggiungere al programma?");
        Console.Write("Inserisci numero: ");

        try
        {
            numeroEventiDaAggiungere = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            numberOfEventsRequest = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Non è possibile inserire il numero in lettere!");
        }
    }

    int counter = 0;
    while(counter < numeroEventiDaAggiungere)
    {
        bool eventOrConferenceRequest = true;
        while(eventOrConferenceRequest)
        {
            Console.WriteLine("Vuoi creare un Evento generico o una Conferenza?");
            Console.WriteLine("[1]: Evento generico.");
            Console.WriteLine("[2]: Conferenza.");

            string EventoOConferenza = Console.ReadLine();
            Console.Clear();

            switch (EventoOConferenza)
            {
                case "1":
                    Console.WriteLine($"Evento {counter + 1} di {numeroEventiDaAggiungere}");

                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine();

                    Console.Write("Inserisci titolo: ");
                    string titoloEvento = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine();

                    DateTime dataEvento = new DateTime();
                    Evento nuovoEvento = null;

                    bool EventDateRequest = true;
                    while (EventDateRequest)
                    {
                        Console.WriteLine("Inserisci giorno, mese e anno con formato gg/mm/yyyy.");

                        try
                        {
                            Console.Write("Giorno: ");
                            int giorno = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Mese: ");
                            int mese = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Anno: ");
                            int anno = Convert.ToInt32(Console.ReadLine());

                            dataEvento = new DateTime(anno, mese, giorno);

                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine();

                            EventDateRequest = false;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Non è possibile inserire giorno, mese o anno in lettere!");
                        }
                    }

                    int postiEvento = 0;

                    bool eventRoomRequest = true;
                    while (eventRoomRequest)
                    {
                        Console.Write("Inserisci numero di posti: ");

                        try
                        {
                            postiEvento = Convert.ToInt32(Console.ReadLine());

                            Console.Clear();

                            eventRoomRequest = false;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Non è possibile inserire il numero di posti in lettere!");
                        }
                    }

                    try
                    {
                        nuovoEvento = new Evento(titoloEvento, dataEvento, postiEvento);
                        nuovoProgrammaEvento.AggiungiEvento(nuovoEvento);
                        counter++;
                        Console.WriteLine("Evento aggiunto correttamente!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Qualcosa è andato storto!");
                    }

                    eventOrConferenceRequest = false;
                    break;
                case "2":
                    Console.WriteLine($"Evento {counter + 1} di {numeroEventiDaAggiungere}");
                    Console.Write("Inserisci titolo: ");
                    string titoloConferenza = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine();

                    Console.Write("Inserisci nome relatore: ");
                    string nomeRelatore = Console.ReadLine();

                    Console.WriteLine();
                    Console.WriteLine("--------------------------------------------------------------");
                    Console.WriteLine();

                    DateTime dataConferenza = new DateTime();
                    Conferenza nuovaConferenza = null;

                    bool conferenceDateRequest = true;
                    while (conferenceDateRequest)
                    {
                        Console.WriteLine("Inserisci giorno, mese e anno con formato gg/mm/yyyy.");

                        try
                        {
                            Console.Write("Giorno: ");
                            int giorno = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Mese: ");
                            int mese = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Anno: ");
                            int anno = Convert.ToInt32(Console.ReadLine());

                            dataConferenza = new DateTime(anno, mese, giorno);

                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine();

                            conferenceDateRequest = false;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Non è possibile inserire giorno, mese o anno in lettere!");
                        }
                    }

                    int postiConferenza = 0;

                    bool conferenceRoomRequest = true;
                    while (conferenceRoomRequest)
                    {
                        Console.Write("Inserisci numero di posti: ");

                        try
                        {
                            postiConferenza = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine();
                            Console.WriteLine("--------------------------------------------------------------");
                            Console.WriteLine();

                            conferenceRoomRequest = false;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Non è possibile inserire il numero di posti in lettere!");
                        }
                    }

                    double prezzoConferenza = 0;

                    bool conferencePriceRequest = true;
                    while (conferencePriceRequest)
                    {
                        Console.Write("Inserisci prezzo: ");

                        try
                        {
                            prezzoConferenza = Convert.ToDouble(Console.ReadLine());

                            Console.Clear();

                            conferencePriceRequest = false;
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Non è possibile inserire il prezzo in lettere!");
                        }
                    }

                    try
                    {
                        nuovaConferenza = new Conferenza(nomeRelatore, prezzoConferenza, titoloConferenza, dataConferenza, postiConferenza);
                        nuovoProgrammaEvento.AggiungiEvento(nuovaConferenza);
                        counter++;
                        Console.WriteLine("Evento aggiunto correttamente!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Qualcosa è andato storto!");
                    }
                    eventOrConferenceRequest = false;
                    break;
                default:
                    Console.WriteLine("Opzione non valida!");
                    break;
            }
        }
    }

    Console.WriteLine($"Numero Eventi creati: {ProgrammaEventi.GetNumeroEventiPresenti()}");

    nuovoProgrammaEvento.StampaProgrammaEventi();

    Console.ReadLine();
    Console.Clear();

    Console.WriteLine("Inserisci una data per effettuare una ricerca: ");

    DateTime dataDaControllare = new DateTime();

    bool dateToCheckRequest = true;
    while (dateToCheckRequest)
    {
        Console.WriteLine("Inserisci giorno, mese e anno con formato gg/mm/yyyy.");

        try
        {
            Console.Write("Giorno: ");
            int giorno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Mese: ");
            int mese = Convert.ToInt32(Console.ReadLine());

            Console.Write("Anno: ");
            int anno = Convert.ToInt32(Console.ReadLine());

            dataDaControllare = new DateTime(anno, mese, giorno);
            Console.Clear();
            dateToCheckRequest = false;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Non è possibile inserire giorno, mese o anno in lettere!");
        }
    }

    List<Evento> listaEventiInDataSelezionata = nuovoProgrammaEvento.GetListaEventiDaData(dataDaControllare);

    if(listaEventiInDataSelezionata.Count() > 0)
    {
        ProgrammaEventi.StampaListaEventi(listaEventiInDataSelezionata);
    }
    else
    {
        Console.WriteLine("Non è presente alcun Evento in questa data!");
    }

    //nuovoProgrammaEvento.svuotaListaEventi();
}

void CreaEvento() {

    Console.WriteLine("Quale Evento vuoi creare?");

    Console.Write("Inserisci titolo: ");
    string titoloEvento = Console.ReadLine();

    DateTime data = new DateTime();
    Evento nuovoEvento = null;

    bool dateRequest = true;
    while(dateRequest)
    {
        Console.WriteLine("Inserisci giorno, mese e anno con formato gg/mm/yyyy.");

        try
        {
            Console.Write("Giorno: ");
            int giorno = Convert.ToInt32(Console.ReadLine());

            Console.Write("Mese: ");
            int mese = Convert.ToInt32(Console.ReadLine());

            Console.Write("Anno: ");
            int anno = Convert.ToInt32(Console.ReadLine());

            data = new DateTime(anno, mese, giorno);

            dateRequest = false;
        }
        catch(FormatException ex)
        {
            Console.WriteLine("Non è possibile inserire giorno, mese o anno in lettere!");
        }
    }

    int posti = 0;

    bool roomRequest = true;
    while (roomRequest)
    {
        Console.Write("Inserisci numero di posti: ");

        try
        {
            posti = Convert.ToInt32(Console.ReadLine());
            roomRequest = false;
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Non è possibile inserire il numero di posti in lettere!");
        }
    }

    try
    {
        nuovoEvento = new Evento(titoloEvento, data, posti);
        Console.WriteLine("Evento aggiunto correttamente!");

        bool reservationRequest = true;
        while (reservationRequest)
        {
            Console.WriteLine("Vuoi prenotare dei posti per questo evento?");
            Console.WriteLine("[1]: Sì.");
            Console.WriteLine("[2]: No.");

            string sceltaUtente = Console.ReadLine();

            switch (sceltaUtente)
            {
                case "1":
                    Console.Write("Posti da prenotare: ");
                    int postiDaPrenotare = 0;

                    try
                    {
                        postiDaPrenotare = Convert.ToInt32(Console.ReadLine());
                    }
                    catch (FormatException ex)
                    {
                        Console.WriteLine("Non è possibile inserire il numero di posti in lettere!");
                    }

                    try
                    {
                        nuovoEvento.PrenotaPosti(postiDaPrenotare);
                        Console.WriteLine("Prenotazione avvenuta con successo!!");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Qualcosa è andato storto durante la prenotazione");
                    }

                    reservationRequest = false;
                    break;

                case "2":
                    reservationRequest = false;
                    break;

                default:
                    Console.WriteLine("Scelta errata!");
                    break;
            }
        }

        Console.WriteLine($"Capienza massima evento {nuovoEvento.Titolo}: {nuovoEvento.CapienzaMassima}");
        Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
        Console.WriteLine($"Posti ancora disponibili: {nuovoEvento.PostiDisponibili}");

        if(nuovoEvento.PostiPrenotati > 0)
        {
            bool reservationCancellationRequest = true;
            while (reservationCancellationRequest)
            {
                Console.WriteLine("Vuoi disdire delle prenotazioni?");
                Console.WriteLine("[1]: Sì.");
                Console.WriteLine("[2]: No.");

                string userCancellationRequestChoice = Console.ReadLine();

                switch (userCancellationRequestChoice)
                {
                    case "1":
                        Console.Write("Prenotazioni da disdire: ");

                        int postiDaDisdire = 0;
                        try
                        {
                            postiDaDisdire = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException ex)
                        {
                            Console.WriteLine("Non è possibile inserire il numero di posti in lettere!");
                        }

                        try
                        {
                            nuovoEvento.DisdiciPostiPrenotati(postiDaDisdire);

                            Console.WriteLine($"Capienza massima evento {nuovoEvento.Titolo}: {nuovoEvento.CapienzaMassima}");
                            Console.WriteLine($"Posti prenotati: {nuovoEvento.PostiPrenotati}");
                            Console.WriteLine($"Posti ancora disponibili: {nuovoEvento.PostiDisponibili}");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Immpossibile disdire ulteriori prenotazioni!");
                        }

                        break;

                    case "2":
                        reservationCancellationRequest = false;
                        break;

                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            }
        }
        else
        {
            Console.WriteLine("Creazione Evento terminata!");
        }
    }
    catch(Exception ex)
    {
        Console.WriteLine("Qualcosa è andato storto!");
    }
}

void EsportaProgrammaEventi()
{
    try
    {
        string path = "C:\\Users\\edo_e\\source\\repos\\Classe 4 - Experis\\csharp-gestore-eventi\\programma-eventi.csv";

        if(File.Exists(path))
        {
            File.Delete(path);
        }

        StreamWriter file = File.CreateText(path);

        file.WriteLine("tipo,titolo,data,capienza-massima,posti-prenotati,relatore,prezzo");
        foreach (Evento evento in nuovoProgrammaEvento.Eventi)
        {
            string stringToExport = evento.ToStringToExport();

            List<string> stringListToExport = stringToExport.Split('-').ToList();

            if(stringListToExport.Count() == 4)
            {
                file.WriteLine($"{evento.GetType().ToString().ToLower()},{stringListToExport[0].Replace(" ", "-")},{stringListToExport[1]},{stringListToExport[2]},{stringListToExport[3]},0,0");
            }
            else
            {
                file.WriteLine($"{evento.GetType().ToString().ToLower()},{stringListToExport[0].Replace(" ", "-")},{stringListToExport[1]},{stringListToExport[2]},{stringListToExport[3]},{stringListToExport[4].Replace(" ", "-")},{stringListToExport[5]}");
            }
        }

        file.Close();
        Console.WriteLine("File esportato correttamente!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Si è verificato un errore durante l'esportazione del file.");
    }
}

void ImportaProgrammaEventi()
{
    ProgrammaEventi nuovoProgrammaImportato = null;

    bool newProgramToImportRequest = true;
    while(newProgramToImportRequest)
    {
        Console.WriteLine("Scrivi il titolo del programma eventi che vuoi creare per eseguire l'import: ");

        Console.Write("Titolo: ");
        string titoloProgrammaimportato = Console.ReadLine();

        try
        {
            nuovoProgrammaImportato = new ProgrammaEventi(titoloProgrammaimportato);
            newProgramToImportRequest = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Errore durante la creazione, non è possibile inserire stringhe vuote!");
        }
    }

    try
    {
        string path = "C:\\Users\\edo_e\\source\\repos\\Classe 4 - Experis\\csharp-gestore-eventi\\programma-eventi.csv";
        StreamReader file = File.OpenText(path);

        int counter = 0;
        while (!file.EndOfStream)
        {
            string stringToImport = file.ReadLine();

            List<string> stringListToImport = stringToImport.Split(',').ToList();

            Evento evento = null;

            if (counter > 0)
            {
                if (stringListToImport[5] == "0" && stringListToImport[6] == "0")
                {
                    string titolo = stringListToImport[1].Replace("-", " ");
                    DateTime data = Convert.ToDateTime(stringListToImport[2]);
                    int capienzaMassima = Convert.ToInt32(stringListToImport[3]);
                    int postiPrenotati = Convert.ToInt32(stringListToImport[4]);
                    evento = new Evento(titolo, data, capienzaMassima);
                }
                else
                {
                    string titolo = stringListToImport[1].Replace("-", " ");
                    DateTime data = Convert.ToDateTime(stringListToImport[2]);
                    int capienzaMassima = Convert.ToInt32(stringListToImport[3]);
                    int postiPrenotati = Convert.ToInt32(stringListToImport[4]);
                    string relatore = stringListToImport[5].Replace("-", " ");
                    double prezzo = Convert.ToDouble(stringListToImport[6].Replace(".", ","));
                    evento = new Conferenza(relatore, prezzo, titolo, data, capienzaMassima);
                }

                nuovoProgrammaImportato.AggiungiEvento(evento);
            }
            
            counter++;
        }

        file.Close();
        Console.WriteLine("File importato correttamente!");
        nuovoProgrammaImportato.StampaProgrammaEventi();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Si è verificato un errore durante l'importazione del file.");
    }
}

void TerminaProgramma()
{
    Console.ReadLine();
    Console.Clear();
    bool endProgram = true;

    while (endProgram)
    {
        Console.WriteLine("Vuoi terminare il programma?");
        Console.WriteLine("[1]: Sì.");
        Console.WriteLine("[2]: No.");

        string sceltaTerminaProgramma = Console.ReadLine();
        Console.Clear();

        switch (sceltaTerminaProgramma)
        {
            case "1":
                Console.WriteLine("Grazie e arrivederci!");
                runProgram = false;
                endProgram = false;
                break;

            case "2":
                endProgram = false;
                break;

            default:
                Console.WriteLine("Scelta errata!");
                break;
        }
    }
}