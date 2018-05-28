import './css/global.css';
import './css/form.css';
import './css/list.css';
import 'bootstrap';
import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { AppContainer } from 'react-hot-loader';
import { BrowserRouter } from 'react-router-dom';
import Routes from './routes';

function renderApp() {
    ReactDOM.render(
        <AppContainer>
            <BrowserRouter>
                <Routes />
            </BrowserRouter>
        </AppContainer>,
        document.getElementById('react-app')
    );
}

renderApp();

// Allow Hot Module Replacement
if (module.hot) {
    module.hot.accept( () => {
        renderApp();
    });
}
