declare module Dashboard.Models {
    class Server {
        constructor(serverId: number, displayName: string, hostname: string, isActive: boolean);
        serverId: number;
        displayName: string;
        hostname: string;
        isActive: boolean;
    }
}
