import PathUtility from './PathUtility';
var TokenUtility = /** @class */ (function () {
    function TokenUtility() {
    }
    TokenUtility.getToken = function () {
        return window.localStorage.getItem(PathUtility.TokenKey);
    };
    TokenUtility.setToken = function (token) {
        window.localStorage.setItem(PathUtility.TokenKey, token);
    };
    TokenUtility.removeToken = function () {
        window.localStorage.removeItem(PathUtility.TokenKey);
    };
    return TokenUtility;
}());
export default TokenUtility;
//# sourceMappingURL=TokenUtility.js.map