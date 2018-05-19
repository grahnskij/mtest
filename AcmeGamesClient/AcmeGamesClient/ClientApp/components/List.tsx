import * as React from 'react';
import { RouteComponentProps } from 'react-router';

export class List extends React.Component<RouteComponentProps<{}>, {}> {
    constructor() {
        super();
    }

    public render() {
        return <div>
            list
        </div>;
    }
}