import TokenUtility from '../Utilities/TokenUtility';
import PathUtility from '../Utilities/PathUtility';
import IdUtility from '../Utilities/IdUtility';

export interface loginBody {
    EmailAddress: string,
    Password: string
}

export interface redeemBody {
    Code: string,
    UserAccountId: string
}

export interface userBody {
    firstname: string;
    lastname: string;
    oldPassword: string;
    newPassword: string;
    confirmPassword: string;
    email: string;
}

export default class RestService {
    static AmISignedIn(): boolean {
        return !!TokenUtility.getToken();
    }

    static logOut() {
        TokenUtility.removeToken();
        IdUtility.removeId();
    };

    static logIn(token: string, id: string) {
        TokenUtility.setToken(token);
        IdUtility.setId(id);
    }

    static post(body: Object, url: string, auth: boolean) {
        let payload = {
            body: JSON.stringify(body),
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }),
            method: "post"
        };
        if (auth) { payload.headers.append('Authorization', ('Bearer ' + TokenUtility.getToken())) };

        return fetch(url, payload);
    }

    static get(url: string) {
        let payload = {
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + TokenUtility.getToken(),
            }),
            method: "get"
        };

        return fetch(url, payload);
    }

    static put(body: Object, url: string) {
        let payload = {
            body: JSON.stringify(body),
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + TokenUtility.getToken(),
            }),
            method: "put"
        };
        return fetch(url, payload);
    }
}