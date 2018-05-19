import './css/site.css';
import 'bootstrap';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import Routes from './routes';
function renderApp() {
    ReactDOM.render(React.createElement(AppContainer, null,
        React.createElement(BrowserRouter, null,
            React.createElement(Routes, null))), document.getElementById('react-app'));
}
renderApp();
// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept(function () {
        renderApp();
    });
}
//# sourceMappingURL=boot.js.map