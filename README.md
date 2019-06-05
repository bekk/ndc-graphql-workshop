# GraphQL Workshop

## Introduction

(TODO KNA TEKSTEN) Most of us may be very familiar with creating REST APIs. GraphQL is a query language, created by Facebook with the purpose of building client applications based on intuitive and flexible syntax, for describing their data requirements and interactions. GraphQL was designed to solve one of the biggest drawbacks of REST-like APIs. A GraphQL service is created by defining types and fields on those types, then providing functions for each field on each type.

## Prerequisites

- TODO link til node beskrivelse
- TODO link til .NET beskrivelse

## Task 1 - Basic Queries

(TODO KNA) If you've seen a GraphQL query before, you know that the GraphQL query language is basically about selecting fields on objects

A query is built hierarchical 

```graphql
query {
  characters {
    id
  }
}
```

**a) Use the query above to list all character id's in GraphiQL**

The client decides which character fields it needs. It can ask for both id and name like this:

```graphql
query {
  characters {
    id
    name
  }
}
```
**b) Extend the the query to also list the `name` of each character.**

Nested queries can be used to find information about a characters siblings:

```graphql
query {
  characters {
    name,
    allegiances
    lovers {
      name
    }
  }
}
```

**c) Use a nested query to see the characters' siblings.

## Task 2 - Schema 

(TODO KNA) In GraphQL, the Schema manages queries and mutations, defining what is allowed to be executed in the GraphQL server. A schema defines a GraphQL API's type system. It describes the complete set of possible data (objects, fields, relationships, everything) that a client can access. Calls from the client are validated and executed against the schema. A client can find information about the schema via introspection. A schema resides on the GraphQL API server.

Every schema needs a root query type, defining the top level queries.

```graphql
  type Query {
    characters: [Character]
  }
```

The `characters` field is defined as a list of type `Character`. 

```graphql
type Character {
  id: ID!
  name: String
  allegiances: [String!]
  siblings: [Character!]
}
```

The `Character` type defines two fields of type `ID` and `String`. Both are one of the built in scalar types defined by GraphQL. A scalar type resolves to a single scalar object, which can't have sub-selections in a query. The scalar types are: 

- Int: A signed 32‐bit integer.
- Float: A signed double-precision floating-point value.
- String: A UTF‐8 character sequence.
- Boolean: true or false.
- ID: represents a unique identifier and is serialized in the same way as a String

For scalar types, you can just add a field to a type in your schema - and GraphQL will resolve it based on matching name in the data set. 

**a) Add the field `alligiances`to the `Character`type. Use GraphiQL to find alligiances of all characters.**

## Task 3 - Resolvers

(TODO KNA) A resolver is responsible for mapping the operation to actual function. Inside type Query, we have an operation called users. We map this operation to a function with the same name inside root. We will also create some dummy users for this functionality.

For the `Character` type, there is already defined one resolver - the one that resolved your query for siblings earlier.

```js
const Character = {
  siblings: (root) => {
      return characters.filter(character => root.siblingIds.includes(character.id));
    }
  }
```

All resolvers receives the `root` argument, which is the parent beeing resolved. To find all the siblings, the resolver filters all characters using the `siblingIds` list.

**a) Add resolvers for **

2. Legg på litt ekstra informasjon på hver karakter


### Add extra information on characters

- Utvid typedef med x og y
- Utvid typedef med objektet z

3. Finn Brad Stark
   - Lag en ny resolver som kan hente ut karakter basert på ID
   - Lag en ny spørring som henter ut Brad Start basert på IDen hans
4. Dytt Brad Stark ut av tårnet (Mutation)
   - Legg til en ny boolsk property på Character i typedef "isHealthy"
   - Bruk en mutation til å endre "isHealthy" på Brad Stark til "false"
5. Hent alle houses
   - Lag en ny resolver for å hente ut houses
   - Utvid House i typedef til å inneholde en liste med IDene til alle karakterene som "bor der"
6. Finn alle karakterer fra House Lannister
   - Lag en ny resolver
7. Gjør Geoffry til konge - Legg til feltet "titles" i Character som en liste av strings - Legg til "Protector of the realm", etc.. i titles til Geofrry
   Collapse
