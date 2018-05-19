import * as React from 'react';
import * as ReactDOM from 'react-dom';
import { Switch, Route, Redirect } from 'react-router-dom'
import { Home } from './components/Home';
import { Login } from './components/Login';
import { List } from './components/List';
import Paths from './Utilities/PathUtility';
import RestService from './Services/RestService';

export default class Routes extends React.Component<any, any> {
    render() {
        return <Switch>
            <Route exact path={Paths.Login} component={Login} />
            <Route path="/kuk" component={List}/>
            <AuthRoute exact path={Paths.Home} component={Home} />
        </Switch>
    }
}

const AuthRoute = ({ component: Component, ...rest }: { component: any, path: string, exact?: boolean }) => (
    <Route {...rest} render={props => (
        RestService.AmISignedIn() ? (
            <div>
                <div className="container">
                    <Component {...props} />
                </div>
            </div>
        ) : (
                <Redirect to={{
                    pathname: Paths.Login,
                    state: { from: props.location }
                }} />
            )
    )} />
);
