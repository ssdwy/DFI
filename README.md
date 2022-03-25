# C#/SQLite Gewächshausverwaltung

## Description
A project assignment from the Datenbanken für Ingenieuranwendungen course in TU Darmstadt. Develop a WPF/C#.NET programme based on the implemented database. 

## function characteristics
Reads locally selected sql files on greenhouse management. Deleting, adding and modifying plant data in the database for the greenhouses. Modifying the information of the gardener responsible for the greenhouse. Images representing the temperature and humidity of a plant's recent life. A one-button function is also provided to automatically adjust the plants in the database to their optimum habitat according to their temperature and humidity characteristics.

## NuGet packages
### ADO.NET
The task of the classes is the database connection and data storage in the working memory. For this purpose, there are classes that establish a connection to a database , classes that represent tables in the working memory and make it possible to work with them and classes that stand for entire databases in the working memory
### Dapper
Dapper is an object-relational mapping (ORM) product for theMicrosoft.NET platform: it provides a framework for mapping a class model (domain model) to a traditional relational database.

## Use case diagram
![image](https://user-images.githubusercontent.com/77725215/160159024-18f1b8ee-c52e-45a0-8e2f-536efa7fba49.png)

## Class diagram
![image](https://user-images.githubusercontent.com/77725215/160159212-27570fe0-7526-4541-91f8-a53f78eb8498.png)
