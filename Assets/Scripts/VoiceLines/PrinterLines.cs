using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrinterLines : MonoBehaviour
{
    public static List<string> textName = new List<string> {
        "Oskar [DEA]",
        "Rafal [DEA]",
        "Tomek [DEA]",
    };

    public static List<string> textInit = new List<string> {
        "Napraw drukarke!",
        "Cos nie ten tego z drukarka...",
        "Wymien toner albo odetkaj to cos",
    };
    
    public static List<string> textLost = new List<string> {
        "Czyli jednak nie mozna na ciebie liczyc",
        "Jednak ci sie nie chce tak?",
        "Nastepnym razem sprawie by ci sie zachcialo",
        
    };
    
    public static List<string> textWon = new List<string> {
        "Po prostu przywaliles tak?",
        "To ten dzieki czy cos",
        "Wynagrodzony ten, ktory dal rade!!!",
    };

    public static List<string> textDescription = new List<string> {
        "Podejdz do drukarki i zobacz co da sie zrobic",
        "Podejdz do drukarki i zobacz co da sie zrobic",
        "Podejdz do drukarki i zobacz co da sie zrobic",
    };
}
