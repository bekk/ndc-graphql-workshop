# GraphQL Workshop

TODO: 
- Legg til isHealthy og titles i datasettet
- Kna tekster
- Lag scratch-branch (og fasit branch) 
- Lag node og .NET spesifikke READMEs for prerequisites. 
- Lag fasit for marry
- Lag ferdig intro for graphQL (THORSTEIN)

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

**c) Use a nested query to see the characters' siblings.**

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

The `!` behind `ID` simply means that the field is non-nullable. 

**a) Add the field `alligiances`to the `Character`type. Use GraphiQL to find alligiances of all characters.**

## Task 3 - Resolvers

(TODO KNA) A resolver is responsible for mapping the operation to actual function. Inside type Query, we have an operation called users. We map this operation to a function with the same name inside root. We will also create some dummy users for this functionality.

For the `Character` type, there is already defined one resolver - the one that resolved your query for siblings earlier.

```js
const Character = {
  siblings: (root, args) => {
      return characters.filter(character => root.siblingIds.includes(character.id));
    }
  }
```

All resolvers receives the `root` argument, which is the parent beeing resolved. To find all the siblings, the resolver filters all characters using the `siblingIds` list.

**a) Add lovers and spouses to `Character`. Remember to also add it to your schema**

Up until now we have queried all characters, but we want to be able to get one specific. The following query should return Bran Stark:

```graphql
query {
  character(name: "Bran Stark"){
    name
  }
}
```

To support this query you need to extend the `Query` type in your schema:

```graphql
type Query {
  characters: [Character]
  character(id: String, name: String): Character
  }
```

Now we will make use of the `args` argument. Adding a `character` resolver like below, will allow you to query a specific character by name.

```js
const Query = {
  characters: (root, args, context) => {
    return characters;
  },
  character: (root, args, context) => {
    return characters.find(
      char => char.name === args.name
    );
  }
};
```

**b) Add `House` to the API.**

```graphql
type House {
  id: ID!
  name: String
  words: String
  region: [String!]
  allegiances: [House!]
  members: [Character!]
}
```

**c) It should also be possible to find which house a character belongs to.**


## Task 4 - Mutations

(TODO KNA) So far we have been dealing with queries; operations to retrieve data. Mutations are the second main operation in GraphQL which deal with creating, deleting and updating of data. Let's focus on some examples of how to carry out mutations. For instance, we want to update a user with id==1 and change their age their name and age and return the new user details.

As with the `Query` type in your schema, you will need to add a `Mutation` type. Lets imagine you are Jaime Lannister, secrets are important to you - sometimes desperate actions are needed: 

```graphql
type Mutation {
  pushFromWindow(name: String!): Character
}
```

**a) Implement the pushFromWindow mutation. This includes changes to both schema and resolver. The push should set the isHealthy field to false for Bran Stark.** 

It is not just in Westeros the action is happening. Across the Narrow Sea, an important wedding is taking place. The ruggedly handsome Khal Drogo is marrying the beautiful Daenerys Targaryan. 

**b) Make sure the wedding takes place. Create a mutation taking two names as arguments.**

```graphql
type Mutation {
  pushFromWindow(name: String!): Character
  marry(spouseName1: String!, spouseName2: String!): [Character]
}
```

Allthough the claim may be poor, Joffrey Baratheon manages to be crowned King of the Seven Kingdoms. We have to make sure our API keeps track. 

**c) Give King Joffrey the titles: the First of His Name, King of the Andals and the First Men, Lord of the Seven Kingdoms, and Protector of the Realm**

## Bonus task 

Add seat to all the the houses. To do this you need to define a `Castle` type with the necessary fields (check the data set). 

