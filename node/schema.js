const gql = require("graphql-tag");

module.exports = gql`
  type Query {
    characters: [Character]
  }

  type Character {
    id: ID!
    name: String
    siblings: [Character]
  }
`;
