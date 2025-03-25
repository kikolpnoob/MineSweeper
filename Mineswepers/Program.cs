namespace MineSweeper;

 class Minesweeper {
     
     static void Main(string[] args) {
         Menu();
     }


     static void Menu() {
         Console.Clear();
         Console.ForegroundColor = ConsoleColor.Yellow;
         Console.WriteLine("███╗   ███╗██╗███╗   ██╗███████╗███████╗██╗    ██╗███████╗███████╗██████╗ ███████╗██████╗");
         Console.WriteLine("████╗ ████║██║████╗  ██║██╔════╝██╔════╝██║    ██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗");
         Console.WriteLine("██╔████╔██║██║██╔██╗ ██║█████╗  ███████╗██║ █╗ ██║█████╗  █████╗  ██████╔╝█████╗  ██████╔╝");
         Console.ForegroundColor = ConsoleColor.DarkYellow;
         Console.WriteLine("██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ╚════██║██║███╗██║██╔══╝  ██╔══╝  ██╔═══╝ ██╔══╝  ██╔══██╗");
         Console.WriteLine("██║ ╚═╝ ██║██║██║ ╚████║███████╗███████║╚███╔███╔╝███████╗███████╗██║     ███████╗██║  ██║");
         Console.WriteLine("╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝ ╚══╝╚══╝ ╚══════╝╚══════╝╚═╝     ╚══════╝╚═╝  ╚═╝");
         Console.ResetColor();
       
         Console.WriteLine();
         


         Console.WriteLine("                                    ╔════════════════╗");
         Console.Write("                                    ║    » ");
         Console.ForegroundColor = ConsoleColor.Red;
         Console.Write("Hrať");
         Console.ResetColor();
         Console.WriteLine(" «    ║");
         Console.WriteLine("                                    ║     Koniec     ║");
         Console.WriteLine("                                    ╚════════════════╝");
         
         int aktualMenu = 1;
         int aktualSpot = 0;
         int maxPozicia = 0;
         
         String[] menu1 = {"                                    ║      Hrať      ║", "                                    ║     Koniec     ║"};
         String[] menu2 = {"                                 ║       Amatér       ║", "                                 ║       Znalec       ║", "                                 ║       Expert       ║", "                                 ║       Custom       ║", "                                 ║        Späť        ║" };

         int customRiadky = 0;
         int customStlpce = 0;
         int customMiny = 0;

         while (true) {
             if (aktualMenu == 1) {
                 maxPozicia = 2;
             } else if (aktualMenu == 2) {
                 maxPozicia = 4;
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

                     if (aktualMenu == 1 && aktualSpot == 0) { //Možnosť Začať hru
                         aktualMenu = 2;
                     } else if (aktualMenu == 1 && aktualSpot == 2) { // Možnosť Koniec
                         Environment.Exit(0);
                     } else if (aktualMenu == 2 && aktualSpot == 0) { // Možnosť Začiatočník
                         Console.Clear();
                         int[,] mines = GenerateMines(10, 9, 9);
                         Movement(10, 9, 9, mines);
                     } else if (aktualMenu == 2 && aktualSpot == 1) { // Možnosť Pokročilý
                         Console.Clear();
                         int[,] mines = GenerateMines(40, 16, 16);
                         Movement(40, 16, 16, mines);
                     } else if (aktualMenu == 2 && aktualSpot == 2) { //Možnosť Expert
                         Console.Clear();
                         int[,] mines = GenerateMines(99, 16, 30);
                         Movement(99, 16, 30, mines);
                     } else if (aktualMenu == 2 && aktualSpot == 3) { // Možnosť Custom       TODO : Dorobiť overenia 
                         Console.Clear();
                         Console.ForegroundColor = ConsoleColor.Yellow;
                         Console.WriteLine("███╗   ███╗██╗███╗   ██╗███████╗███████╗██╗    ██╗███████╗███████╗██████╗ ███████╗██████╗");
                         Console.WriteLine("████╗ ████║██║████╗  ██║██╔════╝██╔════╝██║    ██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗");
                         Console.WriteLine("██╔████╔██║██║██╔██╗ ██║█████╗  ███████╗██║ █╗ ██║█████╗  █████╗  ██████╔╝█████╗  ██████╔╝");
                         Console.ForegroundColor = ConsoleColor.DarkYellow;
                         Console.WriteLine("██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ╚════██║██║███╗██║██╔══╝  ██╔══╝  ██╔═══╝ ██╔══╝  ██╔══██╗");
                         Console.WriteLine("██║ ╚═╝ ██║██║██║ ╚████║███████╗███████║╚███╔███╔╝███████╗███████╗██║     ███████╗██║  ██║");
                         Console.WriteLine("╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝ ╚══╝╚══╝ ╚══════╝╚══════╝╚═╝     ╚══════╝╚═╝  ╚═╝");
                         Console.ResetColor();
       
                         Console.WriteLine();

                         Console.WriteLine("                               ╔══════════════════════════╗");
                         Console.WriteLine("                               ║ Koľko chceš mať riadkov? ║"); 
                         Console.WriteLine("                               ╚══════════════════════════╝");
                         customRiadky = Convert.ToInt32(Console.ReadLine());
                         Console.WriteLine("                               ╔══════════════════════════╗");
                         Console.WriteLine("                               ║ Koľko chceš mať stĺpcov? ║");
                         Console.WriteLine("                               ╚══════════════════════════╝");
                         customStlpce = Convert.ToInt32(Console.ReadLine());
                         Console.WriteLine("                                 ╔══════════════════════╗");
                         Console.WriteLine("                                 ║ Koľko chceš mať mín? ║");
                         Console.WriteLine("                                 ╚══════════════════════╝");
                         customMiny = Convert.ToInt32(Console.ReadLine());
                         
                         int[,] mines = GenerateMines(customMiny, customRiadky, customStlpce);
                         Movement(customMiny, customRiadky, customStlpce, mines);
                     } else if (aktualMenu == 2 && aktualSpot == 4) { // Možnosť Späť
                         aktualMenu = 1;
                         aktualSpot = 0;
                     }
                     
                     break;
             }
             
             Console.Clear();
             Console.ForegroundColor = ConsoleColor.Yellow;
             Console.WriteLine("███╗   ███╗██╗███╗   ██╗███████╗███████╗██╗    ██╗███████╗███████╗██████╗ ███████╗██████╗");
             Console.WriteLine("████╗ ████║██║████╗  ██║██╔════╝██╔════╝██║    ██║██╔════╝██╔════╝██╔══██╗██╔════╝██╔══██╗");
             Console.WriteLine("██╔████╔██║██║██╔██╗ ██║█████╗  ███████╗██║ █╗ ██║█████╗  █████╗  ██████╔╝█████╗  ██████╔╝");
             Console.ForegroundColor = ConsoleColor.DarkYellow;
             Console.WriteLine("██║╚██╔╝██║██║██║╚██╗██║██╔══╝  ╚════██║██║███╗██║██╔══╝  ██╔══╝  ██╔═══╝ ██╔══╝  ██╔══██╗");
             Console.WriteLine("██║ ╚═╝ ██║██║██║ ╚████║███████╗███████║╚███╔███╔╝███████╗███████╗██║     ███████╗██║  ██║");
             Console.WriteLine("╚═╝     ╚═╝╚═╝╚═╝  ╚═══╝╚══════╝╚══════╝ ╚══╝╚══╝ ╚══════╝╚══════╝╚═╝     ╚══════╝╚═╝  ╚═╝");
             Console.ResetColor();
       
             Console.WriteLine();

             if (aktualMenu == 1) {
                 Console.WriteLine("                                    ╔════════════════╗");
                 for (int i = 0; i < menu1.Length; i++) {
                     
                     if (aktualSpot == i) {
                         if (i == 0) {
                             Console.Write("                                    ║    » ");
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.Write("Hrať");
                             Console.ResetColor();
                             Console.WriteLine(" «    ║");
                         } else if (i == 1) {
                             Console.Write("                                    ║   » ");
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.Write("Koniec");
                             Console.ResetColor();
                             Console.WriteLine(" «   ║");
                         }
                         
                     } else {
                         Console.WriteLine(menu1[i]);
                     }
                     
                    
                     
                 }
                 Console.WriteLine("                                    ╚════════════════╝");
                 
             } else if (aktualMenu == 2) {
                 Console.WriteLine("                                 ╔════════════════════╗");
                for (int i = 0; i < menu2.Length; i++) {
                     if (aktualSpot == i) {
                         if (i == 0) {
                             Console.Write("                                 ║     » ");
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.Write("Amatér");
                             Console.ResetColor();
                             Console.WriteLine(" «     ║");
                         } else if (i == 1) {
                             Console.Write("                                 ║     » ");
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.Write("Znalec");
                             Console.ResetColor();
                             Console.WriteLine(" «     ║");
                         } else if (i == 2) {
                             Console.Write("                                 ║     » ");
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.Write("Expert");
                             Console.ResetColor();
                             Console.WriteLine(" «     ║");  
                         } else if (i == 3) {
                             Console.Write("                                 ║     » ");
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.Write("Custom");
                             Console.ResetColor();
                             Console.WriteLine(" «     ║");  
                         } else if (i == 4) {
                             Console.Write("                                 ║      » ");
                             Console.ForegroundColor = ConsoleColor.Red;
                             Console.Write("Späť");
                             Console.ResetColor();
                             Console.WriteLine(" «      ║");  
                         }
                     } else {
                         Console.WriteLine(menu2[i]);
                     }
                     
                }
                Console.WriteLine("                                 ╚════════════════════╝");

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

                 if (0 <= (randomRiadok - 1) && 0 <= (randomStlpec - 1) && minyCisla[randomRiadok - 1, randomStlpec - 1] < 8) {
                     if (minyCisla[randomRiadok - 1, randomStlpec - 1] + 1 <= 8) {
                         minyCisla[randomRiadok - 1, randomStlpec - 1]++;
                     }
                 }
                 
                 if (0 <= (randomRiadok - 1)) {
                     if (minyCisla[randomRiadok - 1, randomStlpec] + 1 <= 8) {
                         minyCisla[randomRiadok - 1, randomStlpec]++;
                     }
                 }
                 
                 if (0 <= (randomRiadok - 1) && (randomStlpec + 1) < stlpcePola){
                     if (minyCisla[randomRiadok - 1, randomStlpec + 1] + 1 <= 8) {
                         minyCisla[randomRiadok - 1, randomStlpec + 1]++;
                     }
                 }
                 
                 if (0 <= (randomStlpec - 1)) {
                     if (minyCisla[randomRiadok, randomStlpec - 1] + 1 <= 8) {
                         minyCisla[randomRiadok, randomStlpec - 1]++;
                     }
                 }
                 if ((randomStlpec + 1) < stlpcePola) {
                     if (minyCisla[randomRiadok, randomStlpec + 1] + 1 <= 8) {
                         minyCisla[randomRiadok, randomStlpec + 1]++;
                     }
                 }
                 
                 if ((randomRiadok + 1) < riadkyPola && 0 <= (randomStlpec - 1)) {
                     if (minyCisla[randomRiadok + 1, randomStlpec - 1] + 1 <= 8) {
                         minyCisla[randomRiadok + 1, randomStlpec - 1]++;
                     }
                 }
                 
                 if ((randomRiadok + 1) < riadkyPola ) {
                     if (minyCisla[randomRiadok + 1, randomStlpec] + 1 <= 8) {
                         minyCisla[randomRiadok + 1, randomStlpec]++;
                     }
                 }

                 if ((randomRiadok + 1) < riadkyPola && (randomStlpec + 1) < stlpcePola) {
                     if (minyCisla[randomRiadok + 1, randomStlpec + 1] + 1 <= 8) {
                         minyCisla[randomRiadok + 1, randomStlpec + 1]++;
                     }
                 }

             }
             
         }

         return minyCisla;
     }

     


     static void Movement(int pocetMin, int riadkyPola, int stlpcePola, int[,] mines) { // Funkcia s hlavnými akciami hry číta klávesy a vykonáva k nim pridelené akcie

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
                     if (aktualSpot[1] != stlpcePola - 1) {
                         aktualSpot[1]++;
                     }

                     break;

                 case ConsoleKey.UpArrow:
                     if (aktualSpot[0] != 0) {
                         aktualSpot[0]--;
                     }

                     break;

                 case ConsoleKey.DownArrow:
                     if (aktualSpot[0] != riadkyPola - 1) {
                         aktualSpot[0]++;
                     }

                     break;
                 case ConsoleKey.P: // Placement vlajky
                     
                     if (miny[aktualSpot[0], aktualSpot[1]] == "P") { // Kontrola či miesto obsahuje vlajku (odstranienie vlajky)
                         miny[aktualSpot[0], aktualSpot[1]] = "#";
                         vlajkyPocet--;
                     } else if (miny[aktualSpot[0], aktualSpot[1]] == "#" && vlajkyPocet < pocetMin) { // Kontrola či miesto neobsahuje vlajku a či sa už nedosiahol maximalny počet vlajok (pre pridanie vlajky)
                         miny[aktualSpot[0], aktualSpot[1]] = "P";
                         vlajkyPocet++;
                     }

                     break;
                 case ConsoleKey.Enter:

                     if (miny[aktualSpot[0], aktualSpot[1]] == "#") { //Kontroluje či pole je skryté

                         if (mines[aktualSpot[0], aktualSpot[1]] == 9) { // 

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
                             Console.WriteLine();
                             Console.WriteLine("╔══════════════════════════════════════════════════════════════════════════╗");
                             Console.WriteLine("║ BOOM! Narazil si na mínu! Použi akékolvek tlačítko pre návrat do menu... ║"); 
                             Console.WriteLine("╚══════════════════════════════════════════════════════════════════════════╝");
                             Console.ReadKey();
                             Console.Clear();
                             Menu();

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
                                     Console.Clear();
                                     Console.ForegroundColor = ConsoleColor.Red;
                                     Console.WriteLine("██████  ██████  ███████ ██   ██ ██████   █████  ██          ███████ ██         ██ ");
                                     Console.WriteLine("██   ██ ██   ██ ██      ██   ██ ██   ██ ██   ██ ██          ██      ██         ██ ");
                                     Console.WriteLine("██████  ██████  █████   ███████ ██████  ███████ ██          ███████ ██         ██");
                                     Console.WriteLine("██      ██   ██ ██      ██   ██ ██   ██ ██   ██ ██               ██ ██            ");
                                     Console.WriteLine("██      ██   ██ ███████ ██   ██ ██   ██ ██   ██ ███████     ███████ ██         ██ ");
                                     Console.ResetColor();
                                     
                                     Console.WriteLine();
                                     Console.WriteLine("╔══════════════════════════════════════════════╗");
                                     Console.WriteLine("║ Použi akékolvek tlačítko pre návrat do menu. ║");
                                     Console.WriteLine("╚══════════════════════════════════════════════╝");
                                     
                                     Console.ReadKey();
                                     Console.Clear();
                                     Menu();
                                 }

                             }                    
                             


                             else
                             {
                                 continue;
                             }
                         }
                     }
                     
                     Console.Clear();
                     Console.ForegroundColor = ConsoleColor.Green;
                     Console.WriteLine("██    ██ ██    ██ ██   ██ ██████   █████  ██          ███████ ██         ██");
                     Console.WriteLine("██    ██  ██  ██  ██   ██ ██   ██ ██   ██ ██          ██      ██         ██");
                     Console.WriteLine("██    ██   ████   ███████ ██████  ███████ ██          ███████ ██         ██ ");
                     Console.WriteLine(" ██  ██     ██    ██   ██ ██   ██ ██   ██ ██               ██ ██            ");
                     Console.WriteLine("  ████      ██    ██   ██ ██   ██ ██   ██ ███████     ███████ ██         ██ ");
                     Console.ResetColor();
                     
                     Console.WriteLine();
                     Console.WriteLine("╔══════════════════════════════════════════════╗");
                     Console.WriteLine("║ Použi akékolvek tlačítko pre návrat do menu. ║");
                     Console.WriteLine("╚══════════════════════════════════════════════╝");
                     
                     Console.ReadKey();
                     Console.Clear();
                     Menu();
                     
                     }

                     break;
             }

             Console.Clear();
             VypisPole(riadkyPola, stlpcePola, aktualSpot, miny);

         }
     }

     

     static void VypisPole(int riadkyPola, int stlpcePola, int[] aktualSpot, String[,] miny) { // Funkcia na vypísanie farebného herného pola 
         
         Console.WriteLine();
        
         for (int i = 0; i < riadkyPola; i++) {

                 for (int j = 0; j < stlpcePola; j++) {

                     if (i == aktualSpot[0] && j == aktualSpot[1]) {
                         Console.ForegroundColor = ConsoleColor.DarkRed;
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
                     } else if (miny[i,j] == "P") {
                         Console.ForegroundColor = ConsoleColor.Red;
                     }else {
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