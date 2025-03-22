namespace MineSweeper;

 class Minesweeper
 {



     static void Main(string[] args) {
        int[,] mines = GenerateMines(3, 10, 10);
        Movement(3, 10, 10, mines);

      //Menu();
     }


     static void Menu() {
         Console.ForegroundColor = ConsoleColor.DarkYellow;
         Console.WriteLine("███╗   ███╗██╗███╗   ██╗███████╗███████╗██╗    ██╗███████╗███████╗██████╗ ███████╗██████╗");
         Console.WriteLine("████╗ ████║██║████╗  ██║██╔════╝██╔════╝██║    ██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗");
         Console.WriteLine("██╔████╔██║██║██╔██╗ ██║█████╗  ███████╗██║ █╗ ██║█████╗  █████╗  ██████╔╝█████╗  ██████╔╝");
         Console.WriteLine("██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ╚════██║██║███╗██║██╔══╝  ██╔══╝  ██╔═══╝ ██╔══╝  ██╔══██╗");
         Console.WriteLine("██║ ╚═╝ ██║██║██║ ╚████║███████╗███████║╚███╔███╔╝███████╗███████╗██║     ███████╗██║  ██║");
         Console.WriteLine("╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝ ╚══╝╚══╝ ╚══════╝╚══════╝╚═╝     ╚══════╝╚═╝  ╚═╝");
         Console.ResetColor();
       
         Console.WriteLine();
         Console.WriteLine();
         Console.WriteLine();

         Console.ForegroundColor = ConsoleColor.Red;
         Console.WriteLine("Začať hru");
         Console.ResetColor();
         Console.WriteLine("Ako hrať");
         Console.WriteLine("Koniec");
         
         int aktualMenu = 1;
         int aktualSpot = 0;
         int maxPozicia = 0;

         String[] menu1 = { "Začať hru.", "Ako hrať?", "Koniec" };
         

         while (true) {
             if (aktualMenu == 1) {
                 maxPozicia = 2;
             } 
             
             ConsoleKeyInfo keyInfo = Console.ReadKey(true);
             switch (keyInfo.Key) {
                 case ConsoleKey.UpArrow:
                     
                     if (aktualSpot == 0) {
                         continue;
                     } else {
                         aktualSpot--;
                     }
                     
                     break;
                 
                 case ConsoleKey.DownArrow:

                     if (aktualSpot == maxPozicia ) {
                         continue;
                     } else {
                       aktualSpot++;  
                     }
                     
                     break;
                 
                 case ConsoleKey.Enter:

                     if (aktualMenu == 1 && aktualSpot == 2) {
                         Environment.Exit(0);
                     }
                     
                     break;
             }
             
             Console.Clear();
             Console.ForegroundColor = ConsoleColor.DarkYellow;
             Console.WriteLine("███╗   ███╗██╗███╗   ██╗███████╗███████╗██╗    ██╗███████╗███████╗██████╗ ███████╗██████╗");
             Console.WriteLine("████╗ ████║██║████╗  ██║██╔════╝██╔════╝██║    ██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗");
             Console.WriteLine("██╔████╔██║██║██╔██╗ ██║█████╗  ███████╗██║ █╗ ██║█████╗  █████╗  ██████╔╝█████╗  ██████╔╝");
             Console.WriteLine("██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ╚════██║██║███╗██║██╔══╝  ██╔══╝  ██╔═══╝ ██╔══╝  ██╔══██╗");
             Console.WriteLine("██║ ╚═╝ ██║██║██║ ╚████║███████╗███████║╚███╔███╔╝███████╗███████╗██║     ███████╗██║  ██║");
             Console.WriteLine("╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝ ╚══╝╚══╝ ╚══════╝╚══════╝╚═╝     ╚══════╝╚═╝  ╚═╝");
             Console.ResetColor();
       
             Console.WriteLine();
             Console.WriteLine();
             Console.WriteLine();

             if (aktualMenu == 1) {

                 for (int i = 0; i < menu1.Length; i++) {
                     if (aktualSpot == i) {
                         Console.ForegroundColor = ConsoleColor.Red;
                     }
                     Console.WriteLine(menu1[i]);
                     Console.ResetColor();
                 }

             }
             
         }
     }
     
     
     static int[,] GenerateMines(int pocetMin, int riadkyPola, int stlpcePola) {
         Random random = new Random();

         int[,] minyCisla = new int[riadkyPola, stlpcePola]; //Vytvorenie pola

         for (int i = 0; i < riadkyPola; i++) { //Vyplnenie pola 0mi
             for (int j = 0; j < stlpcePola; j++) {
                 minyCisla[i, j] = 0;
             }
         }

         int randomRiadok;
         int randomStlpec;

         for (int i = 1; i <= pocetMin; i++) {
             randomRiadok = random.Next(riadkyPola);
             randomStlpec = random.Next(stlpcePola);

             if (minyCisla[randomRiadok, randomStlpec] != 9) {
                 minyCisla[randomRiadok, randomStlpec] = 9;

                 if (0 <= (randomRiadok - 1) && 0 <= (randomStlpec - 1) && minyCisla[randomRiadok - 1, randomStlpec - 1] != 9) {
                     minyCisla[randomRiadok - 1, randomStlpec - 1]++;
                 }
                 if (0 <= (randomRiadok - 1) && minyCisla[randomRiadok - 1, randomStlpec] != 9) {
                     minyCisla[randomRiadok - 1, randomStlpec]++;
                 }
                 if (0 <= (randomRiadok - 1) && (randomStlpec + 1) < stlpcePola && minyCisla[randomRiadok - 1, randomStlpec + 1] != 9) {
                     minyCisla[randomRiadok - 1, randomStlpec + 1]++;
                 }
                 
                 if (0 <= (randomStlpec - 1) && minyCisla[randomRiadok, randomStlpec - 1] != 9) {
                     minyCisla[randomRiadok, randomStlpec - 1]++;
                 }
                 if ((randomStlpec + 1) < stlpcePola && minyCisla[randomRiadok, randomStlpec + 1] != 9) {
                     minyCisla[randomRiadok, randomStlpec + 1]++;
                 }
                 
                 if ((randomRiadok + 1) < riadkyPola && 0 <= (randomStlpec - 1) && minyCisla[randomRiadok + 1, randomStlpec - 1] != 9) {
                     minyCisla[randomRiadok + 1, randomStlpec - 1]++;
                 }
                 if ((randomRiadok + 1) < riadkyPola && minyCisla[randomRiadok + 1, randomStlpec] != 9) {
                     minyCisla[randomRiadok + 1, randomStlpec]++;
                 }

                 if ((randomRiadok + 1) < riadkyPola && (randomStlpec + 1) < stlpcePola && minyCisla[randomRiadok + 1, randomStlpec] != 9) {
                     minyCisla[randomRiadok + 1, randomStlpec + 1]++;
                 }

             }
         }

     for (int i = 0; i < riadkyPola; i++) {
             for (int j = 0; j < stlpcePola; j++) {
                 Console.Write(minyCisla[i, j] + " ");
             }
             
             Console.WriteLine();
         }


         return minyCisla;
     }

     


     static void Movement(int pocetMin, int riadkyPola, int stlpcePola, int[,] mines) {

         String[,] miny = new String[riadkyPola, stlpcePola]; // Pole ktoré sa zobrazuje počas hry, hráč sa v ňom pohybuje

         for (int i = 0; i < riadkyPola; i++) { // Vypĺňanie pola s #
             for (int j = 0; j < stlpcePola; j++) {
                 miny[i, j] = "#";
             }
         }
         
         int vlajkyPocet = 0;

         int[] aktualSpot = { 0, 0 }; // Aktuálna pozícia hráča

         for (int i = 0; i < riadkyPola; i++) { // Vypísanie herného pola na začiatku hry
             for (int j = 0; j < stlpcePola; j++) {

                 if (i == aktualSpot[0] && j == aktualSpot[1]) {
                     Console.ForegroundColor = ConsoleColor.Red;
                 } else {
                     Console.ResetColor();
                 }

                 Console.Write(miny[i, j] + " ");
             }

             Console.WriteLine();
         }

         while (true) {
             // Slúži na kontrolu inputu a interakcie s hrou
             ConsoleKeyInfo keyInfo = Console.ReadKey(true);

             switch (keyInfo.Key) {

                 case ConsoleKey.LeftArrow:
                     if (aktualSpot[1] != 0) { // Overenie či nevychádza z pola
                         aktualSpot[1]--; //Nová pozícia
                     }

                     break;

                 case ConsoleKey.RightArrow:
                     if (aktualSpot[1] != 9) {
                         aktualSpot[1]++;
                     }

                     break;

                 case ConsoleKey.UpArrow:
                     if (aktualSpot[0] != 0) {
                         aktualSpot[0]--;
                     }

                     break;

                 case ConsoleKey.DownArrow:
                     if (aktualSpot[0] != 9) {
                         aktualSpot[0]++;
                     }

                     break;
                 case ConsoleKey.P: // Placement vlajky
                     
                     if (miny[aktualSpot[0], aktualSpot[1]] == "P") { // Kontrola či miesto obsahuje vlajku (odstranienie vlajky) TODO: Pridať že k ze sa na odhalene polia nebudu dat na min{
                         miny[aktualSpot[0], aktualSpot[1]] = "#";
                         vlajkyPocet--;
                     } else if (miny[aktualSpot[0], aktualSpot[1]] != "P" && vlajkyPocet < pocetMin) { // Kontrola či miesto neobsahuje vlajku a či sa už nedosiahol maximalny počet vlajok (pre pridanie vlajky)
                         miny[aktualSpot[0], aktualSpot[1]] = "P";
                         vlajkyPocet++;
                     }

                     break;
                 case ConsoleKey.Enter:

                     if (miny[aktualSpot[0], aktualSpot[1]] == "#") { //Kontroluje či pole je skryté

                         if (mines[aktualSpot[0], aktualSpot[1]] == 9) { // TODO: Odhalia sa všetky míni a hráč môže niečo stlačiť pre koniec neskorej navrat do menu

                             for (int i = 0; i < riadkyPola; i++) { // Prejde celou dráhou a nájde míny a odhalí ich
                                 for (int j = 0; j < stlpcePola; j++) {
                                     if (mines[i, j] == 9) {
                                         miny[i, j] = mines[i, j].ToString();
                                     }
                                 }
                             }

                             Console.Clear();
                             for (int i = 0; i < riadkyPola; i++) {
                                 for (int j = 0; j < stlpcePola; j++) {

                                     if (mines[i, j] == 9) {
                                         Console.ForegroundColor = ConsoleColor.Red;
                                     } else {
                                         Console.ResetColor();
                                     }

                                     Console.Write(miny[i, j] + " ");
                                 }

                                 Console.WriteLine();
                             }

                             Console.ResetColor();
                             Console.WriteLine(
                                 "\nBOOM! Narazil si na mínu! Stlač čokolvek pre návrat do menu..."); // TODO: Upraviť text
                             Console.ReadKey();
                             // TODO: Pridať návrat do menu
                             return;

                         } else if (mines[aktualSpot[0], aktualSpot[1]] != 0) { // Keď v okoli pola je mina
                             
                             miny[aktualSpot[0], aktualSpot[1]] = mines[aktualSpot[0], aktualSpot[1]].ToString();
                             
                         } else if (mines[aktualSpot[0], aktualSpot[1]] == 0) { // Keď je pole úplne prazdne
                             
                             
                             miny[aktualSpot[0], aktualSpot[1]] = mines[aktualSpot[0], aktualSpot[1]].ToString();
                             miny = OdhalitOkolie(aktualSpot[0], aktualSpot[1], miny, mines, riadkyPola, stlpcePola);

                           
                             
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                             OdhaleniePrazdnych(riadkyPola, stlpcePola, miny, mines);
                         }

                         
                     }

                    

                     break;
                 case ConsoleKey.C:
                     
                     if (vlajkyPocet == pocetMin ) {

                     for (int i = 0; i < riadkyPola; i++) {
                         for (int j = 0; j < stlpcePola; j++)
                         {

                             if (mines[i, j] == 9) {

                                 if (miny[i, j] == "P") {
                                     continue;
                                 } else {
                                     for (int k = 0; k < riadkyPola; k++) {
                                         // Prejde celou dráhou a nájde míny a odhalí ich
                                         for (int l = 0; l < stlpcePola; l++) {
                                             if (mines[k, l] == 9) {
                                                 miny[k, l] = mines[k, l].ToString();
                                             }
                                         }
                                     }

                                     Console.Clear();
                                     for (int k = 0; k < riadkyPola; k++) {
                                         for (int l = 0; l < stlpcePola; l++) {
                                             
                                             if (mines[k, l] == 9) {
                                                 Console.ForegroundColor = ConsoleColor.Red;
                                             } else {
                                                 Console.ResetColor();
                                             }
                                             Console.Write(miny[k, l] + " ");
                                         }
                                         Console.WriteLine();
                                     }

                                     Console.ResetColor();
                                     Console.WriteLine("Prehral si"); // TODO: Upraviť text
                                     Console.ReadKey();
                                     // TODO: Pridať návrat do menu
                                     return;
                                 }

                             }
                             else
                             {
                                 continue;
                             }
                         }
                     }
                     
                     Console.Clear();
                     Console.WriteLine("Vyhral si"); // TODO: Upraviť text
                     Console.ReadKey();
                     // TODO: Pridať návrat do menu
                     return;
                     
                     }

                     break;
             }

             Console.Clear();
             VypisPole(riadkyPola, stlpcePola, aktualSpot, miny);

         }
     }

     

     static void VypisPole(int riadkyPola, int stlpcePola, int[] aktualSpot, String[,] miny) { // TODO : DOPLNIT VSADE
         
        
         for (int i = 0; i < riadkyPola; i++) {

                 for (int j = 0; j < stlpcePola; j++) {

                     if (i == aktualSpot[0] && j == aktualSpot[1]) {
                         Console.ForegroundColor = ConsoleColor.Red;
                     } else if (miny[i,j] == "0") {
                         Console.ForegroundColor = ConsoleColor.DarkGray;
                     } else if (miny[i,j] == "1") {
                         Console.ForegroundColor = ConsoleColor.Blue;
                     } else if (miny[i,j] == "2") {
                         Console.ForegroundColor = ConsoleColor.Green;
                     } else if (miny[i,j] == "3") {
                         Console.ForegroundColor = ConsoleColor.Magenta;
                     } else if (miny[i,j] == "4") {
                         Console.ForegroundColor = ConsoleColor.DarkBlue;
                     } else if (miny[i,j] == "5") {
                         Console.ForegroundColor = ConsoleColor.DarkYellow;
                     } else if (miny[i,j] == "6") {
                         Console.ForegroundColor = ConsoleColor.Cyan;
                     } else if (miny[i,j] == "7") {
                         Console.ForegroundColor = ConsoleColor.DarkMagenta;
                     } else if (miny[i,j] == "8") {
                         Console.ForegroundColor = ConsoleColor.Yellow;
                     } else {
                         Console.ResetColor();
                     }

                     Console.Write(miny[i, j] + " ");
                 }

                 Console.WriteLine();
         }
     }
     

     static string[,] OdhalitOkolie(int aktualRiadok, int aktualStlpec, String[,] miny, int[,]mines, int riadkyPola, int stlpcePola) { //Funkcia na odhalenie okolia zadaneho miesta
         if (0 <= aktualRiadok - 1 && 0 <= aktualStlpec - 1) {
             miny[aktualRiadok - 1, aktualStlpec - 1] = mines[aktualRiadok - 1, aktualStlpec - 1].ToString();
         }

         if (0 <= aktualRiadok - 1) {
             miny[aktualRiadok - 1, aktualStlpec] = mines[aktualRiadok - 1, aktualStlpec].ToString();
         }

         if (0 <= aktualRiadok - 1 && aktualStlpec + 1 < stlpcePola) { 
             miny[aktualRiadok - 1, aktualStlpec + 1] = mines[aktualRiadok - 1, aktualStlpec + 1].ToString();
         }

         if (0 <= aktualStlpec - 1) {
             miny[aktualRiadok, aktualStlpec - 1] = mines[aktualRiadok, aktualStlpec - 1].ToString();
         }

         if (aktualStlpec + 1 < stlpcePola){ 
             miny[aktualRiadok, aktualStlpec + 1] = mines[aktualRiadok, aktualStlpec + 1].ToString();
         }

         if (aktualRiadok + 1 < riadkyPola && 0 <= aktualStlpec - 1) { 
             miny[aktualRiadok + 1, aktualStlpec - 1] = mines[aktualRiadok + 1, aktualStlpec - 1].ToString();
         }

         if (aktualRiadok + 1 < riadkyPola) { 
             miny[aktualRiadok + 1, aktualStlpec] = mines[aktualRiadok + 1, aktualStlpec].ToString();
         }

         if (aktualRiadok + 1 < riadkyPola && aktualStlpec + 1 < stlpcePola) { 
             miny[aktualRiadok + 1, aktualStlpec + 1] = mines[aktualRiadok + 1, aktualStlpec + 1].ToString();
         }

         return miny;
     }

      static void OdhaleniePrazdnych(int riadkyPola, int stlpcePola, String[,] miny, int[,] mines) {
        for (int i = 0; i < riadkyPola; i++) {
            for (int j = 0; j < stlpcePola; j++) {

                if (miny[i, j] == "0") {
                    if (0 <= i - 1 && 0 <= j - 1) {
                        if (miny[i - 1, j - 1] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }

                    if (0 <= i - 1) {
                        if (miny[i - 1, j] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }

                    if (0 <= i - 1 && j + 1 < stlpcePola) {
                        if (miny[i - 1, j + 1] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }

                    if (0 <= j - 1) {
                        if (miny[i, j - 1] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }

                    if (j + 1 < stlpcePola){
                        if (miny[i, j + 1] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }

                    if (i + 1 < riadkyPola && 0 <= j - 1) {
                        if (miny[i + 1, j - 1] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }

                    if (i + 1 < riadkyPola) {
                        if (miny[i + 1, j] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }

                    if (i + 1 < riadkyPola && j + 1 < stlpcePola) {
                        if (miny[i + 1, j + 1] == "#") {
                            OdhalitOkolie(i, j, miny, mines, riadkyPola, stlpcePola);
                        }
                    }
                                         
                                         
                }
                                      
                                     
            }
        }
    }
 }