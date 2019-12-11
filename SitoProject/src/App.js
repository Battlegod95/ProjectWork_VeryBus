import React from 'react';
import './App.css';
import Dashboard from './Dashboard.js';
import Linea2 from './Linea2'
import Linea3 from './Linea3'

import {
  BrowserRouter as Router,
  Switch,
  Route,
  Link
} from "react-router-dom";

function App() {
  return (
    <div className="App">

      <Router>
        <div>
          <div id='line'>
            <div id='textline'>
              <Link className='linea1' to="/Linea1">Linea1</Link>



              <Link className='linea2' to="/Linea2">Linea2</Link>



              <Link className='linea3' to="/Linea3">Linea3</Link>
            </div>
          </div>



          {/* A <Switch> looks through its children <Route>s and
            renders the first one that matches the current URL. */}
          <Switch>
            <Route path="/Linea1">
              <Dashboard></Dashboard>
            </Route>
            <Route path="/Linea2">
              <Linea2></Linea2>
            </Route>
            <Route path="/Linea3">
              <Linea3></Linea3>
            </Route>
          </Switch>
        </div>
      </Router>



    </div>
  );
}

export default App;
