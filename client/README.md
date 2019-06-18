# React instructions (client)

## Install Node.js

Install Node.js using your favourite package manager, or [download](https://nodejs.org/en/download/) it. The workshop is tested with version 12.1.0, but should also work for older (not to old) versions.

## Install dependencies

Open your terminal and navigate to the `client` folder. Then run

```bash
npm install
```

## Start development server

To start the server, run

```bash
npm run start
```

and open [http://localhost:3000](http://localhost:3000) in the browser. All changes will automatically reload when you change a src file

You are now ready to start doing the exercises.

## Project structure

We use [Apollo Client](https://www.apollographql.com/docs/react/) to consume data from our GraphQL server. The client is designed to help you quickly build a UI that fetches data with GraphQL.

- `src/index.js` is the main file of the client and is where Apollo and React are initialized. 

- `src/queries.js` contains all query definitions used to fetch data from our GraphQL server

- `src/Characters.js` displays a list of all Game of Thrones characters available

- `src/Character.js` is a detail view of a single character selected from the character list
 
## Solution folder

The folder `src-solution` contains a complete solution proposal for all tasks listed in the [workshop README](../README.md). You may copy content from `src-solution` to `src` if you prefer not to focus on client tasks. Be sure that queries listed in `queries.js` match your server side schema definition.