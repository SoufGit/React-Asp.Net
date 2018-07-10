import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import { LoginContainer } from './component'

class App extends Component {
  render() {
    return (
      <div className="App">
        <header className="App-header">
          <h1 className="App-title">Welcome to React and Asp.Net application</h1>
            </header>
                <LoginContainer />
      </div>
    );
  }
}

export default App;
