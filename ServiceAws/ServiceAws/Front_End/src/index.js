import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import 'bootstrap/dist/css/bootstrap.min.css';
import App from './App';
//import LoginView from './component/login/loginView';
import registerServiceWorker from './registerServiceWorker';
ReactDOM.render(
    /*<LoginView />,*/
    <App />,
    document.getElementById('root'));
//ReactDOM.render(<App />, document.getElementById('root'));
registerServiceWorker();

//const toto = "totototototototototototototototo";
