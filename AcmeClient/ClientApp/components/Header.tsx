import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export class Header extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }

    public render() {
        return (
            <div className="header">
                <a className="headerLink" href="/List">LIST</a>
                <a className="headerLink" href="/User">USER INFO</a>
                <a className="headerLink" href="/User">REDEEM</a>
                <a className="headerLink" href="/List">SIGN OUT</a>
            </div>
        );
    }
}