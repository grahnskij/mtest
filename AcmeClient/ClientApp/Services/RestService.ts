import TokenUtility from '../Utilities/TokenUtility';
import PathUtility from '../Utilities/PathUtility';
import IdUtility from '../Utilities/IdUtility';

export default class RestService {
    static AmISignedIn(): boolean {
        return !!TokenUtility.getToken();
    }

    static login(email: string, password: string) {
        let url = PathUtility.ApiAddress + PathUtility.ApiLogin;
        let payload = {
            body: JSON.stringify({
                EmailAddress: email,
                Password: password
            }),
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json'
            }),
            method: "post"
        };

        return fetch(url, payload).then(response => {
            if (response.status === 200) {
                response.json().then((data) => {
                    TokenUtility.setToken(data.token);
                    IdUtility.setId(data.id);
                });
            } else {
                TokenUtility.removeToken();
                IdUtility.removeId();
            }
            return response;
        });
    }

    static gamesList() {
        let url = PathUtility.ApiAddress + PathUtility.ApiGames + "?id=" + IdUtility.getId();
        let payload = {
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + TokenUtility.getToken(),
            }),
            method: "get"
        };

        return fetch(url, payload).then(response => {
            if (response.status !== 200) {
                TokenUtility.removeToken();
                IdUtility.removeId();
                window.location.replace("/");
            }
            return response;
        });
    }

    static userData() {
        let url = PathUtility.ApiAddress + PathUtility.ApiUser + "?id=" + IdUtility.getId();
        let payload = {
            headers: new Headers({
                'Content-Type': 'application/json',
                'Accept': 'application/json',
                'Authorization': 'Bearer ' + TokenUtility.getToken(),
            }),
            method: "get"
        };

        return fetch(url, payload).then(response => {
            if (response.status !== 200) {
                TokenUtility.removeToken();
                IdUtility.removeId();
                window.location.replace("/");
            }
            return response;
        });
    }
}