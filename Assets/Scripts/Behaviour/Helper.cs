using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Behaviour
{
    public class Helper
    {
        // 0 isimler
        // 1 aylar
        // 2 mevsimler
        // 3 hayvan - 
        // 4 meyve
        // 5 eşya
        // 6 şehir
        private static List<string> categoryWord = new()
        {
            "isim", "yılın ayları", "mevsim", "hayvan", "meyve", "eşya", "şehir"
        };

        private static List<string>[] wordList = new[]
        {
            new List<string>
            {
                "Fatih", "Zeynep", "Selim", "Merve", "Onur",
                "Esra", "Burak", "Elif", "Kaan", "İrem",
                "Umut", "Pınar", "Barış", "Gamze", "Emre",
                "Derya", "Can", "Yasemin", "Hakan", "Gizem",
                "Arif", "Deniz", "Serkan", "Aslı", "Cihan",
                "Pelin", "Murat", "Elvan", "Taylan", "İlayda",
                "Kaya", "Ece", "Bilge", "Tuncay", "Melis",
                "Alp", "Nihan", "Doruk", "Zara", "Uğur",
                "Seda", "Emir", "İlke", "Cemal", "Ebru",
                "Özgür", "Simge", "Alara", "Kağan", "Gülşen"
            },
            new List<string>
            {
                "Ocak", "Şubat", "Mart", "Nisan", "Mayıs",
                "Haziran", "Temmuz", "Ağustos", "Eylül",
                "Ekim", "Kasım", "Aralık"
            },
            new List<string>()
            {
                "Kış",
                "Yaz",
                "İlkbahar",
                "Sonbahar"
            },
            new List<string>
            {
                "Köpek", "Kuş", "Kedi", "Balık", "Koyun", "At", "Maymun", "Fil", "Aslan",
                "Zebra", "Kanguru", "Yılan", "Ördek", "Kurbağa", "Tavuk", "Papağan", "Gergedan",
                "Kaplan", "Geyik", "Timsah", "Zürafa", "Arı", "Fok", "Penguen",
                "Baykuş", "Leylek", "Yarasa", "Karınca", "Kangal", "Civciv", "Tavşan", "Güvercin",
                "Balina", "Lama", "Çita", "Keçi", "Goril", "Serçe", "Panda",
                "Fare", "Kartal", "Flamingo", "Hindi", "İguana", "Bukalemun", "Somon", "TonBalığı",
                "Ahtapot", "Istakoz", "Kelebek", "Örümcek", "Sinek", "Akrep", "Kirpi", "Vaşak", "Armadillo",
                "Lemur", "Yaras", "Tukan", "Pelikan", "Devekuşu", "Gecko", "Piranha", "Tetra", "Betta",
            },
            new List<string>()
            {
                "Elma", "Armut", "Muz", "Üzüm", "Çilek", "Kiraz", "Karpuz",
                "Portakal", "Limon", "Şeftali", "Nar", "Ayva", "İncir", "Dut", "Erik", "Kavun",
                "Ananas", "Mango", "Avokado", "Böğürtlen", "Vişne", "Hurma", "Domates", "Zeytin"
            },
            new List<string>
            {
                "Cüzdan",
                "Saçkurutma",
                "Gözlükkutusu",
                "Telefon",
                "Şarjcihazı",
                "Elkremi",
                "Kalemlik",
                "Parfüm",
                "Defter",
                "Kaşık",
                "Çatal",
                "Bıçak",
                "Şişe",
                "Notdefteri",
                "Gözdamlası",
                "Kulaklık",
                "Makas",
                "Anahtar",
                "Şampuan",
                "Dişmacunu",
                "Güneşkremi",
                "Powerbank",
                "Kibrit",
                "Ayna",
                "Şemsiye",
                "Kolonya",
                "Kitap",
                "Harita",
                "Kamera",
                "Laptop",
                "Mouse",
                "Maske",
                "Eldiven",
                "Çanta",
                "Notkağıdı",
                "Termos",
                "havlu",
                "Tarak",
                "toka",
            },
            new List<string>
            {
                "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın",
                "Balıkesir",
                "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
                "Diyarbakır", "Edirne", "Elâzığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun",
                "Gümüşhane",
                "Hakkâri", "Hatay", "Isparta", "Mersin", "İstanbul", "İzmir", "Kars", "Kastamonu", "Kayseri",
                "Kırklareli",
                "Kırşehir", "Kocaeli", "Konya", "Kütahya", "Malatya", "Manisa", "Maraş", "Mardin", "Muğla", "Muş",
                "Nevşehir",
                "Niğde", "Ordu", "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon",
                "Tunceli", "Şanlıurfa", "Uşak", "Van", "Yozgat", "Zonguldak", "Aksaray", "Bayburt", "Karaman",
                "Kırıkkale",
                "Batman", "Şırnak", "Bartın", "Ardahan", "Iğdır", "Yalova", "Karabük", "Kilis", "Osmaniye", "Düzce"
            }
        };

        private static string DefaultPath = "FailFrames";

        public static Sprite GetFailSprite(int failNumber)
            => Resources.Load<Sprite>($"{DefaultPath}/{failNumber}");

        public static (List<string> category, List<string> randomList) GetRandomWord()
        {
            Random random = new Random();

            List<string> randomList = new List<string>();
            List<string> categoryRandom = new List<string>();


            for (int i = 0; i < 5; i++)
            {
                int randomCategoryIndex = random.Next(0, wordList.Length);
                if (!wordList[randomCategoryIndex].Any())
                {
                    i--;
                    continue;
                }
                int randomWordIndex = random.Next(0, wordList[randomCategoryIndex].Count);
                randomList.Add(wordList[randomCategoryIndex][randomWordIndex]);
                wordList[randomCategoryIndex].RemoveAt(randomWordIndex);
                categoryRandom.Add(categoryWord[randomCategoryIndex]);
            }

            return (categoryRandom, randomList);
        }
    }
}