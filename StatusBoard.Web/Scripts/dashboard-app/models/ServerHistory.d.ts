declare module Dashboard.Models {
    class ServerHistory {
        server: Server;
        serverId: number;
        pingStatus: string;
        pingResponseTime: string;
        sslCertificateStatus: string;
        sslCertificateExpiryDate: Date;
        constructor(server: Server, serverId: number, pingStatus: string, pingResponseTime: string, sslCertificateStatus: string, sslCertificateExpiryDate: Date);
    }
}
