var Dashboard;
(function (Dashboard) {
    var Models;
    (function (Models) {
        "use strict";
        var Server = (function () {
            function Server(serverId, displayName, hostname, isActive) {
                this.serverId = serverId;
                this.displayName = displayName;
                this.isActive = isActive;
                this.hostname = hostname;
            }
            return Server;
        })();
        Models.Server = Server;
    })(Models = Dashboard.Models || (Dashboard.Models = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=Server.js.map