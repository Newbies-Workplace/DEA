using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CoffeeLines
{
    public static List<string> textName = new List<string> {
        "Denis [NASA]",
        "Wiktor [DRIVE]",
        "Mateusz [UFO]",
        "Kamil [BB]",
        "Oskar [DEA]",
    };

    public static List<string> textInit = new List<string> {
        "Dobra praktykancie. Jedna srednia, Migiem do mojego pokoju.",
        "kapuczina z dodatkowym mlekiem z trzema lyzkami cukru sama się nie zrobi...",
        "Jak kawa to czarna jak noc i gorzka jak zycie. Chyba wiesz co z tą informacja zrobic.",
        "Syszalem, ze robisz dobre cappuccino... Chetnie sprobuje.",
        "Chce Depresso. Ten kod juz zniecheca do zycia",
    };
    
    public static List<string> textLost = new List<string> {
        "Where kawa???",
        "No to cyk, Ocenka leci w dol ;)",
        "Daj to synek, pokaze Ci jak to zrobic...",
        "Zaraz zasne... ",
        "Ale ale? ale... kawa?",
    };
    
    public static List<string> textWon = new List<string> {
        "Dzk",
        "Nawet nie najgorsza, doceniam!",
        "Ahhh, pyszna kawka chlup chlup...",
        "Dobra kawa! Plotki okazaly sie prawdziwe.",
        "Mmmm Depresso... c:",
    };

    public static List<string> textDescription = new List<string> {
        "Zrob Latte z mlekiem i dodaj 2 lyzeczki cukru",
        "Zrob Kapuczine z mlekiem i dodaj 3 lyzeczki cukru",
        "Zrob Czarna bez mleka i nie dodawaj cukru",
        "Zrob Kapuczine bez mleka i dodaj 1 lyzeczke cukru",
        "Zrob Depresso bez mleka i nie dodawaj cukru",
    };


    public static List<bool> taskMilk = new List<bool> {
        true,
        true,
        false,
        false,
        false,

    };

    public static List<int> taskSugar = new List<int> {
        2,
        3,
        0,
        1,
        0,

    };
    // 0 none, 1 depresso, 2 latte, 3 kapuczina, 4 black
    public static List<int> taskType = new List<int> {
        2,
        3,
        4,
        3,
        1,

    };
}