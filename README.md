Startup Summer School - Vstupný test
============

##Úloha1 - anagramy
###Zadanie
Anagram slova je nové slovo, ktoré vznikne poprehadzovaním písmen pôvodného slova.
Napíš program, ktorý pre zadané slovo a zoznam kanditátov vráti slová, ktoré su anagramom daného slova.
Napríklad pre slovo "listen" a zoznam kandidátov ["enlists", "google", "inlets", "banana"] program vráti zoznam ["inlets"].
Pokús sa algoritmus hľadania anagramov optimalizovať tak, aby bol čo najefektívnejší a vysvetli aké optimalizácie si použil a prečo.
###Riešenie
Túto úlohu som riešil v jazyku C# a jednotlivé metódy som implementoval ako extension metódy rozširujúce value type string (ale aj triedu String, keďže sa vie unboxnúť na value-type string). Tento jazyk som si zvolil, lebo v ňom mám najviac skúseností a momentálne som v ňom najproduktívnejší (v ruby alebo pythone ešte nei som tak zbehlý :) ), čiže prvotné riešenie som mal takmer hneď. 

Trik v riešení anagramov je v tom, že písmena anagramov abecedne zoradíme, tak dostaneme rovnaké reťazce.
Riešenie tejto úlohy som spočiatku ale riešil trochu inak.

Na branchi master sa nachádza moje prvotné riešenie. Použil som v ňom LINQ metódu Except. Myšlienka je taká, že ak spravím rozdiel množín (polí dvoch slov) a dostanem prázdnu množinu (string), tak sa jedná o anagramy. Jediná optimalizácia je, že ak sú stringy rôzne, tak porovnávanie rovno vráti false. Metóda Except by mala zbehnúť v O(n), keďže rozdiel robí sekvenčným prechádzaním oboch zoznamov.

Druhý spôsob, na branchi second_try, stringy zoradí a potom ich provná => O(n * log n), kvoli zoradeniu.

Tretí spôsob, na branchi almost_c_way, beží v O(n). Oba stringy sekvenčne prejde a početnosti výskytu jednotlivých písmen si ukladá v hash mapách. Potom skontroluje, či sa početnosti v hash mapách rovnajú. Keďže tento spôsob extenzívne nepracuje s kolekciami a s LINQ, ale ide iba for cyklami, mal by byť o niečo rýchlejší ako prvý spôsob.


##Uloha2 - dátové modelovanie 

###Zadanie
Navrhni dátový model pre elektronický obchod, ktorý predáva produkty. Produkty majú názov, popis a cenu. Objednávka obsahuje zoznam zákazníkom vybraných produktov a ich množstvo. Zákazník je identifikovaný emailovou adresou. Obchod ponúka aj zľavy cez zľavové kúpóny, ktoré je možné použiť na nákupy a je vždy vyjadrený percentuálnou hodnotou (napr. 5% zľava). Zľavový kupón je identifikovaný kódom (napr. SALE2014) a môže byť použitý len limitovaný čas a limitovaný počet krát. Zoznam objednávok má slúžiť ako evidencia histórie nákupov pre ekonomické oddelenie. V návrhu počítajte s tým, že ceny produktov sa časom zvyknú meniť.
Nakresli a vysvetli dátový model (tabuľky, prepojenia a stĺpce) pre takýto e-shop.
###Diagram
--
![](https://dl.dropboxusercontent.com/u/55261792/spot_uloha2.png)
--
###Popis
* Product - cena je reprezerntovaná samostatnou entitou, ktora ma atribúty začiatku a konca obdobia, kedy cena platí, čo môže byť užitočné pri analýze cien
* Cart - keď používateľ nakupuje v našom e-shope, priebežne si ukladá vybrané produkty do košíka 
    * môže si zvoliť množstvo každého produktu, to je zabezpečené väzobnou entitou CartItem, ktorá rozkladá many-to.many          reláciu medzi produktom a košíkom
* DiscountCode - reprezentuje zlavovy kupon
    * má vymedzenýn čas platnosti (date_starts, date_ends)
    * má vymedzený počet použití
    * je identifikovaný reťazcom (Code => napr. SALE2014)
    * mohol by sa k nej viazať aj customer
* Order - konkrétna už uskutočnená objednávka v e-shope
    * má stav (uskutočne) 
* Customer - aj ked je v e-shope dôležitá len e-mailová adresa, tak modelujem zákazníka zvlášť, čo uľahčí prácu, ak budeme chcieť túto entitu v budúcnosti rozšíriť
