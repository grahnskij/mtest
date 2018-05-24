import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";
import IdUtility from '../Utilities/IdUtility';

interface userState {
    redirect: boolean;
    firstname: string;
    lastname: string;
    birth: string;
    oldPassword: string;
    newPassword: string;
    confirmPassword: string;
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
            oldPassword: "",
            newPassword: "",
            confirmPassword: "",
            email: "",
            role: ""
        }
    }

    updateUser(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        let payload = {
            userAccountId : IdUtility.getId(),
            firstname : this.state.firstname,
            lastname : this.state.lastname,
            birth : this.state.birth,
            email : this.state.email,
            role : this.state.role,
            newPassword : this.state.newPassword,
            confirmPassword : this.state.confirmPassword,
            oldPassword : this.state.oldPassword
        };
        RestService.updateUserData(payload).then(response => {
            console.log(response);
            this.setState({
                oldPassword: "",
                newPassword: "",
                confirmPassword: ""
            });
        });
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
                        oldPassword: "",
                        newPassword: "",
                        confirmPassword: "",
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
                    <input
                        value={this.state.oldPassword}
                        onChange={(e) => { this.setState({ oldPassword: e.target.value }) }}
                        type="password"
                        name="userOldPassword"
                        id="userOldPasswordInput"
                        className="formInput"
                        placeholder="Old password"
                        required />
                    <input
                        value={this.state.newPassword}
                        onChange={(e) => { this.setState({ newPassword: e.target.value }) }}
                        type="password"
                        name="userNewPassword"
                        id="userNewPasswordInput"
                        className="formInput"
                        placeholder="New password"
                        required />
                    <input
                        value={this.state.confirmPassword}
                        onChange={(e) => { this.setState({ confirmPassword: e.target.value }) }}
                        type="password"
                        name="userConfirmPassword"
                        id="userConfirmPasswordInput"
                        className="formInput"
                        placeholder="Confirm password"
                        required />
                    <button className="formButton" type="submit">Update</button>
                </form>
            </div>
        </div>;
    }
}