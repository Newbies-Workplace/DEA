using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThermoLines : MonoBehaviour
{
    public static List<string> textName = new List<string> {
        "Denis [NASA]",
        "Kamil [DRIVE]",
        "Oskar [DEA]",
    };

    public static List<string> textInit = new List<string> {
        "Koksownik sie nam wypalil, we kliknij klime z 25 bedzie git",
        "Brrr, ale tu zimno. Zwieksz temperature na 26",
        "Troche chlodu nikomu nie zaszkodzi",
    };
    
    public static List<string> textLost = new List<string> {
        "-_-",
        "Na podworku jest cieplej niz w tym budynku..",
        "Spoceniec widze z ciebie...",
    };
    
    public static List<string> textWon = new List<string> {
        "Jest git",
        "Dzieki za pomoc, Dalej jest zimno, ale mniej..",
        "Dobry chlodek nie jest zly",
    };

    public static List<string> textDescription = new List<string> {
        "Zmien temperature na 25",
        "Zmien temperature na 26",
        "Zmien temperature na 15",
    };


    public static List<int> taskTemp = new List<int> {
        25,
        26,
        15,
    };

}
