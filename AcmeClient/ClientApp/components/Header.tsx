import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';
import PathUtility from '../Utilities/PathUtility';
import RestService from '../Services/RestService'

export class Header extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }

    public render() {
        return (
            <div className="header">
                <a className="headerLink" href={PathUtility.List}>LIST</a>
                <a className="headerLink" href={PathUtility.User}>USER INFO</a>
                <a className="headerLink" href={PathUtility.Redeem}>REDEEM</a>
                <a className="headerLink" href={PathUtility.Login} onClick={RestService.logOut} >SIGN OUT</a>
            </div>
        );
    }
}