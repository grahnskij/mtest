import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }

    public render() {
        return <div>
            hejdo
        </div>;
    }
}