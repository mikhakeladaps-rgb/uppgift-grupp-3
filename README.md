# uppgift-grupp-3

This is a school group project written in **C#/.NET**. The project is organized into three parts:

* **logiclib** → Class Library (all shared logic)
* **consoleApp** → Console application (command line)
* **wpfApp** → WPF application (Windows desktop GUI)
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
 
