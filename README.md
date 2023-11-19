# WebAppHidonix

Elenco delle API per l'esecuzione delle operazioni CRUD sulle entità e di quelle legate all'utente.

**Login**

/api/Auth/login            -    Type:  POST

esempio body:
{
  "Email":"test@admin.net",
  "Password":"admin1"
}


**Logout**

/api/Auth/logout            -    Type:  GET


**Registrazione**

/api/Auth/register          -    Type:  POST

esempio body:
{
  "Email":"test@admin.net",
  "Password":"admin1",
  "Role" : "Admin"
}


**Recupero Password**

/api/Auth/forgotPassword    -    Type:  POST

esempio body:
{
  "Email":"test@admin.net"
}


**Get All Entità**

/api/SettoreApi/GetAll      -    Type: GET

sostituire Settore con Padiglione, Categoria o Stand per le altre entità

**GetById Entità**

/api/SettoreApi/GetId/4      -    Type: GET

sostituire Settore con Padiglione, Categoria o Stand per le altre entità

sostituire 4 con l'id da desiderato


**Save Entità**

/api/SettoreApi/Save         -    Type:  POST

esempio body:
{
  "Nome" : "Biliardo",
  "Tipologia" : "Stanza",
  "NumStand" : 0,
  "Descrizione" : "Breve descrizione del settore"
}

sostituire Settore con Padiglione, Categoria o Stand per le altre entità


**Update Entità**

/api/SettoreApi/Save         -    Type:  PUT

esempio body:
{
  "ID" : 2,
  "Descrizione" : "Lunghissima descrizioneeee"
}

sostituire Settore con Padiglione, Categoria o Stand per le altre entità


**Delete elemento Entità**

/api/SettoreApi/Delete/4         -    Type:  DELETE

sostituire Settore con Padiglione, Categoria o Stand per le altre entità

sostituire 4 con l'id da desiderato

Le operazioni CRUD sugli elementi possono essere eseguite soltanto se una sessione di login è attiva. Come richiesto l'operazione di DELETE è eseguibile solo da utenti Admin, ed è l'unica operazione che viene eseguita in backgroud con l'utilizzo della libreria Hangfire.
