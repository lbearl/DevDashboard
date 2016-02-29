declare module Dashboard.Models {
    interface IServer extends ng.resource.IResource<IServer> {
        serverId: number;
        displayName: string;
        hostname: string;
        isActive: boolean;
    }
}
