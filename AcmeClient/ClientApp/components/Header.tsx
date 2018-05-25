import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import PathUtility from '../Utilities/PathUtility';
import IdUtility from '../Utilities/IdUtility';
import TokenUtility from '../Utilities/TokenUtility';

export class Header extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }

    logOut() {
        IdUtility.removeId();
        TokenUtility.removeToken();
    }

    public render() {
        return (
            <div className="header">
                <a className="headerLink" href={PathUtility.List}>LIST</a>
                <a className="headerLink" href={PathUtility.User}>USER INFO</a>
                <a className="headerLink" href={PathUtility.Redeem}>REDEEM</a>
                <a className="headerLink" href={PathUtility.Login} onClick={this.logOut} >SIGN OUT</a>
            </div>
        );
    }
}