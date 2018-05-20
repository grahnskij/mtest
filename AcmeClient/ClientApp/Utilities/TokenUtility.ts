import PathUtility from './PathUtility';

export default class TokenUtility {

    static getToken() {
        return window.localStorage.getItem(PathUtility.TokenKey);
    }

    static setToken(token: string) {
        window.localStorage.setItem(PathUtility.TokenKey, token);
    }

    static removeToken(): void {
        window.localStorage.removeItem(PathUtility.TokenKey);
    }
}