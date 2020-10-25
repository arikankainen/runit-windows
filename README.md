# RunIt

RunIt on ohjelma pikakuvakkeiden näyttämiseen muokattavassa ikkunassa, jonka saa esiin joko Windowsin tehtäväpalkin ilmoitusalueen sinistä kuvaketta klikkaamalla, pikanäppäimellä tai viemällä hiiri ruudun tiettyyn reunaan. Ohjelma voidaan myös kiinnittää tehtäväpalkkiin (kuvassa) kuten mikä tahansa ohjelma. Ohjelma katoaa näkyvistä kun joku pikakuvake on käynnistetty, tai jos ohjelma ei ole enää aktiivinen. Useita ohjelmia voidaan käynnistää ikkunaa sulkematta pitämällä `ctrl`-nappia pohjassa.

Ohjelman ikkuna voidaan näyttää myös klikkaamalla ohjelman `exe`-tiedostoa, tai mukana tulevaa kooltaan pientä RunIt Launcheria. Joissain tapauksissa RunIt Launcher on aavistuksen nopeampi tapa näyttää ikkuna kuin ajamalla itse RunIt uudelleen.

![RunIt](/docs/main.png)

## Toiminta

Kuvakkeet luetaan asetuksissa määritellyn pikakuvakekansion alikansioista. Alikansiosta muodostetaan ryhmiä joissa pikakuvakkeet sijaitsevat. Ensimmäisen käynnistyksen yhteydessä ohjelman asennuskansioon luodaan `Shortcuts` -kansio joka otetaan käyttöön pikakuvakekansioksi, ja sinne luodaan kaksi esimerkkialikansiota ja niihin muutama pikakuvake. Kansiota voidaan muuttaa asetuksista. Jos valitaan kansio jota ei ole olemassa, se yritetään luoda (ja sinne luodaan automaattisesti myös ko. esimerkkipikakuvakkeet). Jos luonti ei onnistu, palautetaan oletuskansio.

Alla on näytetty ohjelman käyttämä kansiorakenne. Pääkansio kuvaa asetuksissa määriteltyä kansiota. Sen sisällä olevat alikansiot muodostavat ohjelmassa ryhmiä, joiden sisällä on pikakuvakkeet. Alikansioiden tai niiden sisältämien pikakuvakkeiden määrää ei ole rajoitettu.

- Pääkansio
  - Alikansio 1
    - Pikakuvake 1
    - Pikakuvake 2
    - Pikakuvake 3
    - Pikakuvake 4
  - Alikansio 2
    - Pikakuvake 1
    - Pikakuvake 2
    - Pikakuvake 3
    - Pikakuvake 4
  - Alikansio 3
    - Pikakuvake 1
    - Pikakuvake 2
    - Pikakuvake 3
    - Pikakuvake 4

Alla näkyvissä vielä kansiorakenne ensimmäisellä käyttökerralla luotavista esimerkkipikakuvakkeista. Esimerkkikuvakkeet ovat ylläolevan ruutukaappauksen kaksi ensimmäistä ryhmää.

- Shortcuts
  - Example shortcuts
    - Calculator
    - File Explorer
    - Notepad
    - WordPad
  - Help
    - RunIt Manual

## Käyttö

Ryhmiä voidaan siirrellä eri järjestykseen raahaamalla niitä ryhmän nimestä, ja tiputtamalla toisen ryhmän päälle, jolloin ryhmä siirretään sen paikalle.

Pikakuvakkeita voidaan siirrellä sekä saman ryhmän sisällä että toiseen ryhmään. Saman ryhmän sisällä pikakuvake pudotetaan toisen pikakuvakkeen päälle, jolloin se siirtyy sen paikalle. Toiseen ryhmään siirto onnistuu samalla tavalla, mutta sen voi tiputtaa myös toisen ryhmän nimen päälle, jolloin se siirtyy viimeiseksi pikakuvakkeeksi kyseiseen ryhmään. Ryhmien välillä siirtely siirtää pikakuvakkeen myös toiseen kansioon levyllä.

Pikakuvakkeen kuvake voidaan korvata omalla kuvalla tallentamalla samaan kansioon `.png`-tiedosto, samalla nimellä kuin itse pikakuvake. Kuvan koolla ei ole väliä, se sovitetaan oikeaan kokoon automaattisesti. Terävimmän tuloksen saa toki tekemällä täsmälleen sen kokoisen kuvan kun asetuksissa on kuvakkeen kooksi määritelty.

Ryhmät järjestyvät riveihin ylhäältä alas, jonka jälkeen uuteen riviin edellisen rivin oikealle puolelle. Ikkunan kokoa voidaan muuttaa hiirellä venyttämällä, ja ryhmät mukautuvat parhaansa mukaan ikkunan kokoon. Venyttämisen jälkeen ikkunan koko mukautuu näkyvissä olevan ryhmäjärjestyksen mukaan. Mikäli ikkunan koko on korkeussuunnassa liian pieni, voi osa ryhmistä jäädä ikkunan ulkopuolelle piiloon kun näytön rajat tulevat vastaan. Tällöin asiasta tulee ilmoitus ja ikkunan taustaväri muuttuu punaiseksi, kunnes kaikki ryhmät saadaan mahtumaan näytölle. Ikkunaa voidaan siirtää raahaamalla hiirellä ryhmän tyhjästä kohdasta tai ryhmän ulkopuolelta. Siirretyn ikkunan sijainnin voi tallentaa hiiren oikealla napilla esiin tulevan valikon vaihtoehdolla `Save current position`. Jos sijaintia ei tallenneta, ikkuna palaa uudelleen näytettäessä asetuksissa määriteltyyn paikkaan (oletuksena keskelle näyttöä).

Hiiren oikean napin valikon takaa löytyy myös uuden ryhmän luonti (`New group…`), pikakuvakkeiden päivitys (`Refresh`), pikakuvakekansion avaaminen tiedostonhallintaan (`Open shortcut folder`), asetuksien avaaminen (`Settings`), tämän ohjetiedoston näyttäminen (`Help`), sekä ohjelman sulkeminen (`Exit`). Ryhmän otsikon kohdalla onnistuu ryhmän uudelleen nimeäminen (`Rename group…`), sen poistaminen (`Delete group…`) tai pikakuvakkeiden lisääminen leikepöydältä (`Paste shortcut`). Ryhmän poistaminen poistaa myös koko kansion ja kaikki sen kuvakkeet levyltä. Kuvakkeen kohdalla onnistuu uudelleen nimeäminen (`Rename shortcut…`), muokkaaminen (`Edit shortcut…`), sekä poistaminen (`Delete shortcut…`). Muokkaaminen avaa Windowsin oman pikakuvakkeen muokkausikkunan, jonka kautta pikakuvakkeen nimeä ei kannata muuttaa, koska ohjelma hukkaa sen jälkeen kuvakkeen sijaintitiedon ryhmän sisällä.

## Asetukset _(Settings -välilehti)_

![Asetukset](/docs/settings.png)

**_Folder_**\
Kansio, jossa kaikki pikakuvakkeet sijaitsevat. Pikakuvakkeiden tulee olla määritellyn kansion sisällä alikansioissa. Alikansioiden nimistä muodostetaan ryhmiä, joiden sisällä pikakuvakkeet näytetään.

**_Hotkey_**\
Voidaan määritellä pikanäppäin tai pikanäppäinyhdistelmä, jolla ohjelman ikkuna näytetään.

**_Startup_**\
Voidaan valita käynnistyykö ohjelma automaattisesti Windowsia käynnistettäessä. Asetus tallennetaan suoraan Windowsin rekisteriin, joten se kannattaa napsauttaa pois päältä ennenkuin ohjelman poistaa.

**_Mouse_**\
Ohjelma voidaan näyttää viemällä hiiren kursori näytön tiettyyn reunaan tai nurkkaan. Paikat voidaan määritellä lisäämällä ruksi tai rukseja reunoja tai kulmia kuvaaviin paikkoihin (`Triggering edges of screen`). Alueen koon voi määritellä erikseen korkeus- (`From top/bottom`) ja leveyssuunnassa (`From left/right`). Myös aika jonka hiiren pitää olla alueella että ohjelma näytetään voidaan määritellä millisekunteina (`Waiting time`). Harmaaseen esikatselukuvaan tulevat punaiset alueet kuvaavat valittuja alueita.

**_Location_**\
Paikka johon ikkuna aukeaa voidaan myös määritellä. Ikkuna voidaan kiinnittää näytön reunoihin tai kulmiin, tai se voidaan keskittää näytön keskelle (`Align to screen edges`). Vaihtoehtona on myös näyttää se sillä kohtaa jossa hiiren kursori kulloinkin on (`Mouse position`), kuitenkin niin ettei ikkuna mene näytön reunoista ulos. Jos ikkunan sijainti on tallennettu itsevalittuun kohtaan, on sijantina `Custom position`. Itsevalittu kohta toimii siten, että etäisyys tallennetaan lähimpään reunaan sekä leveys että korkeussuunnassa. Tuloksena on, että ikkuna on aina samalla etäisyydellä lähimmistä reunoista, vaikka ikkunan koko tai näytön resoluutio muuttuisi, tai ikkuna avataan toiselle eriresoluutioiselle näytölle. Ohjelman ikkunan ja näytön reunojen väliin on mahdollista määritellä tietynsuuruinen väli, jos ei halua että ikkuna menee kiinni reunaan (`Margin to screen edges`).

## Asetukset _(Appearance -välilehti)_

![Asetukset](/docs/appearance.png)

**_Colors_**\
Ikkunan eri elementtien värit voidaan määritellä syöttämällä väri HTML-värikoodina suoraan tekstikenttään, tai valitsemalla väri `Change...` -napilla. Neliönmuotoinen ruutu tekstikentän vieressä kuvaa valittua väriä.

**_Application background_**\
Koko ikkunan taustaväri, joka näkyy ikkunan reunoilla ja ryhmien välissä.

**_Group background_**\
Ryhmien taustaväri.

**_Shortcut background_**\
Pikakuvakkeen taustaväri, eli neliö joka näkyy pikakuvakkeen kuvan ja tekstin taustalla.

**_Shortcut background hover_**\
Pikakuvakkeen taustaväri kun hiiren vie pikakuvakkeen päälle.

**_Tooltip background_**\
Taustaväri valinnaiselle tooltipille, joka näyttää pikakuvakkeen nimen ja mahdollisen kuvauksen.

**_Group topic_**\
Ryhmän otsikon tekstin väri.

**_Shortcut text_**\
Pikakuvakkeen tekstin väri.

**_Tooltip text_**\
Tooltipin tekstin väri.

**_Fonts_**\
Ryhmän ja pikakuvakkeen/tooltipin tekstin fontti, koko ja muotoilut voidaan valita suoraan omista säätimistään, tai voidaan käyttää `Change` -nappia, jolla kaikki määritellään Windowsin omassa fontinvalintaikkunassa. Napin alla näkyy esimerkkiteksti valitulla fontilla.

**_Group topic_**\
Ryhmän otsikon tekstin fontti.

**_Shortcut / tooltip_**\
Pikakuvakkeen ja tooltipin tekstin fontti.

**_Opacity_**\
Ohjelman ikkunan ja ikkunan sisällön peittokyky voidaan valita välillä 20%-100%. Oletusasetus on 96%, eli ikkuna on vain hieman läpikuultava.

**_Fading_**\
Normaalisti ikkuna ilmestyy näkyviin ja katoaa pehmeästi. Efektin nopeutta voidaan säätää välillä 1-30, oletuksen ollessa 15. Mitä pienempi numero, sitä hitaammin ikkuna ilmestyy. Efektin voi myös ottaa pois käytöstä jolloin ikkuna ilmestyy heti.

**_Sizes_**\
Ikkunan eri elementtien kokoja ja marginaaleja voidaan säätää, sekä valita kunka monta kuvaketta kansioissa on vierekkäin.

**_Extra outer margin_**\
Ikkunan reunoille lisättävä ylimääräinen tyhjä tila.

**_Group margin_**\
Ryhmien välinen tyhjä tila.

**_Group label height_**\
Ryhmän nimen sisältämän otsikkopalkin korkeus.

**_Shortcut box size_**\
Pikakuvakkeen ja sen nimen sisältävän `laatikon` koko leveys- ja korkeussuunnassa.

**_Shortcut icon size_**\
Pikakuvakkeen kuvan koko. Ohjelma lukee kuvakkeiden vakiokoot 16, 32 ja 48. Näiden välikoot joudutaan pienentämään suuremmasta kuvakkeesta, jolloin kuvake `pehmenee`.

**_Tooltip top margin_**\
Tooltipin ja pikakuvakelaatikon väliin jäävä tyhjä tila

**_Tooltip width padding_**\
Ylimääräinen tyhjä tila tooltipin oikealle ja vasemmalle puolelle.

**_Tooltip height padding_**\
Ylimääräinen tyhjä tila tooltipin ylä- ja alapuolelle.

**_Horizontal shortcuts_**\
Ryhmän sisältämien vierekkäisten pikakuvakkeiden määrä. Ryhmän leveys määräytyy siis tämän mukaan.

**_Labels and tooltips_**\
Pikakuvakkeille voidaan valita näytetäänkö niiden nimi, tooltippi, molemmat tai ei kumpaakaan. Tooltippi ilmestyy pikakuvakkeen alapuolelle kun hiiren vie pikakuvakkeen päälle. Ryhmän nimi voidaan näyttää vasemmalla, keskellä tai oikealla. Pikakuvakkeen teksti taas voidaan asemoida ylös, keskelle tai alas.

**_Reset_**\
Kaikki kyseisen välilehden asetukset palautetaan oletusasetuksiin (kuvan mukainen tumma teema).

**_Export..._**\
Välilehden asetukset tallennetaan valittuun tiedostoon.

**_Import..._**\
Välilehden asetukset voidaan tuoda aiemmin tallennetusta tiedostosta. Ohjelman mukana tulee tiedosto `light.runit`, joka sisältää vaalean esimerkkiteeman.

## Lataus

En ota mitään vastuuta ohjelman mahdollisesti aiheuttamista vahingoista; kukin käyttää ohjelmaa omalla vastuullaan. Toiminta testattu Windows 7 ja Windows 10 -käyttöjärjestelmillä. Vaatimuksena myös .NET Framework 4, joka tulee ainakin Windows 10:n tapauksessa esiasennettuna.

**[Lataa uusin versio](https://github.com/arikankainen/runit-windows/releases)**
