import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";

interface listState {
    listItems: Array<JSX.Element>;
    redirect: boolean;
}

export class List extends React.Component<RouteComponentProps<{}>, listState> {
    constructor() {
        super();

        this.state = {
            listItems: [],
            redirect: false
        }
    }

    componentDidMount() {
        RestService.gamesList().then(response => {
            if (response.status !== 200) {
                this.setState({ redirect: true });
            } else {
                response.json().then((data) => {
                    let list: Array<JSX.Element> = [];
                    for (var index = 0; index < data.length; index++) {
                        let element = <ListItem key={index} name={data[index].game} thumb={data[index].thumb} registered={data[index].registered} />;
                        list.push(element);
                    }
                    this.setState({ listItems: list });
                });
            }
        })
    }

    public render() {
        if (this.state.redirect) { return <Redirect to='/' /> }
        return <div className="contentContainer">
            {this.state.listItems}
        </div>;
    }
}

interface listItemProps {
    name: string,
    thumb: string,
    registered: string
}

class ListItem extends React.Component<listItemProps, {}> {
    constructor() {
        super();
    }

    public render() {
        return (
            <div className="listItem">
                <div className="listItem-info">
                    <label className="flexGrw">{this.props.name}</label>
                    <label className="flexGrw">Registered: {this.props.registered}</label>
                </div>
                <div className="listItem-img flexGrw">
                    <img src={this.props.thumb} />
                </div>
            </div>
        );
    }
}