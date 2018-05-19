var __extends = (this && this.__extends) || (function () {
    var extendStatics = Object.setPrototypeOf ||
        ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
        function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __assign = (this && this.__assign) || Object.assign || function(t) {
    for (var s, i = 1, n = arguments.length; i < n; i++) {
        s = arguments[i];
        for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
            t[p] = s[p];
    }
    return t;
};
var __rest = (this && this.__rest) || function (s, e) {
    var t = {};
    for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p) && e.indexOf(p) < 0)
        t[p] = s[p];
    if (s != null && typeof Object.getOwnPropertySymbols === "function")
        for (var i = 0, p = Object.getOwnPropertySymbols(s); i < p.length; i++) if (e.indexOf(p[i]) < 0)
            t[p[i]] = s[p[i]];
    return t;
};
import * as React from 'react';
import { Switch, Route, Redirect } from 'react-router';
import { Home } from './components/Home';
import { Login } from './components/Login';
import Paths from './Utilities/PathUtility';
import RestService from './Services/RestService';
var Routes = /** @class */ (function (_super) {
    __extends(Routes, _super);
    function Routes() {
        return _super !== null && _super.apply(this, arguments) || this;
    }
    Routes.prototype.render = function () {
        return React.createElement(Switch, null,
            React.createElement(Route, { exact: true, path: Paths.Login, component: Login }),
            React.createElement(AuthRoute, { exact: true, path: Paths.Login, component: Home }));
    };
    return Routes;
}(React.Component));
export default Routes;
var AuthRoute = function (_a) {
    var Component = _a.component, rest = __rest(_a, ["component"]);
    return (React.createElement(Route, __assign({}, rest, { render: function (props) { return (RestService.AmISignedIn() ? (React.createElement("div", null,
            React.createElement("div", { className: "container" },
                React.createElement(Component, __assign({}, props))))) : (React.createElement(Redirect, { to: {
                pathname: Paths.Login,
                state: { from: props.location }
            } }))); } })));
};
//# sourceMappingURL=routes.js.map