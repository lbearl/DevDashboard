module Dashboard.Models {
    "use strict";

    export class ServerHistory {
        constructor(
            public server: Server,
            public serverId: number,
            public pingStatus: string,
            public pingResponseTime: string,
            public sslCertificateStatus: string,
            public sslCertificateExpiryDate: Date
        ) { }
    }
}