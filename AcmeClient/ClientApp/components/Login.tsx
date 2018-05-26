import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";
import PathUtility from '../Utilities/PathUtility';
import loginBody from '../Services/RestService'

interface loginState {
    email: string;
    password: string;
    redirect: boolean;
    info: string;
}

export class Login extends React.Component<RouteComponentProps<{}>, loginState> {
    constructor() {
        super();  

        this.state = {
            email : "",
            password: "",
            redirect: false,
            info: ""
        };
    }

    tryLogin(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        let body: loginBody = {
            EmailAddress: this.state.email,
            Password: this.state.password
        };

        let url = PathUtility.ApiAddress + PathUtility.ApiLogin;

        RestService.post(body, url, false).then(result => {
            if (result.status == 200) {
                result.json().then((data) => {
                    RestService.logIn(data.token, data.userAccountId);
                    this.setState({ redirect: true });
                });
            } else if (result.status == 401) {
                this.setState({ info: "Incorrect email or password!" });
            } else {
                this.setState({ info: "Something unforseen went wrong on the backend!" });
            }
        }); 
    }

    public render() {
        if (this.state.redirect) { return <Redirect to='/List' /> }
        let infoLabel = (this.state.info !== "") ? <label className="infoLabel fail">{this.state.info}</label> : null;

        return (
            <div className="loginContainer">
                <form className="formContainer" onSubmit={(e) => this.tryLogin(e)}>  
                    {infoLabel}
                    <input
                        onChange={(e) => { this.setState({ email: e.target.value }) }}
                        type="email"
                        name="email"
                        id="emailInput"
                        className="formInput"
                        placeholder="Email"
                        autoFocus
                        required />    
                    <input
                        onChange={(e) => { this.setState({ password: e.target.value }) }}
                        type="password" 
                        name="password" 
                        id="passwordInput" 
                        className="formInput" 
                        placeholder="Password" 
                        required />
                    <button className="formButton" type="submit">Log in</button>
                </form>
            </div>
        );
    }
}