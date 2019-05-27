const { GraphQLServer } = require("graphql-yoga");
const characters = require("./data/characters.js");
const houses = require("./data/houses.js");
const castles = require("./data/castles.js");

const Query = {
  characters: (root, args, context) => {
    return characters;
  },
  houses: (root, args, context) => {
    return houses;
  },
  castles: (root, args, context) => {
    return castles;
  }
};

const Character = {
  siblingIds: (root, args, context) => {
    const siblings = root.related.filter(rel =>
      root.siblings.includes(rel.name)
    );
    return siblings.map(sib => characters.find(c => c.slug === sib.slug)._id);
  },
  houseId: (root, args, context) => {
    const house = houses.find(h => h.name === root.house);
    return house && house._id;
  },
  spouseIds: (root, args, context) => {
    const spouse = root.related.filter(rel => root.spouse.includes(rel.name));
    return spouse.map(sib => characters.find(c => c.slug === sib.slug)._id);
  },
  loverIds: (root, args, context) => {
    const lovers = root.related.filter(rel => root.lovers.includes(rel.name));
    return lovers.map(sib => characters.find(c => c.slug === sib.slug)._id);
  }
};

const House = {
  id: (root, args, context) => {
    return root._id;
  },
  image: (root, args, context) => {
    return root.logoURL;
  },
  allegionHouseIds: (root, args, context) => {
    return houses
      .filter(house => root.allegiance.includes(house.name))
      .map(alg => alg._id);
  },
  seatIds: (root, args, context) => {
    return castles
      .filter(castle => root.seat.includes(castle.name))
      .map(castle => castle._id);
  }
};

const Castle = {
  id: (root, args, context) => {
    return root._id;
  },
  rulerIds: (root, args, context) => {
    return houses.filter(h => root.rulers.includes(h.name)).map(c => c._id);
  }
};

const resolvers = {
  Query,
  Character,
  House,
  Castle
};

const server = new GraphQLServer({
  typeDefs: "./schema.graphql",
  resolvers
});
server.start(() => console.log(`Server is running on http://localhost:4000`));
