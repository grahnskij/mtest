import TokenUtility from '../Utilities/TokenUtility';
var RestService = /** @class */ (function () {
    function RestService() {
    }
    RestService.AmISignedIn = function () {
        return !!TokenUtility.getToken();
    };
    return RestService;
}());
export default RestService;
//# sourceMappingURL=RestService.js.map