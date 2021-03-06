import * as React from 'react';
import * as ReactDom from 'react-dom';
import { Switch, Route, Redirect } from 'react-router-dom';
import { Login } from './components/Login';
import { List } from './components/List';
import { User } from './components/User';
import { Redeem } from './components/Redeem';
import { Header } from './components/Header';
import Paths from './Utilities/PathUtility';
import RestService from './Services/RestService';

export default class Routes extends React.Component<any, any> {
    render() {
        return <Switch>
            <Route exact path={Paths.Login} component={Login} />
            <AuthRoute path={Paths.List} component={List} />
            <AuthRoute path={Paths.User} component={User} />
            <AuthRoute path={Paths.Redeem} component={Redeem} />
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
