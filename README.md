# fruitpal

[![N|Solid](https://statestitle.com/wp-content/themes/statestitle/dist/images/logo.svg)](https://nodesource.com/products/nsolid)

Fruitpal is a nuget package for fruit traders, which allows a trader to understand the full cost of buying fruit from various countries of origin.

### Installation

Fruitpal is very easy to install.

Go to your Package Manager Console in Visual Studio and run:

```sh
PM> Install-Package StatesTitle.Fruitpal.Nuget -Version 1.0.1
```
### Tech

Fruitpal is built on top of:

* [Netstandard2.0] - Net framework standard version 2.0
* [Newtonsoft] - Json library 
* [Microsoft.Net.Test.Sdk] - Framework used for the Unit Tests.
* [Moq] - Library to mock objects (used in the Unit Tests)

### Source Code

Fruitpal Source Code is delivered with the following projects:

| Project | Description |
| ------- | ------- |
| Fruitpal.Client | A console application that uses the Nuget Package directly pulled from nuget.org |
| Fruitpal.Nuget | The actual Nuget Package implementation. |
| Fruitpal.Test | The Unit Tests Project to test the Nuget Package Functionality |

