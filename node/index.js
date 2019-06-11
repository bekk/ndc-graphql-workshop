const { GraphQLServer } = require("graphql-yoga");
const typeDefs = require("./schema.js");
const characters = require("./data/characters.js");

const Query = {
  characters: (root, args, context) => {
    return characters;
  }
};

const Character = {
  siblings: (root, args, context) => {
    return characters.filter(char => root.siblingIds.includes(char.id));
  }
};

const resolvers = {
  Query,
  Character
};

const server = new GraphQLServer({
  typeDefs,
  resolvers
});

server.start(() => console.log(`Server is running on http://localhost:4000`));
