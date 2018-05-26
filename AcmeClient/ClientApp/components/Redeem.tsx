import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";
import PathUtility from "../Utilities/PathUtility";
import IdUtility from "../Utilities/IdUtility";
import redeemBody from "../Services/RestService";

interface redeemState {
    redirect: boolean;
    info: string;
    code: string;
    status: string;
}

export class Redeem extends React.Component<RouteComponentProps<{}>, redeemState> {
    constructor() {
        super();

        this.state = {
            redirect: false,
            info: "",
            code: "",
            status: ""
        }
    }

    tryRedeem(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();

        let body: redeemBody = {
            Code: this.state.code,
            UserAccountId: IdUtility.getId()
        };

        let url = PathUtility.ApiAddress + PathUtility.ApiCode;

        RestService.post(body, url, true).then(response => {
            if (response.status == 401) {
                RestService.logOut();
                this.setState({ redirect: true });
            } else if (response.status == 200) {
                this.setState({ info: "Code successfully redeemed!", status: "200" });
            } else if (response.status == 400) {
                this.setState({ info: "Operation failed, code already redeemed or you already own the game!", status: "400" });
            }
        });
    }


    public render() {
        if (this.state.redirect) { return <Redirect to='/' /> }
        let statusClass = (this.state.status == "200") ? "infoLabel success" : "infoLabel fail";
        let errorLabel = (this.state.info !== "") ? <label className={statusClass}>{this.state.info}</label> : null;

        return (
            <div className="loginContainer">
                <form className="formContainer" onSubmit={(e) => this.tryRedeem(e)}>
                    {errorLabel}
                    <input
                        onChange={(e) => { this.setState({ code: e.target.value }) }}
                        type="ematextil"
                        name="code"
                        id="codeInput"
                        className="formInput"
                        placeholder="Code to redeem"
                        autoFocus
                        required />
                    <button className="formButton" type="submit">Redeem code</button>
                </form>
            </div>
        );
    }
}