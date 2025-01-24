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

### `IsDigit()`
| Method         | Mean      | Error     | StdDev    | Median    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|--------------- |----------:|----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| IsDigitBuiltIn | 0.2469 ns | 0.0234 ns | 0.0219 ns | 0.2360 ns | baseline |         |         - |          NA |
| IsDigit        | 0.0094 ns | 0.0108 ns | 0.0101 ns | 0.0058 ns |       NA |      NA |         - |          NA |

### `ToUpperInvariant()`
| Method                  | Mean      | Error     | StdDev    | Median    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|------------------------ |----------:|----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| ToUpperInvariantBuiltIn | 0.2664 ns | 0.0210 ns | 0.0197 ns | 0.2629 ns | baseline |         |         - |          NA |
| ToUpperInvariant        | 0.0013 ns | 0.0029 ns | 0.0027 ns | 0.0000 ns |       NA |      NA |         - |          NA |

### `ToLowerInvariant()`
| Method                  | Mean      | Error     | StdDev    | Median    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|------------------------ |----------:|----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| ToLowerInvariantBuiltIn | 0.2755 ns | 0.0188 ns | 0.0175 ns | 0.2796 ns | baseline |         |         - |          NA |
| ToLowerInvariant        | 0.0018 ns | 0.0041 ns | 0.0034 ns | 0.0000 ns |       NA |      NA |         - |          NA |

### `IsLowerFast()`
| Method         | Mean      | Error     | StdDev    | Median    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|--------------- |----------:|----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| IsLowerBuiltIn | 0.2417 ns | 0.0292 ns | 0.0259 ns | 0.2376 ns | baseline |         |         - |          NA |
| IsLowerFast    | 0.0145 ns | 0.0193 ns | 0.0161 ns | 0.0097 ns |       NA |      NA |         - |          NA |

### `IsUpperFast()`
| Method         | Mean      | Error     | StdDev    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|--------------- |----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| IsUpperBuiltIn | 0.2450 ns | 0.0121 ns | 0.0114 ns | baseline |         |         - |          NA |
| IsUpperFast    | 0.0238 ns | 0.0228 ns | 0.0190 ns |       NA |      NA |         - |          NA |

### `IsWhiteSpace()`

| Method          | Mean      | Error     | StdDev    | Median    | Ratio    | RatioSD | Allocated | Alloc Ratio |
|---------------- |----------:|----------:|----------:|----------:|---------:|--------:|----------:|------------:|
| IsWhiteSpaceBuiltIn | 0.2332 ns | 0.0304 ns | 0.0237 ns | 0.2276 ns | baseline |         |         - |          NA |
| IsWhiteSpace    | 0.0033 ns | 0.0073 ns | 0.0061 ns | 0.0000 ns |       NA |      NA |         - |          NA |