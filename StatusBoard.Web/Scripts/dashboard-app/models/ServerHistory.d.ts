declare module Dashboard.Models {
    class ServerHistory {
        server: Server;
        pingStatus: string;
        pingResponseTime: string;
        sslCertificateStatus: string;
        sslCertificateExpiryDate: Date;
        constructor(server: Server, pingStatus: string, pingResponseTime: string, sslCertificateStatus: string, sslCertificateExpiryDate: Date);
    }
}
