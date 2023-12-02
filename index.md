# What's new in .net 8

## C#

### Primary constructors

```csharp
// Old way
public class Person
{
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
    
    public string Name { get; }
    public int Age { get; }
}
```

```csharp
// New way
public class Person(string name, int age)
{
    public string Name { get; init; }
    public int Age { get; init; }
}
```

```csharp
// Perfect for dependency injection  
public class UserController(UserService userService, ILogger<UserController> logger)
{
}
```

### Collection Expressions

```csharp
int[] = [1, 2, 3, 4, 5];

// Empty array
public string[] CoolThings { get; set; } = [];

// Works with lists too
public List<string> CoolThings { get; set; } = [];

// Spread operator
int[] numbers = [1, 2, 3, 4, 5];
int[] moreNumbers = [0, ..numbers, 6, 7, 8, 9]; // Note the .. operator

```

### Switch expressions

```csharp

public string GetDayOfWeek(int day)
{
    return day switch
    {
        1 or 7 => "Weekend",
        2..6 => "Weekday",
        _ => throw new ArgumentException("Invalid day of week")
    };
}

public string Suffix(int number)
{
    return number switch
    {
        1 => "st",
        2 => "nd",
        3 => "rd",
        >= 4 and <= 20 => "th",
        _ => Suffix(number % 10)
    };
}

public string Family(string[] names) {
    return names switch
    {
        [name] => $"{name} is an only child",
        [child1, child2] => $"The family has two children: {child1} and {child2}",
        [child1, ..others] when others.length < 4 => $"{child1} is the oldest child and has {others.Length} siblings",
        _ => "The family is too big to keep track of"
    };
}
```

### Null type checking

```csharp
public class Person
{
    public required string Name { get; set; }
    public string? FavoriteColor { get; set; }
}
```

### ?? and ??= operators

```csharp
string name = null;
string otherName = name ?? "John Doe";

// Same as
string otherName = name != null ? name : "John Doe";

// ??= operator
name ??= "John Doe";

// Same as
if (name == null)
{
    name = "John Doe";
}
```

## Blazor
* Unified web app template
* Static server side rendering

## Aspire
* Simplify orchestration for containers and microservices
* Add services like Redis, RabbitMQ, and Postgres
* Export manifest for deployment
* Azure Developer CLI support to deploy to Azure