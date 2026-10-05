# C# Övning 1 – Personalregister

Ett konsolprogram för ett litet företag i restaurangbranschen.
Programmet kan registrera anställda med namn och lön samt
skriva ut personalregistret i konsolen.

## Uppgift 1 – Vilka klasser bör ingå i programmet?

Programmet innehåller tre klasser:

- **Employee** representerar en anställd med namn och lön.
- **EmployeeRegister** ansvarar för att lagra och hämta anställda.
- **Program** ansvarar för menyn, inmatningen och utskriften i konsolen.

Uppdelningen ger varje klass ett tydligt ansvar och gör programmet
enklare att förstå, underhålla och vidareutveckla.

## Uppgift 2 – Vilka attribut och metoder bör ingå i klasserna?

### Employee

Egenskaper:

- `Name`: en egenskap av typen `string` som innehåller namnet.
- `Salary`: en egenskap av typen `decimal` som innehåller lönen.

Båda egenskaperna kan läsas men inte ändras efter att objektet skapats.

Konstruktor:

- `Employee(string name, decimal salary)` skapar en anställd.
  Konstruktorn kontrollerar att namnet inte är tomt och att lönen
  inte är negativ. Mellanslag i början och slutet av namnet tas bort.

### EmployeeRegister

Fält:

- `employees`: ett privat fält av typen `List<Employee>` som lagrar
  de anställda. Fältet är `readonly`, vilket innebär att listan inte
  kan ersättas, men nya anställda kan läggas till.

Metoder:

- `Add(Employee employee)` kontrollerar att objektet inte är `null`
  och lägger sedan till den anställda i listan.
- `GetAll()` returnerar en skrivskyddad vy av listan som
  `IReadOnlyList<Employee>`.

### Program

Fält:

- `SalaryCulture`: ett statiskt, skrivskyddat fält av typen `CultureInfo`
  som anger svenskt talformat med decimaltecken komma.

Metoder:

- `Main()` startar programmet och visar menyn tills användaren avslutar.
- `AddEmployee(EmployeeRegister register)` läser och validerar namn
  och lön, skapar ett `Employee`-objekt och lägger till det i registret.
  Metoden returnerar `true` när den anställda har sparats och `false`
  om konsolens inmatning stängs, så att programmet kan avslutas.
- `PrintEmployees(EmployeeRegister register)` skriver ut de anställda
  eller visar ett meddelande om registret är tomt.

## Uppgift 3 – Skriv programmet

Programmet är implementerat i följande filer:

- [Employee.cs](Employee.cs)
- [EmployeeRegister.cs](EmployeeRegister.cs)
- [Program.cs](Program.cs)

Menyn innehåller tre alternativ:

```text
1. Lägg till anställd
2. Visa personalregistret
0. Avsluta
```

När användaren lägger till en anställd läser programmet namn och lön
från konsolen. Uppgifterna kontrolleras innan den anställda sparas.

När användaren väljer att visa registret skrivs varje anställds namn
och lön ut i konsolen. Lönen visas med två decimaler och valutan SEK,
exempelvis:

```text
Namn: Anna | Lön: 25000,50 SEK
```

Uppgifterna lagras endast i minnet och försvinner när programmet
avslutas. Persistent lagring har inte implementerats.

## Robusthet och möjlighet till vidareutveckling

- Tomma namn och namn som endast innehåller mellanslag avvisas.
- Ogiltiga lönebelopp och negativa löner avvisas.
- `decimal.TryParse` används för att hantera felaktig inmatning.
- Ogiltiga menyval ger ett meddelande och menyn visas igen.
- Ett tomt register hanteras med ett tydligt meddelande.
- Programmet avslutas om konsolens inmatning stängs.
- `decimal` används för lönebelopp.
- Listan kan inte ändras direkt genom `GetAll()`.
- Anställda, lagring och konsolhantering har separata ansvarsområden.

Lönen anges i SEK med komma som decimaltecken och utan
tusentalsavskiljare, exempelvis `25000,50`.

Lön 0 och flera anställda med samma namn tillåts i den nuvarande
implementeringen.

## Köra programmet

Projektet använder .NET 8 och kräver .NET 8 SDK.

Kör följande kommandon i katalogen som innehåller
`Personalregister.csproj`:

```bash
dotnet build
dotnet run
```

## Manuella testfall

| Test | Förväntat resultat |
| --- | --- |
| Visa registret utan anställda | Ett meddelande om att registret är tomt visas |
| Lägg till Anna med lönen 25000,50 | Den anställda sparas |
| Visa registret efter registreringen | Annas namn och lön visas med två decimaler och SEK |
| Lägg till ytterligare en anställd | Båda anställda visas i registret |
| Ange ett tomt namn | Programmet ber om ett nytt namn |
| Ange endast mellanslag som namn | Programmet ber om ett nytt namn |
| Ange abc som lön | Programmet ber om ett nytt lönebelopp |
| Ange en negativ lön | Programmet ber om ett nytt lönebelopp |
| Ange 0 som lön | Lönen godkänns |
| Ange ett ogiltigt menyval | Ett felmeddelande visas och menyn visas igen |
| Välj 0 | Programmet avslutas |
| Stäng konsolens inmatning | Programmet avslutas |
| Starta om programmet | Registret är tomt |

Automatiserade tester har inte implementerats.
