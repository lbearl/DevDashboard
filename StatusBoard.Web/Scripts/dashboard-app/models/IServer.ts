module Dashboard.Models {
    "use strict";

    export interface IServer extends ng.resource.IResource<IServer> {
        serverId: number;
        displayName: string;
        hostname: string;
        isActive: boolean;
    }
}