module Dashboard.Models {
    "use strict";

    export class Server {
        constructor(serverId: number, displayName: string, hostname: string, isActive: boolean) {
            this.serverId = serverId;
            this.displayName = displayName;
            this.isActive = isActive;
            this.hostname = hostname;
        }
        serverId: number;
        displayName: string;
        hostname: string;
        isActive: boolean;
    }
}