const { GraphQLServer } = require("graphql-yoga");
const characters = require("./data/characters.js");

const Query = {
  characters: (root, args, context) => {
    return characters;
  }
};

const resolvers = {
  Query
};

const server = new GraphQLServer({
  typeDefs: "./schema.graphql",
  resolvers,
  context: request => {
    return {
      ...request
    };
  }
});
server.start(() => console.log(`Server is running on http://localhost:4000`));
