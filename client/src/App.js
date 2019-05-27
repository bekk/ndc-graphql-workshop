import React from 'react';
import { BrowserRouter, Route, Switch } from 'react-router-dom';
import './App.css';
import Characters from './Characters';
import Character from './Character';

const App = () => {
  return (
      <BrowserRouter basename="/">
        <>
          <main className="main">
            <Switch>
              <Route path="/character/:id" component={Character}/>
              <Route path="/" component={Characters}/>
            </Switch>
          </main>
        </>
      </BrowserRouter>
  );
};

export default App;