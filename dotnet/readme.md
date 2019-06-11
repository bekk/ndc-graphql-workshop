## Prerequisites
* [.NET Core 2.1](https://dotnet.microsoft.com/download/dotnet-core/2.1)

## Setup

1. Navigate to the `GraphQLServer`-folder in your favorite terminal
2. Open the `dotnet.sln`-solution in your faviorite editor
3. Run it! 

## Project structure

The solution contains two projects: `GraphQLServer` and `GoT`. The `GraphQLServer`-project contains
a slim web server with a nifty GraphQL-middleware which handles most of the GraphQL-specific stuff for us. So we can focus on learning 
the GraphQL fundamentals first.  The server is also responsible for serving our GraphiQL UI.

The `GoT`-project is where we will be doing most of our work. The `GoTData`-class is our data repository. It is responsible for 
fetching and serializing the JSON-files in the `data`-folder. 

`GoTQuery` defines all the queries supported by our API. It also is responsible for handling arguments and the resolver functions.

`GotMutation` is similar to `GoTQuery` but contains all the mutations.

The `GoTTypes`-folder contains all our models. There is an important distinction between the `Character` and the `CharacterType`. The `Character` is the serialised character from our json-file but the `CharacterType` is the GraphQL-type provided by our API.
