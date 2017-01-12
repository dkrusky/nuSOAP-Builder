# nuSOAP-Builder
Easily build SOAP api's using php and nusoap and build .NET code to match.

## Purpose

This application is designed to take a lot of the pain away from building a soap api using php. Even with NuSOAP, writing a SOAP api is extremely repetetive (and boring), and also prone to error when cascading data types and so on.
The other thing that is common with an API, is usually you are going to connect to a database and use the input recieved to generate a response from the database. Although not perfect, this takes a lot of the grunt work out of repetetive database stuff as well.

We wrote this as it was consuming quite a lot of time to write complex functional SOAP api's with complex cascading data types. After writing this software, we tested on one of our larger projects that took roughly 70 hours to do, and this cut that time down to around 15 minutes, most of which was spent just plugging in our SQL queries and about 5 minutes was adding the data types, methods, and structures.

## Distribution

You are free to distribute and/or modify this code so long as you give clear attribution to [MicroVB](https://www.microvb.com) as the original author.

## Dependancies

* [NuSOAP - SOAP Toolkit for PHP](https://sourceforge.net/projects/nusoap/) (included)
* FastColoredTextBox [nuget] - heavily modified, so included the binary in `/compiled/`
* [Telerik UI for WinForms](http://www.telerik.com/products/winforms.aspx) (commercial product)
* [DevExpress WinForms](https://www.devexpress.com/products/net/controls/winforms/) (commercial product)
* System.Data.SQLite.Core.1.0.94.0 [nuget]
* MySQL.NET.6.6.4 [nuget]

## Screenshots

#### Add Function/Method Screen

![image](https://cloud.githubusercontent.com/assets/11585632/21906363/0daf152a-d8d9-11e6-930f-eb8a975077d9.png)

* Name - the name of the method
* Returns - the data type you wish it to return. Lists custom data types as well as standard SOAP types.
* Auth Level - when used in conjunction with the SQL table for API keys, this allows you to restrict an api keys' use of methods by the level you assign to the api key. This sets the required minimum level an api key must have to be able to call this method.
* Description - this goes into the comments section in phpdoc format
* Field Name - the name of the parameter you wish to accept.
* Field Type - the data type of the parameter you wish to accept
* Parameter List - a list of the parameters you have added using: Field Name + Field Type + [Add]
* Create method for this function in WSDL - if checked, will create the necessary WSDL for the method. if not checked, it will ceate it as a normal php function.
* Add Database Code - if checked allows you to use the query builder to generate the starter code for select/etc. The code generated uses mysqli prepared statements.

#### Method Added

![image](https://cloud.githubusercontent.com/assets/11585632/21905997/8071df36-d8d7-11e6-9b89-7538a65add82.png)

*The SQL starter code inserted was done with the helper while adding the method*

#### Add Type

![image](https://cloud.githubusercontent.com/assets/11585632/21906741/814036a8-d8da-11e6-82d0-538c8e178a66.png)

*If you intend to use the "Create an array of this type" feature, it is recommended you use a Name which is the singular form of what you want a collection of. The generator will automatically create the plural form as a collection of this object*

* Name - the name of the type.
* Field Name - the name of a field you wish to add to this type.
* Field Type - the data type of the field you wish to add to this type.
* Create an array of this type - when checked it will create two WSDL types, one by the name you set (eg Client), and a second one which is a collection of this type adding an `s` to the end (eg Clients)

#### Type Added

![image](https://cloud.githubusercontent.com/assets/11585632/21906288/af4d4cb8-d8d8-11e6-9890-385236a51e42.png)

*This is a single entry for a type, and a collection of that type. It creates `Client` and `Clients` (an array of `Client`)*

## Caveats

Presently, this is a one-way only process. While it does store what is generated in a sqlite database which you can load and add to later, it can not load from edited code. It will write any changes you make to the source manually within the code editor section, but it can not load and parse this back in (hence the use of sqlite to store the core information). Also, once a method/type is added, there is no way to remove it. Fortunately it is very easy and fast to just start over - you will still save LOTS of time !!
