using System.Linq.Expressions;

bool runProgram = true;

while(runProgram)
{
    Console.WriteLine("Cosa vuoi fare?");
    Console.WriteLine("[1]: Aggiungi Programma Evento.");
    Console.WriteLine("[2]: Termina programma.");

    string sceltaMenu = Console.ReadLine();

    switch(sceltaMenu)
    {
        case "1":
            AggiungiProgrammaEvento();
            TerminaProgramma();
            break;

        case "2":
            runProgram = false;
            break;

        default:
            Console.WriteLine("Scelta errata!");
            TerminaProgramma();
            break;
    }
}

void TerminaProgramma()
{
    bool endProgram = true;

    while (endProgram)
    {
        Console.WriteLine("Vuoi terminare il programma?");
        Console.WriteLine("[1]: Sì.");
        Console.WriteLine("[2]: No.");

        string sceltaTerminaProgramma = Console.ReadLine();

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

void AggiungiProgrammaEvento()
{
    Console.WriteLine("Quale Programma Evento vuoi aggiungere?");

    Console.Write("Inserisci titolo: ");
    string titoloProgrammaEvento = Console.ReadLine();

    ProgrammaEventi nuovoProgrammaEvento;
    try
    {
        nuovoProgrammaEvento = new ProgrammaEventi(titoloProgrammaEvento);
        Console.WriteLine("Programma Evento creato correttamente!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("Qualcosa è andato storto!");
    }

    int numeroEventiDaAggiungere = 0;

    bool numberOfEventsRequest = true;
    while(numberOfEventsRequest)
    {
        Console.WriteLine("Quanti Eventi vuoi creare e aggiungere al programma?");
        Console.Write("Inserisci numero: ");

        try
        {
            numeroEventiDaAggiungere = Convert.ToInt32(Console.ReadLine());
            numberOfEventsRequest = false;
        }
        catch (Exception ex)
        {
            Console.WriteLine("Non è possibile inserire il numero in lettere!");
        }
    }

    



    //====================================================================

    Console.WriteLine("Quale Evento vuoi aggiungere?");

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
    }
    catch(Exception ex)
    {
        Console.WriteLine("Qualcosa è andato storto!");
    }

    bool reservationRequest = true;
    while(reservationRequest)
    {
        Console.WriteLine("Vuoi prenotare dei posti per questo evento?");
        Console.WriteLine("[1]: Sì.");
        Console.WriteLine("[2]: No.");

        string sceltaUtente = Console.ReadLine();

        switch(sceltaUtente)
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
                catch(Exception ex)
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

    bool reservationCancellationRequest = true;
    while(reservationCancellationRequest)
    {
        Console.WriteLine("Vuoi disdire delle prenotazioni?");
        Console.WriteLine("[1]: Sì.");
        Console.WriteLine("[2]: No.");

        string userCancellationRequestChoice = Console.ReadLine();

        switch(userCancellationRequestChoice)
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
                catch(Exception ex)
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