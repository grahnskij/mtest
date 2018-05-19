import TokenUtility from '../Utilities/TokenUtility';
import PathUtility from '../Utilities/PathUtility';

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
            //console.log(response.status );
            if (response.status === 200) {
                response.json().then((data) => {
                    //console.log(data);
                    TokenUtility.setToken(data.token);
                });
            } else {
                TokenUtility.removeToken();
            }
            return response;
        });
    }
}