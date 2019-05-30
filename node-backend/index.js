const { GraphQLServer } = require("graphql-yoga");
const characters = require("./data/characters.js");
const houses = require("./data/houses.js");
const castles = require("./data/castles.js");

const Query = {
  characters: (root, args, context) => {
    return characters;
  },
  character: (root, args, context) => {
    return characters.find(
      char => char.id === args.id || char.name === args.name
    );
  },
  houses: (root, args, context) => {
    return houses;
  },
  castles: (root, args, context) => {
    return castles;
  }
};

const Mutation = {
  pushFromWindow: (root, args, context) => {
    const char = characters.find(
      char => char.id === args.id || char.name === args.name
    );
    char.isHealthy = false;
    return char;
  }
};

const Character = {
  siblings: (root, args, context) => {
    return characters.filter(char => root.siblingIds.includes(char.id));
  },
  house: (root, args, context) => {
    return houses.find(h => h.id === root.houseId);
  },
  spouses: (root, args, context) => {
    return characters.filter(char => root.spouseIds.includes(char.id));
  },
  lovers: (root, args, context) => {
    return characters.filter(char => root.loverIds.includes(char.id));
  },
  isHealthy: (root, args, context) => {
    return root.isHealthy != false;
  }
};

const House = {
  allegiances: (root, args, context) => {
    return houses.filter(house => root.allegianceHouseIds.includes(house.id));
  },
  seats: (root, args, context) => {
    return castles.filter(castle => root.seatIds.includes(castle.id));
  }
};

const Castle = {
  rulers: (root, args, context) => {
    return houses.filter(house => root.rulerIds.includes(house.id));
  }
};

const resolvers = {
  Query,
  Mutation,
  Character,
  House,
  Castle
};

const server = new GraphQLServer({
  typeDefs: "./schema.graphql",
  resolvers
});
server.start(() => console.log(`Server is running on http://localhost:4000`));
