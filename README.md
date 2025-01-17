[![](https://img.shields.io/nuget/v/soenneker.extensions.char.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.char/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.extensions.char/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.extensions.char/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.extensions.char.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.extensions.char/)

# ![](https://user-images.githubusercontent.com/4441470/224455560-91ed3ee7-f510-4041-a8d2-3fc093025112.png) Soenneker.Extensions.Char
### A collection of helpful char extension methods

## Installation

```
dotnet add package Soenneker.Extensions.Char
```

## Benchmarks

### `IsDigit()` - 1,279% faster
| Method         | Mean      | Error     | StdDev    | Ratio         | RatioSD | Allocated | Alloc Ratio |
|--------------- |----------:|----------:|----------:|--------------:|--------:|----------:|------------:|
| IsDigitBuiltIn | 0.2449 ns | 0.0055 ns | 0.0046 ns |      baseline |         |         - |          NA |
| IsDigit        | 0.0214 ns | 0.0102 ns | 0.0096 ns | 13.79x faster |   6.03x |         - |          NA |

### `ToUpperInvariant()` - 6,332% faster

| Method                  | Mean      | Error     | StdDev    | Median    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|------------------------ |----------:|----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| ToUpperInvariantBuiltIn | 0.2470 ns | 0.0034 ns | 0.0030 ns | 0.2464 ns | baseline |         |         - |          NA |
| ToUpperInvariant        | 0.0039 ns | 0.0063 ns | 0.0059 ns | 0.0000 ns |       NA |      NA |         - |          NA |

### `IsLower()` - 144% faster
| Method         | Mean      | Error     | StdDev    | Allocated |
|--------------- |----------:|----------:|----------:|----------:|
| IsLowerBuiltIn | 0.2416 ns | 0.0051 ns | 0.0046 ns |         - |
| IsLowerFast    | 0.0992 ns | 0.0069 ns | 0.0064 ns |         - |

### `IsWhitespace()` - 197% faster

| Method          | Mean      | Error     | StdDev    | Ratio        | RatioSD | Allocated | Alloc Ratio |
|---------------- |----------:|----------:|----------:|-------------:|--------:|----------:|------------:|
| IsWhiteSpaceBuiltIn | 0.2513 ns | 0.0123 ns | 0.0115 ns |     baseline |         |         - |          NA |
| IsWhiteSpace    | 0.0846 ns | 0.0030 ns | 0.0023 ns | 2.97x faster |   0.15x |         - |          NA |

### `IsLetterOrDigit()` - 837% faster
| Method                 | Mean      | Error     | StdDev    | Ratio        | RatioSD | Allocated | Alloc Ratio |
|----------------------- |----------:|----------:|----------:|-------------:|--------:|----------:|------------:|
| IsLetterOrDigitBuiltIn | 0.2803 ns | 0.0194 ns | 0.0181 ns |     baseline |         |         - |          NA |
| IsLetterOrDigit        | 0.0323 ns | 0.0093 ns | 0.0087 ns | 9.37x faster |   2.94x |         - |          NA |