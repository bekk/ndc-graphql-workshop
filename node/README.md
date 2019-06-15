## Node instructions

### Install Node.js

Install Node.js using your favourite package manager, or [download](https://nodejs.org/en/download/) it. The workshop is tested with version 12.1.0, but should also work for older (not to old) versions.

### Install dependencies

Open your terminal and navigate to the `node` folder. Then run

```bash
npm install
```

### Start GraphQL server

To start the server, run

```bash
npm run start
```

and open [http://localhost:4000](http://localhost:4000) in the browser. All changes to the API will restart the server.

You are now ready to start doing the exercises.

### Project structure

We use the [graphql-yoga](https://github.com/prisma/graphql-yoga), which means that we can focus on the functional parts of a GraphQL server.

To solve the exercises, you only need to make changes to `index.js` and `schema.graphql`.

- `index.js` includes the setup for the GraphQL server, and the implementation of the resolvers. We will use an in memory database, which includes all the files in the `node/data` folder. Import the data needed as done with `characters` in `index.js`. Remember that all changes to the API will restart the server, which means that the in-memory database will be reset as well.

- `schema.js` includes the GraphQL schemas for our API. All changes must be done within the `gql` template string. If there is a mismatch between the resolvers in `index.js` and the schema, the project will not compile.

### IDE

If you do not have a preferred IDE for node, you can download [vscode](https://code.visualstudio.com/download). There are multiple extensions available to get GraphQL syntax highlighting, for example https://marketplace.visualstudio.com/items?itemName=Prisma.vscode-graphql.
