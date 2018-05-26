import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";
import PathUtility from '../Utilities/PathUtility';
import IdUtility from '../Utilities/IdUtility';

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
        let url = PathUtility.ApiAddress + PathUtility.ApiGames + "?id=" + IdUtility.getId();
        RestService.get(url).then(response => {
            if (response.status == 401) {
                RestService.logOut();
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
                    <label className="labelGameName">{this.props.name}</label>
                    <label className="labelGameReg">Registered: {this.props.registered}</label>
                </div>
                <div className="listItem-img flexGrw">
                    <img src={this.props.thumb} />
                </div>
            </div>
        );
    }
}