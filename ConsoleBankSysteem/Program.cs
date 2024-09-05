using System;
using System.Collections.Generic;


public class kaartHouder
{
    string kaartNum;
    int pinNum;
    string voorNaam;
    string achterNaam;
    double balans;

    public kaartHouder(string Kaartnum, int pinNum, string voorNaam, string achterNaam, double balans)
    {
        this.kaartNum = Kaartnum;
        this.pinNum = pinNum;
        this.voorNaam = voorNaam;
        this.achterNaam = achterNaam;
        this.balans = balans;
    }

    public string getNum()
    {
        return kaartNum;
    }

    public int getPinNum()
    {
        return pinNum;
    }

    public string getVoorNaam()
    {
        return voorNaam;
    }

    public string getAchternaam()
    {
        return achterNaam;
    }

    public double getBalans()
    {
        return balans;
    }

    public void setkaart(string newKaartNum)
    {
        kaartNum = newKaartNum;
    }

    public void setPin(int newPinNum)
    {
        pinNum = newPinNum;
    }

    public void setVoorNaam(string newVoorNaam)
    {
        voorNaam = newVoorNaam;
    }

    public void setAchterNaam(string newAchterNaam)
    {
        achterNaam = newAchterNaam;
    }

    public void setBalans(double newBalans)
    {
        balans = newBalans;
    }

    public static void Main(String[] args)
    {
        void printOpties()
        {
            Console.WriteLine("kies astjeblieft een van de opties...");
            Console.WriteLine("1. storten");
            Console.WriteLine("2. opnemen");
            Console.WriteLine("3. balans bekijken");
            Console.WriteLine("4. annuleren");
        }

        void deposit(kaartHouder huidigeGebruiker)
        {
            Console.WriteLine("hoeveel geld zou je willen storten?");
            double stort = Double.Parse(Console.ReadLine());
            huidigeGebruiker.setBalans(huidigeGebruiker.getBalans() + stort);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(huidigeGebruiker.getVoorNaam() + " de storting is gelukt! je nieuwe balans is: " + huidigeGebruiker.getBalans());
            Console.ResetColor();
        }
        
        void opnemen(kaartHouder huidigeGebruiker)
        {
            Console.WriteLine("hoeveel geld zou je willen opnemen?");
            double opneem = Double.Parse(Console.ReadLine());
            if (huidigeGebruiker.getBalans() < opneem)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("te weinig balans!");
                Console.ResetColor();
            }
            else
            {
                huidigeGebruiker.setBalans(huidigeGebruiker.getBalans() - opneem);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("opnemen gelukt! je nieuwe balans is: " + huidigeGebruiker.getBalans());
                Console.ResetColor();
            }
        }

        void balans(kaartHouder huidigeGebruiker)
        {
            Console.WriteLine("je balans is op dit moment: " + huidigeGebruiker.getBalans());
        }

        List<kaartHouder> kaartHouders = new List<kaartHouder>();
        kaartHouders.Add(new kaartHouder("3416789012676", 1234, "Jhon", "griffith", 150.31));
        kaartHouders.Add(new kaartHouder("3416589012676", 1734, "sid", "de laat", 150.31));
        kaartHouders.Add(new kaartHouder("3416784012676", 5234, "lloyd", "van eijndhoven", 150.31));
        kaartHouders.Add(new kaartHouder("3426789012676", 1284, "harris", "csharp", 150.31));

        
        Console.WriteLine("Welkom bij Harris csharp bank!");
        Console.WriteLine("steek je kaart in de machine");
        String debitKaartNum = "";
        kaartHouder huidigeGebruiker;

        while (true)
        {
            try
            {
                debitKaartNum = Console.ReadLine();
                huidigeGebruiker = kaartHouders.FirstOrDefault(a => a.getNum() == debitKaartNum);
                if (huidigeGebruiker != null) { break; }
                else { Console.WriteLine("kan de kaart niet herkennen"); }
               
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("kan de kaart niet herkennen");
                Console.ResetColor();
            }
        }

        Console.WriteLine("Vul astjeblieft je pin in:");
        int userPin = 0;
        while (true)
        {
            try
            {
                userPin = int.Parse(Console.ReadLine());
                if (huidigeGebruiker.getPinNum() == userPin) { break; }
                else {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Incorrecte pin, probeer het opnieuw."); }
                    Console.ResetColor();
            }
            catch
            {
                Console.WriteLine("Incorrecte pin, probeer het opnieuw.");
            }
        }

        Console.WriteLine("Welkom " + huidigeGebruiker.getVoorNaam());
        int option = 0;
        do
        {
            printOpties();
            try
            {
                option = int.Parse(Console.ReadLine());
            }
            catch { }
            if (option == 1) { deposit(huidigeGebruiker); }
            else if (option == 2) { opnemen(huidigeGebruiker); }
            else if (option == 3) { balans(huidigeGebruiker); }
            else if (option == 4) { break; }
            else { option = 0; }
        }
        while (option != 4);

        Console.WriteLine("dankjewel, heb nog een fijne dag");
    }
}
