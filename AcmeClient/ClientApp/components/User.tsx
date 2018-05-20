import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";

interface userState {
    redirect: boolean;
    firstname: string;
    lastname: string;
    birth: string;
    password: string;
    email: string;
    role: string;
}

export class User extends React.Component<RouteComponentProps<{}>, userState> {
    constructor() {
        super();

        this.state = {
            redirect: false,
            firstname: "",
            lastname: "",
            birth: "",
            password: "",
            email: "",
            role: ""
        }
    }

    updateUser(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
    }

    componentDidMount() {
        RestService.userData().then(response => {
            if (response.status !== 200) {
                this.setState({ redirect: true });
            } else {
                response.json().then((data) => {
                    this.setState({
                        firstname: data.firstname,
                        lastname: data.lastname,
                        birth: data.birth,
                        email: data.email,
                        password: data.password,
                        role: data.role
                    });
                });
            }
        })
    }

    public render() {
        if (this.state.redirect) { return <Redirect to='/' /> }
        let errorLabel = null;
        return <div>
            <div className="userContainer">
                <form className="formContainer" onSubmit={(e) => this.updateUser(e)}>
                    {errorLabel}
                    <input
                        value={this.state.email}
                        onChange={(e) => { this.setState({ email: e.target.value }) }}
                        type="email"
                        name="userEmail"
                        id="userEmailInput"
                        className="formInput"
                        placeholder="Email"
                        required />
                    <input
                        value={this.state.password}
                        onChange={(e) => { this.setState({ password: e.target.value }) }}
                        type="password"
                        name="userPassword"
                        id="userPasswordInput"
                        className="formInput"
                        placeholder="Password"
                        required />
                    <input
                        value={this.state.firstname}
                        onChange={(e) => { this.setState({ firstname: e.target.value }) }}
                        type="text"
                        name="userFirstname"
                        id="userFirstnameInput"
                        className="formInput"
                        placeholder="First name"
                        required />
                    <input
                        value={this.state.lastname}
                        onChange={(e) => { this.setState({ lastname: e.target.value }) }}
                        type="text"
                        name="userLastname"
                        id="userLastnameInput"
                        className="formInput"
                        placeholder="Last name"
                        required />
                    <input
                        value={this.state.birth}
                        type="text"
                        name="userBirth"
                        id="birthInput"
                        className="formInput"
                        placeholder="Date of birth"
                        disabled />
                    <input
                        value={this.state.role}
                        type="text"
                        name="userRole"
                        id="roleInput"
                        className="formInput"
                        placeholder="Userrole"
                        disabled />
                    <button className="formButton" type="submit">Update</button>
                </form>
            </div>
        </div>;
    }
}