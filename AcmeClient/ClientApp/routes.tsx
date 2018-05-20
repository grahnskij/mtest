import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Switch, Route, Redirect } from 'react-router-dom';
import { Home } from './components/Home';
import { Login } from './components/Login';
import { List } from './components/List';
import { User } from './components/User';
import { Header } from './components/Header';
import Paths from './Utilities/PathUtility';
import RestService from './Services/RestService';

export default class Routes extends React.Component<any, any> {
    render() {
        return <Switch>
            <Route exact path={Paths.Login} component={Login} />
            <AuthRoute path={Paths.Home} component={Home} />
            <AuthRoute path={Paths.List} component={List} />
            <AuthRoute path={Paths.User} component={User} />
        </Switch>
    }
}

const AuthRoute = ({ component: Component, ...rest }: { component: any, path: string, exact?: boolean }) => (
    <Route {...rest} render={props => (
        RestService.AmISignedIn() ? (
            <div>
                <Header {...props}/>
                    <Component {...props} />
            </div>
        ) : (
                <Redirect to={{
                    pathname: Paths.Login,
                    state: { from: props.location }
                }} />
            )
    )} />
);
