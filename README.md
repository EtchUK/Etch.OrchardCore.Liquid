# Etch.OrchardCore.Liquid

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that provides a collection of helpful Liquid filters.

## Build Status

[![NuGet](https://img.shields.io/nuget/v/Etch.OrchardCore.Liquid.svg)](https://www.nuget.org/packages/Etch.OrchardCore.Liquid)

## Orchard Core Reference

This module is referencing a stable build of Orchard Core ([`1.7.2`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.7.2)).

## Installing

This module is available on [NuGet](https://www.nuget.org/packages/Etch.OrchardCore.Liquid). Add a reference to your Orchard Core web project via the NuGet package manager. Search for "Etch.OrchardCore.Menu", ensuring include prereleases is checked.

Alternatively you can [download the source](https://github.com/etchuk/Etch.OrchardCore.Liquid/archive/master.zip) or clone the repository to your local machine. Add the project to your solution that contains an Orchard Core project and add a reference to Etch.OrchardCore.Liquid.

## Usage

Enabled the "Etch Liquid Filters" feature, which will make the additional Liquid functionality available.

## Features

### Environment

Creates an `Environment` object that is available within the Liquid templates to expose enviroment properties

`IsDeveloment` - Returns `true` if current host environment name is "Development"
`IsStaging` - Returns `true` if current host environment name is "Staging"
`IsProduction` - Returns `true` if current host environment name is "Production"

Below is a usage example.

```
{% if Environment.IsDevelopment %}
    <p>This is a development environment.</p>
{% endif %}
```

### Ordinal Dates

Format a date into a Month Date Year format, providing the correct suffix for the date.

| Input               | Usage                                     | Output         |
| ------------------- | ----------------------------------------- | -------------- |
| 01/06/2021 14:11:57 | {{ 01/12/2020 14:11:57 \| ordinal_date }} | June 1st 2021  |
| 22/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_date }} | June 22nd 2021 |
| 03/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_date }} | June 3rd 2021  |
| 11/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_date }} | June 11th 2021 |

This filter also supports being passed date fields from the content item itself, such as `{{ Model.Content.CreatedUtc | ordinal_date }}`

### Ordinal Day

Return only the day part of a date, complete with the correct suffix for the date.

| Input               | Usage                                    | Output |
| ------------------- | ---------------------------------------- | ------ |
| 01/06/2021 14:11:57 | {{ 01/12/2020 14:11:57 \| ordinal_day }} | 1st    |
| 22/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_day }} | 22nd   |
| 03/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_day }} | 3rd    |
| 11/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_day }} | 11th   |

This filter also supports being passed date fields from the content item itself, such as `{{ Model.Content.CreatedUtc | ordinal_day }}`
