import * as React from 'react';
import { RouteComponentProps, Redirect } from 'react-router';
import RestService from "../Services/RestService";

interface redeemState {
    redirect: boolean;
    info: string;
    code: string;
}

export class Redeem extends React.Component<RouteComponentProps<{}>, redeemState> {
    constructor() {
        super();

        this.state = {
            redirect: false,
            info: "",
            code: ""
        }
    }

    tryRedeem(e: React.FormEvent<HTMLFormElement>) {
        e.preventDefault();
        RestService.hej(this.state.code).then(response => {
            console.log(response);
        });
    }


    public render() {
        if (this.state.redirect) { return <Redirect to='/' /> }
        let errorLabel = (this.state.info !== "") ? <label className="errorLabel">{this.state.info}</label> : null;

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