 ## Super Zapatos Site

This project contains the implementation of Super Zapatos Technical Test for ASP.NET Core 1.1. 

It is meant as a demonstration of the test sent to apply for a job and **not** for general use

## How is structured

The project was made using [Visual Studio 2015 Community](https://www.visualstudio.com/vs/community/) and the
[Omnisharp generator for ASP.NET](https://github.com/OmniSharp/generator-aspnet), Also 
[Visual Studio Code](https://code.visualstudio.com/) was used for implementing the web in 
[Angular2](https://angular.io)

The solution will load 4 projects:

### sz.web

This holds the implementation of the Super Zapatos site in [Angular2](https://angular.io), 
[ASP.NET MVC](https://www.asp.net/mvc) y [.NET CORE](https://www.microsoft.com/net/core)
to access you must go (in your local machine) to [http://localhost:61048/](http://localhost:61048/)

### sz.api

This holds the implementation of the Super Zapatos site in  
[ASP.NET MVC](https://www.asp.net/mvc) y [.NET CORE](https://www.microsoft.com/net/core)
For now it's unrestricted and without authorization (sorry). The address to access the api is
[http://localhost:62115/](http://localhost:62115/)

*Implemented API*

**List all Articles**
[http://localhost:62115/services/articles](http://localhost:62115/services/articles)

should return 
``` json
{
  "articles": [
    {
      "store_name": "Christies",
      "id": 1000002,
      "name": "Box",
      "description": "Schrodinger Box",
      "price": 150.15,
      "total_in_shelf": 100,
      "total_in_vault": 500
    },
    {
      "store_name": "Christies",
      "id": 1000003,
      "name": "Toy",
      "description": "Cat",
      "price": 40.15,
      "total_in_shelf": 100,
      "total_in_vault": 500
    },
    {
      "store_name": "Apple Store",
      "id": 1000004,
      "name": "Dog",
      "description": "Dog Puff",
      "price": 140.15,
      "total_in_shelf": 100,
      "total_in_vault": 500
    }
  ],
  "total_elements": 3,
  "success": true
}
````

**List one Articles**
[http://localhost:62115/services/articles/1000002](http://localhost:62115/services/articles/1000002)

should return 
``` json
{
  "article": {
    "store_name": "Christies",
    "id": 1000002,
    "name": "Box",
    "description": "Schrodinger Box",
    "price": 150.15,
    "total_in_shelf": 100,
    "total_in_vault": 500
  },
  "success": true
}
````

**List Articles by store**
[http://localhost:62115/services/articles/stores/1000002](http://localhost:62115/services/articles/stores/1000002)

should return 
``` json
{
  "articles": [
    {
      "id": 1000004,
      "name": "Dog",
      "description": "Dog Puff",
      "price": 140.15,
      "total_in_shelf": 100,
      "total_in_vault": 500
    }
  ],
  "total_elements": 1,
  "success": true
}
````
 
**Add Article (POST)**
[http://localhost:62115/services/articles/](http://localhost:62115/services/articles/)

with a entry like
``` json
{
    "store_id": "100001",
    "id": 0,
    "name": "Box",
    "description": "Schrodinger Box",
    "price": 150.15,
    "total_in_shelf": 100,
    "total_in_vault": 500  
}
````

should return 
``` json
{
  "article": {
    "store_name": "Christies",
    "id": 1000002,
    "name": "Box",
    "description": "Schrodinger Box",
    "price": 150.15,
    "total_in_shelf": 100,
    "total_in_vault": 500
  },
  "success": true
}
````

**Update Article (PUT)**
 [http://localhost:62115/services/articles/1000002](http://localhost:62115/services/articles/1000002)

similar to before only that you should supply and existent id, in this case *1000002*

with a entry like (suppose that this entry is an updated document )
``` json
 {
    "store_id": "100001",
    "id": 1000002,
    "name": "Box",
    "description": "Schrodinger Box",
    "price": 150.15,
    "total_in_shelf": 100,
    "total_in_vault": 500
  }
````

should return 
``` json
{
  "article": {
    "store_name": "Christies",
    "id": 1000002,
    "name": "Box",
    "description": "Schrodinger Box",
    "price": 150.15,
    "total_in_shelf": 100,
    "total_in_vault": 500
  },
  "success": true
}
````

**List all Stores**
[http://localhost:62115/services/stores](http://localhost:62115/services/stores)

should return 
```json
{
  "stores": [
    {
      "id": 1000001,
      "name": "Christies",
      "address": "5th Avenue, New York"
    },
    {
      "id": 1000002,
      "name": "Apple Store",
      "address": "5th Avenue, New York"
    }
  ],
  "total_elements": 2,
  "success": true
}
```

**List one Store**
[http://localhost:62115/services/stores/1000001](http://localhost:62115/services/stores/1000001)

should return 
```json
{
  "store": {
    "id": 1000001,
    "name": "Christies",
    "address": "5th Avenue, New York"
  },
  "success": true
}
```

**Insert one Store(POST)**

with an entry like
```json
{
    "id": 0,
    "name": "Christies",
    "address": "5th Avenue, New York"
}
```

should return
```json
{
  "store": {
    "id": 1000001,
    "name": "Christies",
    "address": "5th Avenue, New York"
  },
  "success": true
}
```

**Update one Store(POST)**

similar to before only that you should supply and existent id, in this case *1000001*

with a entry like (suppose that this entry is an updated document )
```json
{
    "id": 1000001,
    "name": "Christies",
    "address": "5th Avenue, New York"
}
```

should return
```json
{
  "store": {
    "id": 1000001,
    "name": "Christies",
    "address": "5th Avenue, New York"
  },
  "success": true
}
```


### sz.dataprovider

This library is responsible to hold the connection to the database. It also include a static class
to populate some data at the beggining of the app. For this development it was used 
[Entity Framework](https://www.asp.net/entity-framework) and by default the In-Memory database so all
the data is volatile.

### sz.commons

Holds the common models to used by the dataprovider y the api.

## NOTES AND USAGE

This project doesn't contains (yet) the basic authentication feature requested. If you like to run the
project you could do it loading it in *Visual Studio* and pressing **RUN**. This should launch the sz.api
and the sz.web sites through the IIS-Express feature.

Another option could be [Docker](https://www.docker.com/)
```cmd
FROM microsoft/dotnet:1.1.0-sdk-projectjson

RUN apt-get update
RUN wget -qO- https://deb.nodesource.com/setup_4.x | bash -
RUN apt-get install -y build-essential nodejs

COPY . /app

WORKDIR /app

RUN ["dotnet", "restore"]
RUN ["dotnet", "build"]

EXPOSE 5000/tcp

CMD ["dotnet", "run", "--server.urls", "http://*:5000"]
```

Or if you want a cmd approach, over the main folder of the app

```cmd
dotnet restore
dotnet build
dotnet run
```








