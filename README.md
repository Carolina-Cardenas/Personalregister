# C# Övning 1 – Personalregister

Det här är ett enkelt konsolprogram i C# för ett litet restaurangföretag.
Man kan lägga till anställda med namn och lön och visa dem i en lista.

## Uppgift 1 – Klasser

Programmet har tre klasser:

- `Employee` innehåller information om en anställd.
- `EmployeeRegister` håller en lista med anställda.
- `Program` visar menyn och läser det användaren skriver.

## Uppgift 2 – Egenskaper och metoder

### Employee

- `Name` är den anställdas namn. Typen `string` används för text.
- `Salary` är den anställdas lön. Typen `decimal` används för tal med decimaler.
- `Employee(name, salary)` skapar en anställd med namn och lön.

### EmployeeRegister

- `employees` är listan där de anställda finns.
- `Add()` lägger till en anställd.
- `GetAll()` hämtar de anställda så att de kan visas.

### Program

- `Main()` startar programmet och visar menyn.
- `AddEmployee()` frågar efter namn och lön och lägger till den anställda.
- `PrintEmployees()` visar alla anställda i konsolen.

## Uppgift 3 – Använda programmet

Menyn ser ut så här:

```text
1. Lägg till anställd
2. Visa personalregistret
0. Avsluta
```

Välj `1` för att ange namn och lön. Skriv lönen utan tusentalsavskiljare
och med komma om den har decimaler, till exempel `25000,50`.

Välj `2` för att visa de anställda. Exempel:

```text
Namn: Anna | Lön: 25000,50 SEK
```

Namnet får inte vara tomt och lönen får inte vara negativ.
Om du skriver fel ber programmet dig att försöka igen.

Välj `0` för att avsluta. Uppgifterna försvinner när programmet stängs.

## Köra programmet

Du behöver .NET 8 SDK. Öppna en terminal i projektets mapp och kör:

```bash
dotnet run
```

## Testa själv

- Lägg till Anna med lönen `25000,50` och visa registret.
- Lägg till en till anställd och kontrollera att båda visas.
- Prova ett tomt namn, en negativ lön och bokstäver som lön.
- Avsluta med `0`.
