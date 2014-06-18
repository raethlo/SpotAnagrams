Startup Summer School - Vstupný test
============

##Úloha1 - anagramy

##Uloha2 - dátové modelovanie 

###Zadanie
Navrhni dátový model pre elektronický obchod, ktorý predáva produkty. Produkty majú názov, popis a cenu. Objednávka obsahuje zoznam zákazníkom vybraných produktov a ich množstvo. Zákazník je identifikovaný emailovou adresou. Obchod ponúka aj zľavy cez zľavové kúpóny, ktoré je možné použiť na nákupy a je vždy vyjadrený percentuálnou hodnotou (napr. 5% zľava). Zľavový kupón je identifikovaný kódom (napr. SALE2014) a môže byť použitý len limitovaný čas a limitovaný počet krát. Zoznam objednávok má slúžiť ako evidencia histórie nákupov pre ekonomické oddelenie. V návrhu počítajte s tým, že ceny produktov sa časom zvyknú meniť.
Nakresli a vysvetli dátový model (tabuľky, prepojenia a stĺpce) pre takýto e-shop.
###Diagram
--
![](https://dl.dropboxusercontent.com/u/55261792/spot_uloha2.png)
--
###Popis
- Product - cena je reprezerntovaná samostatnou entitou, ktora ma atribúty začiatku a konca obdobia, kedy cena platí, čo môže byť užitočné pri analýze cien
- Cart - keď používateľ nakupuje v našom e-shope, priebežne si ukladá vybrané produkty do košíka, môže si zvoliť množstvo každého produktu, to je zabezpečené väzobnou entitou CartItem, ktorá rozkladá many-to.many reláciu medzi produktom a košíkom
- 
