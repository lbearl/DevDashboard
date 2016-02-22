var Dashboard;
(function (Dashboard) {
    var Models;
    (function (Models) {
        "use strict";
        var ServerHistory = (function () {
            function ServerHistory(server, serverId, pingStatus, pingResponseTime, sslCertificateStatus, sslCertificateExpiryDate) {
                this.server = server;
                this.serverId = serverId;
                this.pingStatus = pingStatus;
                this.pingResponseTime = pingResponseTime;
                this.sslCertificateStatus = sslCertificateStatus;
                this.sslCertificateExpiryDate = sslCertificateExpiryDate;
            }
            return ServerHistory;
        })();
        Models.ServerHistory = ServerHistory;
    })(Models = Dashboard.Models || (Dashboard.Models = {}));
})(Dashboard || (Dashboard = {}));
//# sourceMappingURL=ServerHistory.js.map