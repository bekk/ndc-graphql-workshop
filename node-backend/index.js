const { GraphQLServer } = require("graphql-yoga");
const characters = require("./data/characters.js");
const houses = require("./data/houses.js");

const Query = {
  characters: (root, args, context) => {
    return characters;
  },
  houses: (root, args, context) => {
    return houses;
  }
};

const Character = {
  siblings: (root, args, context) => {
    const siblings = root.related.filter(rel =>
      root.siblings.includes(rel.name)
    );
    return siblings.map(sib => characters.find(c => c.slug === sib.slug)._id);
  },
  house: (root, args, context) => {
    const house = houses.find(h => h.name === root.house);
    return house && house._id;
  },
  allegiances: (root, args, context) => {
    const allegiances = root.related.filter(rel =>
      root.allegiances.includes(rel.name)
    );
    return allegiances.map(
      sib => characters.find(c => c.slug === sib.slug)._id
    );
  },
  spouse: (root, args, context) => {
    const spouse = root.related.filter(rel => root.spouse.includes(rel.name));
    return spouse.map(sib => characters.find(c => c.slug === sib.slug)._id);
  },
  lovers: (root, args, context) => {
    const lovers = root.related.filter(rel => root.lovers.includes(rel.name));
    return lovers.map(sib => characters.find(c => c.slug === sib.slug)._id);
  }
};

const House = {
  image: (root, args, context) => {
    return root.logoURL;
  }
};

const resolvers = {
  Query,
  Character,
  House
};

const server = new GraphQLServer({
  typeDefs: "./schema.graphql",
  resolvers
});
server.start(() => console.log(`Server is running on http://localhost:4000`));
