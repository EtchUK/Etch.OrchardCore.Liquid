# Etch.OrchardCore.Liquid

Module for [Orchard Core](https://github.com/OrchardCMS/OrchardCore) that provides a collection of helpful Liquid filters.

## Build Status

[![Build Status](https://secure.travis-ci.org/etchuk/Etch.OrchardCore.Liquid.png?branch=master)](http://travis-ci.org/etchuk/Etch.OrchardCore.Liquid) [![NuGet](https://img.shields.io/nuget/v/Etch.OrchardCore.Liquid.svg)](https://www.nuget.org/packages/Etch.OrchardCore.Liquid)
## Orchard Core Reference

This module is referencing the RC1 build of Orchard Core ([`1.0.0-rc2-13450`](https://www.nuget.org/packages/OrchardCore.Module.Targets/1.0.0-rc2-13450)).


## Features

### Ordinal Dates

Format a date into a Month Date Year format, providing the correct suffix for the date.

| Input | Usage | Output | 
|- |- |- |
| 01/06/2021 14:11:57 | {{ 01/12/2020 14:11:57 \| ordinal_date }} | June 1st 2021 |
| 22/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_date }} | June 22nd 2021 |
| 03/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_date }} | June 3rd 2021 |
| 11/06/2021 14:11:57 | {{ 28/06/2021 14:11:57 \| ordinal_date }} | June 11th 2021 |

This filter also supports being passed date fields from the content item itself, such as `{{ Model.Content.CreatedUtc | ordinal_date }}`
