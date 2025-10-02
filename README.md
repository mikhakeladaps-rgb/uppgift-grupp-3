# uppgift-grupp-3

This is a school group project written in **C#/.NET**. The project is organized into three parts:

* **AddressBook.Core** → Class Library (all shared logic)
* **AddressBook.CLI** → Console application (command line)
* **AddressBook.WPF** → WPF application (Windows desktop GUI)
* **Playground** → Temporary project which can be used for testing of logiclib instead of doing changes to consoleApp.

---

## Build the Solution

```bash
# Restore packages
dotnet restore

# Build all projects
dotnet build
```

---

## Run the Applications

### Run Console App

```bash
dotnet run --project consoleApp
```

### Run WPF App (Windows only)

```bash
dotnet run --project wpfApp
```

---

## Git Workflow

### 1. Always get latest in repo before making changes
```bash
git pull
```

### 2. Stage and commit changes

```bash
git add .
git commit -m "Describe your changes"
```

### 3. Push to GitHub

If you are on an existing branch:
```bash
git push
```

Pushing for the first time on a new branch: (change my-feature to the name of branch)
```bash
git push origin feature/my-feature
```

---

## Git Quick Reference / Lathund (SV)

### Branching

```bash
# Skapa och byta till ny branch
git checkout -b feature/my-feature

# Byt till befintlig branch
git checkout master
```

### Stage & Commit

```bash
# Lägg till alla ändringar
git add .

# Lägg till specifik fil
git add filnamn.txt

# Commit med meddelande
git commit -m "Kort beskrivning av ändringar"
```

### Push & Pull

```bash
# Push ny branch första gången och koppla till remote
git push -u origin feature/my-feature

# Push ändringar (från kopplad branch)
git push

# Hämta senaste ändringar från remote
git pull
```

### View status & log

```bash
# Visa ändringar och staged files
git status

# Visa commit-logg
git log
```

### Undo / Reset

```bash
# Ta bort staged filer (men behåll ändringar i filerna)
git reset

# Ta bort staged specifik fil
git reset filnamn.txt

# Återställ filer till senaste commit (raderar ändringar)
git restore filnamn.txt
git restore .   # alla filer
```

**Tips:**

* Undvik mellanslag i branch-namn → använd bindestreck `-` eller underscore `_`.
* `git push -u origin branch-name` behövs bara första gången på en ny branch.

---

 # Konceptet med dll-projekt
 Vi har satt upp en solution med 4 projekt.

 **logiclib** -> detta är vårt klassbibliotek och skapar en dll-fil. Denna är inte körbar direkt som t.ex. de exe-filer som skapas i de andra projekten.
 Här är lämpligt att lägga den logik som behövs som inte i sig är kopplat till hur vi "presenterar" data i antingen konsol-appen eller WPF-appen.
 De klasser och funktioner som ligger i detta projekt delas sedan till de andra projekten och blir åtkomliga därifrån
 
 **consoleApp** och **wpfApp** -> här satte vi upp en refererens till logiclib i terminalen när vi skapade våra projekt och har då tillgång till koden som ligger i dll-filen ovan.
 För att komma åt klasser och funktioner i dll-filen så lägger vi till
 ```bash
using logiclib;
```
överst i de filer som behöver access.

**Playground**
Detta är en konsol applikation. För att undivka onödig konflikter i koden i vår **consoleApp** så kan denna användas med fördel för snabba tester av t.ex. koden som läggs i dll-filen då denna inte går att köra direkt. Denna är inte nödvändig att pusha utan tanken är mest att använda den lokalt. Dock följer ändingar här med i *git add .* men det gör inget och skulle det bli konflikter är det mest att skriva över då detta inte är någon kod som vi ska använda i vårt färdiga arbete. Så detta projekt tar vi bort helt när vi är färdiga.

Projekten i detta lägen är uppsatta med detta för att demonstrera hur det ska se ut.

---

# Hur satte VI upp projektet för Visual Code?

### 1. Val av lokal mapp

### 2. Skapade en solution
Solution -> samlar alla projekt i EN lösning
```bash
dotnet new sln -n grupp3.sln
```

### 3. Skapade projekten
```bash
dotnet new console -n consoleApp
dotnet new classlib -n logiclib
dotnet new wpf - wpfApp
```

### 4. La till projekten till vår solution
```bash
dotnet sln add consoleApp/consoleApp.csproj
dotnet sln add logiclib/logiclib.csproj
dotnet sln add wpfApp/wpfApp.csproj
```

### 5. Kopplade ihop projekten
Så att consoleApp och wpfApp kan använda logiclib
```bash
dotnet add consoleApp/consoleApp.csproj reference logiclib/logiclib.csproj
dotnet add wpfApp/wpfApp.csproj reference logiclib/logiclib.csproj
```

