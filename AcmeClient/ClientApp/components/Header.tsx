import * as React from 'react';
import { RouteComponentProps } from 'react-router-dom';

export class Header extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }

    public render() {
        return (
            <div className="header">
                <a className="headerLink" href="/List">List</a>
                <a className="headerLink" href="/User">User info</a>
                <a className="headerLink" href="/List">Sign out</a>
            </div>
        );
    }
}