const gql = require("graphql-tag");

module.exports = gql`
  type Query {
    characters: [Character!]
    character(id: String, name: String): Character
    houses: [House!]
    house(id: String, name: String): House
    castles: [Castle!]
    castle(id: String, name: String): Castle
  }

  type Mutation {
    pushFromWindow(name: String!): Character
    marry(spouseName1: String!, spouseName2: String!): [Character!]
    addTitle(name: String!, title: String!): Character
  }

  type Character {
    id: ID!
    slug: String!
    name: String
    siblings: [Character!]
    house: House
    allegiances: [String!]
    spouses: [Character!]
    lovers: [Character!]
    image: String
    isHealthy: Boolean
    titles: [String!]
  }

  type House {
    id: ID!
    name: String
    words: String
    seats: [Castle!]
    region: [String!]
    allegiances: [House!]
    image: String
    members: [Character!]
  }

  type Castle {
    id: ID!
    name: String
    location: String
    religion: [String!]
    rulers: [House!]
  }
`;
