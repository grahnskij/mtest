import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";
import userBody from "../Services/RestService";
import IdUtility from '../Utilities/IdUtility';
import PathUtility from '../Utilities/PathUtility';

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
    info: string;
    status: string;
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
            role: "",
            info: "",
            status: ""
        }
    }

    updateUser(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        let body: userBody = {
            userAccountId : IdUtility.getId(),
            firstname : this.state.firstname,
            lastname : this.state.lastname,
            email : this.state.email,
            newPassword : this.state.newPassword,
            confirmPassword : this.state.confirmPassword,
            oldPassword : this.state.oldPassword
        };
        let url = PathUtility.ApiAddress + PathUtility.ApiUser;

        RestService.put(body, url).then(response => {
            if (response.status == 401) {
                RestService.logOut();
                this.setState({ redirect: true });
            } else if (response.status == 200) {
                this.setState({
                    oldPassword: "",
                    newPassword: "",
                    confirmPassword: "",
                    info: "User data updated!",
                    status : "200"
                });
            }
            else if (response.status == 400) {
                this.setState({
                    oldPassword: "",
                    newPassword: "",
                    confirmPassword: "",
                    info: "Operation failed, data incorrect or missing",
                    status: "400"
                });
            }
        });
    }

    componentDidMount() {
        let url = PathUtility.ApiAddress + PathUtility.ApiUser + "?id=" + IdUtility.getId();
        RestService.get(url).then(response => {
            if (response.status == 401) {
                RestService.logOut();
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
        let statusClass = (this.state.status == "200") ? "infoLabel success" : "infoLabel fail";
        let info = (this.state.info != "") ? <label className={statusClass}>{this.state.info}</label> : null;
        return <div>
            <div className="userContainer">
                <form className="formContainer" onSubmit={(e) => this.updateUser(e)}>
                    {info}
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
                        placeholder="New password" />
                    <input
                        value={this.state.confirmPassword}
                        onChange={(e) => { this.setState({ confirmPassword: e.target.value }) }}
                        type="password"
                        name="userConfirmPassword"
                        id="userConfirmPasswordInput"
                        className="formInput"
                        placeholder="Confirm password" />
                    <button className="formButton" type="submit">Update</button>
                </form>
            </div>
        </div>;
    }
}