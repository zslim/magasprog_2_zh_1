# 1. ZH

Egy fűtési rendszereket forgalmazó bolt szoftverét kell lefejlesztenünk.

Egy **fűtési eszközt** jellemeznek a következő adatok:

* modell neve: csak olvasható, nem null, nem üres string
* gyártási év: csak olvasható, nem lehet a mostani évnél későbbi
* teljesítmény (kW-ban): legalább 0,01 kW
* konstruktor a 3 mező kezdőértékével
* konstruktor 2 mező kezdőértékével, a teljesítmény legyen a minimális érték

Egy **gázkazánt** (mint fűtési eszközt) jellemeznek még a következő adatok:

* kondenzációs a kazán vagy sem: csak olvasható
* milyen funkciójú a kazán: csak olvasható, értékei: fűtő kazán, kombi kazán, beépített tárolós kazán
* konstruktor az összes mező kezdőértékével
* konstruktor, amely alapból kondenzációs kombi kazánt példányosít

Egy **hőszivattyút** (mint fűtési eszközt) jellemeznek még a következő adatok:

* működési elv: csak olvasható, értékei: levegő-víz, levegő-levegő, talajszondás
* konstruktor az összes mező kezdőértékével

A **boltban** fűtési eszközök sokaságát árulják. Írj property-ket/metódusokat ehhez az osztályhoz:

* Új eszköz hozzáadása: 2018 után csak olyan gázkazánt lehet árusítani, mely kondenzációs. A nem gázkazánokra nincs megkötés.
* Hány darab kondenzációs kombi gázkazán van raktáron?
* Hány darab hőszivattyú van raktáron a paraméterként megadott működési elvűből?
* Melyik a legnagyobb teljesítményű gázkazán?

Írj **Main** eljárást, mely

* példányosít egy boltot
* ebből a szöveges fájlból beolvassa fűtési eszközök adatait és hozzáadja azokat a bolthoz
* listázza a boltban árult eszközöket a képernyőn (ToString!)
* kiírja (a bolt megfelelő metódusainak hívásával):
  * hány darab kondenzációs kombi gázkazán van raktáron
  * hány darab talajszondás hőszivattyú van raktáron
  * a legnagyobb teljesítményű kazán adatait (ToString!)

A feladat szerzője Kovásznai Gergely.
