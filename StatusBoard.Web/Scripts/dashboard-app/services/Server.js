var Dashboard;
(function (Dashboard) {
    var Models;
    (function (Models) {
        "use strict";
        var Server = (function () {
            function Server(displayName, isActive, serverHistory) {
                this.displayName = displayName;
                this.isActive = isActive;
                this.serverHistory = serverHistory;
            }
            return Server;
        })();
        Models.Server = Server;
    })(Models = Dashboard.Models || (Dashboard.Models = {}));
})(Dashboard || (Dashboard = {}));
