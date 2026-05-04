# GDPR.Abstractions

Zero-dependency abstractions for GDPR compliance in .NET.

[![NuGet](https://img.shields.io/nuget/v/GDPR.Abstractions.svg)](https://www.nuget.org/packages/GDPR.Abstractions)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

## Overview

`GDPR.Abstractions` provides lightweight, zero-dependency attributes for annotating properties and fields that hold personal or sensitive data as defined by the General Data Protection Regulation (GDPR). By decorating your models with these attributes, you enable compliance tooling — such as data export, anonymization, and audit scanning — to discover regulated data programmatically.

## Installation

```bash
dotnet add package GDPR.Abstractions
```

Or via the NuGet Package Manager:

```
Install-Package GDPR.Abstractions
```

## Supported Frameworks

- .NET Standard 2.0
- .NET Standard 2.1

## Attributes

### `PersonalDataAttribute`

Marks a property or field as containing **personal data** subject to GDPR (e.g. name, email address, IP address).

```csharp
using GDPR.Abstractions;

public class UserProfile
{
    [PersonalData]
    public string FullName { get; set; }

    [PersonalData]
    public string EmailAddress { get; set; }

    public DateTime CreatedAt { get; set; }
}
```

### `SensitiveDataAttribute`

Marks a property or field as containing **sensitive data** that requires extra protection under GDPR Article 9 (e.g. health information, biometric data, racial or ethnic origin).

```csharp
using GDPR.Abstractions;

public class MedicalRecord
{
    [PersonalData]
    public string PatientName { get; set; }

    [SensitiveData]
    public string Diagnosis { get; set; }

    [SensitiveData]
    public string BiometricHash { get; set; }
}
```

## Usage with Reflection

Because both attributes are standard .NET `Attribute` types, you can use reflection to discover annotated members at runtime — for example, to build a data export or anonymization pipeline:

```csharp
using System.Reflection;
using GDPR.Abstractions;

var personalFields = typeof(UserProfile)
    .GetProperties()
    .Where(p => p.IsDefined(typeof(PersonalDataAttribute), inherit: true));

foreach (var field in personalFields)
{
    Console.WriteLine($"Personal data field: {field.Name}");
}
```

## Design Goals

- **Zero dependencies** — no third-party packages, no transitive dependencies.
- **Non-invasive** — attributes are purely declarative; they do not alter runtime behaviour.
- **Interoperable** — targets .NET Standard so the package works across .NET Framework, .NET Core, and modern .NET.

## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the [MIT License](LICENSE).
